using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContohPrism.ViewModels
{
	public class CalculatorPageViewModel : ViewModelBase
	{
        public CalculatorPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Contoh Calculator";
        }

        private double _bilangan1;
        public double Bilangan1
        {
            get { return _bilangan1; }
            set { SetProperty(ref _bilangan1, value); }
        }

        private double _bilangan2;
        public double Bilangan2
        {
            get { return _bilangan2; }
            set { SetProperty(ref _bilangan2, value); }
        }

        private double _hasil;
        public double Hasil
        {
            get { return _hasil; }
            set { SetProperty(ref _hasil, value); }
        }


        private DelegateCommand _calculateCommand;
        public DelegateCommand CalculateCommand =>
            _calculateCommand ?? (_calculateCommand = new DelegateCommand(ExecuteCalculateCommand));

        private void ExecuteCalculateCommand()
        {
            Hasil = Bilangan1 + Bilangan2;
        }
    }
}
