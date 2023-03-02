#Creado por Manuel Sampen Antonio
Tener en cuenta para el funcionamiento local de la Api desarrollada:
1. Clonar las fuentes a una ubicación local.
2. Ejecutar el archivo Nectia.sln en Visual Studio 2019.
3. Compilar la solución.  (Se descargará del nugget las extensiones usadas en la solución)
4. Presionar F5 para iniciar la Api. Aparecerá como página inicial la de swagger.
5. Para los crud de la entidad Customer y Users primero hay que generar el token de autorización:
  Url: http://localhost:49327/api/Users/Authenticate
  Body: {
    "userId": 0,
    "firstName": "string",
    "lastName": "string",
    "userName": "admin",
    "password": "Lima2020",
    "token": "string"
   }
 6. Se agregará el token JWT generado en el header de cada request enviado. 
 7. La sección 4 y 5 pueden realizarse con una herramienta como Postman o sino desde la misma página de swagger.
 8. Se usó como base de datos el AWS RDS para SQL Server. Las credenciales son:
     Host: test.c8xzq6cejscw.us-east-2.rds.amazonaws.com,1433
     Usuario: admin
     clave: Lima2023
     bd: Northwind
     tablas utilizadas: Customers, Users
