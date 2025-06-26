namespace Lotus_surrogacy_agency_Admin_panel.Service
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
