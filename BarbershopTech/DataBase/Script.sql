create table Usuarios(
UsuarioId int identity(1,1) primary key,
Nombres varchar(50),
Email varchar(70),
Contrasena varchar(25),
Confirmar varchar(25),
);

create table Clientes(
ClienteId int identity(1,1) primary key,
Nombres varchar(50),
Apellidos varchar(50),
Direccion varchar(50),
Cedula varchar(25),
Email varchar(255),
Fecha datetime,
Telefono varchar(12),
Celular varchar(12),
);

create table Peluqueros(
PeluqueroId int identity(1,1)primary key,
Nombre varchar(25),
HoraOcupadoHasta datetime,
);

create table Turnos(
TurnosId int identity(1,1) primary key,
ClienteId int,
PeluqueroId int,
ServicioId int,
NombrePeluquero varchar(50),
NombreCliente varchar(50),
NombreServicio varchar(25)
);

create table TipoServicios(
ServicioId int identity(1,1) primary key,
Nombre varchar(25),
Costo varchar(12)
);

create table Productos(
ProductoId int identity(1,1) primary key,
Nombre varchar(25),
Descripcion varchar(255),
PrecioCompra int,
PrecioVenta int,
Cantidad int,
);

create table Facturas(
FacturaId int identity(1,1) primary key,
NombreCliente varchar(50),
Descuento int,
DescuentoPorciento float,
Comentario varchar(255),
Impuesto int,
Fecha datetime,
TipoPago varchar(50),
ServicioId int,
Total float,
SubTotal float
);

create table FacturaServiciosDetalles(
FacturaServicioId int identity(1,1) primary key,
ServicioId int,
FacturaId int
);

create table FacturaProductos(
FacturaProductoId int identity(1,1) primary key,
ProductoId int,
FacturaId int
);
