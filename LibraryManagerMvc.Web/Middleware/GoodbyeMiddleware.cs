namespace LibraryManagerMvc.Web.Middleware
{
	public class GoodbyeMiddleware
	{
		private readonly RequestDelegate _next;

        public GoodbyeMiddleware(RequestDelegate next)
		{
			_next = next;
		}

        public async Task InvokeAsync(HttpContext context)
		{
            var message = $"Goodbye... Exiting the GoodbyeMiddleware... The time is {DateTime.Now}";
            Console.WriteLine(message);
            await _next(context);
        }
    }
}
