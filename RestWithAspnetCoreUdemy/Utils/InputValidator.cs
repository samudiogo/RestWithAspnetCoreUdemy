using System.Globalization;

namespace RestWithAspnetCoreUdemy.Utils
{
    public static class InputValidator
    {
        private static readonly CultureInfo Br = CultureInfo.CreateSpecificCulture("pt-BR");

        public static bool IsNumeric(string strNumber, out double result) => double.TryParse(strNumber, NumberStyles.Any, Br, out result);
    }
}