using System;
namespace T3Game
{
    class Program
    {
        //Variables globales del personaje principal
        static string jugadorNombre="Héroe";
        static char jugadorSimbolo='@';
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
        
        static char[,] mapa=new char[,]
        {
           { '┌', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '┐', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', '─', '─', '┐', ' ', '┌', '─', '─', ' ', '─', '─', '┬', '─', '─', ' ', '│', ' ', '│', ' ', '─', '─', '┐', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', '├', '─', '─', '│', ' ', '├', '─', '─', ' ', '─', '─', '┴', '─', '┐', ' ', '│', ' ', '└', '─', '┐', '│', ' ',' ', '│', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', '┌', '─', '┴', '─', '┴', '─', '─', '─', '─', '─', '─', '─', ' ', '└', '─', '┴', '─', '─', '─', '┤', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', '│', '│', ' ', '│', ' ', ' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', '└', '─', '┬', '─', '─', ' ', '│', ' ', '┌', '─', '─', '─', '─', ' ', '┌', '─', '─', ' ', '└', '─', '┴', '─', '┤', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '│', ' ', ' ', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ',' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
    { '├', '─', '─', '─', '┘', ' ', '─', '─', '┴', '─', '┤', ' ', '─', '─', '┐', ' ', '├', '─', '─', ' ', '┌', '─', '─', ' ', '├', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '─', '┐' },
    { '│', ' ', ' ', ' ', ' ', ' ',' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', '│', ' ', ' ', ' ',' ',' ', '│',  ' ',' ',' ', '│', ' ', ' ', ' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│' },
    { '│', ' ', '│', ' ', '─', '─', '┐', ' ', '│', ' ', '└', '─', '─', '─', '┴', '─', '┤', ' ', '│', ' ', '└', '─', '┬', '─', '┘', ' ', '─', '─', '─', '─', '┐', ' ', '│', ' ', '┌', '─', '─', ' ', '│', ' ', '│', ' ', '─', '─', '┐', ' ', '┌', '─', '─', '│' },
    { '│', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', '│' },
    { '│', ' ', '│', ' ', '│', ' ', '├', '─', '┘', ' ', '│', ' ', '│', ' ', '─', '─', '┼', '─', '┘', ' ', '─', '─', '┤', ' ', '│', ' ', '┌', '─', '─', '─', '┘', ' ', '│', ' ', '├', '─', '─', '─', '┴', '─', '┴', '─', '─', '─', '┴', '─', '┘', ' ', '│', '│' },
    { '│', ' ', '│', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', '│' },
    { '├', '─', '┘', ' ', '├', '─', '┘', ' ', '─', '─', '┼', '─', '┘', ' ', '─', '─', '┤', ' ', '┌', '─', '─', '─', '┘', ' ', '├', '─', '┴', '─', '─', ' ', '│', ' ', '└', '─', '┴', '─', '─', '─', '┐', ' ', '│', ' ', '│', ' ', '┌', '─', '─', '─', '┘', '│' },
    { '│', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', '│', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '│', ' ', '│', ' ', '│', ' ', '│', ' ', ' ', ' ', ' ', ' ' },
    { '└', '─', '─', '─', '┴', '─', '─', '─', '─', '─', '┴', '─', '─', '─', '─', '─', '┴', '─', '┴', '─', '─', '─', '─', '─', '┴', '─', '─', '─', '─', '─', '┴', '─', '─', '─', '─', '─', '─', '─', '┴', '─', '┴', '─', '┴', '─', '┴', '─', '─', '─', '─', '─' }
};
        static void Main(string[]args)
        {
            //Permite el uso de caracteres especiales
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            //Menú de inicio
            Console.Clear();
            System.Console.WriteLine("========================================");
            System.Console.WriteLine("        BIENVENIDO A LA MAZMORRA        ");
            System.Console.WriteLine("========================================");
            System.Console.Write("Por favor, ingrese el nombre de su personaje: ");
            string entradaNombre=Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(entradaNombre))
            {
                jugadorNombre=entradaNombre;
            }
            System.Console.WriteLine("Seleccione su avatar");
            System.Console.WriteLine("1. Guerrero Estándar  [☺]");
            System.Console.WriteLine("2. Héroe del Escudo   [Ω]");
            System.Console.WriteLine("3. Mago de Magia      [✵]");
            System.Console.WriteLine("4. Gladiador          [┼]");
            System.Console.WriteLine("5. Asesino            [☠]");

            string opcion=Console.ReadLine();
            switch(opcion)
            {
                case "2":jugadorSimbolo='Ω';break;
                case "3":jugadorSimbolo='✵';break;
                case "4":jugadorSimbolo='┼';break;
                case "5":jugadorSimbolo='☠';break;
                default: jugadorSimbolo='☺';break;
            }
            Console.WriteLine("Creación de personaje completada, Presione ENTER para continuar...");
            Console.ReadLine();

            //Inicio del juego
            Console.CursorVisible=false;
            DibujarEscenario();
            Console.ReadLine();
        }
        static void DibujarEscenario()
        {
            Console.SetCursorPosition(0,0);
            int filas=mapa.GetLength(0);
            int columnas=mapa.GetLength(1);

            for(int f=0;f<filas;f++)
            {
                for(int c=0;c<columnas;c++)
                {
                    if (f==jugadorFila&&c==jugadorColumna)
                    {
                        Console.ForegroundColor=ConsoleColor.Cyan;
                        Console.Write(jugadorSimbolo);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(mapa[f,c]);
                    }
                }
                Console.WriteLine();
            }
            //AQUI IRA EL HUD DE PERSONAJE
        }
    }
}