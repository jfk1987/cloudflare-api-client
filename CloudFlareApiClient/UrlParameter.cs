namespace CloudFlareApiClient
{
    public class UrlParameter
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }

        public UrlParameter(string parameterName, string value)
        {
            ParameterName = parameterName;
            Value = value;
        }
    }
}
