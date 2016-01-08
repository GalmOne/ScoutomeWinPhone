using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Scoutome.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace Scoutome.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private INavigationService _navigationService;
        private ICommand _editReunionCommand;
        private ICommand _nouvelleReunionCommand;

        public MainViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        public void OnNavigateTo(NavigationEventArgs e)
        {
            //TODO
        }



        public ICommand EditReunionCommand
        {
            get
            {
                if (this._editReunionCommand == null)
                {
                    this._editReunionCommand = new RelayCommand(() => EditReunion());
                }
                return this._editReunionCommand;
            }
        }

        private void EditReunion()
        {
            _navigationService.NavigateTo("ReunionPage");
        }

        public ICommand NouvelleReunionCommand
        {
            get
            {
                if (this._nouvelleReunionCommand == null)
                {
                    this._nouvelleReunionCommand = new RelayCommand(() => nouvelleReunion());
                }
                return this._nouvelleReunionCommand;
            }
        }

        private void nouvelleReunion()
        {
            _navigationService.NavigateTo("AjoutReunion");
        }
    }
}
