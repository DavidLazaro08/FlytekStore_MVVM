using FlytekStore_MVVM.Data;
using FlytekStore_MVVM.Models;
using FlytekStore_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace FlytekStore_MVVM.Views
{
    public partial class MainWindow : Window
    {
        // Carrito sencillo (solo nombres de productos por ahora)
        private List<string> carrito = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

            // Cargamos el ViewModel para que la vista se alimente de sus datos
            DataContext = new ProductosViewModel();
        }

        // Evento que se lanza al pulsar "Añadir al carrito"
        private void AgregarProductoDesdeLista_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string nombreProducto = null;

                // Si viene desde el ItemsControl (tiene DataContext = Producto)
                if (btn.DataContext is Producto p)
                {
                    nombreProducto = p.Nombre;
                }
                // Si es el botón del dron (usa Tag)
                else if (btn.Tag is string tag)
                {
                    nombreProducto = tag;
                }

                if (!string.IsNullOrEmpty(nombreProducto))
                {
                    carrito.Add(nombreProducto);
                    MessageBox.Show($"{nombreProducto} añadido al carrito.");
                }
            }
        }


        // Muestra el contenido del carrito en un MessageBox
        private void AbrirCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            string contenido = string.Join("\n", carrito);
            MessageBox.Show("Productos en el carrito:\n" + contenido);

            // Guardar en base de datos
            GestorBD gestor = new GestorBD();
            gestor.RegistrarCompra(carrito);
            MessageBox.Show("Compra registrada en la base de datos.");
        }
        // Botón AcercaDe funcional
                private void AbrirAcercaDe_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        // Buscador con LINQ: filtra los productos según el texto introducido
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as FlytekStore_MVVM.ViewModels.ProductosViewModel;
            if (vm != null)
            {
                vm.Filtrar(txtBuscador.Text);
            }
        }
    }
}

