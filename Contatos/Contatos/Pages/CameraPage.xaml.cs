using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace Contatos.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
        private MediaFile arquivoMidia;

        public CameraPage ()
		{
			InitializeComponent ();
		}

        private void tprVoltar_Tapped(object sender, EventArgs e)
        {

        }

        private async void tprCamera_Tapped(object sender, EventArgs e)
        {
            //pega a foto tirada
            arquivoMidia = await Contatos.Helpers.CameraHelper.TirarFotoAsync("foto"); 
        }

        private void tprAlbum_Tapped(object sender, EventArgs e)
        {

        }

        private void tprTrocar_Tapped(object sender, EventArgs e)
        {

        }
        private void ExibirFoto()
        {
            //verifica se existe uma foto para exibicao
            if(arquivoMidia != null)
            {
                //armazena ocaminho onde esta a foto tirada
                //string caminho = arquivoMidia.Path;
                //var streamFoto = arquivoMidia.GetStream();
                //converte a foto armazenada na pasta em formato de memoria
                imgFoto.Source = ImageSource.FromStream(() =>
                {
                    var stream = arquivoMidia.GetStream();
                    return stream;
                });

                //imgFoto.Source = ImageSource.FromUri(caminhoFoto);
            }
        }

    }
}