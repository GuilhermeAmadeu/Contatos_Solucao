using Contatos.iOS;
using System;
using System.IO;
using Xamarin.Forms;


namespace Contatos.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            //OBTER A PASTA PESSOAL
            var personalfolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            //CONCATENAR A PASTA LIBRARY
            var folder = Path.Combine(personalfolder, "..", "Library");

            //VERIFICAR SE A PASTA EXISTE
            if (!Directory.Exists(folder))
            {
                //CRIAR A PASTA 
                Directory.CreateDirectory(folder);

            }

            //RETORNAR O CAMINHO DO ARQUIVO
            return Path.Combine(folder, fileName);
        }
    }
}