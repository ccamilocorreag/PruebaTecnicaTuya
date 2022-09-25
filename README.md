# PruebaTecnicaTuya
La siguiente es la prueba técnica para ingreso a Tuya

# Prueba Técnica Tuya
La siguiente es la prueba técnica para ingreso a Tuya

**1. Especificaciones Técnicas:**

* WebApi .Net 6
* Base de datos Sql Server Express
* Frameworks / Librerías

| Framework / Librería | Usado en: |
|--|--|
| Automapper | Usado para el mapeo y transformación de propiedades de un objeto en particular. |
| Fluent Validation | Usado para la validación de propiedades de objetos de entrada (modelos) en los controladores. También es usado para definir roles en los modelos de dominio. |
| EntityFrameworkCore | ORM usado para el control de acceso y la manipulación de la data sobre la aplicación. |
| ILogger | Usado para la escritura de trazas de información o error por consola. |
| Moq | Usado para la simulación del comportamiento de objetos en las pruebas unitarias.  |
| xUnit | Usado para la realización y ejecución de pruebas unitarias.  |
| Swagger| Usado para obtener y mostrar la documentación del API, permitiendo utilizar una interfaz gráfica para el testeo funcional a las operaciones del api  |

**2. Base de Datos**

La base de datos parte de la filosofía utilizada como Code First con EntityFrameworkCore que, a partir de la defición y configuración de clases se construye y manipula la base dedatos. Debe seguir los siguientes pasos:

1. Una vez clonado el proyecto y abierta la solución, abra La consola de Gestor de Paquetes (Package Manager Console).
2. Escribir en la consola update-database.
3. Esto creará la base de datos inicial. 
4. Este es el modelo:

![Modelo DB.png](Modelo%20DB.png)

5. La tabla Productos se construye con una información base:

| Id | Nombre | Descripcion | Precio | PorcentajeImpuesto |  
|--|--|--|--|--|
|  1| Tarjeta de Crédito Éxito | Tarjeta de crédito | 1000 | 19 |  
| 2 | Tarjeta de Crédito Carulla | Tarjeta de crédito | 4000 | 0 |  
| 3 | Tarjeta de Crédito Alkosto | Tarjeta de crédito | 3000 | 10 | 
|4  | Tarjeta de Crédito Claro | Tarjeta de crédito | 2000 | 10 | 

**3. Arquitectura**

La arquitectura es DDD (Domain Driven Design).

![Arquitectura DDD](Arquitectura%20DDD.png)

* **WebApi:** Tiene contenido los controladores que son como punto de entrada del API y configuración de servicios. 
* **Application:** Tiene contenido los servicios de aplicación que orquestará la lógica a la capa de dominio donde estarán reglas de negocio y repositorios de la base de datos. También estarán los Dtos (clases que controlan la entrada y salida de la información) así como también el perfil para el mapeo de propiedades y transformación de objetos. 
* **Domain:** Tiene contenido las entidades y toda la lógica de negocio. La lógica de negocios se realiza a traves de unos servicios de dominio.
* **Infraestructura:** Tiene contenido la immplementación de los repositorios usando el Patrón Repository y Unit of Work, permitiendo la gestión y comunicación de la información a la base de datos. Por otra parte, mediante su contexto y la filosofía Code First permite realizar la definición de la base de datos con sus tablas, campos y relaciones. 
* **Tests:** Tiene contenido las pruebas unitarias de la aplicación. 

**4. Funcionamiento**
* Ejecute la aplicación. Se abrirá la definición entregada por Swagger

![Swagger](Definici%C3%B3n%20Swagger.png)


##Módulo de Facturas

* Operación Post: /Facturacion 
* Crea una factura a partir de los datos de un cliente con sus respectivos productos seleccionados. 
* Debe contener la lista de productos y cantidades.
* La operación automáticamente calcula los subtotales por producto y el total de la factura, queda almacenada en la bd.
* Se hace control de los datos de entrada

Para consultar Facturas:
* **Operación Get:** /Facturacion/{id}
* Consulta la información básica de una factura.
* Si la factura no existe genera excepción

* **Operación Get:** /Facturacion/{id}/Complete
* Consulta la información completa de una factura incluyendo el cliente y el detalle. 
* Si la factura no existe genera excepción

##Módulo de Pedidos

* Operación Post: /Pedidos
* Crea un pedido de una factura previa. Es necesario conocer el identificador de la factura. 
* Si la factura no existe, genera excepción.
* Se hace control de los datos de entrada

Para consultar Facturas:
* **Operación Get:** /Pedido/{id}
* Consulta la información básica de un pedido.
* Si el pedido no existe genera excepción



