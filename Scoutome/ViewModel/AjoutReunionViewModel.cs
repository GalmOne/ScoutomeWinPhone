using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using Scoutome.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using Scoutome.DAO;

namespace Scoutome.ViewModel
{
    public class AjoutReunionViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private INavigationService _navigationService;
        private ICommand _ajoutReunionCommand;
        private ICommand _backCommand;
        private Reunion reunion;
        private String mylieu = "Moustier";
        private String mylibelle = "Réunion du " + DateTime.Now.ToString("dd/MM/yyyy");
        private double myprix = 1;
        private String myDate = DateTime.Now.ToString("dd/MM/yyyy");
        private ObservableCollection<Anime> myAnimeListView = new ObservableCollection<Anime>();
        private ObservableCollection<Anime> selectedAnime = new ObservableCollection<Anime>();
        //private ListView selectedAnime = new ListView();
        private DataAccessObject data = new DataAccessObject();



        [PreferredConstructor]
        public AjoutReunionViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            reunion = new Reunion();
            Anime anime = new Anime();

            
            myAnimeListView = data.getChildrenList();
        }

        public String Mylibelle
        {
            get { return mylibelle; }
            set { mylibelle = value; }

            //set { RaisePropertyChanged("Mylibelle"); mylibelle = value; }
        }
        public String MyDate
        {
            get { return myDate; }
            set { myDate = value; }
            
        }
        
        public String Mylieu
        {
            get { return mylieu; }
            set { mylieu = value; }
        }
        public double Myprix
        {
            get { return myprix; }
            set { myprix = value; }
        }
        public ObservableCollection<Anime> MyAnimeListView
        {
            get { return myAnimeListView; }
            set { myAnimeListView = value; }
        }
        public ObservableCollection<Anime> SelectedAnime
        {
            get { return selectedAnime; }
           /* set { selectedAnime = value;
                  RaisePropertyChanged("SelectedAnime");
                }*/
            set
            {
                NotifyPropertyChanged(ref this.selectedAnime, value);
            }
        }
        private bool NotifyPropertyChanged<T>(ref T variable, T valeur, string propertyName = null)
        {
            if (object.Equals(variable, valeur)) return false;
            variable = valeur;
            RaisePropertyChanged("SelectedAnime");
            return true;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO
        }

        // Ajout Réunion 
        public ICommand AjoutReunionCommand
        {
            get
            {
                if (_ajoutReunionCommand == null)
                {
                    _ajoutReunionCommand = new RelayCommand(() => ajouterReunion());
                }
                return _ajoutReunionCommand;
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                {
                    _backCommand = new RelayCommand(() => retourMainPage());
                }
                return _backCommand;
            }
        }

        public void retourMainPage()
        {
            _navigationService.NavigateTo("MainPage");
        }

        public void ajouterReunion()
        {
            Debug.WriteLine(selectedAnime.Count());
            createReunionObject();

            TrtSelectedItems();
            
            //data.addReunion(reunion, selectedAnime);
            
            _navigationService.NavigateTo("MainPage");
            // Code à faire quand je clique sur le boutton
        }

        public void createReunionObject()
        {
            DateTime date = DateTime.Now;
            reunion.codeReunion = date.Year * 10000 + date.Month * 100 + date.Day + date.Hour * 60 + date.Minute;
            reunion.dateReunion = date.ToString("dd/MM/yyyy");
            reunion.libelle = mylibelle;
            reunion.lieu = mylieu;
            reunion.prix = myprix;
        }
       
        public void TrtSelectedItems()
        {
            for (int i = 0; i < 3; i++)
            {
                selectedAnime.Add(myAnimeListView[i]);
            }

        }

        


    }
}
