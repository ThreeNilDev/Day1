using System;
using System.Linq;

namespace Day1
{

	public class GatherItems
	{
        public List<Int32> ElfBackpackCount;
        Int32 elfCount;
        string[] Backpack;
         

		public GatherItems()
		{

            ReadTextFile();
            ItemsIntoBags();
            Console.WriteLine("There is " +elfCount + " elfs with backpacks");
            FindElfWithTheMostCalories();
            FindTopNWithMostCalories(3);

        }

        void FindElfWithTheMostCalories()
        {
            if (ElfBackpackCount is not null)
            {
                Console.WriteLine("Elf with the most! : " + ElfBackpackCount.Max());

            }
        }

        void FindTopNWithMostCalories(int n)
        {
            List<Int32> result = new List<Int32>();
            result = ElfBackpackCount;
            result.Sort();
            result.RemoveRange(0, (elfCount - n));
                
            //result.Take(n);
            Int32 retVal = result.Sum();

            Console.WriteLine("The sum of the top "+ n + " backpacks: "  + retVal);
        }

        void ReadTextFile()
        {
            string filePath = "@../../input.txt";
            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist :{0} ", filePath);
                return;
            }

            string[] textFromFile = File.ReadAllLines(filePath);
            Backpack = textFromFile;
            
            return;           
        }

        void ItemsIntoBags()
        {
            List<Int32> backpackCount = new List<Int32>();
            List<Int32> elfBackpackCount = new List<Int32>();
            foreach (string item in Backpack)
            {
                
                Int32.TryParse(item, out int i);
                if (i == 0)
                {
                    elfCount++;
                    Console.WriteLine(backpackCount.Sum());
                    Int32 result = backpackCount.Sum();
                    try
                    {    
                        elfBackpackCount.Add(result);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    backpackCount.Clear();
                }
                else
                {
                    try
                    {
                        Int32 Calories = Int32.Parse(item);
                        backpackCount.Add(Calories);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Unable to parse '{item}'");
                    }
                    
                }

            }
            ElfBackpackCount = elfBackpackCount;
        
        }
        


	}
}
