using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace GzipBundle
{
    public class GzipStyleBundle : GzipBundle
    {
        public GzipStyleBundle(string virtualPath) : base(virtualPath) { }
        public GzipStyleBundle(string virtualPath, params IBundleTransform[] transforms) : base(virtualPath, transforms) { }
        public GzipStyleBundle(string virtualPath, string cdnPath) : base(virtualPath, cdnPath) { }
        public GzipStyleBundle(string virtualPath, string cdnPath, params IBundleTransform[] transforms) : base(virtualPath, cdnPath, transforms) { }
    }
}
