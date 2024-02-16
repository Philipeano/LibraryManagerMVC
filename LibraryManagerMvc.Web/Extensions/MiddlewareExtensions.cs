using LibraryManagerMvc.Web.Middleware;

namespace LibraryManagerMvc.Web.Extensions
{
	public static class MiddlewareExtensions
	{

		public static IApplicationBuilder UseWelcomeMiddleware(this IApplicationBuilder app)
		{
			return app.UseMiddleware<WelcomeMiddleware>();
		}
    }
}
