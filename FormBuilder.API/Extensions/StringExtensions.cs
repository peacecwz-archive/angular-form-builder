namespace FormBuilder.API
{
    public static class StringExtensions
    {
        public static string GetFriendlyUrl(this string input)
        {
            return input.ToLower().Replace(" ", "-");
        }
    }
}