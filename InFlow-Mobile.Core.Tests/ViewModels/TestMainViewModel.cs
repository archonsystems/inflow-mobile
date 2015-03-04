//// --------------------------------------------------------------------------------------------------------------------
//// <summary>
////    Defines the TestMainViewModel type.
//// </summary>
//// --------------------------------------------------------------------------------------------------------------------
//namespace InFlow_Mobile.Core.Tests.ViewModels
//{
//    using Core.ViewModels;
//    using Xunit;

//    /// <summary>
//    /// Defines the TestMainViewModel type.
//    /// </summary>
//    public class TestMainViewModel : BaseTest
//    {
//        /// <summary>
//        /// The MainViewModel.
//        /// </summary>
//        private ItemListViewModel _itemListViewModel;

//        /// <summary>
//        /// Creates an instance of the object to test.
//        /// To allow Ninja automatically create the unit tests
//        /// this method should not be changed.
//        /// </summary>
//        public override void CreateTestableObject()
//        {
//            this._itemListViewModel = new ItemListViewModel();
//        }

//        /// <summary>
//        /// Tests my property.
//        /// </summary>
//        [Fact]
//        public void TestMyProperty()
//        {
//            //// arrange
//            bool changed = false;

//            this._itemListViewModel.PropertyChanged += (sender, args) =>
//                {
//                    if (args.PropertyName == "MyProperty")
//                    {
//                        changed = true;
//                    }
//                };

//            //// act
//            this._itemListViewModel.MyProperty = "Hello MvvmCross";

//            //// assert
//            Assert.AreEqual(changed, true);
//        }

//        /// <summary>
//        /// Tests my command.
//        /// </summary>
//        [Fact]
//        public void TestMyCommand()
//        {
//            //// arrange

//            //// act
//            this._itemListViewModel.MyCommand.Execute(null);

//            //// assert
//        }
//    }
//}
