## Implementación curiosa patrón singleton

El ingeniero Alberto tenia una visión curiosa del patrón singleton. Para optimizar el uso de memoria de los aplicativos decidió implementar todas las clases de lógica de negocio con el modificador "static". Si bien a dia de hoy puede funcionar correctamente, dicho hecho nos impide testar unitariamente dicha lógica de negocio teniendo un código de baja calidad.

## Carpetas Katas.Code.StaticTesting



### DAL

Clases que contienen la lógica de acceso a la base de datos.

### BusinessLayer

Clases que contienen la lógica de negocio.

### Database

Clases dummy que simulan los distintos objetos de la base de datos (conexión, comando, etc)

### Objects

Clases necesarias para la lógica de negocio.


## EXERCICIO

Se debería refactorizar el código utilizando principios SOLID para poder testear unitariamente toda la lógina de negocio así como implementar los tests pertinentes.

## ¿Como entregar la solución?
- Puedes de descargar/clonar la solución, implementarla offline y al finalizar, enviarla por email en un zip a people@voxelgroup.net.
