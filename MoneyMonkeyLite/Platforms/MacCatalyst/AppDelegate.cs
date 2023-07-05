using Foundation;
using MoneyMonkeyLite.Pages;

namespace MoneyMonkeyLite
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}