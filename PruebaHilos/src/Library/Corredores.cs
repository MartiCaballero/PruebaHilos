using System; 
using System.Threading;

namespace Library;


public class Corredores
    {
        private static Corredores ganador;
        private static object lockObject = new object();
        private static bool carreraFinalizada = false;
        private static int distanciaCarrera = 100;

        public string Nombre { get; }
        public int DistanciaRecorrida { get; private set; }
        private Random random;

        public Corredores(string nombre)
        {
            Nombre = nombre;
            DistanciaRecorrida = 0;
            random = new Random();
        }

        public void Correr()
        {
            lock (lockObject)
            {
                if (!carreraFinalizada)
                {
                    int distanciaAvanzada = random.Next(1, 11); /** Cada corredor avanza aleatoriamente entre 1 y 10 metros. */
                    DistanciaRecorrida += distanciaAvanzada;
                    Console.WriteLine($"{Nombre} ha recorrido {DistanciaRecorrida} metros.");

                    if (DistanciaRecorrida >= distanciaCarrera) /** Verifica si algun corredor llegó a la meta.*/
                    {
                        carreraFinalizada = true;
                        ganador = this;
                        Console.WriteLine($"¡{Nombre} ha cruzado la línea de meta!");
                    }
                }
            }

            Thread.Sleep(random.Next(250, 501)); /** El programa espera un tiempo random antes de mostrae el siguiente resultado. */
        }

        public static bool CarreraFinalizada
        {
            get { return carreraFinalizada; }
        }

        public static Corredores GanadorCarrera()
        {
            return ganador;
        }

        public static void ReiniciarCarrera()
        {
            carreraFinalizada = false;
            ganador = null;
    }
}