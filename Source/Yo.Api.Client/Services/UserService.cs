using AKSoftware.WebApi.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Yo.Api.Client.ResponseModels;
using Yo.Api.Client.Models;
using Yo.Models.ViewModels;
using System.IO;
using Newtonsoft.Json;

namespace Yo.Api.Client.Services
{
    public class UserService
    {
        private static readonly ServiceClient client = new ServiceClient();

        string url = $@"{HttpSettings.BaseAddress}Users/";

        public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            var result = await client.GetAsync<UserResponse>(url + "GetAllUsers");

            return result.Users;
        }

        public async Task<UserViewModel> GetUserAsync(string id)
        {
            var result = await client.GetAsync<UserResponse>(url + "GetUser/" + id);

            return result.User;
        }

        public async Task<UserViewModel> GetUserByUsernameAsync(string username)
        {
            return (await client.GetAsync<UserResponse>(url + "GetUserByUsername/" + username)).User;
        }

        public async Task<Response> EditProfileAsync(EditProfileInfoViewModel model)
        {
            return await client.PutAsync<Response>(url + "EditProfile", model);
        }

        public async Task<UserResponse> SignInUserAsync(SignInUserViewModel model)
        {
            return await client.PostAsync<UserResponse>(url + "SignInUser", model);
        }

        public async Task<UserResponse> SignUpUserAsync(SignUpUserViewModel model)
        {
            return await client.PostAsync<UserResponse>(url + "SignUpUser", model);
        }

        public async Task<Response> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            return await client.PutAsync<Response>(url + "ChangePassword", model);
        }

        public async Task<UploadProfilePictureResponse> UploadProfilePictureAsync(string uploaderId, string fileName)
        {
            using(var myclient = new HttpClient())
            {
                var buffer = File.ReadAllBytes(fileName);

                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new StreamContent(new MemoryStream(buffer)),"Uploader", Guid.NewGuid().ToString());

                var response = await (await myclient.PostAsync(url + "UploadProfilePicture?uploaderId=" + uploaderId, content)).Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<UploadProfilePictureResponse>(response);
            }
        }

        public async Task<Response> DeleteUserAsync(string id)
        {
            return await client.DeleteAsync<Response>(url + "DeleteUser/" + id, null);
        }
    }
}
