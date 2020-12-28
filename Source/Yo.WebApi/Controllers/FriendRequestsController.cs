using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yo.Models;
using Yo.Models.ViewModels;
using Yo.WebApi.Models;

namespace Yo.WebApi.Controllers
{
    [RoutePrefix("api/FriendRequests")]
    public class FriendRequestsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        #region Get

        /// <summary>
        /// Api to get all the pending requests for a specific user
        /// </summary>
        /// <param name="id">The id of the user to get the pending requests for</param>
        /// <returns></returns>
        //GET: api/FriendRequests/GetRequests/fdshaf69ay797
        [HttpGet]
        [Route("GetPendingRequests/{id}")]
        public IHttpActionResult GetPendingRequests(string id)
        {
            //Validate the id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An error has occured.");
            }

            //Get the user with the sent id
            var user = db.Users.Find(id);

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }
            
            //Get all users that sent request to this current user and are still pending
            var pendingUsers = user.FromRequests.Where(r => r.Status.Equals(FriendRequestStatus.Pending.ToString()))
                .Select(u => u.FromUser).Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.ImagePath,
                    u.FullName
                });

            return Ok(new
            {
                Message = "Pending requests have been retreived successfully.",
                Status = Status.Success.ToString(),
                PendingUsers = pendingUsers
            });

        }

        #endregion

        #region Post

        /// <summary>
        /// Api to send a friendship Request
        /// </summary>
        /// <param name="model">Model containing the id of the requester and the reciever users</param>
        /// <returns></returns>
        //POST: api/FriendRequests/SendRequest
        [HttpPost]
        [Route("SendRequest")]
        public IHttpActionResult SendRequest([FromBody]SendRequestViewModel model)
        {
            //Validate the models
            if (ModelState.IsValid)
            {
                //Get both the users according to the id
                var sourceUser = db.Users.Find(model.RequesterId);
                var destinationUser = db.Users.Find(model.ReceiverId);

                //Check if the users exist
                if (sourceUser == null || destinationUser == null)
                {
                    return NotFound();
                }

                //Check if a similar pending request exists in the database
                var similarRequest = db.FriendsRequests.FirstOrDefault(r => r.FromId.Equals(sourceUser.UserId) &&
                                                                            r.ToId.Equals(destinationUser.UserId) &&
                                                                            r.Status.Equals(FriendRequestStatus.Pending.ToString()));
                //Request exists and it's pending
                if (similarRequest != null)
                {
                    return BadRequest("Request can't be sent. Request already exists and it's pending.");
                }

                //Create a new request with the suitable data
                var request = new FriendsRequest
                {
                    FriendRequestId = Guid.NewGuid().ToString(),
                    FromId = sourceUser.UserId,
                    ToId = destinationUser.UserId,
                    Status = FriendRequestStatus.Pending.ToString(),
                    RequestDate = DateTime.UtcNow,
                    FromUser = sourceUser,
                    ToUser = destinationUser
                };

                //Add the request to the database
                db.FriendsRequests.Add(request);

                sourceUser.ToRequests.Add(request);
                destinationUser.FromRequests.Add(request);

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Request has been added successfully.",
                    Status = Status.Success.ToString()
                });
            }

            //Error in the validate of the models
            return BadRequest("Models sent have Errors.");
        }

        #endregion

        #region Put

        /// <summary>
        /// Api to accept a friend request
        /// </summary>
        /// <param name="model">Model containing the id of the accepter and requester users</param>
        /// <returns></returns>
        //PUT: api/FriendRequests/AcceptRequest
        [HttpPut]
        [Route("AcceptRequest")]
        public IHttpActionResult AcceptRequest([FromBody]AcceptRequestViewModel model)
        {
            //Validate the models
            if (ModelState.IsValid)
            {
                //Get both the users according to the id
                var accepterUser = db.Users.Find(model.AccepterId);
                var requesterUser = db.Users.Find(model.RequesterId);

                //Check if the users exist
                if (accepterUser == null || requesterUser == null)
                {
                    return NotFound();
                }

                //Get the request
                var request = db.FriendsRequests.FirstOrDefault(r => r.FromId.Equals(requesterUser.UserId) &&
                                                                     r.ToId.Equals(accepterUser.UserId) &&
                                                                     r.Status.Equals(FriendRequestStatus.Pending.ToString()));
                //Check if the request exists
                if (request == null)
                {
                    return NotFound();
                }

                //Change the status of the request
                request.Status = FriendRequestStatus.Accepted.ToString();

                //Relation for the requester
                var friendRelation1 = new Yo.Models.FriendRelation
                {
                    FriendRelationId = Guid.NewGuid().ToString(),
                    IsBlocked = false,
                    CurrentUser = requesterUser,
                    FriendUser = accepterUser,
                    CurrentUserId = requesterUser.UserId,
                    FriendUserId = accepterUser.UserId,
                    FriendshipDate = DateTime.UtcNow
                };

                //Relation for the accpeter
                var friendRelation2 = new Yo.Models.FriendRelation
                {
                    FriendRelationId = Guid.NewGuid().ToString(),
                    IsBlocked = false,
                    CurrentUser = accepterUser,
                    FriendUser = requesterUser,
                    CurrentUserId = accepterUser.UserId,
                    FriendUserId = requesterUser.UserId,
                    FriendshipDate = DateTime.UtcNow
                };

                //Add the relations to the database
                db.FriendRelations.Add(friendRelation1);
                db.FriendRelations.Add(friendRelation2);

                //Add the friendship relation between the users
                requesterUser.FriendRelations.Add(friendRelation1);
                accepterUser.FriendRelations.Add(friendRelation2);

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Friendship relation has been added successfully.",
                    Status = Status.Success.ToString()
                });
            }

            //Error in the validate of the models
            return BadRequest("Models sent have Errors.");
        }

        /// <summary>
        /// Api that rejects a friendship request
        /// </summary>
        /// <param name="model">Model containing the id of the rejecter and requester users</param>
        /// <returns></returns>
        //PUT: api/FriendRequests/RejectRequest
        [HttpPut]
        [Route("RejectRequest")]
        public IHttpActionResult RejectRequest([FromBody]RejectRequestViewModel model)
        {
            //Validate the models
            if (ModelState.IsValid)
            {
                //Get the users
                var rejecterUser = db.Users.Find(model.RejecterId);
                var requesterUser = db.Users.Find(model.RequesterId);

                //Check if the users exist
                if (rejecterUser == null || requesterUser == null)
                {
                    return NotFound();
                }

                //Get the request
                var request = db.FriendsRequests.FirstOrDefault(r => r.FromId.Equals(requesterUser.UserId) &&
                                                                     r.ToId.Equals(rejecterUser.UserId) &&
                                                                     r.Status.Equals(FriendRequestStatus.Pending.ToString()));

                //Check if the request exists
                if (request == null)
                {
                    return NotFound();
                }

                //Change the status of the request
                request.Status = FriendRequestStatus.Rejected.ToString();

                return Ok(new
                {
                    Message = "Friendship request has been rejected successfully.",
                    Status = Status.Success.ToString()
                });
            }

            //Models are not valid
            return BadRequest("Models have errors.");
        }

        #endregion

        #region Delete

        /// <summary>
        /// Api that deletes a specific request
        /// </summary>
        /// <param name="id">The id of the request to delete</param>
        /// <returns></returns>
        //DELETE: api/FriendRequest/Delete/676n76786n76njin
        [HttpDelete]
        [Route("Delete/{id}")]
        public IHttpActionResult DeleteRequest(string id)
        {
            //Validate the id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An error has occured.");
            }

            //Get the request according to the id
            var request = db.FriendsRequests.Find(id);

            //Check if the request exists
            if (request == null)
            {
                return NotFound();
            }

            //Remove the request from the database
            db.FriendsRequests.Remove(request);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Request has been deleted successfully.",
                Status = Status.Success.ToString()
            });
        }
        #endregion
    }
}
