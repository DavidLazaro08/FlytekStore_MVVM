using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlytekStore_MVVM.Views
{
    // Ventana principal (XAML + C#)
    public partial class MainWindow : Window
    {
        // Carrito sencillo en memoria
        private List<string> carrito = new List<string>();

        // Listado base para el buscador
        private List<string> productos = new List<string>
        {
            "DRON AVANZADO X20",
            "RELOJ AVANZADO",
            "CASCOS AVANZADOS",
            "GAFAS AVANZADAS",
            "ALTAVOZ AVANZADO"
        };

        public MainWindow()
        {
            InitializeComponent(); // carga lo del XAML
        }

        // Añadir al carrito (se usa el Tag del botón, como en clase)
        private void AgregarProducto_Click(object sender, RoutedEventArgs e)
        {
            Button boton = sender as Button;
            string producto = boton?.Tag?.ToString();

            if (!string.IsNullOrEmpty(producto))
            {
                carrito.Add(producto);
                MessageBox.Show(producto + " añadido al carrito.");
            }
        }

        // Ver carrito
        private void AbrirCarrito_Click(object sender, RoutedEventArgs e)
        {
            if (carrito.Count == 0)
            {
                MessageBox.Show("El carrito está vacío.");
                return;
            }

            string contenido = string.Join("\n", carrito);
            MessageBox.Show("Productos en el carrito:\n" + contenido);
        }

        // Buscar por nombre (coincidencia sencilla)
        private void Buscar_Click(object sender, RoutedEventArgs e)
        {
            string termino = txtBuscador.Text.ToLower().Trim();

            // Si no hay término, aviso normalito
            if (string.IsNullOrWhiteSpace(termino))
            {
                MessageBox.Show("Escribe algo para buscar.");
                return;
            }

            // Búsqueda sencilla (lo visto en colecciones/LINQ)
            var encontrados = productos
                .Where(p => p.ToLower().Contains(termino))
                .ToList();

            if (encontrados.Count == 0)
            {
                MessageBox.Show("No se encontraron productos.");
            }
            else
            {
                MessageBox.Show("Resultados:\n" + string.Join("\n", encontrados));
            }
        }
    }
}
