using System;

public class Laberinto
{
    public static bool Ruta(int[][] mapa, int filaActual, int columnaActual, int filaDestino, int columnaDestino)
    {
        if (filaActual < 0 || filaActual >= mapa.Length || columnaActual < 0 || columnaActual >= mapa[0].Length)
        {
            Console.WriteLine($"La posicion ({filaActual}, {columnaActual}) esta fuera de los limites.");
            return false;
        }

        if (mapa[filaActual][columnaActual] == 1)
        {
            Console.WriteLine($"La posicion ({filaActual}, {columnaActual}) es una pared.");
            return false;
        }
        if (mapa[filaActual][columnaActual] == 2)
        {
            Console.WriteLine($"La posicion ({filaActual}, {columnaActual}) ya fue visitada.");
            return false;
        }

        if (filaActual == filaDestino && columnaActual == columnaDestino)
        {
            Console.WriteLine($"Salida encontrada en la posicion ({filaActual}, {columnaActual})");
            Mapa(mapa);
            return true;
        }

        mapa[filaActual][columnaActual] = 2;
        Console.WriteLine($"Visitando posicion ({filaActual}, {columnaActual}).");

        Mapa(mapa);

        if (Ruta(mapa, filaActual - 1, columnaActual, filaDestino, columnaDestino))
        {
            return true;
        }
        if (Ruta(mapa, filaActual + 1, columnaActual, filaDestino, columnaDestino))
        {
            return true;
        }
        if (Ruta(mapa, filaActual, columnaActual - 1, filaDestino, columnaDestino))
        {
            return true;
        }
        if (Ruta(mapa, filaActual, columnaActual + 1, filaDestino, columnaDestino))
        {
            return true;
        }

        mapa[filaActual][columnaActual] = 0;
        Console.WriteLine($"Volviendo desde la posición ({filaActual}, {columnaActual}).");

        Mapa(mapa);

        return false;
    }

    public static void Mapa(int[][] mapa)
    {
        for (int i = 0; i < mapa.Length; i++)
        {
            for (int j = 0; j < mapa[i].Length; j++)
            {
                if (mapa[i][j] == 2)
                {
                    Console.Write("* ");
                }
                else
                {
                    Console.Write(mapa[i][j] + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {

        int[][] laberinto1 = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 0, 1, 1 },
            new int[] { 0, 0, 0, 0, 0 }
        };

        Console.WriteLine("Laberinto 2:");
        Console.WriteLine(Ruta(laberinto1, 0, 0, 4, 4) ? "Camino encontrado" : "No hay camino");

        int[][] laberinto2 = new int[][]
        {
            new int[] { 0, 0, 1, 1, 1, 0, 0, 0 },
            new int[] { 1, 0, 1, 0, 0, 0, 1, 1 },
            new int[] { 1, 0, 0, 0, 1, 1, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 0, 0, 0, 0, 1, 0 },
            new int[] { 0, 1, 1, 1, 0, 1, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 0 }
        };

        Console.WriteLine("Laberinto 2:");
        Console.WriteLine(Ruta(laberinto2, 0, 0, 7, 4) ? "Camino encontrado" : "No hay camino");

        int[][] laberinto3 = new int[][]
        {
            new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 },
            new int[] { 0, 1, 1, 1, 0, 1, 1, 1, 0, 1 },
            new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
            new int[] { 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 },
            new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 },
            new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 },
            new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        Console.WriteLine("Laberinto 3:");
        Console.WriteLine(Ruta(laberinto3, 0, 0, 9, 9) ? "Camino encontrado" : "No hay camino");


    }
}
