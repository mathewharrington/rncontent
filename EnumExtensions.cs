using System.ComponentModel;

namespace Rename
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Get string value from description attribute of the flags enum.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string GetStringValue(this Flags val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}