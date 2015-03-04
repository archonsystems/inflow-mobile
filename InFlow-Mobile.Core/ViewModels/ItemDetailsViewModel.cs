using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using ReactiveUI;

namespace InFlow_Mobile.Core.ViewModels
{
    public class ItemDetailsViewModel : BaseViewModel
    {
        public ItemDetailsViewModel()
        {
            (SaveCommand = ReactiveCommand.Create(this.WhenAnyValue(x => x.Initialized))).Subscribe(async _ => await SaveAsync());
        }

        public async Task Init(ItemDetailsViewNavigationParameters p)
        {
            if (p.ShouldLoad)
            {
                var item = await Mvx.Resolve<IItemRepositoryService>().LoadItemAsync(p.ProdId);
                ProdId = item.ProdId;
                Name = item.Name;
                Description = item.Description;
                IsNew = false;
            }
            else
            {
                ProdId = 0;
                Name = "";
                Description = "";
                IsNew = true;
            }

            Initialized = true;
        }

        private async Task SaveAsync()
        {
            var item = new Item { ProdId = ProdId, Name = Name, Description = Description, };

            if (IsNew)
            {
                await Mvx.Resolve<IItemRepositoryService>().InsertAsync(item);
            }
            else
            {
                await Mvx.Resolve<IItemRepositoryService>().UpdateAsync(item);
            }

            Close(this);
        }

        public ReactiveCommand<object> SaveCommand { get; set; }

        private bool _IsNew;
        public bool IsNew { get { return this._IsNew; } set { this.SetProperty(ref this._IsNew, value, () => this.IsNew); } }

        private int _ProdId;
        public int ProdId { get { return this._ProdId; } set { this.SetProperty(ref this._ProdId, value, () => this.ProdId); } }

        private string _Name = "";
        public string Name { get { return this._Name; } set { this.SetProperty(ref this._Name, value, () => this.Name); } }

        private string _Description = "";
        public string Description { get { return this._Description; } set { this.SetProperty(ref this._Description, value, () => this.Description); } }
    }
}