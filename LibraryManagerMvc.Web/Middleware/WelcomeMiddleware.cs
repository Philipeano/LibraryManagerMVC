namespace LibraryManagerMvc.Web.Middleware
{
	public class WelcomeMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			var message = $"Hello, from WelcomeMiddleware... The time is {DateTime.Now}";
			Console.WriteLine(message);
			await next(context);
        }
	}
}
