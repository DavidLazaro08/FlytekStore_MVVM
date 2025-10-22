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
            DataContext = this;


            // Cargamos el ViewModel para que la vista se alimente de sus datos
            DataContext = new ProductosViewModel();
        }

        // Evento que se lanza al pulsar "Añadir al carrito"
        private void AgregarProductoDesdeLista_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.DataContext is Producto p)
            {
                carrito.Add(p.Nombre);
                MessageBox.Show($"{p.Nombre} añadido al carrito.");
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

        public string MensajeEstado { get; set; } = $"Sesión iniciada: {DateTime.Now:g}";


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

