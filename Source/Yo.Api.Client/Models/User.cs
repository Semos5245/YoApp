using System.Collections.Generic;
using System.Threading.Tasks;
using Yo.Api.Client.ResponseModels;
using Yo.Api.Client.Services;
using Yo.Models.ViewModels;

namespace Yo.Api.Client.Models
{
    public class User
    {
        private static readonly UserService service = new UserService();

        public static async Task<IEnumerable<UserViewModel>> GetUsersAsync()
        {
            return await service.GetUsersAsync();
        }

        public static async Task<UserViewModel> GetUserAsync(string id)
        {
            return await service.GetUserAsync(id);
        }

        public static async Task<UserViewModel> GetUserByUsernameAsync(string username)
        {
            return await service.GetUserByUsernameAsync(username);
        }

        public static async Task<Response> EditProfileAsync(EditProfileInfoViewModel user)
        {
            return await service.EditProfileAsync(user);
        }

        public static async Task<UserResponse> SignInUserAsync(SignInUserViewModel model)
        {
            return await service.SignInUserAsync(model);
        }

        public static async Task<UserResponse> SignUpUserAsync(SignUpUserViewModel model)
        {
            return await service.SignUpUserAsync(model);
        }

        public static async Task<Response> ChangePasswordAsync(string changerId, string newPassword)
        {
            return await service.ChangePasswordAsync(new ChangePasswordViewModel(changerId,newPassword));
        }

        public static async Task<UploadProfilePictureResponse> UploadProfilePictureAsync(string uploaderId, string fileName)
        {
            return await service.UploadProfilePictureAsync(uploaderId, fileName);
        }

        public static async Task<Response> DeleteUserAsync(string id)
        {
            return await service.DeleteUserAsync(id);
        }
    }
}
