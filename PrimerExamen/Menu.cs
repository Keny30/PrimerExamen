using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerExamen
{
    internal class Menu
    {
        
     public static List<Empleado> listaEmpleados = new List<Empleado>();

        public static void EjecutarMenuPrincipal()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Sistema de Recursos Humanos");
                Console.WriteLine("1.) Agregar Empleado");
                Console.WriteLine("2.) Consultar Empleado");
                Console.WriteLine("3.) Modificar Empleado");
                Console.WriteLine("4.) Borrar Empleado");
                Console.WriteLine("5.) Inicializar Arreglos");
                Console.WriteLine("6.) Reportes");
                Console.WriteLine("7.) Salir");
                Console.WriteLine("Digite una opcion");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        AgregarEmpleado();
                        break;
                    case 2:
                        Console.Clear();
                        ConsultarEmpleado();

                        break;
                    case 3:
                        Console.Clear();
                        ModificarEmpleado();
                        break;
                    case 4:
                        Console.Clear();
                        BorrarEmpleado();
                        break;
                    case 5:
                        Console.Clear();
                        InicializarArreglos();
                        break;
                    case 6:
                        Console.Clear();
                        Reportes();
                        break;

                    default:
                        break;

                }


            } while (opcion != 7);


        }
        public static void EjecutarSubMenu()
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("Reportes");
                Console.WriteLine("1.) Consultar empleado");
                Console.WriteLine("2.) Listar todos los empleados");
                Console.WriteLine("3.) Mostrar el promedio de los salarios");
                Console.WriteLine("4.) Mostrar el salario más alto y el más bajo de todos los empleados");
                Console.WriteLine("5.) Salir");
                Console.WriteLine("Digite una opcion");
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                        ConsultarEmpleado();
                        break;
                    case 2:
                        Console.Clear();
                        ConsultarListaEmpleados();
                        break;
                    case 3:
                        Console.Clear();
                        CalcularPromedioSalarios();
                        break;
                    case 4:
                        Console.Clear();
                        Calcular_SalarioMenor_SalarioMayor();
                        break;
                    default:
                        break;

                }


            } while (opcion != 5);


        }
        static void AgregarEmpleado()
        {
            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingrese el teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese el salario: ");
            double salario = double.Parse(Console.ReadLine());

            Empleado empleado = new Empleado(cedula, nombre, direccion, telefono, salario);
            listaEmpleados.Add(empleado);

            Console.WriteLine("Empleado agregado con éxito.");
        }
        public static void ConsultarListaEmpleados()
        {
            Console.WriteLine("Lista de Empleados:");
            foreach (var empleado in listaEmpleados.OrderBy(item => item.Nombre).ToList())
            {
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario}");
                Console.WriteLine();
            }
        }
        public static void ConsultarEmpleado()
        {
            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            var empleado_a_mostrar = listaEmpleados.FirstOrDefault(p => p.Cedula == cedula);
            if (empleado_a_mostrar == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                Console.WriteLine($"Cédula: {empleado_a_mostrar.Cedula}");
                Console.WriteLine($"Nombre: {empleado_a_mostrar.Nombre}");
                Console.WriteLine($"Dirección: {empleado_a_mostrar.Direccion}");
                Console.WriteLine($"Teléfono: {empleado_a_mostrar.Telefono}");
                Console.WriteLine($"Salario: {empleado_a_mostrar.Salario}");
                Console.WriteLine();
            }
        }
        public static void ModificarEmpleado()
        {
            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            var empleado_a_editar = listaEmpleados.FirstOrDefault(p => p.Cedula == cedula);
            if (empleado_a_editar == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                Console.Write("Ingrese el nombre: ");
                empleado_a_editar.Nombre = Console.ReadLine();
                Console.Write("Ingrese la dirección: ");
                empleado_a_editar.Direccion = Console.ReadLine();
                Console.Write("Ingrese el teléfono: ");
                empleado_a_editar.Telefono = Console.ReadLine();
                Console.Write("Ingrese el salario: ");
                empleado_a_editar.Salario = double.Parse(Console.ReadLine());
                Console.WriteLine("Empleado actualizado con éxito.");
            }

        }
        public static void BorrarEmpleado()
        {
            Console.Write("Ingrese la cédula: ");
            string cedula = Console.ReadLine();
            Empleado empleado_a_eliminar = listaEmpleados.FirstOrDefault(empleado => empleado.Cedula == cedula);
            if (empleado_a_eliminar == null)
            {
                Console.WriteLine("El empleado no esta registrado");
            }
            else
            {
                listaEmpleados = listaEmpleados.Where(item => item.Cedula != cedula).ToList();
                Console.WriteLine("Empleado eliminado con éxito.");
            }
        }
        public static void Reportes()
        {
            EjecutarSubMenu();
        }
        public static void InicializarArreglos()
        {
            listaEmpleados = new List<Empleado>();
            Console.WriteLine("Lista de empleados limpiada exitosamente.");
        }
        public static void CalcularPromedioSalarios()
        {

            double promedioSalarios = listaEmpleados.Average(item => item.Salario);
            Console.WriteLine($"El promedio de los salarios registrados es: {promedioSalarios}");
        }
        public static void Calcular_SalarioMenor_SalarioMayor()
        {
            double salarioMenor = listaEmpleados.Min(item => item.Salario);
            double salarioMayor = listaEmpleados.Max(item => item.Salario);
            Console.WriteLine($"El salario menor registrado es: {salarioMenor}");
            Console.WriteLine($"El salario mayor registrado es: {salarioMayor}");
        }

    }
}

    
    

