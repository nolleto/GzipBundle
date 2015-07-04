using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace GzipBundle
{
    public class GzipScriptBundle : GzipBundle
    {
        public GzipScriptBundle(string virtualPath) : base(virtualPath) { BaseDefault(); }
        public GzipScriptBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath, transforms) { BaseDefault(); }
        public GzipScriptBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath) { BaseDefault(); }
        public GzipScriptBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(virtualPath, cdnPath, transforms) { BaseDefault(); }

        private void BaseDefault()
        {
            base.ConcatenationToken = ";" + Environment.NewLine;
        }
    }
}
