using Scoutome.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Scoutome
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ReunionPage : Page
    {
        public ReunionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // base.OnNavigatedTo(e);
            // recherche de la méthode programmée dans le viewmodel associé
            ((ReunionViewModel)DataContext).OnNavigatedTo(e);
        }

        //2eme navigation
        // ne sert à rien 
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            //base.OnNavigatedFrom(e);
            ((ReunionViewModel)DataContext).OnNavigatedTo(e);
        }
    }
}
