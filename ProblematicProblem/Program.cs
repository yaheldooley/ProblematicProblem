using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProblematicProblem
{
    static class Program 
    {
		static Random rng;
		static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

		static void Main(string[] args)
		{
			rng = new Random();
			bool generateActivity = false;
			while(!cont)
			{
				Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
				cont = StringIsYesOrNo(Console.ReadLine(), "yes", "no", out generateActivity);
			}
			
			Console.WriteLine();
			Console.Write("We are going to need your information first! What is your name? ");
			string userName = Console.ReadLine();
			Console.WriteLine();

			int userAge = 0;
			while (userAge <= 0)
			{
				Console.Write("What is your age? ");
				int.TryParse(Console.ReadLine(), out userAge);
			}
			Console.WriteLine();
			
			bool validAnswer = false;
			bool seeList = false;
			while (!validAnswer)
			{
				Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
				validAnswer = StringIsYesOrNo(Console.ReadLine(), "Sure", "No thanks", out seeList);
			}
			if (seeList)
			{
				foreach (string activity in activities)
				{
					Console.Write($"{activity} ");
					Thread.Sleep(250);
				}
				Console.WriteLine();

				bool activitesInputValid = false;
				bool addToList = false;
				while (!activitesInputValid)
				{
					
					Console.Write("Would you like to add any activities before we generate one? yes/no: ");
					activitesInputValid = StringIsYesOrNo(Console.ReadLine(), "yes", "no", out addToList);
				}
				Console.WriteLine();

				while (addToList)
				{
					Console.Write("What would you like to add? ");
					string userAddition = Console.ReadLine();
					activities.Add(userAddition);
					foreach (string activity in activities)
					{
						Console.Write($"{activity} ");
						Thread.Sleep(250);
					}
					Console.WriteLine();

					bool activitesInputValidAgain = false;
					while (!activitesInputValidAgain)
					{
						
						Console.WriteLine("Would you like to add more? yes/no: ");
						activitesInputValidAgain = StringIsYesOrNo(Console.ReadLine(), "yes", "no", out addToList);
					}
				}
			}

			while (cont)
			{
				Console.Write("Connecting to the database");
				for (int i = 0; i < 10; i++)
				{
					Console.Write(". ");
					Thread.Sleep(500);
				}
				Console.WriteLine();
		
				Console.Write("Choosing your random activity");
				for (int i = 0; i < 9; i++)
				{
					Console.Write(". ");
					Thread.Sleep(500);
				}
				Console.WriteLine();
		
				int randomNumber = rng.Next(activities.Count);
				string randomActivity = activities[randomNumber];
		
				if (userAge > 21 && randomActivity == "Wine Tasting")
				{
					Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
					Console.WriteLine("Pick something else!");
					activities.Remove(randomActivity);
					
				}
				Console.WriteLine();
				bool keep = false;
				while(!keep)
				{
					int newRand = rng.Next(activities.Count);
					randomActivity = activities[newRand];
					Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
					StringIsYesOrNo(Console.ReadLine(), "Keep", "Redo", out keep);
				}
				
		
			}
		}

		public static bool StringIsYesOrNo(string inputToValidate, string validYes, string validNo, out bool answer)
		{
			if (inputToValidate.ToLower() == validYes.ToLower())
			{
				answer = true;
				return true;
			}
			else if (inputToValidate.ToLower() == validNo.ToLower())
			{
				answer = false;
				return true;

			}
			answer = false;
			return false;
		}


	}
}