namespace WpfApplication1
{
    /// <summary>
    /// This class provides the client credentials for all the samples in this solution.
    /// In order to run all of the samples, you have to enable API access for every API 
    /// you want to use, enter your credentials here.
    /// 
    /// You can find your credentials here:
    ///  https://code.google.com/apis/console/#:access
    /// 
    /// For your own application you should find a more secure way than just storing your client secret inside a string,
    /// as it can be lookup up easily using a reflection tool.
    /// </summary>
    internal static class ClientCredentials
    {
        /// <summary>
        /// The OAuth2.0 Client ID of your project.
        /// </summary>
        public static readonly string ClientID = "947872154601.apps.googleusercontent.com";

        /// <summary>
        /// The OAuth2.0 Client secret of your project.
        /// </summary>
        public static readonly string ClientSecret = "zHY0fepOEvAg-bQHpIuSV3HL";

        /// <summary>
        /// Your Api/Developer key.
        /// </summary>
        public static readonly string ApiKey = "AIzaSyDbBLHF8zYway1LN7QYqesUoLIsj9eHWYc";

        #region Verify Credentials
        static ClientCredentials()
        {
            ReflectionUtils.VerifyCredentials(typeof(ClientCredentials));
        }
        #endregion
    }
}
