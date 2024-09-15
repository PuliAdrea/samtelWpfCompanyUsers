# Samtel.WPF.CompanyUsers

## Descripción

Samtel.WPF.CompanyUsers es una prueba técnica para Samtel que demuestra la creación de una aplicación utilizando .NET Framework 4.8, MS SQL y WPF. 

El proyecto está diseñado para gestionar usuarios y departamentos en una empresa. Contiene dos vistas principales:
1. **Vista de Usuarios**: Muestra un listado de usuarios, y permite crear y editar la información de contacto de los usuarios.
2. **Vista de Departamentos**: Permite asignar un departamento a cada usuario.

## Instalación

Para instalar y configurar el proyecto, sigue los siguientes pasos:

1. **Ejecutar Scripts SQL**: Primero, asegúrate de ejecutar los scripts que se encuentran en la carpeta `scripts`:
   
   - **Crear la base de datos e insertar datos**:
     1. Ejecuta el script `creacion_db_y_insert_data_samtel.sql` siguiendo los pasos indicados dentro del script.
   
   - **Crear Procedimientos Almacenados**:
     1. Ejecuta el script `CrearProcedimientosAlmacenados.sql`.

2. **Abrir y Ejecutar la Solución**:
   - Abre el proyecto en Visual Studio y ejecuta la solución. Asegúrate de que la conexión a la base de datos esté configurada correctamente en el archivo de configuración de la aplicación.

Con estos pasos, deberías tener la solución funcionando correctamente.

## Requisitos

- .NET Framework 4.8
- MS SQL Server
- Visual Studio

## Contacto

Para cualquier duda o consulta, puedes contactar a [tu nombre o contacto aquí].