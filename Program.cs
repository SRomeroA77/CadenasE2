using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadenasE2
{
    class Program
    {
        /// <summary>
        /// Introducir texto min. 40 caracteres
        /// </summary>
        /// <returns></returns>
        public static string IngresarTexto()
        {
            Console.WriteLine("Introduce texto de al menos 40 caracteres");
            string cadena = Console.ReadLine();
            if (EsCadenaValida(cadena))
            {
                return cadena;
            }
            return IngresarTexto();
        }
        /// <summary>
        /// Comprobar si es texto de min 40 caracteres
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        public static bool EsCadenaValida(string cadena)
        {
            return cadena.Length >= 40 ? true : false;
        }

        /// <summary>
        /// Preguntar qué operación desea realizar
        /// </summary>
        /// <returns></returns>
        public static int SeleccionarOperacion()
        {
            int seleccion = -1;
            Console.WriteLine("Seleccione operación a realizar:\n" +
                            "1. Sustituir una palabra por otra.\n" +
                            "2.Buscar cadena de texto.\n" +
                            "3. Comprobar si texto empieza por cadena.\n" +
                            "0. Salir");
            try
            {
                seleccion = Convert.ToInt32(Console.ReadLine());
                if (seleccion < 0 | seleccion > 3)  return SeleccionarOperacion();
            }
            catch (Exception)
            {

                Console.WriteLine("Selección no válida");
                return SeleccionarOperacion();
            }
            return seleccion;
        }

        /// <summary>
        /// Sustituir una palabra por otra, separada por espacios "palabraViela palabraNueva"
        /// </summary>
        /// <param name="cadena">Texto al que cambiar palabras</param>
        public static string SustituirPalabra(string cadena)
        {
            
            try
            {
                Console.WriteLine("Introduce 'palabraVieja palabraNueva':");
                string cambio = Console.ReadLine();
                string[] palabras = cambio.Split(' ');
                if (cadena.Contains(palabras[0]))
                {
                    cadena = cadena.Replace(palabras[0], palabras[1]);
                }
                else
                {
                    Console.WriteLine($"Palabra no econtrada {palabras[0]}");
                }
                Console.WriteLine(cadena);

            }
            catch (Exception)
            {

                Console.WriteLine("La operación no es válida");
            }
            return cadena;
        }

        /// <summary>
        /// Comprobar si existe cadena en texto
        /// </summary>
        /// <param name="texto">Texto en el que buscar</param>
        public static void ComprobarSiExisteCadena(string texto)
        {
            
            try
            {
                Console.WriteLine("Introduce cadena para ver si existe");
                string textoBuscado = Console.ReadLine();

                if (!texto.Contains(textoBuscado)) Console.WriteLine("No existe cadena cadena en texto");

                Console.WriteLine(texto.Replace(textoBuscado, "'" + textoBuscado + "'"));
            }
            catch (Exception)
            {

                Console.WriteLine("Ha ocurrido un error");
            }
        }

        /// <summary>
        /// Comprueba si una cadena existe al comienzo de un texto
        /// </summary>
        /// <param name="texto"></param>
        public static void ComprobarSiEmpiezaPorCadena(string texto) 
        {
            try
            {
                Console.WriteLine("Introduce cadena para ver si existe al inicio");
                string textoBuscado = Console.ReadLine();
                Console.WriteLine(texto.StartsWith(textoBuscado));
            }
            catch (Exception)
            {

                Console.WriteLine("No se encuentra cadena en texto");
            }
        }

        /// <summary>
        /// Realiza las operaciones con la selección de operación y texto
        /// </summary>
        /// <param name="seleccion"></param>
        /// <param name="texto"></param>
        public static void Operaciones(int seleccion, string texto)
        {
            switch (seleccion)
            {
                case 1:
                    texto = SustituirPalabra(texto);
                    break;
                case 2:
                    ComprobarSiExisteCadena(texto);
                    break;
                case 3:
                    ComprobarSiEmpiezaPorCadena(texto);
                    break;
                case 0:
                    Console.WriteLine("Operaciones finalizadas");
                    break;
                default:
                    Console.WriteLine("Selección no válida");
                    break;
            }
        }

        static void Main(string[] args)
        {
            int seleccion = -1;
            string texto = IngresarTexto();
            seleccion = SeleccionarOperacion();
            while (seleccion != 0)
            {
                Operaciones(seleccion, texto);
                seleccion = SeleccionarOperacion();
            }
        }
    }
}
