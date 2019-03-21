using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContohPrism.ViewModels
{
	public class SampleDelegateCommandPageViewModel : ViewModelBase
	{
        public SampleDelegateCommandPageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "About Page";
            IsEnabled = false;
            IsEnableButton = false;
        }

        private bool _isEnabled;
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { SetProperty(ref _isEnabled, value); }
        }

        private bool _isEnableButton;
        public bool IsEnableButton
        {
            get { return _isEnableButton; }
            set { SetProperty(ref _isEnableButton, value); }
        }


        private string _updateText;
        public string UpdateText
        {
            get { return _updateText; }
            set { SetProperty(ref _updateText, value); }
        }


        private DelegateCommand _submitCommand;
        public DelegateCommand SubmitCommand =>
            _submitCommand ?? (_submitCommand = new DelegateCommand(ExecuteSubmitCommand,CanExecuteButton));

        private bool CanExecuteButton()
        {
            return IsEnableButton;
        }

        public DelegateCommand _toggleCommand;
        public DelegateCommand ToggleCommand =>
            _toggleCommand ?? (_toggleCommand = new DelegateCommand(ExecuteToggleCommand));

        private void ExecuteToggleCommand()
        {
            if (IsEnableButton)
                IsEnableButton = false;
            else
                IsEnableButton = true;
        }

        private void ExecuteSubmitCommand()
        {
            if (IsEnabled)
                IsEnabled = false;
            else
                IsEnabled = true;
        }
    }
}
