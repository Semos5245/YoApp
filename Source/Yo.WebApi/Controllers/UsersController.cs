using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Yo.Models;
using Yo.Models.ViewModels;
using Yo.WebApi.Models;

namespace Yo.WebApi.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        #region Get

        /// <summary>
        /// Api that gets all the users
        /// </summary>
        /// <returns></returns>
        //GET: api/Users
        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            return Ok(new
            {
                Message = "Users have been received successfully.",
                Status = Status.Success.ToString(),
                Users = db.Users.Select(u => new
                {
                    u.UserId,
                    u.Username,
                    u.FullName,
                    u.ImagePath,
                    u.Phone,
                    YosCount = u.YosReceived.Count(),
                    u.CreationDate,
                    u.Email,
                })
            });
        }

        /// <summary>
        /// Api that gets a specific user
        /// </summary>
        /// <param name="id">Id of the user to be retreived</param>
        /// <returns></returns>
        //GET: api/Users/n5ji42h582
        [HttpGet]
        [Route("GetUser/{id}")]
        public IHttpActionResult GetUser(string id)
        {
            //Validate the sent id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An error has occurred");
            }

            //Get the user with the sent id
            var user = db.Users.Find(id);

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            //Return to the user with some useful information
            return Ok(new
            {
                Message = "User has been retreived successfully.",
                Status = Status.Success.ToString(),
                User = new
                {
                    user.UserId,
                    user.Username,
                    user.ImagePath,
                    user.FullName,
                    user.CreationDate,
                    user.Email,
                    user.Phone,
                    YosCount = user.YosReceived.Count
                }
            });
        }

        /// <summary>
        /// Api that gets a user by username
        /// </summary>
        /// <param name="username">User's username to look for.</param>
        /// <returns></returns>
        //GET: api/Users/GetUserByUsername/(Some random username)
        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public IHttpActionResult GetUserByUsername(string username)
        {
            //Validate the username
            if (string.IsNullOrEmpty(username))
            {
                return BadRequest("Wrong username input.");
            }

            //Get the user according to the username
            var user = db.Users.FirstOrDefault(u => u.Username.Equals(username));

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                Message = "User has been found and retreived successfully.",
                Status = Status.Success.ToString(),
                User = new
                {
                    user.UserId,
                    user.Username,
                    user.ImagePath,
                    user.FullName,
                    user.CreationDate,
                    user.Email,
                    user.Phone,
                    YosCount = user.YosReceived.Count
                }
            });
        }

        /// <summary>
        /// Api that signs in user to the system
        /// </summary>
        /// <param name="model">Model containing the username and the password of the user</param>
        /// <returns></returns>
        //POST: api/Users/SignInUser
        [HttpPost]
        [Route("SignInUser")]
        public IHttpActionResult SignInUser([FromBody]SignInUserViewModel model)
        {
            //Validate the model
            if (ModelState.IsValid)
            {
                //Get the user according to the username
                var user = db.Users.FirstOrDefault(u => u.Username.Equals(model.Username));

                //Check if the user exists
                if (user == null)
                {
                    return NotFound();
                }

                //Check if the entered password is incorrect
                if (!user.Password.Equals(model.Password))
                {
                    return BadRequest("Password is incorrect.");
                }

                //Username and password and correct
                return Ok(new
                {
                    Message = $"User with username {user.Username} has signed in successfully.",
                    Status = Status.Success.ToString(),
                    User = new
                    {
                        user.UserId,
                        user.Username,
                        user.ImagePath,
                        user.FullName,
                        user.CreationDate,
                        user.Email,
                        user.Phone,
                        YosCount = user.YosReceived.Count
                    }
                });
            }

            //Error in the model validation
            return  BadRequest("Models have some errors.");
        }

        #endregion

        #region Post

        /// <summary>
        /// Api to sign up a new user
        /// </summary>
        /// <param name="model">Model containing the username and the password of the user</param>
        /// <returns></returns>
        //POST: api/Users/SignUpUser
        [HttpPost]
        [Route("SignUpUser")]
        public IHttpActionResult SignUpUser([FromBody]SignUpUserViewModel model)
        {
            //Validating the constraints of the viewModel
            if (ModelState.IsValid)
            {
                //Get a user with the same username
                var userWithSameUsername = db.Users.FirstOrDefault(u => u.Username.Equals(model.Username)) as User;

                //Check whether the user exists
                if (userWithSameUsername != null)
                {
                    return BadRequest("Username is already taken.");
                }

                //Create a new user
                User user = new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Username = model.Username,
                    Password = model.Password,
                    ImagePath = @"D:\\Projects\Mine\YoApp\Yo.WebApi\Images\DefaultUserImage.png",
                    CreationDate = DateTime.UtcNow,
                    CurrentLocation = new Location { Latitude = 0, Longitude = 0 },
                    FriendRelations = new List<FriendRelation>(),
                    FromRequests = new List<FriendsRequest>(),
                    ToRequests = new List<FriendsRequest>(),
                    YosReceived = new List<Yo.Models.Yo>(),
                    YosSent = new List<Yo.Models.Yo>(),
                    Email = string.Empty,
                    FullName = string.Empty,
                    Phone = string.Empty
                };

                db.Users.Add(user);
                db.SaveChanges();

                return Ok(new
                {
                    Message = $"Username {user.Username} has been added successfully.",
                    Status = Status.Success.ToString(),
                    User = new
                    {
                        user.UserId,
                        user.Username,
                        user.ImagePath,
                        user.FullName,
                        user.CreationDate,
                        user.Email,
                        user.Phone,
                        YosCount = user.YosReceived.Count
                    }
                });
            }

            //Invalid model
            return BadRequest("Model has some errors.");
        }

        #endregion

        #region Put

        /// <summary>
        /// Api for Editing the current information of the user
        /// </summary>
        /// <param name="model">Modle containing the info of the user to edit</param>
        /// <returns></returns>
        //PUT: api/Users/EditProfile
        [HttpPut]
        [Route("EditProfile")]
        public IHttpActionResult EditProfile([FromBody]EditProfileInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.Find(model.UserId);
                if (user == null)
                {
                    return NotFound();
                }

                user.Phone = model.Phone;
                user.FullName = model.FullName;
                user.Email = model.Email;

                return Ok(new
                {
                    Message = "User has been updated successfully.",
                    Status = Status.Success.ToString()
                });
            }

            return BadRequest("Model has some errors");
        }

        /// <summary>
        /// Api that changes the password of a user
        /// </summary>
        /// <param name="model">Model containing the userId and the newPassword</param>
        /// <returns></returns>
        //PUT: api/Users/ChangePassword?newpassword={some random text}
        [HttpPut]
        [Route("ChangePassword")]
        public IHttpActionResult ChangePassword(ChangePasswordViewModel model)
        {
            //Validate the password
            if (string.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest("New password is empty.");
            }

            if (ModelState.IsValid)
            {
                //Get the user
                var myUser = db.Users.Find(model.ChangerId);

                //Check if the user exists
                if (myUser == null)
                {
                    return NotFound();
                }

                //Update the password
                myUser.Password = model.NewPassword;

                db.SaveChanges();

                return Ok(new
                {
                    Message = "Password has been updated successfully.",
                    Status = Status.Success.ToString()
                });
            }

            return BadRequest("Model has some errors.");
        }

        /// <summary>
        /// Api that uploads a picture to the server for a particular user
        /// </summary>
        /// <param name="uploaderId">User's id who wants to upload a profile picture.</param>
        /// <returns></returns>
        //POST: api/Users/UploadProfilePicture
        [HttpPost]
        [Route("UploadProfilePicture")]
        public IHttpActionResult UploadProfilePicture([FromUri]string uploaderId)
        {
            //Get the user
            var user = db.Users.Find(uploaderId);

            //Check if the user exists
            if (user == null)
            {
                return NotFound();
            }

            //Upload the picture
            try
            {
                //Get the current http request
                var httpRequest = HttpContext.Current.Request;

                //Max file size allowed
                int maxFileSize = 1024 * 1024 * 1;
                //process all the files sent from the client
                foreach (string file in httpRequest.Files)
                {
                    //Get the posted file
                    var postedFile = httpRequest.Files[file];

                    //Check if the file exists and it has some content
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        //Get the extension of the file
                        var extension = Path.GetExtension(postedFile.FileName);

                        //Check if the extension matches any of the allowed extensions
                        if (extension != ".png" && extension != ".jpg")
                        {
                            return BadRequest("Image extension must be .png or .jpg. Current extension is not allowed.");
                        }

                        //Check if the posted file is larger than allowed
                        else if (postedFile.ContentLength > maxFileSize)
                        {
                            return BadRequest("File size is too large.");
                        }
                        else
                        {
                            //Create the path of the picture
                            var filePath = HttpContext.Current.Server.MapPath(@"~\Images\" + postedFile.FileName + extension);
                            
                            //Save the pictur to the server
                            postedFile.SaveAs(filePath);

                            //Add the picture path to the user
                            user.ImagePath = filePath;

                            db.SaveChanges();

                            return Ok(new
                            {
                                Message = "Image has been uploaded successfully.",
                                Status = Status.Success.ToString(),
                                NewImagePath = filePath
                            });
                        }
                    }
                    return BadRequest("File uploaded is empty.");
                }
                return BadRequest("No file has been uploaded.");
            }
            catch (Exception e)
            {
                return BadRequest("An error has occurred. " + e.Message);
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Api that deletes a specific user
        /// </summary>
        /// <param name="id">Id of the user to be deleted</param>
        /// <returns></returns>
        //DELETE: api/Users/Delete/re83u2rh7
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public IHttpActionResult DeleteUser(string id)
        {
            //Validate the sent id
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("An Error has occured.");
            }

            //Get the user with the specified id
            var user = db.Users.Find(id);

            //Check whether the user exists
            if (user == null)
            {
                return NotFound();
            }

            //Delete the user
            var deletedUser = db.Users.Remove(user);
            db.SaveChanges();

            return Ok(new
            {
                Message = $"{deletedUser.FullName} user has been deleted successfully.",
                Status = Status.Success.ToString()
            });
        }
        #endregion
    }
}
