//using System.Net.Http.Headers;
//using System.Runtime.CompilerServices;
//using System.Security.Claims;
//using System.Text;
//using System.Text.Encodings.Web;
//using Lotus_surrogacy_agency_Admin_panel.Models;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;

//namespace Lotus_surrogacy_agency_Admin_panel.Container
//{
//    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//    {
//        private readonly LotusFertilitySurrogacyContext context;
//        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, LotusFertilitySurrogacyContext context) : base(options, logger, encoder, clock)
//        {
//            this.context = context;
//        }
//        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
//        {
//            //if (!Request.Headers.ContainsKey("Authorization"))
//            //{
//            //    return AuthenticateResult.Fail("No header found");
//            //}
//            //var headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//            //if (headervalue != null)
//            //{
//            //    var bytes = Convert.FromBase64String(headervalue.Parameter);
//            //    string credentials = Encoding.UTF8.GetString(bytes);
//            //    string[] array = credentials.Split(":");
//            //    string username = array[0];
//            //    string password = array[1];
//            //    var user = await this.context.Tblusers.FirstOrDefaultAsync(item => item.Username == username && item.Password == password);
//            //    if (user != null)
//            //    {
//            //        var claim = new[] { new Claim(ClaimTypes.Name, user.Username) };
//            //        var identity = new ClaimsIdentity(claim, Scheme.Name);
//            //        var principal = new ClaimsPrincipal(identity);
//            //        var ticket = new AuthenticationTicket(principal, Scheme.Name);
//            //        return AuthenticateResult.Success(ticket);
//            //    }
//            //    else
//            //    {
//            //        return AuthenticateResult.Fail("UnAutorized");
//            //    }
//            //}
//            //else
//            //{
//            //    return AuthenticateResult.Fail("Empty header");
//            //}
//        }
//    }
//}
