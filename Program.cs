
//Precios + descuentos//

using System.Reflection;

double precioRBolsillo = 120.00;
double precioRPulsera = 95.00;
double precioRsobremesa = 150.00;

double precioGrabado = 25.00;
double PrecioCaja = 95.00;
double precioFoto = 30.00;

double extraEnvio = 8.50;
double descuentoLimite = 150.00;
double descuento = 0.10;

// Datos inicio sesión//

int encargosCobrados = 0;
double ganancias = 0;
double EncargoMasCaro = 0;
string clienteMasCaro = "";

// Menu 1 //

int opcionesMenu = 0;
while (opcionesMenu != 3)
{
    Console.Write("---K·Han - Relojería Sentimental---");
    Console.Write("1. Nuevo Encargo");
    Console.Write("2. Consultar Caja");
    Console.Write("3. Salir");
    Console.Write("Elige una opción: ");
    opcionesMenu = int.Parse(Console.ReadLine()!);

    if (opcionesMenu == 1)
    {
        //Datos del clientte//
        Console.WriteLine("---Nuevo encargo---");
        string cliente = "";
        while (cliente == "") ;
        {
            Console.Write("Nombre de cliente: ");
            cliente = (Console.ReadLine() ?? "").Trim();
            if (cliente == "") ;
            { Console.WriteLine("El nombre no puede estar vacío."); }
        }


        int modelo = 0;
        while (modelo < 1 || modelo > 3)
        {
            Console.WriteLine("Eliga su reloj personal:");
            Console.WriteLine($"1. Reloj de bolsillo clasico - {precioRBolsillo:F2} €");
            Console.WriteLine($"2. Reloj de pulsera - {precioRPulsera:F2} €");
            Console.WriteLine($"3. Reloj de sobremesa - {precioRsobremesa:F2} €");
            Console.WriteLine("Opción: ");
            modelo = int.Parse(Console.ReadLine()!);
            if (modelo < 1 || modelo > 3)
            {
                Console.WriteLine("Opción no valida. Intentelo de nuevo.");
            }
        }

        string nombreModelo = "";
        double precioModelo = 0;
        if (modelo == 1)
        {
            nombreModelo = "Reloj de bolsilllo cláico";
            precioModelo = precioRBolsillo;
        }

        else if (modelo==2){
            nombreModelo = "Reloj de pulsera";
            precioModelo = precioRPulsera;
        }

        else
        {
            nombreModelo = "Reloj de sobremesa";
            precioModelo = precioRsobremesa;

        }

        //Extras (1 cada 1)//

        bool Grabado = false;
        bool Caja = false;
        bool foto = false;
        int numExtras = 0;
        double totalExtras = 0;

        int extra = -1;
        while (extra != 0) ;
        {
            Console.WriteLine("Opciones extras para personalizar su reloj:");
            Console.WriteLine($"1. Grabado de dedicatoria - {precioGrabado:F2} €");
            Console.WriteLine($"2. Grabado de dedicatoria - {PrecioCaja:F2} €");
            Console.WriteLine($"3. Grabado de dedicatoria - {precioFoto:F2} €");
            Console.WriteLine($"0. Terminar de elegir extras");
            Console.WriteLine("Opcion: ");
        }

        if (extras == 1)
        {
            if (graduado)
            {
                Console.WriteLine("Aviso: El graduado ya esta añadido.");
            }
            else
            {
                Grabado = true;
                numExtras++;
                totalExtras += precioGrabado;
            }
        }
        else if (Extras == 2)
        {
            if (caja)
            {
                Console.WriteLine("Aviso: La caja ya esta añadido.");
            }
            else
            {
                caja = true;
                numExtras++;
                totalExtras += PrecioCaja;
            }
        }
        else if (extra == 3)
        {
            if (foto)
            {
                Console.WriteLine("Aviso: La foto ya esta añadido.");
            }
            else
            {
                foto = true;
                numExtras++;
                totalExtras += precioFoto;
            }
        }
        else if (numExtras != 0)
        {
            Console.WriteLine("Opcion no válida. Intentalo de nuevo.");
        }


        if (extra >= 1 && extra <= 3)
        {
            double provisional = precioModelo + totalExtras;
            Console.WriteLine($"Extras eleidos: {numExtras}");
            Console.WriteLine($"Importe provisional: {provisional:F2} €");
        }



        //Recogida o envío//

        int entrega = 0;
        while (entrega < 1 || entrega > 2)
        {
            Console.WriteLine("Forma de entrega:");
            Console.WriteLine("1.recogida en tienda - gratis");
            Console.WriteLine($"2.Envío a domicilio - {extraEnvio:F2}");
            Console.WriteLine("Opción: ");
            entrega = int.Parse(Console.ReadLine()!);
            if (entrega < 1 || entrega > 2)
            {
                Console.WriteLine("Opcion no valida. Inténtalo de nuevo.");
            }
        }

        string modalidad = "";
        string direccion = "";
        double suplemento = 0;
        if (entrega == 2)
        {
            modalidad = "envío a domicilio";
            suplementos = suplementoEnvio;

            while (direccion == "")
            {
                Console.WriteLine("Direccíon de envío");
                direccion = (Console.ReadLine() ?? "").Trim();
                if (direccion == "")
                {
                    Console.WriteLine("La direccion no puede estar vacía");
                }
            }

        }
        else
        {
            modalidad = "Recogidad de tiendo";
        }

        //Calculo de importe
        double subtotal = precioModelo + totalExtras;
        double descuento = 0;
        if (subtotal >= limiteDescuento)
        {
            descuento = subtotal * porcentajeDescuento;
        }
        double total = subtotal - descuento + suplemento;
        if (total < 0)
        {
            total = 0;
        }

        Console.WriteLine("---Gasto Extras-- -");
        Console.WriteLine($"Reloj: {precioModelo:F2} €");
        Console.WriteLine($"Extras: {totalExtras:F2} €");
        Console.WriteLine($"Subtotal: {subtotal:F2} €");
        Console.WriteLine($"Descuento: -{descuento:F2} €");
        Console.WriteLine($"Suplemento de envío: {suplemento:F2} €");
        Console.WriteLine($"TOTAL A PAGAR: {total:F2} €");

        //Cobro

        double entregado;
        do
        {
            Console.Write("Dinero entregado: ");
            entregado = double.Parse(Console.ReadLine()!);
            if (entregado < total)
            {
                Console.WriteLine($"Importe insuficiente. Debes entregar al menos {total:F2} €.");
            }

        } while (entregado < total);
        double cambio = entregado - total;

        //Contabilizar encargo 1 sola vez

        encargosCobrados++;
        recaudacion += total;
        if (total > EncargoMasCaro)
        {
            EncargoMasCaro = total;
            clienteMasCaro = cliente;
        }

        //TICKET

        Console.WriteLine("=== JUSTIFICANTE K·HAN ===");
        Console.WriteLine($"Encargo nº: {encargosCobrados}");
        Console.WriteLine($"Cliente: {cliente}");
        Console.WriteLine($"Reloj: {NombreModelo}");

        if (numExtras == 0)
        {
            Console.WriteLine("Extras: ninguno");
        }
        else
        {
            Console.WriteLine("extras");
            if (Grabado)
            { Console.WriteLine(" - Grabado de dedicatoria "); }
            if (caja)
            { Console.WriteLine(" - Caja de regalo artesanal "); }
            if (foto)
            { Console.WriteLine(" - fotografia en la esfera "); }
        }
        Console.WriteLine($"entrega: {modalidad}");
        if (entrega == 2)
        { Console.WriteLine($"Direccion: {direccion}");}
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Precio del reloj: {precioModelo:F2 } €");
        Console.WriteLine($"Extras: {totalExtras:F2 }€");
        Console.WriteLine($"Descuento: -{descuento:F2 }€");
        Console.WriteLine($"Suplemento de envío: {suplemento:F2 }€");
        Console.WriteLine($"TOTAL: {total:F2 }€");
        Console.WriteLine($"Entregado: {entregado:F2 }€");
        Console.WriteLine($"Cambio: {cambio:F2 }€");
        Console.WriteLine("-------------------------------------");
        Console.WriteLine($"Gracias por confiar en K·HAN: {cliente: }");
else if{
            Console.WriteLine("---CAJA---");
            if (encargosCobrados == 0)
            {
                Console.WriteLine("Todavia no hay encargos cobrados.");
            }
            else
            {
                double media = recaudacion / encargosCobrados;
                Console.WriteLine($"Encargos cobrados: {encargosCobrados}");
                Console.WriteLine($"Recaudación: {recaudacion:F2} €");
                Console.WriteLine($"Importe medio: {media:F2} €");
                Console.WriteLine($"Encaro mas caro: {encargoMasCaro:F2} €({clienteMasCaro})");

            }
        }
        else if (opcionesMenu == 3)
        {
            Console.WriteLine("Gracias por usar los servicios de K·HAN. ¡Hasta pronto!");
            Console.WriteLine($"Encaros cobrados: {encargosCobrados}");
            Console.WriteLine($"Ingresos totales: {recaudacion:F2} €");
        }
        else
        {
            Console.WriteLine("opción no valida. Intentalo de nuevo.")
        }
    }
}