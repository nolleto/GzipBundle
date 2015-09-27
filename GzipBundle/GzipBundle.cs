using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace GzipBundle
{
    public class GzipBundle : Bundle
    {
        public GzipBundle(string virtualPath) : base(virtualPath) { }
        public GzipBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath, transforms) { }
        public GzipBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath) { }
        public GzipBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(virtualPath, cdnPath, transforms) { }

        public override BundleResponse CacheLookup(BundleContext context)
        {
            if (null != context) GZipEncodePage(context.HttpContext);
            return base.CacheLookup(context);
        }

        private static void GZipEncodePage(HttpContextBase httpContext)
        {
            HttpResponseBase httpResponse = null;
            string acceptEncoding = null;

            if (CheckHttpContext(httpContext))
            {
                httpResponse = httpContext.Response;
                acceptEncoding = httpContext.Request.Headers["Accept-Encoding"];
                if (!string.IsNullOrEmpty(acceptEncoding) && ResponseNotEncoded(httpResponse))
                {
                    if (acceptEncoding.Contains(DecompressionMethods.GZip.ToString()))
                    {
                        httpResponse.Filter = new GZipStream(httpResponse.Filter, CompressionMode.Compress);
                        httpResponse.AddHeader("Content-Encoding", DecompressionMethods.GZip.ToString().ToLowerInvariant());
                        httpContext.Response.AppendHeader("Vary", "Content-Encoding");
                    }
                    else if (acceptEncoding.Contains(DecompressionMethods.Deflate.ToString()))
                    {
                        httpResponse.Filter = new DeflateStream(httpResponse.Filter, CompressionMode.Compress);
                        httpResponse.AddHeader("Content-Encoding", DecompressionMethods.Deflate.ToString().ToLowerInvariant());
                        httpContext.Response.AppendHeader("Vary", "Content-Encoding");
                    }
                }
            }
        }

        private static bool CheckHttpContext(HttpContextBase httpContext)
        {
            return httpContext != null && httpContext.Request != null && httpContext.Response != null;
        }

        private static bool ResponseNotEncoded(HttpResponseBase httpResponse)
        {
            return httpResponse.Filter == null || !(httpResponse.Filter is GZipStream || httpResponse.Filter is DeflateStream);
        }
    }
}
