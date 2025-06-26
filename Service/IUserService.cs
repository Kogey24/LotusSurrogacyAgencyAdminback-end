using Lotus_surrogacy_agency_Admin_panel.Modal;

namespace Lotus_surrogacy_agency_Admin_panel.Service
{
    public interface IUserService
    {
        Task<APIResponse> UserRegistration(UserRegister userRegister);
        Task<APIResponse> ConfirmRegistration(int userid, string username, string otptext);
        Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword);
        Task<APIResponse> ForgotPassword(string username);
        Task<APIResponse> UpdatePassword(string username, string password, string otptext);
        Task<APIResponse> UpdateStatus(string username, bool userstatus);
        Task<APIResponse> UpdateRole(string username, string userrole);
        Task<List<UserModal>> GetUsers();
    }
}
