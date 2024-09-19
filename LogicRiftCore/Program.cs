// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
namespace LogicRiftCore
{
    public class Player
    {
        public string Name { get; set; }

        public Player(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

    }
}