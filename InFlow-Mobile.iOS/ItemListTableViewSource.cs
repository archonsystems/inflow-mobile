using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Windows.Input;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Foundation;
using InFlow_Mobile.Core.ViewModels;
using ReactiveUI;
using UIKit;
using System.Windows.Input;

namespace InFlow_Mobile.iOS
{
    public class ItemListTableViewSource<T> : MvxStandardTableViewSource
    {
        public ItemListTableViewSource(UITableView tableView) : base(tableView, UITableViewCellStyle.Subtitle, new NSString("StandardCellId"), new NSString("TitleText Name; DetailText Description"), UITableViewCellAccessory.None)
        {
        }

        public IObservable<T> ItemClicked { get { return _itemClicked; } }
        private readonly Subject<T> _itemClicked = new Subject<T>(); 

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var list = (this.ItemsSource as IList<T>);
            if(list != null)
                _itemClicked.OnNext(list[indexPath.Row]);
        }
    }
}