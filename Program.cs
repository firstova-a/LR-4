using System;
using System.Threading.Tasks;

namespace LR4
{
	class Program
	{
		public static bool ShowSum = false;
		public static bool ShowMul = false;
		public static bool StopSum = false;
		public static bool StopMul = false;

		async static Task Main(string[] args)
		{
			Task<int> sum = Summ(1, 2, 2000);
			Task<int> mul = Multi(1, 3, 3000);
			while (true)
			{
				Console.WriteLine("Enter the command");
				Console.WriteLine("Commands for the program: 'show', 'stop'");
				string command = Console.ReadLine();
				if (command.ToLower() == "show")
				{
					ShowMul = true;
					ShowSum = true;
				}
				if (command.ToLower() == "stop")
				{
					StopMul = true;
					StopSum = true;
					await sum;
					await mul;
					Console.WriteLine("Shutting down the program");
					break;
				}
			}
		}

		static async Task<int> Multi(int a, int b, int delay)
		{
			int multiplication = a;
			int step = b;
			int count = 0;
			while (true)
			{
				if (ShowMul)
				{
					Console.WriteLine("Step: " + count.ToString() + " Multiplication: " + multiplication.ToString());
					ShowMul = false;
				}
				if (StopMul)
				{
					break;
				}
				await Task.Delay(delay);
				count++;
				multiplication *= step;
			}

			return multiplication;
		}

		static async Task<int> Summ(int a, int b, int delay)
		{
			int sum = a;
			int step = b;
			int count2 = 0;
			while (true)
			{
				if (ShowSum)
				{
					Console.WriteLine("Step: " + count2.ToString() + " Summ: " + sum.ToString());
					ShowSum = false;
				}
				if (StopSum)
				{
					break;
				}
				await Task.Delay(delay);
				count2++;
				sum += step;
			}

			return sum;
		}
	}
}
