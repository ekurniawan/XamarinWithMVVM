using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContohPrism.ViewModels
{
	public class AboutPageViewModel : ViewModelBase
	{
        public AboutPageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "About Page";
            Deskripsi = "Ini adalah halaman About pada Aplikasi Coba Prism";
        }

        private string _deskripsi;

        public string Deskripsi
        {
            get { return _deskripsi; }
            set { SetProperty(ref _deskripsi, value); }
        }

        private DelegateCommand _navigateCommand;
        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        private async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("MainPage");
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Deskripsi = parameters.GetValue<string>("title") + " Nama: "+
                parameters.GetValue<string>("nama") + " Alamat: "+
                parameters.GetValue<string>("alamat");
        }
    }
}
