# IRentBook
Esta aplicación se deasrrollo inicialmente en C#, en el framework de .net core 3.1, en donde se implementan seis patrones de diseños para el funcionamiento de este aplicación.

## ¿En qué consiste?
La finalidad con la que se desarrollo está aplicación es reducir tiempos de desplazamientos hacia bibliotecas, ya que permite realizar un presta de un libro o un medio audiovisual de manera virtual, para garantizar el prestamo, y eventualmete retirarlo.

## Funcionamiento
Los patrones implementados fuerion los siguentes:
- Singleton, para realizar la conexión a la base de datos.
- Fachada, se implemento para crear las clases y metodos con los cuales se puede añadir un usuario, eliminar un usuario, editar un usuario y listar los usuarios.
- Proxy, se uso en libros, peliculas, prestamos, empleados y generos para hacer las mismas funcionalidades de agregar, editar, modificar y listar los elementos anteriormente mencionados.
- Cadena de responsabilidad, para verificar identificar el tipo de rol del loggeo, es decir, si es usuario o empleado.
- Comando, para controlar acciones de administrar inventarios desde el controlador.
- Metodo fabrica, para controlar la creación de objetos.
- Iterador, para recorrer lista de objetos.

### Equipo de desarrollo
- Juan David Roserro Torres
- Yeimer Serrano Navarro
- Santiago Andres Gordillo Piñerso
