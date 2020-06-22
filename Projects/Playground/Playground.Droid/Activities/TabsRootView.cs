﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Playground.Core.ViewModels;

namespace Playground.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Theme = "@style/AppTheme", ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize)]
    public class TabsRootView : MvxActivity<TabsRootViewModel>
    {
        Bundle startBundle;
        bool isStarted;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TabsRootView);
            startBundle = bundle;
        }

        protected override void OnResume()
        {
            base.OnResume();
            if (startBundle == null && !isStarted)
            {
                isStarted = true;
                ViewModel.ShowInitialViewModelsCommand.Execute();
            }
        }
    }
}
