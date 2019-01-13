using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BlobStorageTest
{
    public static class StaticContentUrlHtmlHelper
    {
        public static string StaticContentUrl(this IHtmlHelper<dynamic> helper, Settings settings, string contentPath)
        {
            if (contentPath.StartsWith("~"))
            {
                contentPath = contentPath.Substring(1);
            }

            contentPath = string.Format("{0}/{1}", settings.StaticContentBaseUrl.TrimEnd('/'), contentPath.TrimStart('/'));

            var url = new UrlHelper(helper.ViewContext);

            return url.Content(contentPath);
        }

        public static string CdnUrl(this IHtmlHelper<dynamic> helper, Settings settings, string contentPath)
        {
            if (contentPath.StartsWith("~"))
            {
                contentPath = contentPath.Substring(1);
            }

            contentPath = string.Format("{0}/{1}", settings.CdnConnectionString.TrimEnd('/'), contentPath.TrimStart('/'));

            var url = new UrlHelper(helper.ViewContext);

            return url.Content(contentPath);
        }
    }
}
