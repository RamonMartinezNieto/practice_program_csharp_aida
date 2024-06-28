Inspiration of the day
================

Problem Description
-------------------

You are to write a service that, every time it gets executed, 
connects to a web service that returns a list of quotes 
containing a word chosen by a manager,
then it randomly selects one quote from the list
and sends it by WhatsApp to a random employee 
so that that employee gets inspired and motivated by the manager.

 
### Constraints

The entry point of the service only has this public method: `void InspireSomeone(string word);`


## Dependencias incomodas
	* Servicio de citas que devuelve una lista de citas que contiene una palabra seleccionada
	* Servicio de envio por WhatsApp 
	* Clase Random 

## In/Out
	* Input directo: palabra (que selecciona el manager, entra a través del entry point del contrato)
	
	* Tenemos posibles inputs directos e indirectos 

## Lista de ejemplos
	* Manager: pato
	* Lista 'pato uno', 'pato dos', 'pato tres'
	* Seleccion: 'pato uno'
	* Seleccion empleado: pepe
	* Se envía correo a pepe con pato uno