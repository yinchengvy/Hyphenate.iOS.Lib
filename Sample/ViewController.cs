using System;
using Foundation;
using Hyphenate.iOS.Lib;
using Masonry;
using UIKit;

namespace Sample
{
    public partial class ViewController : UIViewController, IEMChatManagerDelegate
    {
        public string Account;

        UITextField ContactTextField;
        UITextField SendMessageTextField;

        UITextView TextView;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ConfigrationUI();
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            EMClient.SharedClient().ChatManager.AddDelegate(this, null);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            EMClient.SharedClient().ChatManager.RemoveDelegate(this);
        }

        void ConfigrationUI()
        {
            ContactTextField = new UITextField
            {
                BackgroundColor = UIColor.Clear,
                Placeholder = "Please input a contact",
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15),
                LeftView = new UILabel
                {
                    Frame = new CoreGraphics.CGRect(0, 0, 80, 40),
                    BackgroundColor = UIColor.Clear,
                    Text = "Contact",
                    TextColor = UIColor.Black,
                    Font = UIFont.BoldSystemFontOfSize(14)
                },
                LeftViewMode = UITextFieldViewMode.Always
            };
            View.AddSubview(ContactTextField);

            SendMessageTextField = new UITextField
            {
                BackgroundColor = UIColor.Clear,
                Placeholder = "Please input a message",
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15),
                LeftView = new UILabel
                {
                    Frame = new CoreGraphics.CGRect(0, 0, 80, 40),
                    BackgroundColor = UIColor.Clear,
                    Text = "Msg",
                    TextColor = UIColor.Black,
                    Font = UIFont.BoldSystemFontOfSize(14)
                },
                LeftViewMode = UITextFieldViewMode.Always
            };
            View.AddSubview(SendMessageTextField);

            var sendButton = new UIButton
            {
                BackgroundColor = UIColor.Blue,
            };
            sendButton.SetTitleColor(UIColor.White, UIControlState.Normal);
            sendButton.SetTitle("Send", UIControlState.Normal);
            sendButton.AddTarget(HandleSendMessageEventHandler, UIControlEvent.TouchUpInside);
            View.AddSubview(sendButton);

            TextView = new UITextView
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15)
            };
            View.AddSubview(TextView);

            ContactTextField.MakeConstraints(make =>
            {
                make.Top.EqualTo(View).Offset(100);
                make.Left.EqualTo(View).Offset(30);
                make.Right.EqualTo(View).Offset(-30);
                make.Height.EqualTo(new NSNumber(45));
            });

            SendMessageTextField.MakeConstraints(make =>
            {
                make.Top.EqualTo(ContactTextField.Bottom()).Offset(10);
                make.Left.EqualTo(View).Offset(30);
                make.Height.EqualTo(new NSNumber(45));
            });
            sendButton.MakeConstraints(make =>
            {
                make.Top.EqualTo(ContactTextField.Bottom()).Offset(10);
                make.Left.EqualTo(SendMessageTextField.Right()).Offset(15);
                make.Right.EqualTo(View).Offset(-30);
                make.Width.EqualTo(new NSNumber(100));
                make.Height.EqualTo(new NSNumber(45));
            });

            TextView.MakeConstraints(make =>
            {
                make.Top.EqualTo(SendMessageTextField.Bottom()).Offset(20);
                make.Bottom.EqualTo(View.Bottom()).Offset(30);
                make.Left.EqualTo(View).Offset(30);
                make.Right.EqualTo(View).Offset(-30);
            });
        }

        void HandleSendMessageEventHandler(object sender, EventArgs e)
        {
            var contact = ContactTextField.Text?.Trim();
            var msg = SendMessageTextField.Text?.Trim();

            if (string.IsNullOrEmpty(contact))
            {
                AlertText("Prompt", "Please input a contact");
                return;
            }
            if (string.IsNullOrEmpty(msg))
            {
                AlertText("Prompt", "Please input a message");
                return;
            }

            var chatManager = EMClient.SharedClient().ChatManager;

            var message = new EMMessage(
             contact,
             EMClient.SharedClient().CurrentUsername,
             contact,
             new EMTextMessageBody(msg),
             new NSDictionary())
            {
                ChatType = EMChatType.Chat
            };

            chatManager.SendMessage(message, (progress) => {
                System.Console.WriteLine($"Send message with progress {progress}");
            }, (EMMessage aMessage, EMError error) =>
            {
                if (error != null)
                {
                    AlertText("Prompt", $"Send message failed: {error.ErrorDescription}!");
                }
                else
                {
                    var text = TextView.Text;
                    TextView.Text = $"{text}\n>>>>>>>>>Send message:{msg}";
                }
            });
        }

        [Export("didReceiveMessages:")]
        public void DidReceiveMessages(NSObject[] aMessages)
        {
            if (aMessages == null || aMessages.Length == 0)
            {
                return;
            }
            foreach (var obj in aMessages)
            {
               var msg = HandleMessage(obj);

                if (!string.IsNullOrEmpty(msg))
                {
                    var text = TextView.Text;
                    TextView.Text = $"{text}\n>>>>>>>>>Receive message:{msg}";
                }
            }
        }

        string HandleMessage(NSObject obj)
        {
            var text = "";
            if (obj is EMMessage message)
            {
                var msgBody = message.Body;

                switch (msgBody.Type)
                {
                    case EMMessageBodyType.Text:
                        var textBody = msgBody as EMTextMessageBody;
                        text = $"Text message {textBody?.Text}";
                        System.Console.WriteLine($"收到的文字是 -- {textBody?.Text}");
                        break;
                    case EMMessageBodyType.Image:
                        var imageBody = msgBody as EMImageMessageBody;
                        text = $"Image message {imageBody?.ThumbnailRemotePath}";
                        System.Console.WriteLine($"收到的图片是 -- {imageBody?.ThumbnailRemotePath} {imageBody?.ThumbnailLocalPath}");
                        break;
                    case EMMessageBodyType.Location:
                        var locationBody = msgBody as EMLocationMessageBody;
                        text = $"Location message {locationBody?.Address}";
                        System.Console.WriteLine($"收到的位置是 -- {locationBody?.Address} {locationBody?.Latitude} {locationBody?.Longitude}");
                        break;
                    case EMMessageBodyType.Voice:
                        var voiceBody = msgBody as EMVoiceMessageBody;
                        text = $"Voice message {voiceBody?.RemotePath}";
                        System.Console.WriteLine($"收到的语音是 -- {voiceBody?.RemotePath} {voiceBody?.FileLength} {voiceBody?.Duration}");
                        break;
                    case EMMessageBodyType.Video:
                        var videoBody = msgBody as EMVideoMessageBody;
                        text = $"Video message {videoBody?.RemotePath}";
                        System.Console.WriteLine($"收到的视频是 -- {videoBody?.RemotePath} {videoBody?.FileLength} {videoBody?.Duration}");
                        break;
                    case EMMessageBodyType.File:
                        var fileBody = msgBody as EMFileMessageBody;
                        text = $"File message {fileBody?.RemotePath}";
                        System.Console.WriteLine($"收到的文件是 -- {fileBody?.RemotePath} {fileBody?.FileLength} {fileBody?.FileLength}");
                        break;
                }
            }
            return text;
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
