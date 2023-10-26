using guia_30__de_parcial_2_progra_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

// ALUMNO:Remberto Jose Viscarra Ortiz
class Program
{
    static void Main()
    {
        using (var contextdb = new ContextDB())
        {
            bool Avanzar = true;
            while (Avanzar)
            {
                Console.WriteLine("");
                Console.WriteLine("BIENVENIDOS AL MENU DEL CRUD DE LA BASE DE DATOS");
                Console.WriteLine("");
                Console.WriteLine("1 Insertar Datos");
                Console.WriteLine("");
                Console.WriteLine("2 Actualizar Datos");
                Console.WriteLine("");
                Console.WriteLine("3 Eliminar Datos");
                Console.WriteLine("");

                int op1 = Convert.ToInt32(Console.ReadLine());

                switch (op1)
                {
                    case 1:
                        contextdb.Database.EnsureCreated();

                        Student estudiante = new Student();

                        Console.WriteLine("Ingrese el Nombre: ");
                        estudiante.Nombres = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Apellido: ");
                        estudiante.Apellidos = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Sexo: ");
                        estudiante.Sexo = Console.ReadLine();

                        Console.WriteLine("");

                        Console.WriteLine("Ingrese el Edad: ");
                        estudiante.Edad = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("");

                        contextdb.Add(estudiante);
                        contextdb.SaveChanges();

                        Console.WriteLine("Estudiante agregado correctamente.");
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.WriteLine("Ingrese el Id del registro que desea modificar");
                        var id = Console.ReadLine();
                        var persona = contextdb.Estudiantes.FirstOrDefault(p => p.Id == Int32.Parse(id));

                        if (persona != null)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Que opción desea modificar");
                            Console.WriteLine("");
                            Console.WriteLine("1 Nombre");
                            Console.WriteLine("");
                            Console.WriteLine("2 Apellido");
                            Console.WriteLine("");
                            Console.WriteLine("3 Sexo");
                            Console.WriteLine("");
                            Console.WriteLine("4 Edad");

                            int op2 = Convert.ToInt32(Console.ReadLine());
                            switch (op2)
                            {

                                case 1:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo nombre: ");
                                    persona.Nombres = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo Apellido: ");
                                    persona.Apellidos = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese el nuevo Sexo: ");
                                    persona.Sexo = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("");
                                    Console.WriteLine("Ingrese la nueva Edad: ");
                                    if (int.TryParse(Console.ReadLine(), out int NE))
                                    {
                                        persona.Edad = NE;
                                    }
                                    break;
                            }
                            contextdb.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registro no encontrado");
                        }
                        break;
                    case 3:
                        Console.WriteLine("");
                        Console.WriteLine("Ingrese el ID del registro que desea eliminar");
                        var Id = Console.ReadLine();
                        var Persona = contextdb.Estudiantes.SingleOrDefault(x => x.Id == Int32.Parse(Id));
                        if (Persona != null)
                        {
                            contextdb.Estudiantes.Remove(Persona);
                            contextdb.SaveChanges();
                        }
                        break;
                }
                Console.WriteLine("");
                Console.WriteLine("Desea seguir avanzando PRECIONE EN MAYUSCULAS S/N");
                var cont = Console.ReadLine();
                if (cont.Equals("N"))
                {
                    Avanzar = false;
                }

            }
            Console.WriteLine("");

            Console.WriteLine("LISTADO DE LOS DATOS:");
            Console.WriteLine("");

            foreach (var s in contextdb.Estudiantes)
            {
                Console.WriteLine($"Nombre: {s.Nombres}, Apellido: {s.Apellidos}, Sexo: {s.Sexo}, Edad: {s.Edad}");
            }

        }
    }
}


