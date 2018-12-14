using System;
namespace Labirinth
{
	class Game
	{

		// player position
		Vector2 playerPos;

		//running flag
		bool Running = true;

		GameObject floor = new Floor();
		GameObject wall = new Wall();


		public GameObject[,] LabMap = new GameObject[GameOptions.AreaHeight, GameOptions.AreaWidth];





		void PrepareConsole()
		{
			Console.CursorVisible = false;
			Console.Clear();
		}


		void DrawLabirinth()
		{
			for (int row = 0; row < GameOptions.AreaHeight; row++)
			{
				for (int col = 0; col < GameOptions.AreaWidth; col++)
				{
					Vector2 pos = new Vector2(row, col);

					PrintSymbol(pos, (CellType)GameOptions.Lab[row, col]);


					//check if Player start
					if (GameOptions.Lab[row, col] == (int)CellType.player)
						playerPos = pos;
				}
			}
		}


		void MovePlayer(Vector2 shift)
		{
			//check for new coords in area
			int new_row = playerPos.row + shift.row;
			int new_col = playerPos.col + shift.col;

			if ((new_row < 0) || (new_row > GameOptions.AreaHeight - 1) || (new_col < 0) || (new_col > GameOptions.AreaWidth - 1))
				return;


			// check if new place is wall
			if (GameOptions.Lab[new_row, new_col] == (int)CellType.wall)
				return;


			// check, if new place is Finish
			if (GameOptions.Lab[new_row, new_col] == (int)CellType.finish)
			{
				Running = false;
				return;
			}


			// in other case simply move

			//clear 
			PrintSymbol(playerPos, CellType.floor);

			playerPos.row = new_row;
			playerPos.col = new_col;

			PrintSymbol(playerPos, CellType.player);
		}


		public void Run()
		{
			PrepareConsole();
			DrawLabirinth();





			// entering infinity loop
			while (Running)
			{
				ConsoleKeyInfo keyInfo = Console.ReadKey(true);


				switch (keyInfo.Key)
				{
					case ConsoleKey.RightArrow:
						MovePlayer(new Vector2(0, 1));
						break;

					case ConsoleKey.LeftArrow:
						MovePlayer(new Vector2(0, -1));
						break;

					case ConsoleKey.UpArrow:
						MovePlayer(new Vector2(-1, 0));
						break;

					case ConsoleKey.DownArrow:
						MovePlayer(new Vector2(1, 0));
						break;

					case ConsoleKey.Escape:
						Running = false;
						break;
				}
			}
		}
	}

}
