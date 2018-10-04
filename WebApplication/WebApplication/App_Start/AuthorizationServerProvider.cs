using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using Unity;
using WebApplication.Business.LogicInterface;
using WebApplication.Models.Models;

namespace WebApplication.App_Start
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserBusiness UserBusiness { get; set; }
        private IUnityContainer Container;
        private User user;
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            Container = UnityConfig.Container;

            string clientId;
            string clientSecret;

            UserBusiness = Container.Resolve<IUserBusiness>();

            clientId = context.Parameters.Get("username");
            clientSecret = context.Parameters.Get("password");

            if (!String.IsNullOrEmpty(clientId) || !String.IsNullOrEmpty(clientSecret))
            {
                UserManager<IdentityUser> userManager =
                    context.OwinContext.GetUserManager<UserManager<IdentityUser>>();
                IdentityDbContext dbContext =
                    context.OwinContext.Get<IdentityDbContext>();

                try
                {
                    user = UserBusiness.FindUserByEmail(clientId);
                    user.Password = clientSecret.GetHashCode().ToString();
                    user.Email = clientId;
                    if (user != null)
                    {
                        if (user.Active)
                        {
                            context.OwinContext.Set<string>("oauth:client", clientId);
                            context.Validated(clientId);
                        }
                        else
                        {
                            context.SetError("client_deactivated", "Client account is deactivated.");
                            context.Rejected();
                        }
                    }
                    else
                    {
                        context.SetError("invalid_client", "Client credentials not found.");
                        context.Rejected();
                    }
                }
                catch (Exception e)
                {
                    // Could not get the client through the IClientManager implementation.
                    context.SetError("server_error");
                    context.Rejected();
                }
            }
            else
            {
                // The client credentials could not be retrieved.
                context.SetError(
                    "invalid_client",
                    "Client credentials could not be retrieved through the Authorization header.");

                context.Rejected();
            }
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            if (user != null)
            {

                identity.AddClaim(new Claim(ClaimTypes.Role, "USER"));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}