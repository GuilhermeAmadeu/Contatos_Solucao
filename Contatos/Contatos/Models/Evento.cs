using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contatos.Models
{
    public class Evento : INotifyPropertyChanged
    {
        private int id;
        public string nome;
        public string local;
        public DateTime data;
        public TimeSpan horainicio;
        public TimeSpan horatermino;
        public string anotacoes;
        public string status;

        

        public int Id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        // Método para registrar a alteração da propriedade
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // Disparar o evento
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}