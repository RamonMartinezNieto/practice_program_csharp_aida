# Stock Broker client

A kata to practice TDD with test doubles.

The Big Picture
The goal of this kata is to implement a stock broker client that can be used to place orders to an online stock broker service.

The entry point of the stock broker client is:

void PlaceOrders(string orderSequence);

The stock broker client will:

receive a sequence or orders through its entry point.

parse the orders and tell the stock broker online service to execute the order (you should assume that the stock broker online service connects to the real stock exchange, and that any placed order will be executed). The stock broker online service may fail.

it will print on the console a summary of all the orders in the received orders sequence that will tell the user how much money was spent on buying and selling the stocks and the date the orders where placed. Have a look at the examples below.

When the stock broker client receives an order such as, "GOOG 300 829.08 B", and placing the order succeeds, on 12/20/2023 1:45 AM the following order summary will be printed on the console:

12/20/2023 1:45 AM Buy: € 248724.00, Sell: € 0.00

presenting the total amount of money spent and earned. (248724.00 = 300 * 829.08) (assuming the order was executed correctly by the stock broker online service).

Orders sequence format.
A regular order for a stock is represented by a string like the following:

"GOOG 300 829.08 B"

Each order is composed of the following four parts:

A ticker symbol, such as GOOG
A quantity, such as 300
A price in €, such as 829.08
The type of order: Buy (B) or Sell (S)
A client could also place an order covering multiple stocks.

A multi-order is a coma-separated list of regular orders:

"ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S"
Examples
Example 1:
For a single, correctly executed order we'd have:

input: "GOOG 300 829.08 B"

console output:

7/25/2008 3:45 PM € 248724.00, Sell: € 0.00

given it was placed at 7/25/2008 3:45 PM

Example 2:
for a multi-order:

input: "ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S"

console output:

6/15/2009 1:45 PM Buy: € 10603.00, Sell: € 43894.40

given it was placed at 6/15/2009 1:45 PM

Example 3:
If any of the orders could not be executed by the stock broker online service (because it failed), the summary should mention this as well.

For example, assuming the stock broker online service could not execute the GOOG order:

input: "GOOG 300 829.08 B"

console output:

6/15/2009 1:45 PM € 0.00, Sell: € 0.00, Failed: GOOG

given it was placed at 6/15/2009 1:45 PM

Example 4:
And if several orders on stocks failed (for example FB and ORCL), but other worked fine:

input: "ZNGA 1300 2.78 B,AAPL 50 139.78 B,FB 320 137.17 S,ORCL 1000 42.69 S"

console output:

6/15/2009 1:45 PM Buy: € 10603.00, Sell: € 00.40, Failed: FB, ORCL

given it was placed at 6/15/2009 1:45 PM

Example 5:
An empty order is not treated as an error and should produce the following summary:

input: ""

console output:

8/15/2019 2:45 PM Buy: € 0.00, Sell: € 0.00

given it was placed at 12/20/2023 1:45 AM

Hints
For the purpose of this exercise it's fine to assume that the input data provided by the user is always well-formed and correct.

For the purpose of this exercise it's fine to assume that all outputs will be in American English Culture, "en-US" (. is the decimal separator). Use thisDate.ToString("d", new CultureInfo("en-US"); to print the current date.

Design the interface of the stock broker service as you see fit.



## Notas: 

Las ordenes son "GOOG 300 829.08 B"  y los bloques se separan por " " (espacio)
STRING INT DECIMAL CHAR

### Asumptions: 
Las ordenes siempre estarán bien 
Cultura fecha harcoded thisDate.ToString("d", new CultureInfo("en-US")
Cultura decimal en-US 

### ¿Qué necesitamos? 

Parseador:
	Parsear una orden 
	Parsear múltiples ordenes (ojo)

Objeto de negocio que contenga la orden 
	Contendra los calculos 

Formateador para construir el mensaje 

Agregado con todas las ordenes 
	Tendra sumatorio de los cálculos 

Notifier (siempre hay un notifier jeje)

DateTimeProvider proveedor de fechas 

Exception personalizada para cuando falla el cliente 

### Ejemplos 

Interaz
StockBrokerService.PlaceOrders(string orderSequence)

Pedido vacio "" => 08/15/2019 14:45 Compra: 0,00 €, Venta: 0,00 €
	Nos obliga a tener el dateProvider 
	Nos obliga a tener el Notifier 
	Nos obliga a tener un Formateador de mensajes
	¿Nos obliga a tener ya el agregado? 

Un pedido que falla  "GOOG 300 829.08 B" => 6/15/2009 1:45 PM € 0.00, Sell: € 0.00, Failed: GOOG

Un solo pedido de compra "GOOG 300 829.08 B"
7/25/2008 3:45 PM € 248724.00, Sell: € 0.00

Un solo pedido de venta "FB 100 30 S"
7/11/2012 2:45 PM € 0.00, Sell: € 300.00

Dos pedidos de compra: "GOOG 1 30.00 B,FB 1 10.00 B"
1/22/2012 3:45 PM € 40.00, Sell: € 0.00

Dos pedidos de venta: "GOOG 1 30.00 S,FB 1 10.00 S"
1/22/2012 3:45 PM € 0.00, Sell: € 40.00

Un pedido de venta y otro de compra: "GOOG 1 30.00 B,FB 1 10.00 S"
1/22/2012 3:45 PM € 30.00, Sell: € 10.00


Un pedido de venta, otro de compra y el último que falla: "GOOG 1 30.00 B,FB 1 10.00 S,ORCL 1000 42.69 S"
1/22/2012 3:45 PM € 30.00, Sell: € 10.00, Failed: GOOG