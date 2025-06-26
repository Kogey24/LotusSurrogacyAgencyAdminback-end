using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Container
{
    public class UserRoleService : IUserRoleService
    {
        private readonly LotusFertilitySurrogacyContext context;
        public UserRoleService(LotusFertilitySurrogacyContext context)
        {
            this.context = context;
        }

        public async Task<APIResponse> AssignRolePermission(List<Tblrolepermission> data)
        {
            APIResponse response = new APIResponse();
            int processcount = 0;
            try
            {
                using (var dbtransaction = await this.context.Database.BeginTransactionAsync())
                {
                    if (data.Count > 0)
                    {
                        data.ForEach(item =>
                        {
                            var userdata = this.context.Tblrolepermissions.FirstOrDefault(opt => opt.Usrrole == item.Usrrole && opt.Menucode == item.Menucode);
                            if (userdata != null)
                            {
                                userdata.Haveview = item.Haveview;
                                userdata.Haveadd = item.Haveadd;
                                userdata.Havedelete = item.Havedelete;
                                userdata.Haveedit = item.Haveedit;
                                processcount++;
                            }
                            else
                            {
                                this.context.Tblrolepermissions.Add(item);
                                processcount++;
                            }
                        });
                        if (data.Count == processcount)
                        {
                            await this.context.SaveChangesAsync();
                            await dbtransaction.CommitAsync();
                            response.Result = "Pass";
                            response.message = "Saved successfully";
                        }
                        else
                        {
                            await dbtransaction.RollbackAsync();
                        }
                    }
                    else
                    {
                        response.Result = "Failed";
                        response.message = "Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                response = new APIResponse();
            }
            return response;
        }

        public async Task<List<Tblmenu>> GetAllMenu()
        {
            return await this.context.Tblmenus.ToListAsync();
        }

        public async Task<List<AppMenu>> GetAllMenubyRole(string userrole)
        {
            List<AppMenu> appmenus = new List<AppMenu>();
            var accessdata = (from menu in this.context.Tblrolepermissions.Where(o => o.Usrrole == userrole && o.Haveview == true)
                              join m in this.context.Tblmenus on menu.Menucode equals m.Code into _jointable
                              from p in _jointable.DefaultIfEmpty()
                              select new { code = menu.Menucode, name = p.Name }).ToList();
            if (accessdata.Any())
            {
                accessdata.ForEach(item =>
                {
                    appmenus.Add(new AppMenu()
                    {
                        code = item.code,
                        Name = item.name
                    });
                });
            }
            return appmenus;
        }

        public async Task<List<Tblrole>> GetAllRoles()
        {
            return await this.context.Tblroles.ToListAsync();
        }

        public async Task<MenuPermission> GetMenuPermissionbyRole(string userrole, string menucode)
        {
            MenuPermission menupermission = new MenuPermission();
            var data = await this.context.Tblrolepermissions.FirstOrDefaultAsync(item => item.Usrrole == userrole && item.Menucode == menucode && item.Haveview == true);
            if (data != null)
            {
                menupermission.Code = data.Menucode;
                menupermission.Haveview = data.Haveview;
                menupermission.Haveadd = data.Haveadd;
                menupermission.Haveedit = data.Haveedit;
                menupermission.Havedelete = data.Havedelete;
            }
            return menupermission;
        }
    }
}
