using MathNet.Numerics.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraIntegrales
{
   
    internal class Program
    {
        //----------------------------------------CÓDIGO PARA INTEGRALES DE TIPO x^2-----------------------------------------------------
        static void Main(string[] args)
        {
            //----------------------------------------CÓDIGO PARA INTEGRALES DE TIPO x^2-----------------------------------------------------
           
            
                // Mensaje de bienvenida
                Console.WriteLine("Bienvenido a la calculadora de integrales!");

                // Mostrar el menú de opciones
                Console.WriteLine("Seleccione la función a integrar:");
                Console.WriteLine("1. x^2");
                Console.WriteLine("2. sin(x)");
                Console.WriteLine("3. cos(x)");
                Console.WriteLine("4. Polinomio");

                // Obtener la opción del usuario
                Console.Write("Ingrese el número de la opción deseada: ");
                int opcion = Convert.ToInt32(Console.ReadLine());

                // Definir los límites de integración
                Console.Write("Ingrese el límite inferior de integración: ");
                double limiteInferior = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ingrese el límite superior de integración: ");
                double limiteSuperior = Convert.ToDouble(Console.ReadLine());

                // Declarar la función a integrar
                Func<double, double> funcion = null;

                // Asignar la función según la opción seleccionada
                switch (opcion)
                {
                    case 1:
                        funcion = x => Math.Pow(x, 2);
                        break;

                    case 2:
                        funcion = x => Math.Sin(x);
                        break;

                    case 3:
                        funcion = x => Math.Cos(x);
                        break;

                    case 4:
                        // Obtener los coeficientes del polinomio
                        Console.Write("Ingrese el número de coeficientes del polinomio: ");
                        int numCoeficientes = Convert.ToInt32(Console.ReadLine());
                        double[] coeficientes = new double[numCoeficientes];

                        for (int i = 0; i < numCoeficientes; i++)
                        {
                            Console.Write($"Ingrese el coeficiente para x^{numCoeficientes - 1 - i}: ");
                            coeficientes[i] = Convert.ToDouble(Console.ReadLine());
                        }

                        // Definir la función del polinomio
                        funcion = x => EvaluarPolinomio(coeficientes, x);
                        break;

                    default:
                        Console.WriteLine("Opción no válida. Saliendo del programa.");
                        return;
                }

                // Calcular la integral
                double resultado = NewtonCotesTrapeziumRule.IntegrateComposite(funcion, limiteInferior, limiteSuperior, 1000);

                // Mostrar el resultado
                Console.WriteLine($"La integral entre {limiteInferior} y {limiteSuperior} es: {resultado}");


                //-----------------------------------------CALCULOS PARA SENO Y COSENO------------------------------------------------
                // Integrar sin(x)
                Func<double, double> seno = x => Math.Sin(x);
                // Limites de integración
                double limiteInferiorSeno = 0;
                double limiteSuperiorSeno = Math.PI; // Integral de 0 a π
                double resultadoSeno = NewtonCotesTrapeziumRule.IntegrateComposite(seno, limiteInferiorSeno, limiteSuperiorSeno, 1000);

                Console.WriteLine($"La integral de sin(x) entre {limiteInferiorSeno} y {limiteSuperiorSeno} es: {resultadoSeno}");

                // Integrar cos(x)
                Func<double, double> coseno = x => Math.Cos(x);
                // Limites de integración
                double limiteInferiorCoseno = 0;
                double limiteSuperiorCoseno = Math.PI / 2; // Integral de 0 a π/2
                double resultadoCoseno = NewtonCotesTrapeziumRule.IntegrateComposite(coseno, limiteInferiorCoseno, limiteSuperiorCoseno, 1000);

                Console.WriteLine($"La integral de cos(x) entre {limiteInferiorCoseno} y {limiteSuperiorCoseno} es: {resultadoCoseno}");


                //---------------------------------------------CODIGO PARA RESOLVER CON POLINOMIOS--------------------------------------
                // Coeficientes de un polinomio. Ejemplo: 3x^3 + 2x^2 + 4x + 5
                // Esto se maneja en la opción 4 del menú, por lo que no es necesario aquí.
            }

            // Función para evaluar un polinomio dado x y los coeficientes
            static double EvaluarPolinomio(double[] coeficientes, double x)
            {
                double resultado = 0;
                int grado = coeficientes.Length - 1;

                for (int i = 0; i < coeficientes.Length; i++)
                {
                    resultado += coeficientes[i] * Math.Pow(x, grado - i);
                }

                return resultado;
            }
        }
    }
    

    
    

