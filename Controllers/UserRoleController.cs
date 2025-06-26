using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lotus_surrogacy_agency_Admin_panel.Controllers
{
    [Route("api/[controller]")]
    [EnableCors]
    [ApiController]
    
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService service;
        public UserRoleController(IUserRoleService service)
        {
            this.service = service;
        }
        [HttpPost("AssignRolePermission")]
        public async Task<IActionResult> AssignRolePermission(List<Tblrolepermission> rolePermissions)
        {
            var data = await this.service.AssignRolePermission(rolePermissions);
            return Ok(data);
        }

        [HttpGet("GetAllMenus")]
        public async Task<IActionResult> GetAllmenus()
        {
            var data = await this.service.GetAllMenu();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var data = await this.service.GetAllRoles();
            if (data != null)
            {
                return Ok(data);
            }
            return NotFound();
        }
        [HttpGet("GetAllMenuByRole")]
        public async Task<IActionResult> GetAllMenuByRole(string userrole)
        {
            var data = await this.service.GetAllMenubyRole(userrole);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetMenuPermissionbyRole")]
        public async Task<IActionResult> GetMenuPermissionbyRole(string userrole, string menucode)
        {
            var data = await this.service.GetMenuPermissionbyRole(userrole, menucode);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
