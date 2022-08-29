using System;
using System.Threading.Tasks;

namespace Inspector
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var app = new App();

            await app.Run();
        }
    }
}
