using EF2.Contexts;

namespace EF2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EventHubContexts db = new();
        }
    }
}
