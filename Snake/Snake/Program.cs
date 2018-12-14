using System;
using System.Threading;

namespace Snake
{

    //█ ■


    public enum CellType { field, snake, apple }

    public struct Vector2 {
        public int x;
        public int y;


        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void AddShift(Vector2 shift)
        {
            x += shift.x;
            y += shift.y;
        }
    }


    public class SnakeSegment
    {
        public Vector2 pos;

        public SnakeSegment Next; 

        public SnakeSegment(Vector2 _pos, SnakeSegment _next)
        {
            pos = _pos;

            Next = _next;
        }


    }


    public class Snake 
    {
        int area_width = 20;
        int area_height = 20;

        SnakeSegment Head;

        ConsoleColor SEG_COLOR = ConsoleColor.Red;
        ConsoleColor FIELD_COLOR = ConsoleColor.White;
        ConsoleColor APPLE_COLOR = ConsoleColor.Green;

        Vector2 Direction = new Vector2(0, 1);



        void PrintSymbol(Vector2 pos, CellType ctype)
        {
            Console.SetCursorPosition(pos.x, pos.y);

            switch (ctype) {
                case CellType.field:
                    Console.ForegroundColor = FIELD_COLOR;
                    Console.Write(' ');
                    break;

                case CellType.snake: 
                    Console.ForegroundColor = SEG_COLOR;
                    Console.Write('■');
                    break;

                case CellType.apple: 
                    Console.ForegroundColor = APPLE_COLOR;
                    Console.Write('*');
                    break;    
            }

        }


        void PrintArea()
        {
            for (int j = 0; j <= area_height; j++)
            {
                for (int i = 0; i <= area_width; i++)
                {
                    if ((i == 0) || (j == 0) || (i == area_width) || (j == area_height))
                        Console.Write('+');
                    else
                        Console.Write(' ');
                }

                Console.WriteLine();
            }

        }


        bool Move()
        {
            PrintSymbol(Head.pos, CellType.field);

            Head.pos.AddShift( Direction );

            bool in_field = (Head.pos.x >= 0) || (Head.pos.x <= area_width) || (Head.pos.y >= 0) || (Head.pos.y <= area_height);

            if (in_field)
                PrintSymbol(Head.pos, CellType.snake);

            return in_field;
        }


        public Snake(int width, int height)
        {
            area_width = width;
            area_height = height;

            Head = new SnakeSegment( new Vector2(width / 2, height / 2), null);


            Console.CursorVisible = false;
            //  Console.SetWindowSize(width, height);

            PrintArea();
        }


        public void Run()
        {
            bool Running = true;
            ConsoleKeyInfo keyInfo;

            while (Running)
            {
                if (!Move())
                {
                    Running = false;
                    continue;
                }


                if (Console.KeyAvailable) {
                    keyInfo = Console.ReadKey(false);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            Direction = new Vector2(1, 0);
                            break;
                        case ConsoleKey.LeftArrow:
                            Direction = new Vector2(-1, 0);
                            break;
                        case ConsoleKey.UpArrow:
                            Direction = new Vector2(0, -1);
                            break;
                        case ConsoleKey.DownArrow:
                            Direction = new Vector2(0, 1);
                            break;
                        case ConsoleKey.Escape:
                            Running = false;
                            break;

                    }
                }
                    

                Thread.Sleep(1000);
            }
        }


    }


    class MainClass
    {
        public static void Main()
        {
            (new Snake(20, 20)).Run();
        }
    }
}
