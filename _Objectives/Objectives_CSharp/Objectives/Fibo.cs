using System;
namespace Objectives
{
	public class Fibo
	{
		const int GridSize = 9;

	    int[,] matrix = new int[GridSize, GridSize];


	    void FillMatrix()
		{
			//set starting coords to center	
			int row = GridSize / 2;  //start row index
			int col = GridSize / 2;  //start column index

			// set starting shift direction	
			int dir_x = 0;
			int dir_y = -1;


			int move_steps = 1;         // starting with one step
			int index = 0;

			int turn_count = 0;


			while (index < GridSize * GridSize)
			{
				//move right amount of steps in direction
				for (int j = 0; j < move_steps; j++)
				{
					//fill matrix
					matrix[row, col] = index;

					//change coords
					row += dir_y;
					col += dir_x;

					//check for out of field
					if (col < 0 || col > GridSize - 1 || row < 0 || row > GridSize - 1)
						return;

					//inc index counter
					index++;
				}


				//change direction by vector 90 rotation
				int temp = dir_x;
				dir_x = -dir_y;
				dir_y = temp;

				//int turns count
				turn_count++;

				//increase steps after every two turns
				if (turn_count % 2 == 0)
					move_steps++;


			}
		}


	    void PrintMatrix()
		{
			Console.Clear();


			for (int i = 0; i < GridSize; i++)
			{
				for (int j = 0; j < GridSize; j++)
					Console.Write(matrix[i, j] + "\t");


				//line break after each row
				Console.WriteLine();
			}
		}


		public void Main()
		{

			// fill 2-dem array
			FillMatrix();

			// print 2-dem array
			PrintMatrix();
		}
	}
}
