# CalculatorService

Implemente un 'Servicio de calculadora' basado en HTTP / REST capaz de realizar algunas operaciones aritméticas básicas, como sumar, restar, cuadrar, etc. junto con un historial

## Empezar

El proyecto esta basado en los principios SOLID y esta conformado con dos proyectos principales el CalculatorService.Server y CalculatorService.Client

### Prerrequisitos

Qué cosas necesita para ejeuctar el software


* NET core 2.2
* visual studio community 2017


## Capas

A continuación se detallan las capas

### CalculatorService.Server

el componente principal de la aplicación y es el queimplementa el 'servicio de calculadora' HTTP / REST



### CalculatorService.Data

componente de persitencia de datos

### CalculatorService.Model

Componentes de Modelos


### CalculatorService.Service

Componete de servicios


### CalculatorService.Test

Pruebas Unitarias, basadas en Moq


### CalculatorService.Client

una consola de demostración / cliente de línea de comandos, capaz de realizar solicitudes al servicio HTTP 


## Ejecuar

Para ejecutar la aplicacion se deben ejecutar los siguientes pasos:
* abrir la solucion CalculatorService.sln
* compilar la solución CalculatorService.sln
* ejecutar la solución CalculatorService.sln
* abrir la solución CalculatorService.Client.sln
* compilar la solcion CalculatorService.Client.sln
* ejecutar la solcion CalculatorService.Client.sln

