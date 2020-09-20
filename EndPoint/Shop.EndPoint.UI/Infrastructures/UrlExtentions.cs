using Microsoft.AspNetCore.Http;

namespace Shop.EndPoints.WebUI.Infrastructures
{
    public static class UrlExtentions
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue ? 
                $"{request.Path.Value}{request.QueryString.Value}" 
                : request.Path.Value.ToString();
        }

    }
}
