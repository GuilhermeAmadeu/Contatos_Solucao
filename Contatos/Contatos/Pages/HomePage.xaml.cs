using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contatos.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contatos.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            //Seta as paginas TabbedPage
            var tab1 = new EventoListaPage() { Title = "Eventos" , Icon = "ic_map.png" };
            var tab2 = new PessoaListaPage() { Title = "Pessoas" , Icon = "ic_phone.png" };
            this.Children.Add(tab1);
            this.Children.Add(tab2);
        }
    }
}