namespace SMS_APDP.Middleware
{
    public class AuthorizeMiddleware
    {
        private readonly RequestDelegate _next;
        public AuthorizeMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();
            var role = context.Session.GetString("UserRole");

            if ((path.StartsWith("/admin") && role != "Admin") ||
                (path.StartsWith("/faculty") && role != "Faculty") ||
                (path.StartsWith("/student") && role != "Student"))
            {
                context.Response.Redirect("/Account/Login");
                return;
            }

            await _next(context);
        }
    }
}
