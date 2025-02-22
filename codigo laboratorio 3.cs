List<string> estudiantes = new List<string>();
List<string> apellidos = new List<string>();
List<double> calificaciones = new List<double>();
List<string> carreras = new List<string>();
string[] opcionesCarreras = { "Ingenieria", "Medicina", "Derecho", "Arquitectura", "Administracion" };

while (true)
{
    Console.WriteLine("Bienvenido al sistema de gestion de estudiantes.");
    Console.WriteLine("Seleccione una carrera:");

    for (int i = 0; i < opcionesCarreras.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {opcionesCarreras[i]}");
    }

    int seleccion;
    Console.Write("Ingrese el numero de la carrera: ");
    while (!int.TryParse(Console.ReadLine(), out seleccion) || seleccion < 1 || seleccion > opcionesCarreras.Length)
    {
        Console.Write("Entrada invalida. Seleccione un numero valido: ");
    }

    string carrera = opcionesCarreras[seleccion - 1];
    carreras.Add(carrera);

    while (true)
    {
        Console.WriteLine("\n1. Agregar estudiante");
        Console.WriteLine("2. Mostrar lista de estudiantes");
        Console.WriteLine("3. Calcular promedio de calificaciones");
        Console.WriteLine("4. Mostrar estudiante con la calificación más alta");
        Console.WriteLine("5. Regresar al menú de carreras");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opción: ");
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 6)
        {
            Console.WriteLine("Opción no valida. Intente de nuevo.");
            Console.Write("Seleccione una opción: ");
        }

        if (opcion == 1)
        {
            Console.Write("Ingrese el nombre del estudiante: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el apellido del estudiante: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingrese la calificacion del estudiante: ");
            double calificacion;
            while (!double.TryParse(Console.ReadLine(), out calificacion) || calificacion < 0 || calificacion > 10)
            {
                Console.WriteLine("Calificacion no valida. Intente de nuevo.");
                Console.Write("Ingrese la calificacion del estudiante: ");
            }
            estudiantes.Add(nombre);
            apellidos.Add(apellido);
            calificaciones.Add(calificacion);
            Console.WriteLine("Estudiante agregado correctamente.");

            Console.WriteLine("¿Desea regresar al menu de selección de carrera? (s/n): ");
            string respuesta = Console.ReadLine().ToLower();
            if (respuesta == "s")
            {
                break;
            }
        }
        else if (opcion == 2)
        {
            if (estudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
            }
            else
            {
                Console.WriteLine("\nLista de estudiantes:");
                for (int i = 0; i < estudiantes.Count; i++)
                {
                    Console.WriteLine($"{estudiantes[i]} {apellidos[i]} - Calificacion: {calificaciones[i]} - Carrera: {carreras[i]}");
                }
            }
        }
        else if (opcion == 3)
        {
            if (calificaciones.Count == 0)
            {
                Console.WriteLine("No hay calificaciones registradas.");
            }
            else
            {
                double suma = 0;
                foreach (double calificacion in calificaciones)
                {
                    suma += calificacion;
                }
                double promedio = suma / calificaciones.Count;
                Console.WriteLine($"El promedio de calificaciones es: {promedio}");
            }
        }
        else if (opcion == 4)
        {
            if (calificaciones.Count == 0)
            {
                Console.WriteLine("No hay calificaciones registradas.");
            }
            else
            {
                double maxCalificacion = calificaciones[0];
                string estudianteMax = estudiantes[0];
                string apellidoMax = apellidos[0];
                string carreraMax = carreras[0];
                for (int i = 1; i < calificaciones.Count; i++)
                {
                    if (calificaciones[i] > maxCalificacion)
                    {
                        maxCalificacion = calificaciones[i];
                        estudianteMax = estudiantes[i];
                        apellidoMax = apellidos[i];
                        carreraMax = carreras[i];
                    }
                }
                Console.WriteLine($"El estudiante con la calificacion más alta es: {estudianteMax} {apellidoMax} ({carreraMax}) con {maxCalificacion}");
            }
        }
        else if (opcion == 5)
        {
            Console.WriteLine("Regresando al menu de carreras...");
            break;
        }
        else if (opcion == 6)
        {
            Console.WriteLine("Saliendo del sistema...");
            Environment.Exit(0);
        }
    }
}



