﻿using Prism;
using Prism.Ioc;
using ContohPrism.ViewModels;
using ContohPrism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContohPrism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ContohPrism
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //await NavigationService.NavigateAsync("PrismMasterDetailPage/NavigationPage/CalculatorPage");
            //await NavigationService.NavigateAsync("PrismTabbedPage");
            await NavigationService.NavigateAsync("NavigationPage/ListRestaurantPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutPageViewModel>();
            containerRegistry.RegisterForNavigation<SampleDelegateCommandPage, SampleDelegateCommandPageViewModel>();
            containerRegistry.RegisterForNavigation<CalculatorPage, CalculatorPageViewModel>();
            containerRegistry.RegisterForNavigation<ListArtikelPage, ListArtikelPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismMasterDetailPage, PrismMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<PrismTabbedPage, PrismTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<ListRestaurantPage, ListRestaurantPageViewModel>();
            containerRegistry.RegisterForNavigation<DetailRestaurantPage, DetailRestaurantPageViewModel>();

            //daftarkan Services
            containerRegistry.RegisterInstance<IRestaurant>(new RestaurantServices());
            containerRegistry.RegisterForNavigation<AddRestaurantPage, AddRestaurantPageViewModel>();
        }
    }
}
