using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scoutome.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReunionViewModel>();
            SimpleIoc.Default.Register<InformationsReunionViewModel>();
            SimpleIoc.Default.Register<AjoutReunionViewModel>();


            NavigationService navigationService = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("ReunionPage", typeof(ReunionPage));
            navigationService.Configure("InformationsReunionPage", typeof(InformationsReunionPage));
            navigationService.Configure("AjoutReunion", typeof(AjoutReunion));
        }

        public MainViewModel MainPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        public ReunionViewModel ReunionPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReunionViewModel>();
            }
        }
        public InformationsReunionViewModel InformationsReunionPage
        {
            get
            {
                return ServiceLocator.Current.GetInstance<InformationsReunionViewModel>();
            }
        }
        public AjoutReunionViewModel AjoutReunion
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AjoutReunionViewModel>();
            }
        }


    }
}
