using System;
using Acr.UserDialogs;
using PropertyChanged;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;

namespace DialogsExamples
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {
        public string Message
        {
            get;
            set;
        }

        public ICommand ActionSheetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var choices = new [] { "Oranges", "Apples", "Bananas" };

                    var choice = await userDialogs.ActionSheetAsync("Choose A Fruit", "Cancel", "Destroy", CancellationToken.None, choices);

                    if (!string.IsNullOrEmpty(choice))
                    {
                        Message = "You chose " + choice;
                    }
                    else
                    {
                        Message = "Action sheet was cancelled";
                    }
                });
            }
        }

        public ICommand CustomPopupCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var result = await CustomPopup.ConfirmConferenceAttendance(navigation);

                    if (result)
                    {
                        Message = "You confirmed conference attendance";
                    }
                    else
                    {
                        Message = "You are not going to the conference ☹️";
                    }
                });
            }
        }

        public ICommand ProgressIndicatorCommand
        {
            get
            {
                return new Command(async () =>
                {
                    using (var progress = userDialogs.Progress("Loading..."))
                    {
                        for (var i = 0; i < 100; i++)
                        {
                            progress.PercentComplete = i;

                            await Task.Delay(20);
                        }
                    }
                });
            }
        }

        public ICommand AlertCommand
        {
            get
            {
                return new Command(() =>
                {
                    userDialogs.Alert("Welcome to alert dialogs", "Welcome", "Ok");
                });
            }
        }

        public ICommand ConfirmCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var result = await userDialogs.ConfirmAsync("Would you like to confirm selection?", "Confirm Selection", "Yes", "No");

                    if (result)
                    {
                        Console.WriteLine("Selection confirmed!");
                    }
                });
            }
        }

        public ICommand ToastCommand
        {
            get
            {
                return new Command(() =>
                {
                    userDialogs.Toast("I am a toast. Great for showing small pieces of transient information.");
                });
            }
        }

        public ICommand PromptCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var input = await userDialogs.PromptAsync("What is your email?", "Confirm Email", "Confirm", "Cancel");

                    if (input.Ok)
                    {
                        Console.WriteLine("Your email is" + input.Text);
                    }
                });
            }
        }

        IUserDialogs userDialogs;
        INavigation navigation;

        public MainViewModel(INavigation navigation, IUserDialogs userDialogs)
        {
            this.navigation = navigation;
            this.userDialogs = userDialogs;
        }
    }
}