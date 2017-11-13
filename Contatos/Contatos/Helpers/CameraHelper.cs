using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Plugin.Media;

namespace Contatos.Helpers
{
    public static class CameraHelper
    {
        public static async Task<MediaFile> TirarFotoAsync(string nomeArquivo)
        {
            //Inicializa a camera do dispositivo
            await CrossMedia.Current.Initialize();
            //verificar se existe uma camera e esta preparada para tirar fotos
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.DialogoAlerta("Atenção", "Camera não suportada", "Fechar");
                return null;
            }

            //verifica se foi informado um nome para o arquivo
            if (string.IsNullOrWhiteSpace(nomeArquivo))
            {
                nomeArquivo = Guid.NewGuid().ToString();
                nomeArquivo += ".jpg";
            }
            //armazena a foto ao tirar
            var midia = new StoreCameraMediaOptions();
            //salva no album de foto do dispositivo
            midia.SaveToAlbum = true;
            midia.CompressionQuality = 60;
            midia.PhotoSize = PhotoSize.Medium;
            midia.Name = nomeArquivo;
            //retornar o arquivo
            var foto = await CrossMedia.Current.TakePhotoAsync(midia);
            return foto;
            
        }
    }
}
