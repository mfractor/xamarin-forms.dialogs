# A Beginners Guide To Dialogs In Xamarin.Forms

## Introduction

When developing mobile applications, dialogs are a foundational building block in our tool-belt. We can use dialogs to show a confirmation message, to indicate when the app is working or even to create a rich input form that appears over our main user interface.

This article aims to be a getting-started guide for using dialogs in Xamarin.Forms and is intended to be a beginners guide. I aim to introduce the core concepts and terminology, get you started with the most current dialog frameworks and provide a quick reference on the main dialog types. 

If you're totally new Xamarin.Forms and want to learn about dialogs, this is the article for you 😉

Before we dive in, let's take a moment to introduce two important terms used throughout this article:

 * **Modal**: A dialog appears over the existing user interface and blocks input to the elements beneath it, not allowing users to exit by tapping outside it. Modal dialogs effectively "focus" the users attention onto the dialog.
 * **Transient**: A temporary dialog that dismisses by itself without user intervention. For example, dialogs that automatically dismiss after a specified time span are transient.

These terms, Modal and Transient, will be used many times in this article

Next, let's explore the six main dialogs kinds that we will explore in this guide:

 * [Alerts](#alerts): A dialog that shows a message.
 * [Prompts](#prompts): A dialog that requests input from a user.
 * [Action Sheets](#action-sheets): A list of choices presented to a user.
 * [Toast](#toasts): A small, unobtrusive message that shows for a small amount of time.
 * [Progress Indicator](#progress-indicator): A dialog to indicate that our app is working.
 * [Custom Popups](#custom-popup): A modal dialog with fully customised content.

The full source code for this article can be found here.

## Packages And Frameworks

Before we get started lets take a look at the packages we'll be using.

While Xamarin.Forms has Alerts and Action Sheets built in, to access the other dialogs we'll need to bring some nugets.

 * Acr.UserDialogs: A rich dialogs library for Xamarin.Forms. Acr.User dialogs is the de facto standard when working with dialogs in Xamarin.Forms.
    * [Readme](https://github.com/aritchie/userdialogs);
 * Rg.Popups: Create fully customised popups and modal dialogs using Xamarin.Forms pages.
    * [Getting Start Guide](https://github.com/rotorgames/Rg.Plugins.Popup/wiki/Getting-started)

## Dialogs 101

### Alerts

An **Alert** is a modal dialog used to show a message to a user.

![Using an alert in Xamarin.Forms](img/alert.png)

Alerts are a convenient way to inform the user that something has happened or that they need to make an action. They're useful when you need confirmation from 

Using Acr.UserDialogs, we would show an alert like so:

```
Acr.UserDialogs.UserDialogs.Instance.Alert("Welcome to alert dialogs", "Ok");
```

Some common use cases

A special kind of alert dialog is a **Confirm** dialog, an alert that display a message with a choice of two or more actions.

![Using a confirmation dialog in Xamarin.Forms](img/confirm.png)

Confirm dialogs are used to force a user to double check

**Showing a confirmation**
Short tutorial on how I show an alert with Acr user dialogs

Include image.

### Prompts

A **Prompt** is a modal dialog that asks the user for some basic text input, such as asking for a name or email address.

![Using a prompt in Xamarin.Forms](img/prompt.png)

**Using a prompt**

Prompt is used very similarly to Alert and Confirm dialogs. The key difference being in the PromptResult that it returns, where you'll find a bool `Ok` to indicate if the user confirmed input and `Text` which contains the text they entered.

```
var input = await userDialogs.PromptAsync("What is your email?", "Confirm Email", "Confirm", "Cancel");

if (input.Ok)
{
   Console.WriteLine("Your email is" + input.Text);
}
```

### Action Sheets

An **Action Sheet** is a popup dialog that presents the user with a selection of choices and, optionally, a cancel and destructive action.

These are typically used when there are multiple actions a user might want to take. An example would be in an email application if a user clicks on an email they may want to Open, Forward, Reply, etc. In this case the destructive action would be **Delete** which would be displayed in red and separated from the rest of the list, hinting to the user that this action is serious and that they should think carefully. The **Cancel** option is also displayed differently to make it obvious that it is different to the other choices, this would generally 

![Using an action sheet in Xamarin.Forms](img/action-sheet.png)

What is an action sheet? Why would I use one?

 -> A modal dialog that presents a list of selections.

Short tutorial on how I show an action sheet with Acr user dialogs

Include image.

### Toasts

A **Toast** is a small, temporary popup that shows at the bottom of the screen useful for display displaying small and unobtrusive messages. Toasts are effectively transient dialogs. 

![Using a toast in Xamarin.Forms](img/toast.png)

A good example of when to use a toast is to notify the user that their data has been saved successfully.

Displaying a Toast is once again done using userDialogs, but this time calling the Toast method. As there is no title or dismiss button we only need one string input for the text to display.
```
userDialogs.Toast("I am a custom toast. Great for showing small pieces of transient information.");
```

### Progress Indicator

A progress indicator is similar to the built in activity indicator, the key difference being that it keeps the user updated on the progress through out the task instead of simply indicating that something is happening.

![Using a progress dialog in Xamarin.Forms](img/progress.png)

Here I'm updating progress using a loop with a delay of 20ms, in a real app you would update this based on how much work had been done and what was remaining.

```
using (var progress = userDialogs.Progress("Loading..."))
{
   for (var i = 0; i < 100; i++)
   {
         progress.PercentComplete = i;

         await Task.Delay(20);
   }
}
```

### Custom Popup

All the dialogs we've looked at so far have a fixed layout and serve a specific purpose. With a custom popup you can put any content you want inside with any appearance. These are useful if you want more advanced interaction than the defaults or if you want it styled to match your app instead of the system UI.

Custom popup take a bit more work than the others, for this example we'll show a popup with an image and two buttons.

![Using a custom popup in Xamarin.Forms](img/custom-popup.png)

The first step is to create a new Xaml ContentView called CustomPopup, this will give use a `CustomPopup.xaml` and a `CustomPopup.xaml.cs`. Instead of using ContentView as the base class, we'll swap the element to be a `popups:PopupPage` which will allow us to use it as a popup.

Inside the PopupPage we can put any Xamarin.Forms content we like. Here I've got a `Grid` that contains an `Image` and two `Button`s.
```
<?xml version="1.0" encoding="UTF-8"?>
<popups:PopupPage xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns="http://xamarin.com/schemas/2014/forms"
    x:Class="DialogsExamples.CustomPopup"
    CloseWhenBackgroundIsClicked="False"
    xmlns:popups="clr-namespace:Rg.Plugins.Popup.Pages;assembly=Rg.Plugins.Popup"
    xmlns:controls="clr-namespace:DialogsExamples.Controls">
    <Grid HorizontalOptions="Center" VerticalOptions="Center" Padding="10" BackgroundColor="WhiteSmoke">
       <Grid.RowDefinitions>
           <RowDefinition Height="Auto"/>
           <RowDefinition Height="Auto"/>
        </Grid.RowDefinitions>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <Image Grid.Row="0" Grid.Column="0" Grid.ColumnSpan="2" Source="monkeyfest"/>
        <Button Grid.Row="1" Grid.Column="0" Text="Confirm Attendance" Clicked="ConfirmAttendanceClicked"/>
        <Button Grid.Row="1" Grid.Column="1" Text="Cancel Attendance" Clicked="CancelAttendanceClicked"/>
    </Grid>
</popups:PopupPage>
```

In the code behind we'll need a constructor that takes in an `Action`, and methods for Confirm and Cancel.

```
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
}
```

With these methods we can create a our custom popup and display it with the true/false result being passed to a callback. This code is a little messy and if we're using this code in multiple places in the app it's a bit of a pain. instead we can add a static method to CustomPopup which makes it much neater to call from other classes.

```
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
```

This wraps up the callback in an awaitable `Task<bool>` so you don't have to worry about actions. Now when we want to display the `CustomPopup`, it feels a lot more like how we displayed the other dialogs.

```
var result = await CustomPopup.ConfirmConferenceAttendance(navigation);
```


## Summary

All of these dialogs serve similar purposes but have slight variations based on what you need to present and what input you need from the user.

As a quick guide for deciding which to use pick which situation best describes your needs:

I want to display some text and have the user acknowledge the message 
 * Use an [Alert](#alerts)

I want to get some short text input from a user
* Use a [Prompt](#prompts) dialog.

* I want to display some text to a user but no interaction is needed
  
   Use a Toast
* I want to ask the user a question with two options such as yes/no or confirm/cancel
   
   Use a Confirm dialog

* I want to ask to present the user with multiple options.

   Use and ActionSheet
* I want to let the user know how much of a job has been completed.

   Use a Progress dialog
* 



### I want to  


These libraries are both free and Open Source but they rely on the support of their user's. If you find UserDialogs to be useful in your project please sponsor Allan Ritchie through his [github sponsor page](https://github.com/sponsors/aritchie). Visit the repo for more information on Rg.Popup [https://github.com/rotorgames/Rg.Plugins.Popup](https://github.com/rotorgames/Rg.Plugins.Popup)




 * [Alerts](#alerts): A dialog that shows a message.
 * [Prompts](#prompts): A dialog that requests input from a user.
 * [Action Sheets](#action-sheets): A list of choices presented to a user.
 * [Toast](#toasts): A small, unobtrusive message that shows for a small amount of time.
 * [Progress Indicator](#progress-indicator): A dialog to indicate that our app is working.
 * [Custom Popups](#custom-popup): A modal dialog with fully customised content.