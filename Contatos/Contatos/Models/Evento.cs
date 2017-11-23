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
        private string nome;
        private string local;
        private DateTime data;
        private TimeSpan horainicio;
        private TimeSpan horatermino;
        private string anotacoes;
        private string status;

        

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
        

        public string Nome
        {
            get
            {
                return Nome;
            }
            set
            {
                Nome = value;
                OnPropertyChanged();
            }
        }
                                

        public string Local
        {
            get
            {
                return Local;
            }
            set
            {
                Local = value;
                OnPropertyChanged();
            }
        }
        

        public DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }
        
        public TimeSpan HoraInicio
        {
            get
            {
                return horainicio;
            }
            set
            {
                horainicio = value;
                OnPropertyChanged();
            }
        }
        
        public TimeSpan HoraTermino
        {
            get
            {
                return horatermino;
            }
            set
            {
                horatermino = value;
                OnPropertyChanged();
            }
        }
        
        public string Anotacoes
        {
            get
            {
                return anotacoes;
            }
            set
            {
                anotacoes = value;
                OnPropertyChanged();
            }
        }
        
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
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