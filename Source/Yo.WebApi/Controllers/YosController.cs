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
    [RoutePrefix("api/Yos")]
    public class YosController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        #region Get

        /// <summary>
        /// Api that gets the total number of yos received for a specific user
        /// </summary>
        /// <param name="id">User id to get yos for</param>
        /// <returns></returns>
        //GET: api/Yos/GetYosCount/fy7asthf67at7
        [HttpGet]
        [Route("GetYos/{id}")]
        public IHttpActionResult GetYos(string id)
        {
            //Validate the inputed id
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

            //Get yos that are not recieved by the user
            var yos = user.YosReceived.Where(y => !y.IsReceived).Select(u => new
            {
                u.IsSeen,
                u.IsYoLocation,
                u.Longitude,
                u.Latitude,
                u.YoDate,
                FromUser = new
                {
                    u.FromUser.UserId,
                    u.FromUser.Username,
                    u.FromUser.Email,
                    u.FromUser.CreationDate,
                    u.FromUser.FullName,
                    u.FromUser.Phone,
                    YosCount = u.FromUser.YosReceived.Count,
                    u.FromUser.ImagePath
                }
            });

            return Ok(new
            {
                Message = "User's unreceived Yos have been retreived successfully.",
                Status = Status.Success.ToString(),
                Yos = yos
            });
        }

        #endregion

        #region Post

        /// <summary>
        /// Api that sends a normal yo from a friend to another friend
        /// </summary>
        /// <param name="model">Model that contains id of the sender and receiver users</param>
        /// <returns></returns>
        //POST: api/Yos/SendNormalYo
        [HttpPost]
        [Route("SendYo")]
        public IHttpActionResult SendYo([FromBody]SendYoViewModel model)
        {
            //Validate the models
            if (ModelState.IsValid)
            {
                //Get the users
                var yoerUser = db.Users.Find(model.YoerId);
                var yoedUser = db.Users.Find(model.YoedId);

                if (yoerUser == null || yoedUser == null)
                {
                    return BadRequest("One or more users have not been found.");
                }

                //Check if sender user is friends with the reciever
                var relationFromYoerToYoed = yoerUser.FriendRelations.FirstOrDefault(r => r.FriendUser.UserId.Equals(yoedUser.UserId));

                //Check if users are friends
                if (relationFromYoerToYoed == null)
                {
                    return NotFound();
                }

                //Get the relation from Yoed user to Yoer user
                var relationFromYoedToYoer = yoedUser.FriendRelations.FirstOrDefault(r => r.FriendUser.UserId.Equals(yoerUser.UserId));

                //Check if the relation from the other side exists
                if (relationFromYoedToYoer == null)
                {
                    return NotFound();
                }

                //Check if the receiver has blocked the sender
                if (relationFromYoedToYoer.IsBlocked)
                {
                    return BadRequest("Yo can't be sent. You are blocked by this friend.");
                }

                //Create a yo
                var yo = new Yo.Models.Yo
                {
                    YoId = Guid.NewGuid().ToString(),
                    IsYoLocation = model.IsYoLocation,
                    YoDate = DateTime.UtcNow,
                    IsReceived = false,
                    IsSeen = false,
                    Longitude = yoerUser.CurrentLocation.Longitude,
                    Latitude = yoerUser.CurrentLocation.Latitude,
                    FromId = yoerUser.UserId,
                    ToId = yoedUser.UserId,
                    FromUser = yoerUser,
                    ToUser = yoedUser
                };

                //Add the yo to the database
                db.Yos.Add(yo);

                //Add the yos to the users
                yoerUser.YosSent.Add(yo);
                yoedUser.YosReceived.Add(yo);

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Yo has been sent successfully.",
                    Status = Status.Success.ToString()
                });
            }
           
            //Error in the models
            return BadRequest("Models have some errors.");
        }

        /// <summary>
        /// Api that makes all yos of a specific user received
        /// </summary>
        /// <param name="yoedId">User id to make the yos received for</param>
        /// <returns></returns>
        //PUT: api/MakeYosReceived/nf7d9asy788
        [HttpPut]
        [Route("MakeYosRecieved")]
        public IHttpActionResult MakeYosRecieved([FromUri]string yoedId)
        {
            //Valide the uploaderId
            if (string.IsNullOrEmpty(yoedId))
            {
                return BadRequest("Wrong Input.");
            }

            //Get the user
            var user = db.Users.Find(yoedId);

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            //Make all yos for this user recieved
            foreach (var yo in user.YosReceived)
            {
                yo.IsReceived = true;
                yo.IsSeen = true;
            }

            db.SaveChanges();

            return Ok(new
            {
                Messsage = "Yos have been made received.",
                Status = Status.Success.ToString()
            });
        }
        
        #endregion

        #region Delete

        /// <summary>
        /// Api for deleting a specific yo
        /// </summary>
        /// <param name="id">The id of the yo to be deleted</param>
        /// <returns></returns>
        //DELETE: api/Yos/DeleteYo/hkf7d8asyf6a7
        [HttpDelete]
        [Route("DeleteYo/{id}")]
        public IHttpActionResult DeleteYo(string id)
        {
            //Validate the inputed id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An error has occured.");
            }

            //Get the yo
            var yo = db.Yos.Find(id);

            //Check if the yo exists
            if (yo == null)
            {
                return NotFound();
            }

            //Delete from the database
            db.Yos.Remove(yo);
            db.SaveChanges();

            return Ok(new
            {
                Message = "Yo has been deleted successfylly.",
                Status = Status.Success.ToString()
            });
        }

        #endregion

    }
}
