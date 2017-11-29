﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Contatos.Models
{
    public class Pessoa : INotifyPropertyChanged
    {
        // Declarar os campos internos
        private Guid id;
        private string nome;
        private string email;
        private string telefone;
        private string observacao;

        // Declarar as propriedades
        public Guid Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
                // Informar a alteração na propriedade
                OnPropertyChanged();
            }
        }

        public string Email {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string Telefone {
            get
            {
                return telefone;
            }
            set
            {
                telefone = value;
                OnPropertyChanged();
            }
        }

        public string Observacao {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
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
