using Lotus_surrogacy_agency_Admin_panel.Modal;

namespace Lotus_surrogacy_agency_Admin_panel.Service
{
    public interface IClientService
    {

        //Intended Parents APIs
        Task<List<ParentModal>> GetallParents();
        Task<ParentModal> GetParentbycode(int parentId);
        Task<APIResponse> RemoveParent(int parentId);
        Task<APIResponse> Create(ParentModal data);

        Task<APIResponse> UpdateParent(ParentModal data, int parentId);

        //Sperm Donor APIs
        Task<List<DonorModal>> GetallDonors();
        Task<DonorModal> GetDonorbycode(int donorId);
        Task<APIResponse> RemoveDonor(int donorId);
        Task<APIResponse> CreateDonor(DonorModal data);

        Task<APIResponse> UpdateDonor(DonorModal data, int donorId);

        //Surrogate Mother APIs
        Task<List<MotherModal>> GetallMothers();
        Task<MotherModal> GetMotherbycode(int motherId);
        Task<APIResponse> RemoveMother(int motherId);
        Task<APIResponse> CreateMother(MotherModal data);

        Task<APIResponse> UpdateMother(MotherModal data, int motherId);
    }
}
