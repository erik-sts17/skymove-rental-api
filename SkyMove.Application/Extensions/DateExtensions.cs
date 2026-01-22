namespace SkyMove.Application.Extensions
{
    public static class DateExtensions
    {
        public static bool MustBeOver18(DateTime date)
        {
            var today = DateTime.Today;
            var age = today.Year - date.Year;

            if (date.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}