using ContohPrism.Models;
using ContohPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContohPrism.ViewModels
{
	public class AddRestaurantPageViewModel : ViewModelBase
	{
        private IPageDialogService _dialogService;
        private IRestaurant _restoServices;

        public AddRestaurantPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService, IRestaurant restoServices)
            : base(navigationService)
        {
            Title = "Add New Resto";
            _dialogService = dialogService;
            _restoServices = restoServices;
        }

        private Restaurant _itemRestaurant;
        public Restaurant ItemRestaurant
        {
            get { return _itemRestaurant; }
            set { SetProperty(ref _itemRestaurant, value); }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            ItemRestaurant = new Restaurant();
        }

        //untuk tombol add
        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand =>
            _addCommand ?? (_addCommand = new DelegateCommand(ExecuteAddCommand));

        private async void ExecuteAddCommand()
        {
            try
            {
                await _restoServices.InsertRestaurant(ItemRestaurant);
                await _dialogService.DisplayAlertAsync("Informasi", "Data Berhasil Ditambah", "OK");
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Kesalahan", ex.Message, "OK");
            }
        }
    }
}
