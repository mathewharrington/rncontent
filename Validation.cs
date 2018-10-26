using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Rename
{
    public class Validation
    {
        /// <summary>
        /// Validate path not null or empty.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ValidatePathGiven(string path)
        {
            // Get target directory.
            if (path.Length == 0)
            {
                Console.WriteLine("No target directory specified.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validate path is absolute and complete.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ValidatePathAbsolute(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || Uri.IsWellFormedUriString(path, UriKind.Absolute))
            {
                Console.WriteLine("Invalid target directory. Must be absolute path.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate given path points to a directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool ValidatePathPointsToValidDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Given directory does not exist.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate we have not been given an empty directory.
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public bool ValidateDirectoryContainsFiles(List<FileInfo> files)
        {
            if (files == null || !files.Any())
            {
                Console.WriteLine("Given directory is empty.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validate given directory's files are all of the same type.
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public bool ValidateDirectoryContentsHaveSameExtension(List<FileInfo> files)
        {
            var extension = files.First().Extension;

            var differentExtenstions = files.Where(x => x.Extension != extension);

            if (differentExtenstions.Any())
            {
                Console.WriteLine($"All files must be same type. Not all files have extension {extension}");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Validate combination of flag and data. E.g prefix flag must be follwed by prefix.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool ValidateFlagOptionDataCombination(Flag flag)
        {
            switch(flag.Option)
            {
                case Constants.NumericalFlag:
                    return ValidateNumericalFlag(flag);

                case Constants.PrefixFlag:
                    return ValidatePrefixFlag(flag);

                // No flags.
                default:
                    return true;
            }
        }

        /// <summary>
        /// Validate input for numerical flag.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        private bool ValidateNumericalFlag(Flag flag)
        {
            return true;
        }

        /// <summary>
        /// Validate input for prefix flag.
        /// </summary>
        /// <param name="flags"></param>
        /// <returns></returns>
        private bool ValidatePrefixFlag(Flag flag)
        {
            // Must be both flag and data.
            if(string.IsNullOrEmpty(flag.Data) || string.IsNullOrWhiteSpace(flag.Data))
            {
                Console.WriteLine($"Prefix flag must be followed by prefix description.");
                return false;
            }

            // Prefix must not be longer than max characters.
            if(flag.Data.Length > Constants.MaxPrefixLength)
            {
                Console.WriteLine($"Max prefix length is {Constants.MaxPrefixLength}.");
                return false;
            }

            // Validate prefix does not contain illegal characters.
            var invalidChars = flag.Data.IndexOfAny(Path.GetInvalidFileNameChars());
            if(invalidChars > 0)
            {
                Console.WriteLine($"Prefix cannot contain illegal characters.");
                return false;
            }

            return true;
        }
    }
}