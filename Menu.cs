using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPOO
{
    internal class Menu
    {
        List<Opcion> opciones; // Lista de opciones del menú
        private Numeros numeros; // Instancia de la clase Numeros para trabajar con los números que se registren

        // Constructor para inicializar las opciones del menú
        public Menu()
        {
            opciones = new List<Opcion>()
            {
                new Opcion("Registrar los números.", RegistrarNumeros),
                new Opcion("Sumar.",Sumar),
                new Opcion("Restar.", Restar),
                new Opcion("Multiplicar.", Multiplicar),
                new Opcion("Dividir.",Dividir),
                new Opcion("Salir.",()=>Environment.Exit(0))

            };
            while (true) // Bucle para mostrar el menú y para que el usuario elija la opción
            {
                MostrarMenu();
                ElegirOpcion();
            }
        }

        public void MostrarMenu() //Método para mostrar las opciones del menú al usuario
        {
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine((i+1)+"."+ opciones[i].Message);//coloco "i+1" para que la lista empiece desde 1 y no desde 0
            }
        }
        public void ElegirOpcion() // Método para capturar la opción del usuario
        {
            Console.Write("Elige una opción: ");
            int numOpcion = Convert.ToInt32(Console.ReadLine());
            numOpcion--; //Ajusta el índice de la opción seleccionada para que coincida con la lista
            Console.Clear();
            if (numOpcion < opciones.Count) // Valida que la opción seleccionada esté dentro del rango
            {
                opciones[numOpcion].Action.Invoke(); // Ejecuta la acción asociada con la opción seleccionada
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, elige una registra en el menú.");
                Continuar(); // Espera a que el usuario presione una tecla antes de continuar
            }
            Console.Clear();
        }

        public void RegistrarNumeros() // Método para registrar los dos números ingresados por el usuario
        {
            Console.WriteLine("Ingrese el primer número: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el segundo número: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            numeros = new Numeros(num1, num2); //Crea un nuevo objeto con los valores registrados
        }

        public void Sumar()
        {
            if (numeros == null) //Hacer una validación en caso de que se intente llamar al método sin antes haber creado un objeto
            {
                Console.WriteLine("Primero ingresa los números que deseas sumar.");
                Continuar();
                return;
            }
            Console.WriteLine(numeros.Suma());
            Continuar();
        }
        public void Restar()
        {
            if (numeros == null)
            {
                Console.WriteLine("Primero debes registrar los números que deseas restar.");
                Continuar();
                return;
            }
            Console.WriteLine(numeros.Resta());
            Continuar();
        }
        public void Multiplicar()
        {
            if (numeros == null)
            {
                Console.WriteLine("Primero debes registrar los números que deseas multiplicar.");
                Continuar();
                return;
            }
            Console.WriteLine(numeros.Multiplicacion());
            Continuar();
        }
        public void Dividir()
        {
            if (numeros == null)
            {
                Console.WriteLine("Primero debes registrar los números que deseas dividir.");
                Continuar();
                return;
            }
            if (numeros.Division() != null)
            { Console.WriteLine(numeros.Division()); }

            else//si se recibe un null, significa que el divisor ingresado fue 0, por lo que se envía una advertencia
            {
                Console.WriteLine("La división entre cero es inválida.");
            }
            Continuar();
        }
        public void Continuar() //Método para esperar a que el usuario presione una tecla antes de continuar
        {
            Console.WriteLine("Presiona cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}
