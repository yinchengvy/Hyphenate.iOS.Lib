using Foundation;
using Hyphenate.iOS.Lib;
using UIKit;

namespace Sample
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            RegisterHyphenate();

            Window = new UIWindow(UIScreen.MainScreen.Bounds)
            {
                BackgroundColor = UIColor.White
            };
            Window.MakeKeyAndVisible();
            Window.RootViewController = new UINavigationController(new MainViewController());

            return true;
        }

        void RegisterHyphenate()
        {
            var apnsCertName = "";
#if DEBUG
            apnsCertName = "demoappstore-dev";
#else
            apnsCertName = "demoappstore";
#endif
            var appkey = NSUserDefaults.StandardUserDefaults.StringForKey("identifier_appkey");
            if (string.IsNullOrEmpty(appkey))
            {
                appkey = "easemob-demo#chatdemoui";
                NSUserDefaults.StandardUserDefaults.SetString(appkey, "identifier_appkey");
                NSUserDefaults.StandardUserDefaults.Synchronize();
            }
            var isHttpsOnly = NSUserDefaults.StandardUserDefaults.BoolForKey("identifier_httpsonly");

            EMOptions options = EMOptions.OptionsWithAppkey(appkey);
            options.ApnsCertName = apnsCertName;
            options.IsAutoAcceptGroupInvitation = false;
            options.EnableConsoleLog = true;
            options.UsingHttpsOnly = isHttpsOnly;

            var error = EMClient.SharedClient().InitializeSDKWithOptions(options);
            if (error != null)
            {
                System.Console.WriteLine($"Register hyphenate sdk failed: [{error.Code} {error.Description}]!");
            }
        }
    }
}

