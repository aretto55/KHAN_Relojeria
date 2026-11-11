
        // --precios y reglas
        double precioBolsillo = 120.00;     // reloj de bolsillo clásico
        double precioPulsera = 95.00;       // reloj de pulsera
        double precioSobremesa = 150.00;    // reloj de sobremesa

        double precioGrabado = 25.00;       
        double precioCaja = 15.00;          
        double precioFoto = 30.00;          

        double suplementoEnvio = 8.50;      
        double limiteDescuento = 150.00;    
        double porcentajeDescuento = 0.10;  

        int encargosCobrados = 0;
        double recaudacion = 0;
        double encargoMasCaro = 0;
        string clienteMasCaro = "";

        // --Menú principal se repite hasta elegir salir
        int opcionMenu = 0;
        while (opcionMenu != 3)
        {
            Console.WriteLine("\n===== K·HAN - Relojería Sentimental =====");
            Console.WriteLine("1. Nuevo encargo");
            Console.WriteLine("2. Consultar caja");
            Console.WriteLine("3. Salir");
            Console.Write("Elige una opción: ");
            opcionMenu = int.Parse(Console.ReadLine()!);

            if (opcionMenu == 1)
            {
                // --Datos del cliente 
                Console.WriteLine("\n--- NUEVO ENCARGO ---");
                string cliente = "";
                while (cliente == "")
                {
                    Console.Write("Nombre del cliente: ");
                    cliente = (Console.ReadLine() ?? "").Trim();   // Trim quita los espacios
                    if (cliente == "")
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                    }
                }

                // --Reloj principal 
                int modelo = 0;
                while (modelo < 1 || modelo > 3)
                {
                    Console.WriteLine("\nElige el reloj a personalizar:");
                    Console.WriteLine($"1. Reloj de bolsillo clásico - {precioBolsillo:F2} €");
                    Console.WriteLine($"2. Reloj de pulsera - {precioPulsera:F2} €");
                    Console.WriteLine($"3. Reloj de sobremesa - {precioSobremesa:F2} €");
                    Console.Write("Opción: ");
                    modelo = int.Parse(Console.ReadLine()!);
                    if (modelo < 1 || modelo > 3)
                    {
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    }
                }

                string nombreModelo = "";
                double precioModelo = 0;
                if (modelo == 1)
                {
                    nombreModelo = "Reloj de bolsillo clásico";
                    precioModelo = precioBolsillo;
                }
                else if (modelo == 2)
                {
                    nombreModelo = "Reloj de pulsera";
                    precioModelo = precioPulsera;
                }
                else
                {
                    nombreModelo = "Reloj de sobremesa";
                    precioModelo = precioSobremesa;
                }

                // --extras cada uno solo una vz
                bool grabado = false;
                bool caja = false;
                bool foto = false;
                int numExtras = 0;
                double totalExtras = 0;

                int extra = -1;
                while (extra != 0)
                {
                    Console.WriteLine("\nExtras para personalizar tu reloj:");
                    Console.WriteLine($"1. Grabado de dedicatoria - {precioGrabado:F2} €");
                    Console.WriteLine($"2. Caja de regalo artesanal - {precioCaja:F2} €");
                    Console.WriteLine($"3. Fotografía en la esfera - {precioFoto:F2} €");
                    Console.WriteLine("0. Terminar de elegir extras");
                    Console.Write("Opción: ");
                    extra = int.Parse(Console.ReadLine()!);

                    if (extra == 1)
                    {
                        if (grabado)
                        {
                            Console.WriteLine("Aviso: el grabado ya está añadido.");
                        }
                        else
                        {
                            grabado = true;
                            numExtras++;
                            totalExtras += precioGrabado;
                        }
                    }
                    else if (extra == 2)
                    {
                        if (caja)
                        {
                            Console.WriteLine("Aviso: la caja de regalo ya está añadida.");
                        }
                        else
                        {
                            caja = true;
                            numExtras++;
                            totalExtras += precioCaja;
                        }
                    }
                    else if (extra == 3)
                    {
                        if (foto)
                        {
                            Console.WriteLine("Aviso: la fotografía ya está añadida.");
                        }
                        else
                        {
                            foto = true;
                            numExtras++;
                            totalExtras += precioFoto;
                        }
                    }
                    else if (extra != 0)
                    {
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    }

                    if (extra >= 1 && extra <= 3)
                    {
                        double provisional = precioModelo + totalExtras;
                        Console.WriteLine($"Extras elegidos: {numExtras}");
                        Console.WriteLine($"Importe provisional: {provisional:F2} €");
                    }
                }

                // --Recogida o envío
                int entrega = 0;
                while (entrega < 1 || entrega > 2)
                {
                    Console.WriteLine("\nForma de entrega:");
                    Console.WriteLine("1. Recogida en tienda - gratis");
                    Console.WriteLine($"2. Envío a domicilio - {suplementoEnvio:F2} €");
                    Console.Write("Opción: ");
                    entrega = int.Parse(Console.ReadLine()!);
                    if (entrega < 1 || entrega > 2)
                    {
                        Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
                    }
                }

                string modalidad = "";
                string direccion = "";
                double suplemento = 0;
                if (entrega == 2)
                {
                    modalidad = "Envío a domicilio";
                    suplemento = suplementoEnvio;
                    // La dirección solo se pide si hay envío
                    while (direccion == "")
                    {
                        Console.Write("Dirección de envío: ");
                        direccion = (Console.ReadLine() ?? "").Trim();
                        if (direccion == "")
                        {
                            Console.WriteLine("La dirección no puede estar vacía.");
                        }
                    }
                }
                else
                {
                    modalidad = "Recogida en tienda";
                }

                // --cálculo del pago

                double subtotal = precioModelo + totalExtras;
                double descuento = 0;
                if (subtotal >= limiteDescuento)
                {
                    descuento = subtotal * porcentajeDescuento;
                }

                double total = subtotal - descuento + suplemento;
                if (total < 0)
                {
                    total = 0;   // El total nunca puede ser negativo
                }

                Console.WriteLine("\n--- DESGLOSE ---");
                Console.WriteLine($"Reloj: {precioModelo:F2} €");
                Console.WriteLine($"Extras: {totalExtras:F2} €");
                Console.WriteLine($"Subtotal: {subtotal:F2} €");
                Console.WriteLine($"Descuento: -{descuento:F2} €");
                Console.WriteLine($"Suplemento de envío: {suplemento:F2} €");
                Console.WriteLine($"TOTAL A PAGAR: {total:F2} €");

                // --cobro
                // Se repite pidiendo el importe completo hasta que sea suficiente
                double entregado;
                do
                {
                    Console.Write("\nDinero entregado: ");
                    entregado = double.Parse(Console.ReadLine()!);
                    if (entregado < total)
                    {
                        Console.WriteLine($"Importe insuficiente. Debes entregar al menos {total:F2} €.");
                    }
                } while (entregado < total);

                double cambio = entregado - total;

                // --Se contabiliza el encargo una sola vez
                encargosCobrados++;
                recaudacion += total;                 // sumar el total final, no lo entregado
                if (total > encargoMasCaro)           
                {
                    encargoMasCaro = total;
                    clienteMasCaro = cliente;
                }

                // -- justificante
                Console.WriteLine("\n========== JUSTIFICANTE K·HAN ==========");
                Console.WriteLine($"Encargo nº: {encargosCobrados}");
                Console.WriteLine($"Cliente: {cliente}");
                Console.WriteLine($"Reloj: {nombreModelo}");
                if (numExtras == 0)
                {
                    Console.WriteLine("Extras: ninguno");
                }
                else
                {
                    Console.WriteLine("Extras:");
                    if (grabado)
                    {
                        Console.WriteLine("  - Grabado de dedicatoria");
                    }
                    if (caja)
                    {
                        Console.WriteLine("  - Caja de regalo artesanal");
                    }
                    if (foto)
                    {
                        Console.WriteLine("  - Fotografía en la esfera");
                    }
                }
                Console.WriteLine($"Entrega: {modalidad}");
                if (entrega == 2)
                {
                    Console.WriteLine($"Dirección: {direccion}");
                }
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Precio del reloj: {precioModelo:F2} €");
                Console.WriteLine($"Extras: {totalExtras:F2} €");
                Console.WriteLine($"Descuento: -{descuento:F2} €");
                Console.WriteLine($"Suplemento de envío: {suplemento:F2} €");
                Console.WriteLine($"TOTAL: {total:F2} €");
                Console.WriteLine($"Entregado: {entregado:F2} €");
                Console.WriteLine($"Cambio: {cambio:F2} €");
                Console.WriteLine("========================================");
                Console.WriteLine($"Gracias por confiar en K·HAN, {cliente}.");
            }
            else if (opcionMenu == 2)
            {
                // --caja de la sesión
                Console.WriteLine("\n--- CAJA DE LA SESIÓN ---");
                if (encargosCobrados == 0)
                {
                    Console.WriteLine("Todavía no hay encargos cobrados.");   // --no dividir entre 0
                }
                else
                {
                    double media = recaudacion / encargosCobrados;
                    Console.WriteLine($"Encargos cobrados: {encargosCobrados}");
                    Console.WriteLine($"Recaudación: {recaudacion:F2} €");
                    Console.WriteLine($"Importe medio: {media:F2} €");
                    Console.WriteLine($"Encargo más caro: {encargoMasCaro:F2} € ({clienteMasCaro})");
                }
            }
            else if (opcionMenu == 3)
            {
                //-- resumen
                Console.WriteLine("\nGracias por usar la gestión de K·HAN. ¡Hasta pronto!");
                Console.WriteLine($"Encargos cobrados: {encargosCobrados}");
                Console.WriteLine($"Ingresos totales: {recaudacion:F2} €");
            }
            else
            {
                Console.WriteLine("Opción no válida. Inténtalo de nuevo.");
            }
        }
