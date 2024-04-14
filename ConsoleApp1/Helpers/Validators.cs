using System.Globalization;


namespace ConsoleApp1.Helpers
{
    public class Validators
    {
        private static string[] _dateFormats = { "dd.MM.yyyy", "d.M.yyyy", "yyyy-MM-dd", "MM/dd/yyyy" };
        public static DateTime ConvertToDatetime(string date)
        {

            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime result;

            if (!string.IsNullOrWhiteSpace(date) && DateTime.TryParseExact(date, _dateFormats, provider, DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                result = DateTime.Now;
                return result;
            }

        }

        public static int TryParseInt(string id)
        {
            if (int.TryParse(id, out int result))
            {
                return result;
            }
            throw new FormatException("Parsing failed. The input string was not in a correct format.");
        }
    }
}
