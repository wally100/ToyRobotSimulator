using System.Text.RegularExpressions;

namespace ToyRobotSimulator.Utilities
{
    public static class Extensions
    {
        private static Regex digitsOnly = new Regex(@"[^\d]");

        public static string RemoveNonNumericCharacters(this string val)
        {
            if(val != null)
                return digitsOnly.Replace(val, string.Empty);
            return null;
        }

        public static int? ToInt32(this string val)
        {
            int output = 0;
            if(int.TryParse(val, out output))
                return output;
            return null;
        }

       
    }
}
