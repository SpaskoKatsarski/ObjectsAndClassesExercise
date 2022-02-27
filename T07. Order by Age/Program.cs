using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._Order_by_Age
{
    class Info
    {
        public Info(string name, string id, int age)
        {
            this.Name = name;
            this.ID = id;
            this.Age = age;
        }

        public string Name { get; set; }

        public string ID { get; set; }

        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Info> allInfo = new List<Info>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                string id = data[1];
                int age = int.Parse(data[2]);

                Info currentPersonInfo = new Info(name, id, age);

                if (allInfo.Any(i => i.ID == id))
                {
                    allInfo[allInfo.IndexOf(allInfo.First(i => i.ID == id))] = currentPersonInfo;
                }
                else
                {
                    allInfo.Add(currentPersonInfo);
                }
            }

            foreach (Info personInfo in allInfo.OrderBy(p => p.Age))
            {
                Console.WriteLine($"{personInfo.Name} with ID: {personInfo.ID} is {personInfo.Age} years old.");
            }
        }
    }
}
