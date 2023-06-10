using MyEcommerce.Debugging;

namespace MyEcommerce
{
    public class MyEcommerceConsts
    {
        public const string LocalizationSourceName = "MyEcommerce";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "f56887d36ca34d208c2ffae9ad65fa3f";
    }
}
