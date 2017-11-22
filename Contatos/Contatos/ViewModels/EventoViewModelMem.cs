using Contatos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.ViewModels
{
    public class EventoViewModelMem
    {
        public ObservableCollection<Evento> Lista { get; set; }

        public EventoViewModelMem()
        {
            Lista = new ObservableCollection<Evento>();
        }

        public void Salvar(Evento item)
        {
            // Se o Id for 0, então é um novo registro
            if (item.Id == 0)
            {
                item.Id = DateTime.Now.Minute + DateTime.Now.Day;
                Lista.Add(item);
            }
            else
            {
                // Localizar o item existente
                var existente = Lista.Where(r => r.Id == item.Id)
                    .FirstOrDefault();

                
            }
        }
    }
}