using FlytekStore_MVVM.Data;
using FlytekStore_MVVM.Models;
using System;
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
            string nombre = txtNombre.Text;
            string clave = txtClave.Password;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(clave))
            {
                MessageBox.Show("Completa ambos campos para continuar.");
                return;
            }

            // Guardar en la base de datos (ficticio pero funcional)
            GestorBD gestor = new GestorBD();
            Usuario u = new Usuario
            {
                Nombre = nombre,
                Apellidos = "",
                Email = $"{nombre.ToLower()}@flytek.com",
                Contrasena = clave,
                Rol = "Cliente"
            };

            gestor.InsertarUsuario(u);

            MessageBox.Show($"Bienvenido, {nombre}. Tu sesión se ha guardado.");

            new MainWindow().Show();
            Close();
        }
    }
}

