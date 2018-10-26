using System;

namespace Rename
{
    public class ManualService
    {
        public void DisplayManual()
        {
            Console.WriteLine("");
            Console.WriteLine("    ____                                  ______            __             __      ");
            Console.WriteLine("   / __ \\___  ____  ____ _____ ___  ___  / ____/___  ____  / /____  ____  / /______");
            Console.WriteLine("  / /_/ / _ \\/ __ \\/ __ `/ __ `__ \\/ _ \\/ /   / __ \\/ __ \\/ __/ _ \\/ __ \\/ __/ ___/");
            Console.WriteLine(" / _, _/  __/ / / / /_/ / / / / / /  __/ /___/ /_/ / / / / /_/  __/ / / / /_(__  ) ");
            Console.WriteLine("/_/ |_|\\___/_/ /_/\\__,_/_/ /_/ /_/\\___/\\____/\\____/_/ /_/\\__/\\___/_/ /_/\\__/____/  ");
            Console.WriteLine("");
            Console.WriteLine("Usage:\trncontent [TARGET] [OPTION] PREFIX");
            Console.WriteLine("");
            Console.WriteLine("Rename all files within a directory");
            Console.WriteLine("");
            Console.WriteLine("Targets:");
            Console.WriteLine("\tman\t\tDisplay manual page");
            Console.WriteLine("\tthis\t\tPass in current directory as target");
            Console.WriteLine("\tpath\t\tAn absolute path to the target directory");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("\t--n\t\tRename files using ascending numerical values");
            Console.WriteLine("\t--p\t\tRename files using a given prefix followed by incrementing numbers from 1");
            Console.WriteLine("");
            Console.WriteLine("Prefix:");
            Console.WriteLine("\toptional\tThe prefix to use for renaming. Required if prefix option used");
            Console.WriteLine("");
        }
    }
}