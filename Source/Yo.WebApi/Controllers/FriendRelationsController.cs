using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Yo.WebApi.Models;
using Yo.Models;
using Yo.Models.ViewModels;

namespace Yo.WebApi.Controllers
{
    [RoutePrefix("api/FriendRelations")]
    public class FriendRelationsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        #region Get

        /// <summary>
        /// Api that gets the unblocked friends of a user
        /// </summary>
        /// <param name="id">Id of the user to get friends of</param>
        /// <returns></returns>
        //GET : api/FriendRelations/GetUsers/fd7s8nay7f9na7
        [HttpGet]
        [Route("GetFriends/{id}")]
        public IHttpActionResult GetFriends(string id)
        {
            //Validate the id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An error has occured");
            }

            //Get the user
            var user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            //Get all unblocked friends that are not also blocking this user
            var friends = user.FriendRelations.Where(r => !r.IsBlocked && !(r.FriendUser.FriendRelations.FirstOrDefault(f => f.FriendUserId.Equals(r.CurrentUserId)).IsBlocked)).Select(f => f.FriendUser).Select(f => new
            {
                f.UserId,
                f.Username,
                f.ImagePath,
                f.FullName,
                f.Email
            });

            return Ok(new
            {
                Message = "Friends have been retreived successfully.",
                Status = Status.Success.ToString(),
                Friends = friends
            });
        }

        /// <summary>
        /// Api that gets all the blocked friends for a specific user
        /// </summary>
        /// <param name="id">User id to get the blocked friends for</param>
        /// <returns></returns>
        //GET: api/FriendRelations/GetBlockedFriends/fd7sna7f8a
        [HttpGet]
        [Route("GetBlockedFriends/{id}")]
        public IHttpActionResult GetBlockedFriends(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id can't be empty.");
            }

            //Get the user
            var user = db.Users.Find(id);

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            //Get all blocked friends
            var blockedFriends = user.FriendRelations
                .Where(r => r.CurrentUserId.Equals(id) && r.IsBlocked)
                .Select(u => u.FriendUser).Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.ImagePath,
                    u.FullName
                });

            return Ok(new
            {
                Message = "All blocked friends have been retreived succesfully.",
                Status = Status.Success.ToString(),
                BlockedFriends = blockedFriends
            });
        }

        #endregion

        #region Put

        /// <summary>
        /// Api for blocking friends
        /// </summary>
        /// <param name="model">Model containing the id of the blocker and the blocked users</param>
        /// <returns></returns>
        //PUT: api/FriendRelations/BlockFriend
        [HttpPut]
        [Route("BlockFriend")]
        public IHttpActionResult BlockFriend([FromBody]BlockFriendViewModel model)
        {
            //Get the users
            var blockerUser = db.Users.Find(model.BlockerId);
            var blockedUser = db.Users.Find(model.BlockedId);

            //Check if the usrs exists
            if (blockedUser == null && blockerUser == null)
            {
                return NotFound();
            }

            //Check if they are friends or not
            var relation1 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(blockerUser.UserId) &&
                                                                   r.FriendUserId.Equals(blockedUser.UserId));
            var relation2 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(blockedUser.UserId) &&
                                                                   r.FriendUserId.Equals(blockerUser.UserId));

            //Check if the relations exist
            if (relation1 == null || relation2 == null)
            {
                return BadRequest("Users do not have a friendship relation.");
            }

            //Check if friend is already blocked
            if (relation1.IsBlocked)
            {
                return BadRequest("Can't block an already blocked friend.");
            }

            //Block friend
            relation1.IsBlocked = true;

            db.SaveChanges();

            return Ok(new
            {
                Message = "Friend has been blocked successfully.",
                Status = Status.Success.ToString()
            });
        }

        /// <summary>
        /// Api that unblocks a specific friend
        /// </summary>
        /// <param name="model">Model containing the id of the unblocker and the unblocked users</param>
        /// <returns></returns>
        //PUT: api/FriendRelations/UnblockFriend
        [HttpPut]
        [Route("UnblockFriend")]
        public IHttpActionResult UnBlockFriend([FromBody]UnblockFriendViewModel model)
        {
            //Validate the state of the model
            if (ModelState.IsValid)
            {
                //Get the users
                var unblockerUser = db.Users.Find(model.UnblockerId);
                var unblockedUser = db.Users.Find(model.UnblockedId);

                //Check if the users exist or not
                if (unblockerUser == null || unblockedUser == null)
                {
                    return NotFound();
                }

                //Check if they are friends or not
                var relation1 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(unblockerUser.UserId) &&
                                                                       r.FriendUserId.Equals(unblockedUser.UserId));
                var relation2 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(unblockedUser.UserId) &&
                                                                       r.FriendUserId.Equals(unblockerUser.UserId));

                //Check if the relations exist
                if (relation1 == null || relation2 == null)
                {
                    return BadRequest("Users do not have a friendship relation.");
                }

                //Check if friend is already unblocked
                if (!relation1.IsBlocked)
                {
                    return BadRequest("Can't block an already blocked friend.");
                }

                //Unblock friend
                relation1.IsBlocked = false;

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Friend has been unblocked successfully.",
                    Status = Status.Success.ToString()
                });
            }

            return BadRequest("Model has some errors.");
        }
        #endregion

        #region Delete

        /// <summary>
        /// Api for deleting or unfriending a friend
        /// </summary>
        /// <param name="model">Model containing the id of the unfriender and the unfriended users</param>
        /// <returns></returns>
        //DELETE: api/FriendRelations/UnFriend
        [HttpDelete]
        [Route("DeleteFriend")]
        public IHttpActionResult DeleteFriend([FromBody]UnFriendViewModel model)
        {
            //Validate the models
            if (ModelState.IsValid)
            {
                //Get both the users
                var unfrienderUser = db.Users.Find(model.UnFrienderId);
                var unfriendedUser = db.Users.Find(model.UnFriendedId);

                //Check if the users exist
                if (unfrienderUser == null || unfriendedUser == null)
                {
                    return NotFound();
                }

                //Get the relation between the users
                var relation1 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(unfrienderUser.UserId) &&
                                                             r.FriendUserId.Equals(unfriendedUser.UserId));
                var relation2 = db.FriendRelations.FirstOrDefault(r => r.CurrentUserId.Equals(unfriendedUser.UserId) &&
                                                             r.FriendUserId.Equals(unfrienderUser.UserId)) as Yo.Models.FriendRelation;

                if (relation1 == null || relation2 == null)
                {
                    return NotFound();
                }

                //Remove the relations records
                db.FriendRelations.Remove(relation1);
                db.FriendRelations.Remove(relation2);

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Friend has been removed successfully.",
                    Status = Status.Success.ToString()
                });
            }

            //Error in the validation of the models
            return BadRequest("Models have some errors.");
        }

        #endregion

    }
}
