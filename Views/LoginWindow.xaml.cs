using System.Windows;

namespace FlytekStore_MVVM.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Entrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            // Si el usuario no escribe nada, usamos un texto genérico
            if (string.IsNullOrEmpty(nombre))
            {
                nombre = "usuario";
            }

            // Mostramos mensaje de bienvenida
            MessageBox.Show($"¡Bienvenido, {nombre}! 👋", "Flytek Store",
                            MessageBoxButton.OK, MessageBoxImage.Information);

            // Abre la ventana principal
            MainWindow main = new MainWindow();
            main.Show();

            // Cierra el login
            this.Close();
        }
    }
}

