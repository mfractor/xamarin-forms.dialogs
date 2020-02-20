using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;


namespace DialogsExamples
{
    public partial class CustomPopup : PopupPage
    {
        private readonly Action<bool> setResultAction;

        public void CancelAttendanceClicked(object sender, EventArgs e)
        {
            setResultAction?.Invoke(false);
            this.Navigation.PopPopupAsync().ConfigureAwait(false);
        }

        public void ConfirmAttendanceClicked(object sender, EventArgs e)
        {
            setResultAction?.Invoke(true);
            this.Navigation.PopPopupAsync().ConfigureAwait(false);
        }

        public CustomPopup(Action<bool> setResultAction)
        {
            InitializeComponent();
            this.setResultAction = setResultAction;
        }

        public static async Task<bool> ConfirmConferenceAttendance(INavigation navigation)
        {
            TaskCompletionSource<bool> completionSource = new TaskCompletionSource<bool>();

            void callback(bool didConfirm)
            {
                completionSource.TrySetResult(didConfirm);
            }

            var popup = new CustomPopup(callback);

            await navigation.PushPopupAsync(popup);

            return await completionSource.Task;
        }
    }
}