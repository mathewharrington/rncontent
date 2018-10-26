using System;
using System.Linq;

namespace Rename
{
    /// <summary>
    /// Args: [0] target, [1] flag (opt), [2] flag data (opt).
    /// </summary>
    class Program
    {
        private static Verifier Verifier { get; set; }
        private static RenamingService RenamingService { get; set; }
        private static ManualService ManualService { get; set; }

        static void Main(string[] args)
        {
            Verifier = new Verifier();
            RenamingService = new RenamingService();
            ManualService = new ManualService();

            try
            {
                // Get target.
                var target = RenamingService.GetTargetDirectory(args);

                switch (target)
                {
                    case Constants.ManualParam:
                        ManualService.DisplayManual();
                        break;
                    default:
                        Rename(target, args);
                        break;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return;
            }

            finally
            {
                
            }
        }

        /// <summary>
        /// Perform the renaming process.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="args"></param>
        private static void Rename(string target, string[] args)
        {
            // Verify input params.
            if (!Verifier.VerifyPathParam(target))
                return;

            var flagInput = RenamingService.GetFlagInput(args);

            // Verify flag input.
            if (!Verifier.VerifyFlag(flagInput))
                return;

            // Get directory contents.
            var contents = RenamingService.GetFilesInDirectory(target);

            // Verify contents of directory.
            if (!Verifier.VerifyDirectoryContents(contents))
                return;

            Console.WriteLine($"{contents.Count} {contents.First().Extension} files found.");

            // Rename files in directory.
            RenamingService.RenameFiles(contents, flagInput);

            // End processing.
            Console.WriteLine("");
            Console.WriteLine($"Renaming complete.");
        }
    }
}
