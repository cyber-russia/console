using System;
namespace Race
{
    public enum Symbol { border, floor, obstacle, wheel, car_body };


    public struct Vector2
	{
		public int row;
		public int col;

		public Vector2(int new_row, int new_col)
		{
			row = new_row;
			col = new_col;
		}
	}


    public class Game
    {
        public static int AreaWidth = 20;
        public static int AreaHeight = 20;

        const char BorderSymbol = '|';
        const char FloorSymbol = '';


        public char GetSymbol(Symbol s) {

            char result = ' ';

            switch (s) {
                case Symbol.border:
                    result = '║';
                    break;
                case Symbol.floor:
                    result = '░';
					break;
                case Symbol.obstacle:
                    result = '▓';
					break;
                case Symbol.wheel:
                    result = '■';
					break;
                case Symbol.car_body:
                    result = '█';
					break;
            }


            return result;
        }

       
        void DrawField()
        {
            for (int i = 0; i < AreaHeight; i++)
			{
                Console.Write('|');


                for (int j = 1; j < AreaWidth-2; j++)
				{

				}


                Console.Write('|');
			}
		}



		public void Run()
        {
            
        }

    }
}
