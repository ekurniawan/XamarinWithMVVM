using ContohPrism.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContohPrism.ViewModels
{
    public class ListArtikelPageViewModel : ViewModelBase
    {
        public ListArtikelPageViewModel(INavigationService navigationService,IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            _listArtikel = new List<Artikel>
            {
                new Artikel{ArtikelID=1,Judul="Pemrograman CSharp",Deskripsi="Deskripsi Buku Pemrograman CSharp"},
                new Artikel{ArtikelID=2,Judul="ASP.NET Core 2.1",Deskripsi="Deskripsi Buku Pemrogaman ASP.NET Core 2.1"},
                new Artikel{ArtikelID=3,Judul="Xamarin Forms",Deskripsi="Deskripsi Buku Xamarin Forms"}
            };
            _dialogService = dialogService;
        }

        private List<Artikel> _listArtikel;
        private IPageDialogService _dialogService;

        public List<Artikel> ListArtikel
        {
            get { return _listArtikel; }
            set { SetProperty(ref _listArtikel, value); }
        }

        public Artikel ItemSelected { get; set; }

        public DelegateCommand<Artikel> _itemTappedCommand;
        public DelegateCommand<Artikel> ItemTappedCommand =>
            _itemTappedCommand ?? (_itemTappedCommand = new DelegateCommand<Artikel>(ExecuteTtemTappedCommand));

        private void ExecuteTtemTappedCommand(Artikel obj)
        {
            ItemSelected = obj;
            _dialogService.DisplayAlertAsync("Keterangan", $"Judul: {obj.Judul}", "OK");
        }
    }
}
