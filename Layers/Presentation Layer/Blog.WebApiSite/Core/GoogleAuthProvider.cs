namespace Blog.WebApiSite.Core
{
	using System.Security.Claims;
	using System.Threading.Tasks;
	using Microsoft.Owin.Security.Google;

	public class GoogleAuthProvider : IGoogleOAuth2AuthenticationProvider
	{
		public void ApplyRedirect(GoogleOAuth2ApplyRedirectContext context)
		{
			context.Response.Redirect(context.RedirectUri);
		}

		public Task Authenticated(GoogleOAuth2AuthenticatedContext context)
		{
			context.Identity.AddClaim(new Claim("ExternalAccessToken", context.AccessToken));
			context.Identity.AddClaim(new Claim("Image", context.User.GetValue("image").ToString()));
			context.Identity.AddClaim(new Claim("Email", context.Email));
			return Task.FromResult<object>(null);
		}

		public Task ReturnEndpoint(GoogleOAuth2ReturnEndpointContext context)
		{
			return Task.FromResult<object>(null);
		}
	}
}