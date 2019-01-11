using System;
using Foundation;
using Hyphenate.iOS.Lib;
using Masonry;
using UIKit;

namespace Sample
{
    public partial class MainViewController : UIViewController
    {
        UITextField AccountTextField;
        UITextField PasswordTextField;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Demo";

            ConfigrationUI();
        }

        void ConfigrationUI()
        {
            var accountTextField = new UITextField
            {
                BackgroundColor = UIColor.Clear,
                Placeholder = "Please input account",
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15),
                LeftView = new UILabel
                {
                    Frame = new CoreGraphics.CGRect(0, 0, 80, 40),
                    BackgroundColor = UIColor.Clear,
                    Text = "Account",
                    TextColor = UIColor.Black,
                    Font = UIFont.BoldSystemFontOfSize(14)
                },
                LeftViewMode = UITextFieldViewMode.Always
            };
            View.AddSubview(accountTextField);
            AccountTextField = accountTextField;

            var passwordTextField = new UITextField
            {
                BackgroundColor = UIColor.Clear,
                Placeholder = "Please input password",
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15),
                LeftView = new UILabel
                {
                    Frame = new CoreGraphics.CGRect(0, 0, 80, 40),
                    BackgroundColor = UIColor.Clear,
                    Text = "Password",
                    TextColor = UIColor.Black,
                    Font = UIFont.BoldSystemFontOfSize(14)
                },
                LeftViewMode = UITextFieldViewMode.Always
            };
            View.AddSubview(passwordTextField);
            PasswordTextField = passwordTextField;

            var registerButton = new UIButton
            {
                BackgroundColor = UIColor.Blue,
            };
            registerButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            registerButton.SetTitle("Register", UIControlState.Normal);
            registerButton.AddTarget(HandleRegisterEventHandler, UIControlEvent.TouchUpInside);
            View.AddSubview(registerButton);

            var loginButton = new UIButton
            {
                BackgroundColor = UIColor.Red,
            };
            loginButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            loginButton.SetTitle("Login", UIControlState.Normal);
            loginButton.AddTarget(HandleLoginEventHandler, UIControlEvent.TouchUpInside);
            View.AddSubview(loginButton);

            accountTextField.MakeConstraints(make =>
            {
                make.Top.EqualTo(View).Offset(100);
                make.Left.EqualTo(View).Offset(30);
                make.Right.EqualTo(View).Offset(-30);
                make.Height.EqualTo(new NSNumber(45));
            });

            passwordTextField.MakeConstraints(make =>
            {
                make.Top.EqualTo(accountTextField.Bottom()).Offset(10);
                make.Left.EqualTo(View).Offset(30);
                make.Right.EqualTo(View).Offset(-30);
                make.Height.EqualTo(new NSNumber(45));
            });

            registerButton.MakeConstraints(make =>
            {
                make.Top.EqualTo(passwordTextField.Bottom()).Offset(20);
                make.Left.EqualTo(View).Offset(30);
                make.Width.EqualTo(loginButton.Width()).DividedBy(2);
                make.Height.EqualTo(new NSNumber(50));
            });

            loginButton.MakeConstraints(make =>
            {
                make.Top.EqualTo(passwordTextField.Bottom()).Offset(20);
                make.Left.EqualTo(registerButton.Right()).Offset(10);
                make.Right.EqualTo(View).Offset(-30);
                make.Height.EqualTo(new NSNumber(50));
            });
        }

        void HandleRegisterEventHandler(object sender, EventArgs e)
        {
            var account = AccountTextField.Text?.Trim();
            var password = PasswordTextField.Text;

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                AlertText("Promot", "Account or password cannot be empty!");
                return;
            }
            EMClient.SharedClient().AsyncRegisterWithUsername(account, password, () =>
            {
                AlertText("Promot", $"Register {account} success!");
            }, (error) =>
            {
                AlertText("Promot", $"Register {account} failed: {error.ErrorDescription}!");
            });
        }

        void HandleLoginEventHandler(object sender, EventArgs e)
        {
            var account = AccountTextField.Text?.Trim();
            var password = PasswordTextField.Text;

            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                AlertText("Promot", "Account or password cannot be empty!");
                return;
            }
            EMClient.SharedClient().LoginWithUsernameAndPasswordAndCompletion(account, password, (userName, error) =>
            {
                if (error != null)
                {
                    AlertText("Prompt", $"Login {account} failed: {error.ErrorDescription}!");
                }
                else
                {
                    AlertText("Promot", $"Login {account} success!");
                    NavigationController.PushViewController(new ViewController { Account = account }, true);
                }
            });
        }

        void AlertText(string title, string message)
        {
#pragma warning disable
            var alert = new UIAlertView(title, message, null, "OK", null);
#pragma warning restore
            alert.Show();
        }
    }
}
