using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Lotus_surrogacy_agency_Admin_panel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly LotusFertilitySurrogacyContext context;
        private readonly IClientService service;
        public ClientController(LotusFertilitySurrogacyContext context, IClientService service)
        {
            this.context = context;
            this.service = service;
        }

        [HttpGet("GetAllParents")]
        public async Task<IActionResult> GetallParents()
        {
            var data = await this.service.GetallParents();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetParentbycode")]
        public async Task<IActionResult> GetParentbycode(int parentId)
        {
            var data = await this.service.GetParentbycode(parentId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ParentModal _data)
        {
            var data = await this.service.Create(_data);
            return Ok(data);
        }
        [HttpPut("UpdateParent")]
        public async Task<IActionResult> UpdateParent(ParentModal _data, int parentId)
        {
            var data = await this.service.UpdateParent(_data, parentId);
            return Ok(data);
        }

        [HttpDelete("RemoveParent")]
        public async Task<IActionResult> RemoveParent(int parentId)
        {
            var data = await this.service.RemoveParent(parentId);
            return Ok(data);
        }

        [HttpGet("GetallDonors")]
        public async Task<IActionResult> GetallDonors()
        {
            var data = await this.service.GetallDonors();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetDonorbycode")]
        public async Task<IActionResult> GetDonorbycode(int donorId)
        {
            var data = await this.service.GetDonorbycode(donorId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("CreateDonor")]
        public async Task<IActionResult> CreateDonor(DonorModal _data)
        {
            var data = await this.service.CreateDonor(_data);
            return Ok(data);
        }
        [HttpPut("UpdateDonor")]
        public async Task<IActionResult> UpdateDonor(DonorModal _data, int donorId)
        {
            var data = await this.service.UpdateDonor(_data, donorId);
            return Ok(data);
        }

        [HttpDelete("RemoveDonor")]
        public async Task<IActionResult> RemoveDonor(int donorId)
        {
            var data = await this.service.RemoveDonor(donorId);
            return Ok(data);
        }

        [HttpGet("GetallMothers")]
        public async Task<IActionResult> GetallMothers()
        {
            var data = await this.service.GetallMothers();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpGet("GetMotherbycode")]
        public async Task<IActionResult> GetMotherbycode(int motherId)
        {
            var data = await this.service.GetMotherbycode(motherId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("CreateMother")]
        public async Task<IActionResult> CreateMother(MotherModal _data)
        {
            var data = await this.service.CreateMother(_data);
            return Ok(data);
        }
        [HttpPut("UpdateMother")]
        public async Task<IActionResult> UpdateMother(MotherModal _data, int motherId)
        {
            var data = await this.service.UpdateMother(_data, motherId);
            return Ok(data);
        }

        [HttpDelete("RemoveMother")]
        public async Task<IActionResult> RemoveMother(int motherId)
        {
            var data = await this.service.RemoveMother(motherId);
            return Ok(data);
        }
    }
}
