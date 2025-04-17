using System;
using System.Globalization;
using System.IO;
using UnitTestProject1.Xml;

namespace UnitTestProject1 {

    public static class TestHelpers {

        public static string MapPath(string virtualPath) {
            return virtualPath.Replace("~/", Path.GetDirectoryName(typeof(GetElementTests).Assembly.Location) + "/");
        }

        public static string ToString(string value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(int value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(long value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(float value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(double value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(bool value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(object value) {
            return string.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

    }

}