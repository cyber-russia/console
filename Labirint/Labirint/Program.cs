using System;



namespace Labirinth
{

    public enum CellType { floor = 0, wall = 1, player = 2, finish = 3};

    struct Vector2
    {
        public int row;
        public int col;


        public Vector2(int new_row, int new_col)
        {
            row = new_row;
            col = new_col;
        }

    }


    public static class GameOptions
    {
        public const int AreaWidth = 10;
        public const int AreaHeight = 10;

        public static char WallSymbol = '█';
        public static char PlayerSymbol = '■';

        public static ConsoleColor WallColor = ConsoleColor.Blue;
        public static ConsoleColor FloorColor = ConsoleColor.White;
        public static ConsoleColor FinishColor = ConsoleColor.Magenta;
        public static ConsoleColor PlayerColor = ConsoleColor.Green;


        // 0 - floor
        // 1 - wall
        // 2 - start
        // 3 - finish

        public static int[,] Lab = new int[AreaHeight, AreaWidth] {

            { 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
            { 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 3 }
        };

    }


    class Game
    {
        // player position var
        Vector2 player_pos;

        //running flag
        bool Running = true;


        //PrintSymbol
        void PrintSymbol(Vector2 pos, CellType t)
        {
            Console.SetCursorPosition(pos.col, pos.row);

            switch (t)
            {
                case CellType.floor:
                    Console.ForegroundColor = GameOptions.FloorColor;
                    Console.Write( GameOptions.WallSymbol );
                    break;

                case CellType.wall:
                    Console.ForegroundColor = GameOptions.WallColor;
                    Console.Write(GameOptions.WallSymbol);
                    break;

                case CellType.player:
                    Console.ForegroundColor = GameOptions.PlayerColor;
                    Console.Write(GameOptions.PlayerSymbol);
                    break;

                case CellType.finish:
                    Console.ForegroundColor = GameOptions.FinishColor;
                    Console.Write(GameOptions.WallSymbol);
                    break;
            }
        }


        //PrepareConsole
        void PrepareConsole()
        {
            Console.Clear();
            Console.CursorVisible = false;
        }

        //DrawLab
        void DrawLab()
        {
            for (int row = 0; row < GameOptions.AreaHeight; row++)
            {
                //print row
                for (int col = 0; col < GameOptions.AreaWidth; col++)
                {
                    Vector2 pos = new Vector2(row, col);

                    //draw symbol
                    PrintSymbol( pos, (CellType)GameOptions.Lab[row, col] );

                    //check for player start pos
                    if (GameOptions.Lab[row, col] == (int)CellType.player)
                        player_pos = pos;

                }

                Console.WriteLine();
            }
        }


        //MovePlayer
        void MovePLayer(Vector2 shift)
        {
            int new_row = player_pos.row + shift.row;
            int new_col = player_pos.col + shift.col;

            //check for area
            if ( new_row < 0 || new_row > GameOptions.AreaHeight-1 ||
                new_col < 0 || new_col > GameOptions.AreaWidth-1 )
                return;

            //check for wall
            if (GameOptions.Lab[new_row, new_col] == (int)CellType.wall)
                return;

            //check for finish
            if (GameOptions.Lab[new_row, new_col] == (int)CellType.finish)
            {
                Running = false;
                return;
            }


            PrintSymbol(player_pos, CellType.floor);

            player_pos.row = new_row;
            player_pos.col = new_col;

            PrintSymbol(player_pos, CellType.player);
                
        }


        public void Run()
        {
            //PrepareConsole
            PrepareConsole();

            //DrawLab
            DrawLab();


            //endless running
            while (Running)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch(keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Running = false;
                        break;

                    case ConsoleKey.UpArrow:
						MovePLayer( new Vector2(0,-1) );
						break;
					
					case ConsoleKey.DownArrow:
						MovePLayer(new Vector2(0, 1));
						break;

					case ConsoleKey.RightArrow:
						MovePLayer(new Vector2(1, 0));
						break;

					case ConsoleKey.LeftArrow:
						MovePLayer(new Vector2(-1, 0));
						break;
                }
            }
        }
    }



    class MainClass
    {
        public static void Main()
        {
            (new Game()).Run();
        }
    }
}