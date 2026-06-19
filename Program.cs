using System;

namespace T3Game
{
    class Program
    {
        //Variables globales del personaje principal
        static string jugadorNombre="Heroe";
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

        //Posicion del jugador
        static int jugadorFila=1;
        static int jugadorColumna=1;

        // Fase 2: Control de interacciones de NPCs y mensajes temporales
        static bool npcLenadorUsado = false;
        static bool npcPescadorUsado = false;
        static bool npcCientificaUsado = false;
        static string mensajeTemporal = "";
        
        static char[,] mapa=new char[,]
        {
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
            { '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#' },
            { '#', ' ', '#', 'L', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '#', ' ', '#', ' ', '#' }, // Lenador
            { '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#' },
            { '#', ' ', '#', ' ', ' ', 'P', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', '#' }, // Pescador
            { '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', '^', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', '#' }, // Pinchos
            { '#', '#', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', ' ', '#', ' ', '^', ' ', ' ', '#', ' ', '#', ' ', '#' }, // Pinchos
            { '#', '#', '#', ' ', '#', '#', '#', ' ', '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', '~', '#', ' ', '#', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#', ' ', '#' }, // Agua
            { '#', ' ', '#', '#', '#', '#', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', 'C', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', '#' }, // Cientifica
            { '#', ' ', '#', '#', '#', ' ', '#', '#', '#', '#', '#', ' ', '#', ' ', '#', '#', '#', ' ', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', '~', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', '#' }, // Agua
            { '#', ' ', '#', ' ', '#', ' ', '#', '#', '#', '#', '#', '#', '#', ' ', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'S' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }
        };

        static void Main(string[]args)
        {
            //Permite el uso de caracteres especiales
            Console.OutputEncoding=System.Text.Encoding.UTF8;
            //Menu de inicio
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
            System.Console.WriteLine("1. Guerrero Estandar  [☺]");
            System.Console.WriteLine("2. Heroe del Escudo   [Ω]");
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
            Console.WriteLine("Creacion de personaje completada, Presione ENTER para continuar...");
            Console.ReadLine();

            //Fase 2, introduccion!!!
            MostrarHistoria();

            //Inicio del juego
            Console.CursorVisible=false;
            Console.Clear();
            while(true)
            {
                DibujarEscenario();
                ConsoleKeyInfo tecla=Console.ReadKey(true);

                int nuevaFila=jugadorFila;
                int nuevaColumna=jugadorColumna;

                switch(tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        nuevaFila--;
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        nuevaFila++;
                        break;
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        nuevaColumna--;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        nuevaColumna++;
                        break;
                    //Fase 2, interaccion
                    case ConsoleKey.E:
                        ProcesarInteraccion();
                        break;
                    //Para salir del juego
                    case ConsoleKey.Escape:
                        Console.Clear();
                        System.Console.WriteLine("Juego finalizado. Gracias por jugar");
                        return;
                    
                }
                if (nuevaFila>=0&&nuevaFila<mapa.GetLength(0)&&nuevaColumna>=0&&nuevaColumna<mapa.GetLength(1))
                {
                    char celdaDestino=mapa[nuevaFila,nuevaColumna];
                    if(celdaDestino=='S')
                    {
                        jugadorFila=nuevaFila;
                        jugadorColumna=nuevaColumna;

                        DibujarEscenario();

                        Console.Clear();
                        System.Console.WriteLine("Felicitaciones, has encontrado la salida de la mazmorra.");
                        System.Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                    //Fase 2, extendiendo la logica de movimiento
                    else if(celdaDestino==' ' || celdaDestino=='L' || celdaDestino=='P' || celdaDestino=='C' || celdaDestino=='^' || celdaDestino=='~')
                    {
                        jugadorFila=nuevaFila;
                        jugadorColumna=nuevaColumna;
                        mensajeTemporal = ""; // Limpiar mensaje en cada nuevo movimiento normal

                        // Fase 2, anadiendo peligros para mas complejidad
                        if (celdaDestino == '^')
                        {
                            jugadorHPActual -= 4;
                            mensajeTemporal = "Has pisado unos pinchos.\nHP -4";
                        }
                        else if (celdaDestino == '~')
                        {
                            JugadorVelocidad -= 4;
                            mensajeTemporal = "Has atravesado agua.\nVelocidad -4";
                        }
                    }
                }
            }
        }

        //lorecito pe
        static void MostrarHistoria()
        {
            Console.Clear();
            Console.WriteLine("El heroe regresa a su mundo de origen.\n");
            Console.WriteLine("Sin embargo, algo ha cambiado.\n");
            Console.WriteLine("Las tierras que una vez conocio estan llenas de");
            Console.WriteLine("peligros, misterios y vidas necesitadas.\n");
            Console.WriteLine("Determinado a sanar el mundo,");
            Console.WriteLine("el heroe inicia un nuevo viaje.\n");
            Console.WriteLine("Presione ENTER para continuar...");
            Console.ReadLine();
        }

        //interaccion
        static void ProcesarInteraccion()
        {
            char celdaActual = mapa[jugadorFila, jugadorColumna];
            if (celdaActual == 'L' && !npcLenadorUsado)
            {
                EjecutarEventoNPC();
                npcLenadorUsado = true;
            }
            else if (celdaActual == 'P' && !npcPescadorUsado)
            {
                EjecutarEventoNPC();
                npcPescadorUsado = true;
            }
            else if (celdaActual == 'C' && !npcCientificaUsado)
            {
                EjecutarEventoNPC();
                npcCientificaUsado = true;
            }
        }

        static void EjecutarEventoNPC()
        {
            Console.Clear();
            Console.WriteLine("1. Escuchar");
            Console.WriteLine("2. Ignorar");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Random rnd = new Random();
                int probabilidad = rnd.Next(1, 101); // 1 a 100

                if (probabilidad <= 50)
                {
                    Console.WriteLine("\nHas recibido una recompensa!!!");
                    Console.WriteLine("+10 Oro");
                    jugadorOro += 10;
                }
                else
                {
                    Console.WriteLine("\nHas sido maldecido...");
                    Console.WriteLine("Ataque -1\nDefensa -1\nVelocidad -1");
                    jugadorAtaque--;
                    jugadorDefensa--;
                    JugadorVelocidad--;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
            else if (opcion == "2")
            {
                Console.Clear();
            }
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
                    //Fase 2, colorcito para los npcs
                    else if (mapa[f,c] == 'L' || mapa[f,c] == 'P' || mapa[f,c] == 'C')
                    {
                        Console.ForegroundColor=ConsoleColor.Blue;
                        Console.Write(mapa[f,c]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(mapa[f,c]);
                    }
                }
                Console.WriteLine();
            }
            //HUD integrado debajo del mapa
            System.Console.WriteLine("==================================================");
            System.Console.WriteLine($"Jugador: {jugadorNombre.ToUpper()} | Clase: [Simbolo: {jugadorSimbolo} | Nivel: {jugadorNivel}]");
            System.Console.WriteLine("==================================================");
            System.Console.WriteLine($"HP: {jugadorHPActual}/{jugadorHPMax} | Mana: {jugadorManaACtual}/{jugadorManaMax}");
            System.Console.WriteLine($"Ataque: {jugadorAtaque}          |           Defensa: {jugadorDefensa}");
            System.Console.WriteLine($"Oro: {jugadorOro}              |           Experiencia: {jugadorEXP}");
            System.Console.WriteLine("==================================================");
            
            //Fase 2!!!! interfaz adicional (informacion temporal y detalles)
            char celdaActual = mapa[jugadorFila, jugadorColumna];
            bool sobreNpcValido = (celdaActual == 'L' && !npcLenadorUsado) ||
                                  (celdaActual == 'P' && !npcPescadorUsado) ||
                                  (celdaActual == 'C' && !npcCientificaUsado);

            if (sobreNpcValido)
            {
                Console.WriteLine("Presione E para interactuar.                      ");
            }
            else
            {
                Console.WriteLine("                                                  "); //espaciado para evitar textos fantaaaasmas
            }

            if (!string.IsNullOrEmpty(mensajeTemporal))
            {
                Console.WriteLine(mensajeTemporal + "                                    ");
            }
            else
            {
                Console.WriteLine("                                                  ");
                Console.WriteLine("                                                  ");
            }
        }
    }
}