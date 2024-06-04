using System; 
using System.Threading; 

namespace Library;
public class Program 
{
    public static void Main(string[] args)
    {
        Corredores corredor1 = new Corredores("Martina");
        Corredores corredor2 = new Corredores("Alberto");
        Corredores corredor3 = new Corredores("Marta");

        Thread hiloCarrera = new Thread(() =>
        {
            while (!Corredores.CarreraFinalizada)
            {
                corredor1.Correr();
                corredor2.Correr();
                corredor3.Correr();
            }
        });

        hiloCarrera.Start();
        hiloCarrera.Join();

        Corredores ganador = Corredores.GanadorCarrera();
        Console.WriteLine($"El ganador es {ganador.Nombre}.");

        Corredores.ReiniciarCarrera();
        }

    }

