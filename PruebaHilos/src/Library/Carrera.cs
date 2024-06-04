/**using System;
using System.Threading;

namespace Library; 

public class Carrera
{
    private List<Thread> hilosCorredores = new List<Thread>();
    private List<Corredores> corredores = new List<Corredores>();

    public Carrera(string[] nombresCorredores)
    {
        foreach (string nombre in nombresCorredores)
        {
            Corredores corredor = new Corredores(nombre);
            corredores.Add(corredor);
            Thread hiloCorredor = new Thread(corredor.Correr);
            hilosCorredores.Add(hiloCorredor);
        }
    }

    public void ComenzarCarrera()
    {
        foreach (Thread hiloCorredor in hilosCorredores)
        {
            hiloCorredor.Start();
        }
    }

    public void EsperarFinalCarrera()
    {
        foreach (Thread hiloCorredor in hilosCorredores)
        {
            hiloCorredor.Join();
        }
    }

    //Metodo para obtener el ganador
    public Corredores ObtenerGanador()
    {
        Corredores ganador = corredores[0];
        foreach (Corredores corredor in corredores)
        {
            if (corredor.DistanciaRecorrida > ganador.DistanciaRecorrida)
            {
                ganador = corredor;
            }
        }
        return ganador;
    }
}*/
