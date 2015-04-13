using Cirrious.CrossCore;
using Cirrious.MvvmCross.Touch.Views;
using InFlow_Mobile.Core;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;

namespace InFlow_Mobile.iOS
{
    /// <summary>
    ///    Defines the Setup type.
    /// </summary>
    public class Setup : MvxTouchSetup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Setup"/> class.
        /// </summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="presenter">The presenter.</param>
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        /// <summary>
        /// Creates the app.
        /// </summary>
        /// <returns>An instance of IMvxApplication</returns>
        protected override IMvxApplication CreateApp()
        {
			Mvx.RegisterSingleton<IPlatform> (new Platform ());
            Mvx.RegisterSingleton<IInitializeDatabaseService>(new InitializeDatabaseService());
            return new Core.App();
        }

        protected override IMvxTouchViewsContainer CreateTouchViewsContainer()
        {
            return new StoryboardViewsContainer();
        }
    }
}