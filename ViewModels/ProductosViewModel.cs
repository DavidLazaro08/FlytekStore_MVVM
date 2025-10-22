using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using FlytekStore_MVVM.Models;

namespace FlytekStore_MVVM.ViewModels
{
    public class ProductosViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Producto> _listaProductos;
        public ObservableCollection<Producto> ListaProductos
        {
            get { return _listaProductos; }
            set
            {
                _listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }

        // Copia interna de todos los productos (sin filtrar)
        private ObservableCollection<Producto> TodosLosProductos { get; set; }

        public ProductosViewModel()
        {
            TodosLosProductos = new ObservableCollection<Producto>
            {
                new Producto { Id = 2, Nombre = "Reloj inteligente",  Categoria = "Wearables", Precio = 129.00m, Stock = 10, Imagen = "pack://application:,,,/Resources/RELOJ.png",  Descripcion = "Smartwatch con control de ritmo cardíaco." },
                new Producto { Id = 3, Nombre = "Cascos inalámbricos",Categoria = "Audio",     Precio = 89.00m,  Stock = 8,  Imagen = "pack://application:,,,/Resources/CASCOS.png", Descripcion = "Auriculares con cancelación de ruido." },
                new Producto { Id = 4, Nombre = "Gafas VR",           Categoria = "Realidad Virtual", Precio = 159.00m, Stock = 6, Imagen = "pack://application:,,,/Resources/GAFAS.png",  Descripcion = "Gafas de realidad virtual con sensor de movimiento." },
                new Producto { Id = 5, Nombre = "Altavoz portátil",   Categoria = "Audio", Precio = 49.00m, Stock = 12, Imagen = "pack://application:,,,/Resources/ALTAVOZ.png", Descripcion = "Altavoz inalámbrico con Bluetooth." }
            };

            // Inicialmente mostramos todos
            ListaProductos = new ObservableCollection<Producto>(TodosLosProductos);
        }

        // Método que filtra usando LINQ
        public void Filtrar(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
            {
                ListaProductos = new ObservableCollection<Producto>(TodosLosProductos);
            }
            else
            {
                var filtrados = TodosLosProductos
                    .Where(p => p.Nombre.ToLower().Contains(termino.ToLower()))
                    .ToList();

                ListaProductos = new ObservableCollection<Producto>(filtrados);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




