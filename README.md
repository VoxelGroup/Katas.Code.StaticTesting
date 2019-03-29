## Implementación curiosa patrón singleton

El ingeniero Alberto tenia una visión curiosa del patrón singleton. Para optimizar el uso de memoria de los aplicativos decidió implementar todas las clases de lógica de negocio con el modificador "static". Si bien a dia de hoy puede funcionar correctamente, dicho hecho nos impide testar unitariamente dicha lógica de negocio teniendo un código de baja calidad.

## Carpetas Voxel.CodeKatas.StaticTesting



### DAL

Clases que contienen la lógica de acceso a la base de datos.

### BusinessLayer

Clases que contienen la lógica de negocio.

### Database

Clases  dummy que simulan los distintos objetos de la base de datos (conexión, comando, etc)

### Objects

Clases necesarias para la lógica de negocio.


## EXERCICIO

Se debería refactorizar el código en la medida de lo posible para poder testear unitariamente toda la lógina de negocio así como implementar los tests pertinentes.

