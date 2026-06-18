using System;
namespace T3Game
{
    class Program
    {
        //Variables globales del personaje principal
        static int jugadorNivel=1;
        static int jugadorHPMax=100;
        static int jugadorHPActual=100;
        static int jugadorManaMax=50;
        static int jugadorManaACtual=50;
        static int jugadorAtaque=15;
        static int jugadorDefensa=5;
        static int JugadorVelocidad=10;
        static int jugadorOro=0;
        static int jugadorEXP=0;

        //Posición del jugador
        static int jugadorFila=1;
        static int jugadorColumna=1;
        
        static void Main(string[] args)
        {
            System.Console.WriteLine("Personaje creado satisfactoriamente-");
            System.Console.WriteLine($"Nivel: {jugadorNivel} | HP: {jugadorHPActual}");
        }
    }
}