using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Models;

namespace Lotus_surrogacy_agency_Admin_panel.Service
{
    public interface IUserRoleService
    {
        Task<APIResponse> AssignRolePermission(List<Tblrolepermission> data);
        Task<List<Tblrole>> GetAllRoles();
        Task<List<Tblmenu>> GetAllMenu();
        Task<List<AppMenu>> GetAllMenubyRole(string userrole);
        Task<MenuPermission> GetMenuPermissionbyRole(string userrole, string menucode);
    }
}
