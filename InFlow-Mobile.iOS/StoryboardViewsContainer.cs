using System;
using System.Reflection;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace InFlow_Mobile.iOS
{
    /// <summary>
    /// See http://stackoverflow.com/questions/28598392/monotouch-exception-not-getting-caught-on-device
    /// http://stackoverflow.com/questions/22126929/mvvmcross-support-for-xamarin-ios-storyboards
    /// </summary>
    public class StoryboardViewsContainer : MvxTouchViewsContainer
    {
        protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
        {
            var storyboardAttribute = viewType.GetCustomAttribute<FromStoryboardAttribute>();
            if (storyboardAttribute != null)
            {
                var storyboard = UIStoryboard.FromName(storyboardAttribute.StoryboardName ?? viewType.Name, null);
                var viewController = storyboard.InstantiateViewController(viewType.Name);
                return (IMvxTouchView)viewController;
            }
            return base.CreateViewOfType(viewType, request);
        }
    }
}