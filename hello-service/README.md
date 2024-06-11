# Hello Kata

A kata to practice TDD with test doubles.

Your task is to implement a service, the HelloService, that will greet you through the console in a different way depending on the hour it gets called.

Entry point's interface: void hello();

Between 6 AM and 12 AM it will greet you with "Buenos días!".
After 12 AM and until 8 PM it will greet you with "Buenas tardes!".
The rest of the day it will greet you with "Buenas noches!"


Inputs indirectos hora 6AM 12AM 
Outputs Saludo

Dependencias Incomodas 
* DateTime 
* Console.WriteLine

Ejemplos: 

8AM => Buenos días! 
5AM => Buenas noches! 
7PM => Buenas tardes! 