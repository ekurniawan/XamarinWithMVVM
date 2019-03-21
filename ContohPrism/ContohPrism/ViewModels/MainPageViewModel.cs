using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContohPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase,IConfirmNavigationAsync
    {
        public MainPageViewModel(INavigationService navigationService,IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            _dialogService = dialogService;
            
        }

        private DelegateCommand _navigateCommand;
        private IPageDialogService _dialogService;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        private async void ExecuteNavigateCommand()
        {
            //menambahkan parameter
            //var p = new NavigationParameters();
            var nama = "Erick Kurniawan";
            var alamat = "Jogja";
            var p = new NavigationParameters($"nama={nama}&alamat={alamat}");
            p.Add("title", "Hello from MainPage");
            await NavigationService.NavigateAsync("DetailRestaurantPage", p);
        }

        public Task<bool> CanNavigateAsync(INavigationParameters parameters)
        {
            return _dialogService.DisplayAlertAsync("My Title", "Save?", 
                "Accept", "Cancel");
        }

        /*public bool CanNavigate(INavigationParameters parameters)
        {
            return false;
        }*/
    }
}
