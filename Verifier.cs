using System.Collections.Generic;
using System.Dynamic;
using System.IO;

namespace Rename
{   
    public class Verifier
    {
        private Validation Validator { get; set; }

        public Verifier()
        {
            Validator = new Validation();
        }
        
        /// <summary>
        /// Verify path from command line.
        /// </summary>
        /// <param name="input"></param>
        public bool VerifyPathParam(string path)
        {
            if (!Validator.ValidatePathGiven(path))
                return false;

            if (!Validator.ValidatePathAbsolute(path))
                return false;

            return Validator.ValidatePathPointsToValidDirectory(path);
        }

        /// <summary>
        /// Verify the contents of the provided directory.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        public bool VerifyDirectoryContents(List<FileInfo> contents)
        {
            if (!Validator.ValidateDirectoryContainsFiles(contents))
                return false;

            return Validator.ValidateDirectoryContentsHaveSameExtension(contents);
        }

        /// <summary>
        /// Verify valid combination of flag data from input.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool VerifyFlag(Flag flag)
        {
            return Validator.ValidateFlagOptionDataCombination(flag);
        }
    }
}