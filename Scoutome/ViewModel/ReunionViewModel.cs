using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Scoutome.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Scoutome.DAO;

namespace Scoutome.ViewModel
{
    public class ReunionViewModel : ViewModelBase, INotifyPropertyChanged
    {

        private ObservableCollection<Reunion> _reunions;
        private Reunion _selectedReunion;
        private INavigationService _navigationService;
        private ICommand _infoReunionCommand;
        private ICommand _backCommand;
        private DataAccessObject data = new DataAccessObject();


        [PreferredConstructor]
        public ReunionViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;

            _reunions = data.getReunionList();
        }

        public ObservableCollection<Reunion> Reunions
        {
            get
            {
                return _reunions;
            }

            set
            {
                _reunions = value;
                //RaisePropertyChanged("Reunions");
            }
        }
        public Reunion SelectedReunion
        {
            get
            {
                return _selectedReunion;
            }

            set
            {
                _selectedReunion = value;
                RaisePropertyChanged("SelectedReunion");
            }
        }
       
        public void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
        
        public ICommand InfoReunionCommand
        {
            get
            {
                if (this._infoReunionCommand == null)
                {
                    this._infoReunionCommand = new RelayCommand(() => InformationsReunion());
                }
                return this._infoReunionCommand;
            }
        }

        private void InformationsReunion()
        {
            //Faut mettre une condition pour pas que ça plante
            Reunion reuTest = new Reunion();
            reuTest.prix = 6;
            reuTest.lieu = "Moustier";
            reuTest.libelle = "ReuTEst";
            _navigationService.NavigateTo("InformationsReunionPage", reuTest);
            //_navigationService.NavigateTo("InformationsReunionPage");
        }

        public ICommand BackCommand
        {
            get
            {
                if (this._backCommand == null)
                {
                    this._backCommand = new RelayCommand(() => backToMain());
                }
                return this._backCommand;
            }
        }

        private void backToMain ()
        {
            _navigationService.NavigateTo("MainPage");
        }

        


        






    }
}
