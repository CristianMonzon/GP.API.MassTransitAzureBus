# 🛰️ Prototipo de Comunicación entre Microservicios con MassTransit y Azure Service Bus

Este repositorio contiene un prototipo funcional que demuestra la comunicación asincrónica entre dos microservicios utilizando **MassTransit** como biblioteca de mensajería y **Azure Service Bus** como broker de mensajes.

## 🧩 Microservicios

- 'GP.API.Ship'
  Encargado de emitir eventos relacionados con el envío de datos o acciones específicas. Actúa como **productor** de mensajes.
- 'GP.API.Tower'
  Escucha y consume los mensajes enviados por `GP.API.Ship`. Actúa como **consumidor** de mensajes.

## 🔄 Comunicación

Los microservicios se comunican mediante el patrón **publish/subscribe**, donde:

- `GP.API.Ship` publica eventos a un topic en Azure Service Bus.
- `GP.API.Tower` se suscribe a ese topic y procesa los mensajes recibidos.

La infraestructura de mensajería está orquestada con **MassTransit**, lo que permite una integración sencilla y robusta con Azure Service Bus.

## 🚀 Tecnologías Utilizadas

- .NET 8
- [MassTransit](https://masstransit.io/)
- Azure Service Bus

## 🛠️ Cómo Ejecutar

1. Configura la cadena de conexión a tu Azure Service Bus.
2. Ejecuta ambos microservicios (`GP.API.Ship` y `GP.API.Tower`) desde tu entorno de desarrollo.
3. Observa cómo los mensajes fluyen entre los servicios a través de Azure Service Bus.

## 📂 Estructura del Repositorio

/GP.API.Ship     # Microservicio emisor
/GP.API.Tower    # Microservicio receptor
/README.md       # Este archivo
/GP.LIB.Messages # Libreria de mensajería

## 📌 Objetivo

Este prototipo sirve como base para arquitecturas orientadas a eventos, facilitando la escalabilidad, desacoplamiento y resiliencia en sistemas distribuidos.
