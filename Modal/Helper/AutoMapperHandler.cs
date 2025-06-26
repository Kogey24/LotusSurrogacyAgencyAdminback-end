using AutoMapper;
using Lotus_surrogacy_agency_Admin_panel.Models;

namespace Lotus_surrogacy_agency_Admin_panel.Modal.Helper
{
    public class AutoMapperHandler:Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Tbluser, UserModal>().ForMember(
            dest => dest.statusname,
            opt => opt.MapFrom(
                src => (src.Isactive != null) ? "Active" : "In active")).ReverseMap();

            CreateMap<TblintendedParent, ParentModal>().ForMember(
            dest => dest.StatusName,
            opt => opt.MapFrom(
                src => (src.Status != null) ? "Active" : "In active")).ReverseMap();

            CreateMap<TblspermDonor, DonorModal>().ForMember(
            dest => dest.StatusName,
            opt => opt.MapFrom(
                src => (src.Status != null) ? "Active" : "In active")).ReverseMap();

            CreateMap<TblsurrogateMother, MotherModal>().ForMember(
            dest => dest.StatusName,
            opt => opt.MapFrom(
                src => (src.Status != null) ? "Active" : "In active")).ReverseMap();

        }
    }
}
