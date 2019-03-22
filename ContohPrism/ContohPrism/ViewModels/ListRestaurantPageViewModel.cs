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
	public class ListRestaurantPageViewModel : ViewModelBase
	{
        //private RestaurantServices _restoServices;
        private IPageDialogService _dialogService;
        private IRestaurant _restoService;

        public ListRestaurantPageViewModel(INavigationService navigationService, 
            IPageDialogService dialogService,IRestaurant restoService)
            : base(navigationService)
        {
            Title = "List Restaurant";
            //_restoServices = new RestaurantServices();
            _dialogService = dialogService;
            _restoService = restoService;
        }

        private List<Restaurant> restaurants;
        public List<Restaurant> Restaurants
        {
            get { return restaurants; }
            set { SetProperty(ref restaurants, value); }
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
           
            Restaurants = await _restoService.GetAllRestaurant();
        }

        public Restaurant ItemSelected { get; set; }

        //ketika item pada List dipilih
        public DelegateCommand<Restaurant> _itemTappedCommand;
        public DelegateCommand<Restaurant> ItemTappedCommand =>
            _itemTappedCommand ?? (_itemTappedCommand = new DelegateCommand<Restaurant>(ExecuteTtemTappedCommand));



        private async void ExecuteTtemTappedCommand(Restaurant obj)
        {
            //ItemSelected = obj;
            var par = new NavigationParameters();
            par.Add("model", obj);
            await NavigationService.NavigateAsync("DetailRestaurantPage", par);

            //_dialogService.DisplayAlertAsync("Keterangan", $"Judul: {obj.namarestaurant}", "OK");
        }

        //untuk tombol nav add
        private DelegateCommand _navAddCommand;
        public DelegateCommand NavAddCommand =>
            _navAddCommand ?? (_navAddCommand = new DelegateCommand(ExecuteNavAddCommand));

        private async void ExecuteNavAddCommand()
        {
            await NavigationService.NavigateAsync("AddRestaurantPage");
        }
    }
}
