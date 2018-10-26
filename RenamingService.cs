using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rename
{
    public class RenamingService
    {
        /// <summary>
        /// Get contents of given path directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<FileInfo> GetFilesInDirectory(string path)
        {
            Console.WriteLine($"Loading contents of directory {path}");
            DirectoryInfo directory = new DirectoryInfo(path);
            var contents = directory.GetFiles().ToList();
            return contents;
        }

        /// <summary>
        /// Rename all files in given directory.
        /// Numerical ascending.
        /// </summary>
        /// <param name="files"></param>
        public void RenameFiles(List<FileInfo> files, Flag flag)        
        {
            switch (flag.Option)
            {
                // Numeric rename.
                case Constants.NumericalFlag:
                    RenameFilesNumericAscending(files, flag);
                    break;
                
                // Prefix rename. E.g hamburger1, hamburger2 etc.
                case Constants.PrefixFlag:
                    RenameFilesPrefix(files, flag);
                    break;
                
                // Flag input optional.
                case null:
                default:
                    RenameFilesNumericAscending(files, flag);
                    break;
            }
        }
        
        /// <summary>
        /// Rename files in directory numeric ascending, beginning from 1.
        /// </summary>
        /// <param name="files"></param>
        private void RenameFilesNumericAscending(List<FileInfo> files, Flag flagInput)
        {
            Console.WriteLine("Performing numeric rename on files.");

            // Iterate and rename sequence.
            var i = 1;
            var total = files.Count;
            foreach (FileInfo file in files)
            {
                //Console.WriteLine($"Renaming {file.FullName} to {file.Directory.FullName}\\{i.ToString()}{file.Extension}");
                file.MoveTo(file.Directory.FullName + "\\" + i.ToString() + file.Extension);
                drawTextProgressBar(i, total);
                System.Threading.Thread.Sleep(150);
                i++;
            }
        }

        /// <summary>
        /// Rename files in directory with given prefix follwed by ascending numerical values.
        /// </summary>
        /// <param name="files"></param>
        /// <param name="flagInput"></param>
        private void RenameFilesPrefix(List<FileInfo> files, Flag flagInput)
        {
            Console.WriteLine("Performing prefix rename on files.");

            // Iterate and rename sequence.
            var i = 1;
            var total = files.Count;
            foreach (FileInfo file in files)
            {
                file.MoveTo(file.Directory.FullName + "\\" + flagInput.Data + i.ToString() + file.Extension);
                drawTextProgressBar(i, total);
                System.Threading.Thread.Sleep(150);
                i++;
            }
        }

        /// <summary>
        /// Get the target directory. User can use 'this' keyword for their current directory if they don't want to specify absolute path.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public string GetTargetDirectory(string[] args)
        {
            if (args[0] == Constants.ThisParam)
            {
                Console.WriteLine($"Path is {Environment.CurrentDirectory}");
                return Environment.CurrentDirectory;
            }

            else
                return args[0];
        }

        /// <summary>
        /// Get flag if user has entered one.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Flag GetFlagInput(string[] args)
        {
            // Flag optional.
            if (args.Length > 1)
            {
                return new Flag
                {
                    Option = args.ElementAtOrDefault(1),
                    Data = args.ElementAtOrDefault(2),
                };
            }

            return new Flag();
        }

        #region Private Methods

        /// <summary>
        /// Progress bar for display.
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="total"></param>
        private static void drawTextProgressBar(int progress, int total)
        {
            // Draw empty progress bar.
            Console.CursorLeft = 0;
            Console.Write("["); // Start.
            Console.CursorLeft = 32;
            Console.Write("]"); // End.
            Console.CursorLeft = 1;
            float onechunk = 30.0f / total;

            // Draw filled part.
            int position = 1;
            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            // Draw unfilled part.
            for (int i = position; i <= 31; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }

            // Draw totals.
            Console.CursorLeft = 35;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " of " + total.ToString() + "    "); // Blanks at the end remove any excess.
        }

        #endregion
    }
}