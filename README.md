# 🛒 FlytekStore_MVVM

Aplicación **WPF** desarrollada con el patrón **MVVM (Model-View-ViewModel)** que simula una **tienda tecnológica**.  
El proyecto forma parte del módulo *Desarrollo de Interfaces* y está diseñado para demostrar el uso de **enlace de datos (Data Binding)**, **acceso a bases de datos con ADO.NET**, y una estructura limpia basada en capas.

---

## 🧩 Características principales

- **Arquitectura MVVM completa**
  - Separación clara entre *Modelos*, *Vistas* y *ViewModels*.
- **Base de datos SQL Server (FlytekDB)**
  - Gestión de productos, usuarios y pedidos.
  - Creación automática de tablas mediante script SQL incluido.
- **CRUD funcional**
  - Inserción, consulta, actualización y eliminación de usuarios.
- **Catálogo de productos dinámico**
  - Lista obtenida desde la base de datos.
  - Filtro de búsqueda mediante LINQ.
- **Carrito de compras**
  - Simula la compra de productos.
  - Registra las compras en la tabla `Pedidos`.
- **Login inicial (ficticio pero funcional)**
  - Pantalla de acceso visual que permite ingresar nombre y contraseña.
  - Los datos pueden guardarse en la tabla `Usuarios` como ejemplo de inserción.
- **Ventana “Acerca de”**
  - Información del desarrollador y contexto del proyecto.

---

## 🗂️ Estructura del proyecto

```plaintext
GutierrezDavid_WPF_P2/
├── Data/
│   └── GestorBD.cs             # Conexión y operaciones con SQL Server
├── Database/
│   └── FlytekDB_Setup.sql      # Script de creación de tablas
├── Models/
│   ├── Producto.cs             # Clase Producto
│   ├── Usuario.cs              # Clase Usuario
│   └── Categoria.cs            # Clase auxiliar
├── ViewModels/
│   └── ProductosViewModel.cs   # Lógica del catálogo y filtrado
├── Views/
│   ├── MainWindow.xaml         # Ventana principal
│   ├── LoginWindow.xaml        # Pantalla de inicio de sesión
│   └── AboutWindow.xaml        # Ventana de información
└── Resources/
    └── Imágenes y recursos visuales
```

## 📋 Requisitos

- **Visual Studio 2022**
- **.NET 8.0 o superior**
- **SQL Server Express / LocalDB**
- Acceso habilitado al servidor `SQLEXPRESS`

---

## ⚙️ Configuración de la base de datos

1. Abre **SQL Server Management Studio**.
2. Ejecuta el script `FlytekDB_Setup.sql` incluido en la carpeta `/Database/`.
3. Verifica que se haya creado la base de datos **FlytekDB** con las tablas:
   - `Productos`
   - `Usuarios`
   - `Pedidos`
4. Si es necesario, ajusta la cadena de conexión en `GestorBD.cs`:

   ```csharp
   private string cadenaConexion =
       @"Server=TU_SERVIDOR\SQLEXPRESS;Database=FlytekDB;Trusted_Connection=True;";


  ## 🧠 Conceptos aplicados

- Patrón **MVVM**
- **Data Binding** y notificación de cambios (`INotifyPropertyChanged`)
- **ADO.NET** (uso de `SqlConnection`, `SqlCommand`, `SqlDataReader`)
- **Colecciones observables** (`ObservableCollection`)
- **LINQ** para filtrado de datos
- Separación lógica y visual en capas

---

## 🎨 Extras visuales

- Interfaz moderna y limpia con colores neutros.  
- Íconos y recursos locales desde la carpeta `/Resources`.  
- Pantalla de **login** y **acerca de** con estilo visual coherente.

---

## 👤 Desarrollado por

**David Gutiérrez**  
*Ilerna Sevilla — Desarrollo de Aplicaciones Multiplataforma*  
*Módulo: Desarrollo de Interfaces*  
*Curso 2024/2025*

---

## 🧱 Licencia

Proyecto académico con fines educativos.  
Uso libre con fines didácticos o demostrativos.

