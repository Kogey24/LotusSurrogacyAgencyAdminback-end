using AutoMapper;
using Lotus_surrogacy_agency_Admin_panel.Modal;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Container
{
    public class ClientService : IClientService
    {
        private readonly LotusFertilitySurrogacyContext context;
        private readonly IMapper mapper;
        public ClientService(LotusFertilitySurrogacyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<APIResponse> Create(ParentModal data)
        {
            APIResponse response = new APIResponse();
            try
            { 
                TblintendedParent _parent = this.mapper.Map<ParentModal, TblintendedParent>(data);
                await this.context.TblintendedParents.AddAsync(_parent);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201.ToString();
                response.Result = "pass";
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> CreateDonor(DonorModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                TblspermDonor donor = this.mapper.Map<DonorModal, TblspermDonor>(data);
                await this.context.TblspermDonors.AddAsync(donor);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201.ToString();
                response.Result = "pass";
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> CreateMother(MotherModal data)
        {
            APIResponse response = new APIResponse();
            try
            {
                TblsurrogateMother mother = this.mapper.Map<MotherModal, TblsurrogateMother>(data);
                await this.context.TblsurrogateMothers.AddAsync(mother);
                await this.context.SaveChangesAsync();
                response.ResponseCode = 201.ToString();
                response.Result = "pass";
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<List<DonorModal>> GetallDonors()
        {
            List<DonorModal> _response = new List<DonorModal>();
            var _data = await this.context.TblspermDonors.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblspermDonor>, List<DonorModal>>(_data);
            }
            return _response;
        }

        public async Task<List<MotherModal>> GetallMothers()
        {
            List<MotherModal> _response = new List<MotherModal>();
            var _data = await this.context.TblsurrogateMothers.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblsurrogateMother>, List<MotherModal>>(_data);
            }
            return _response;
        }

        public async Task<List<ParentModal>> GetallParents()
        {
            List<ParentModal> _response = new List<ParentModal>();
            var _data = await this.context.TblintendedParents.ToListAsync();
            if (_data != null)
            {
                _response = this.mapper.Map<List<TblintendedParent>, List<ParentModal>>(_data);
            }
            return _response;
        }

        public async Task<DonorModal> GetDonorbycode(int donorId)
        {
            DonorModal _response = new DonorModal();
            var _data = await this.context.TblspermDonors.FindAsync(donorId);
            if (_data != null)
            {
                _response = this.mapper.Map<TblspermDonor, DonorModal>(_data);
            }
            return _response;
        }

        public async Task<MotherModal> GetMotherbycode(int motherId)
        {
            MotherModal _response = new MotherModal();
            var _data = await this.context.TblsurrogateMothers.FindAsync(motherId);
            if (_data != null)
            {
                _response = this.mapper.Map<TblsurrogateMother, MotherModal>(_data);
            }
            return _response;
        }

        public async Task<ParentModal> GetParentbycode(int parentId)
        {
            ParentModal _response = new ParentModal();
            var _data = await this.context.TblintendedParents.FindAsync(parentId);
            if (_data != null)
            {
                _response = this.mapper.Map<TblintendedParent, ParentModal>(_data);
            }
            return _response;
        }

        public async Task<APIResponse> RemoveDonor(int donorId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblspermDonors.FindAsync(donorId);
                if (_customer != null)
                {
                    this.context.TblspermDonors.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> RemoveMother(int motherId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblsurrogateMothers.FindAsync(motherId);
                if (_customer != null)
                {
                    this.context.TblsurrogateMothers.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> RemoveParent(int parentId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblintendedParents.FindAsync(parentId);
                if (_customer != null)
                {
                    this.context.TblintendedParents.Remove(_customer);
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> UpdateDonor(DonorModal data, int donorId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblspermDonors.FindAsync(donorId);
                if (_customer != null)
                {
                    _customer.Username = data.Username;
                    _customer.Fullname = data.Fullname;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.Age = data.Age;
                    _customer.Complexion = data.Complexion;
                    _customer.Height = data.Height;
                    _customer.Weight = data.Weight;
                    _customer.HivStatus = data.HivStatus;
                    _customer.Status = data.Status;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> UpdateMother(MotherModal data, int motherId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblsurrogateMothers.FindAsync(motherId);
                if (_customer != null)
                {
                    _customer.Username = data.Username;
                    _customer.Fullname = data.Fullname;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.Age = data.Age;
                    _customer.MaritalStatus = data.MaritalStatus;
                    _customer.Occupation = data.Occupation;
                    _customer.Address = data.Address;
                    _customer.Status = data.Status;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> UpdateParent(ParentModal data, int parentId)
        {
            APIResponse response = new APIResponse();
            try
            {
                var _customer = await this.context.TblintendedParents.FindAsync(parentId);
                if (_customer != null)
                {
                    _customer.Username = data.Username;
                    _customer.Fullname = data.Fullname;
                    _customer.Email = data.Email;
                    _customer.Phone = data.Phone;
                    _customer.Status = data.Status;
                    await this.context.SaveChangesAsync();
                    response.ResponseCode = 200.ToString();
                    response.Result = "pass";
                }
                else
                {
                    response.ResponseCode = 404.ToString();
                    response.message = "Data not found";
                }

            }
            catch (Exception ex)
            {
                response.ResponseCode = 400.ToString();
                response.message = ex.Message;
            }
            return response;
        }
    }
}
