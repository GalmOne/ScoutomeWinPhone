using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Scoutome.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;

namespace Scoutome.ViewModel
{
    public class InformationsReunionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private Reunion _selectedReunion = new Reunion();
        private Reunion reunion = new Reunion();
        private INavigationService _navigationService;
        private ICommand _backCommand;
        private string _libelle;
        private string _date;
        private double _prix;
        private string _lieu;


        [PreferredConstructor]
        public InformationsReunionViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        public string Libelle
        {
            get { return _libelle; }
            set { _libelle = SelectedReunion.libelle; }
        }
        public string Date
        {
            get { return _date; }
            set { _date = SelectedReunion.dateReunion; }
        }
        public string Lieu
        {
            get { return _lieu; }
            set { _lieu = SelectedReunion.lieu; }
        }
        public double Prix
        {
            get { return _prix; }
            set { _prix = SelectedReunion.prix; }
        }

        public ICommand BackCommand
        {
            get
            {
                if (this._backCommand == null)
                {
                    this._backCommand = new RelayCommand(() => backToReunion());
                }
                return this._backCommand;
            }
        }

        private void backToReunion()
        {
            
            _navigationService.NavigateTo("ReunionPage");
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
            _selectedReunion = (Reunion)e.Parameter;
            
        }
    }
}
