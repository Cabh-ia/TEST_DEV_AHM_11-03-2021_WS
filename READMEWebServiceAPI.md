# TEST_DEV_AHM_11-03-2021_WS
Back end de MVC CRUD (API)

En este desarrollo se puede encontrar todo el foncionamiento en Back end de un CRUD de persona física en la cual se pueden realizar los siguentes puntos
1.-Registro de personas físicas a la base de datos (POST)
2.-Edición de los registros previamente insertados (PUT)
3.-Consulta de los registros (GET)
4.Eliminación de los registros(DELETE)
Estos procesos se realizan por medio de una API la cual trabaja con un controlador el cual manda a llamar las distintas tareas y tablas a las que está conectado.
También podemos encontrar un controlador el cual nos permite ingresar un correo y una contraseña para después generarnos un JWT por medio de una acción POST
el cual nos regresa un token con autenticación Bearer para poder tener mayor seguridad en nuestro desarrollo.

PUNTOS A CONSIDERAR:
La API está conectada directamente con la aplicación de Blazor (BlazorCrud) por medio de una dirección base de localhost por lo cual es necesario tener corriendo el API
para poder ejecutar la aplicación y poder interactuar con ella.
