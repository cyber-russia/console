using System;
namespace Objectives
{
	public class RandomConsolePoints
	{

		int[,] point = new int[10, 10];
		Random random = new Random();


		char GetChar(int i, int j)
		{
			if (point[i, j] != 0)
			{
				return 'x';
			}

			else
			{
				return ' ';
			}

		}


		void SetRandomPoint()
		{
			int x, y;

			do
			{
				x = random.Next(10);
				y = random.Next(10);

			} while (point[x, y] != 0);


			point[x, y] = 1;
		}


		void FillArray()
		{
			for (int i = 0; i < 10; i++)
				SetRandomPoint();
		}


	    void PrintPoints()
		{
			for (int j = 0; j < 10; j++)
			{
				Console.Write("|");

				for (int i = 0; i < 10; i++)
					Console.Write(GetChar(i, j));

				Console.WriteLine("|");
			}
		}


		public void Main()
		{
			//fill points array
			FillArray();

			//print points array
			PrintPoints();
		}

	}  // end of RandomConsolePoints
}
