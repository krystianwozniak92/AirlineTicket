namespace WebAPI.Helpers
{
    public enum Country
    {
        Poland = 1,
        Germany,
        France,
        UnitedKingdom,
        Spain,
        Ireland
    }

    public static class CountryHelper
    {
        public static int GetCountryID(Country country)
        {
            return (int)country;
        }
    }
}
