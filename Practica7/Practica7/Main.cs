using System;

namespace Practica7
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.ForegroundColor = ConsoleColor.White;
			try
			{
				Menu menu = new Menu();
				menu.swichPrincipal();
			}catch(Exception){
				Console.Clear();
				Console.WriteLine("NO EXISTE BASE DE DATOS\n");
				Console.ReadKey(true);
			}
		}
	}
}
