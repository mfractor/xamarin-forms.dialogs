# A Beginners Guide To Dialogs In Xamarin.Forms
An introduction to the various dialogs that we can use in a Xamarin.Forms app.

## Introduction



This article is an introduction on how to using dialogs in Xamarin.Forms

Before we get started, a quick note on the scope of this article. This article's intent is to be a beginners guide on the types of dialogs available in Xamarin.Forms. I aim to introduce the core concepts and terminology on dialogs, get you started with the most current dialog frameworks and to provide a quick reference on how to use each dialog.

Ideally, this article is suitable for those new to Xamarin.Forms

Firstly, what is some of the key terminology we use when

We'll be using the following frameworks and packages in this tutorial.

 * Xamarin.Forms:
 * Acr.UserDialogs: A cross platform
    * Getting Start Guide
 * Rg.Popups: Create fully customised popups and modal dialogs using Xamarin.Forms pages.
    * [Getting Start Guide](https://github.com/rotorgames/Rg.Plugins.Popup/wiki/Getting-started)

## Terminology

One important

I

 * [Alerts](#alerts): A dialog that shows a message.
 * [Prompts](#prompts): A dialog that requests input from a user.
 * [Action Sheets](#Action-Sheets): A list of choices presented to a user.
 * [Toast](#Toasts): A small, unobtrusive message that shows for a small amount of time.
 * [Activity Indicator](#Activity-Indicators): A dialog to indicate that our app is working.
 * [Custom Popups](#Custom-Popups): A modal dialog with fully customised content.

## Alerts

An **Alert** is a dialog we use to show a message to a user.

Alert dialogs are a convienent

In Acr.UserDialogs we would show an alert like so:

**Showing a message**
```
Acr.UserDialogs.UserDialogs.Instance.Alert("", "Ok");
```

Some common use cases

A special kind of alert dialog is a **Confirm** dialog, an alert that display a message with a choice of two or more actions.

Confirm dialogs are used to force a user to double check

**Showing a confirmation**
Short tutorial on how I show an alert with Acr user dialogs

Include image.

## Prompts

An **Prompt** is a dialog that appears over all


**Using a prompt**

What is an alert and why would I use one?

 -> A modal dialog that shows a message and a confirm/cancel button

Short tutorial on how I show an alert with Acr user dialogs

Include image.

## Action Sheets

Action Sheet: An list of items

What is an action sheet? Why would I use one?

 -> A modal dialog that presents a list of selections.

Short tutorial on how I show an action sheet with Acr user dialogs

Include image.

## Toasts

A **Toast** is


**

A Toast dialog comes is an Android paradigm that is useful for displaying small and unobtrusive messages. It appears as a small a transient popup that appears on the bottom of the screen that contains a small piece of text.

For example:

To

A source code sample

## Activity Indicator

What is a progress indicator and why would I use it?

 -> A modal dialog that display an activity indicator. Can use it to

## Custom Popups

What is a custom popup and why would I use it?

 -> A modal pop

Very short tut

## Summary

Recap each dialog kind and what they do.

Put a call to action to sponsor Acr Userdialogs and Rg.Popups
