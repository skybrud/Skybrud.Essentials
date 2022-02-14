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
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(int value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(long value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(float value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(double value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(bool value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

        public static string ToString(object value) {
            return String.Format(CultureInfo.InvariantCulture, "{0}", value);
        }

    }

}