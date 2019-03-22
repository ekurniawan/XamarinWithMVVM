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
	public class DetailRestaurantPageViewModel : ViewModelBase
	{
        private IPageDialogService _dialogService;
        private IRestaurant _restoServices;
        public DetailRestaurantPageViewModel(INavigationService navigationService, 
            IPageDialogService dialogService,IRestaurant restoServices)
            : base(navigationService)
        {
            Title = "Detail Page";
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
            //var resto = parameters.GetValue<Restaurant>("model");
            ItemRestaurant = parameters.GetValue<Restaurant>("model");
        }

        //untuk tombol edit
        private DelegateCommand _editCommand;
        public DelegateCommand EditCommand =>
            _editCommand ?? (_editCommand = new DelegateCommand(ExecuteEditCommand));

        private async void ExecuteEditCommand()
        {
            try
            {
                await _restoServices.UpdateRestaurant(ItemRestaurant);
                await _dialogService.DisplayAlertAsync("Informasi", "Data Berhasil Diedit", "OK");
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Kesalahan", ex.Message, "OK");
            }
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand =>
            _deleteCommand ?? (_deleteCommand = new DelegateCommand(ExecuteDeleteCommand));

        private async void ExecuteDeleteCommand()
        {
            try
            {
                await _restoServices.DeleteRestaurant(ItemRestaurant.restaurantid);
                await _dialogService.DisplayAlertAsync("Informasi", "Data Berhasil Didelete", "OK");
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.DisplayAlertAsync("Kesalahan", ex.Message, "OK");
            }
        }
    }
}
