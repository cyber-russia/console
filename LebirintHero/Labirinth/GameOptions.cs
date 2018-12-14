using System;



namespace Labirinth
{
	
	public enum CellType { floor = 0, wall = 1, player = 2, finish = 3 };


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



	public static class GameOptions
	{
		public const int AreaWidth = 10;
		public const int AreaHeight = 10;


		public static ConsoleColor DefaultBackColor = ConsoleColor.White;
		public static ConsoleColor DefaultFrontColor = ConsoleColor.Black;




		public static char WallSymbol = '█';
		public static char PlayerSymbol = '■';



		public static ConsoleColor WallColor = ConsoleColor.Cyan;
		public static ConsoleColor FloorColor = ConsoleColor.White;
		public static ConsoleColor FinishColor = ConsoleColor.Magenta;


		public static ConsoleColor PlayerColor = ConsoleColor.Green;


		// 0 - floor
		// 1 - wall
		// 2 - start
		// 3 - finish

		public static int[,] LabMap = new int[AreaHeight, AreaWidth]{
			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
			{ 1, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
			{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 3  },
			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
		};

	}
}
