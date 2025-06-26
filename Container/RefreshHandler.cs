using System.Security.Cryptography;
using Lotus_surrogacy_agency_Admin_panel.Models;
using Lotus_surrogacy_agency_Admin_panel.Service;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly LotusFertilitySurrogacyContext context;

        public RefreshHandler(LotusFertilitySurrogacyContext context)
        {
            this.context = context;
        }

        public async Task<string> GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string refreshtoken = Convert.ToBase64String(randomnumber);
                var ExistToken = await this.context.Refreshtokens.FirstOrDefaultAsync(item => item.Userid == username);
                if (ExistToken != null)
                {
                    ExistToken.RefreshToken1 = refreshtoken;
                }
                else
                {
                    await this.context.Refreshtokens.AddAsync(new Refreshtoken
                    {
                        Userid = username,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken1 = refreshtoken
                    });
                }
                await this.context.SaveChangesAsync();
                return refreshtoken;
            }
        }
    }
}
