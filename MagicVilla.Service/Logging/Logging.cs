using System.Runtime.InteropServices;

namespace MagicVilla.Service.Logging
{
    public class Logging : ILogging
    {
        public void Log(string message, [Optional]string? type)
        {
            if(type.ToLower() == "error")
                Console.Error.WriteLine(message);

            Console.WriteLine(message);
        }
    }
}
