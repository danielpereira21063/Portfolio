namespace Portfolio.API.Extensions
{
    public static class HttpContextExtension
    {
        public static string ObterTokenUsuario(this HttpContext httpContext)
        {
            return httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        }
    }
}
