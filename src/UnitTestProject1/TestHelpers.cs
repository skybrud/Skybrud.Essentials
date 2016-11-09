using System.IO;
using UnitTestProject1.Xml;

namespace UnitTestProject1 {
    
    public static class TestHelpers {

        public static string MapPath(string virtualPath) {
            return virtualPath.Replace("~/", Path.GetDirectoryName(typeof (GetElementTests).Assembly.Location) + "/");
        }

    }

}