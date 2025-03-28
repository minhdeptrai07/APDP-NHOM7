namespace SMS_APDP.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToString();
            var userRole = context.Session.GetString("Role");

            if (!context.Session.Keys.Contains("UserId") && !path.Contains("/Account/Login") && !path.Contains("/Account/Register"))
            {
                context.Response.Redirect("/Account/Login");
                return;
            }

            await _next(context);
        }
    }

}
