using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Adverts
{
    class AdvertisingSystem
    {
        public List<Advertisement> GetAdvertisementsFromFile()
        {
            if(!File.Exists(@"C:\Users\Allie\OneDrive - PROG121\LEXICON-2021\C#\Visual Studio repos\Adverts\Adverts\adverts.txt"))
            {
                return new List<Advertisement>();
            }

            var adverts = File.ReadAllText(@"C:\Users\Allie\OneDrive - PROG121\LEXICON-2021\C#\Visual Studio repos\Adverts\Adverts\adverts.txt");
            return JsonConvert.DeserializeObject<List<Advertisement>>(adverts);
        }

        public void SaveAdvertsToFile(List<Advertisement> listWithAdverts)
        {
            var json = JsonConvert.SerializeObject(listWithAdverts);
            File.WriteAllText(@"C:\Users\Allie\OneDrive - PROG121\LEXICON-2021\C#\Visual Studio repos\Adverts\Adverts\adverts.txt", json);    
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Create new");
            Console.WriteLine("2. List");
            Console.WriteLine("0. Exit");
        }

        public void PrintAds(List<Advertisement> advertsList)
        {
            Console.Clear();
            Console.WriteLine("---- ALL ADVERTS ----");
            foreach (var advertisement in advertsList)
            {
                string day = advertisement.GetWeekday();
                Console.WriteLine($"{advertisement.Title} - {advertisement.Price}");
                if (advertisement.EndsSoon())
                {
                    Console.WriteLine("    ***   ENDS SOON   ***    ");
                }
                Console.WriteLine($"{advertisement.Description}");
                Console.WriteLine($"Expires at {day}, {advertisement.StartEndDateTime}");
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void Run()
        {
            var ListWithAdverts = GetAdvertisementsFromFile();
            while (true)
            {
                ShowMenu();
                Console.Write("Enter what you want to do: ");
                int sel = Convert.ToInt32(Console.ReadLine());
                if (sel == 1)
                {
                    //Create ad
                }

                if (sel == 2)
                {
                    PrintAds(ListWithAdverts);
                }
                else if (sel == 0)
                {
                    break;
                }
            }
            //var ad = new Advertisement
            //{
            //    Description = "This is a little something that can be used for something", Price = 42m, Title = "This is a thing!",
            //    StartEndDateTime = new DateTime(2021,05,19,12,0,0), Username = "The cool guy", Created = new DateTime(2021,01,19,12,0,0)
            //};
            //ListWithAdverts.Add(ad);

            //var ad2 = new Advertisement
            //{
            //    Description = "This is another little something that can be used for something",
            //    Price = 42m,
            //    Title = "This is another thing!",
            //    StartEndDateTime = new DateTime(2021, 09, 12, 12, 0, 0),
            //    Username = "The cool chick",
            //    Created = new DateTime(2021, 05, 12, 12, 0, 0)
            //};
            //ListWithAdverts.Add(ad2);

            SaveAdvertsToFile(ListWithAdverts);
        }
    }
}
