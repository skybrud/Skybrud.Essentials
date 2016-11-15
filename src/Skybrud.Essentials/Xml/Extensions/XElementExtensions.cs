namespace Skybrud.Essentials.Xml.Extensions {

    public static partial class XElementExtensions {

        private static bool ParseBoolean(string str) {
            str = (str ?? "").ToLower();
            return str == "true" || str == "1" || str == "t";
        }

    }

}