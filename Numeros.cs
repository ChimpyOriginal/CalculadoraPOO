using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraPOO
{
    internal class Numeros
    {
        private int num1;
        private int num2;

        
        public Numeros(int num1, int num2)  // Constructor que inicializa los números
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        public int Num1 // Propiedad para obtener o establecer el primer número
        {
            get { return this.num1; }
            set { this.num1 = value; }
        }
        public int Num2 // Propiedad para obtener o establecer el segundo número
        {
            get { return this.num2; }
            set { this.num2 = value; }
        }
        //Métodos para realizar las operciones aritméticas:
        public int Suma() => num1 + num2;

        public int Resta() => num1 - num2;

        public int Multiplicacion() => num1 * num2;

        public float? Division()//utilizo "float?" para que el método pueda devolver un "null" en caso de que el divisor ingresado sea 0
        {
            float division;
            if (num2 != 0)//Para evitar la división entre cero
            {
                division = (float)num1 / num2;
                return division;
            }
            return null;//si el divisor fue 0
        }
    }
}
