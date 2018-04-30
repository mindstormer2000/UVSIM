using System.Text.RegularExpressions;
using UVSIM.Properties;

namespace UVSIM
{
    /// <summary>
    /// Represents the errors that can be returned from the <c>ValidationEngine</c>
    /// </summary>
    public enum InstructionError
    {
        None = 0,
        InvalidLength = 1,
        SignMissing = 2,
        InvalidCharacters = 3
    }

    /// <summary>
    /// An engine used to verify that instructions provided are valid in length, signs, and characters
    /// </summary>
    public static class ValidationEngine
    {
        /// <summary>
        /// Makes sure an instruction meets formatting requirements
        /// </summary>
        /// <param name="instruction">The instruction to validate</param>
        /// <returns>An error code depending on what didn't validate</returns>
        public static InstructionError ValidateInstruction(string instruction)
        {
            Regex regex = new Regex(@"^[\+-]");
            // Ensure proper length
            if (instruction.Length != Settings.Default.InstructionSize && instruction.Length != Settings.Default.SixDigitSize)
            {
                return InstructionError.InvalidLength;
            }
            
            // Ensure a valid sign is present
            if (!regex.IsMatch(instruction))
            {
                return InstructionError.SignMissing;
            }
            // Ensure all characters following sign are digits
            string text = instruction.Substring(1, instruction.Length - 1);
            if (!AllDigits(instruction.Substring(1, instruction.Length - 1)))
            {
                return InstructionError.InvalidCharacters;
            }
            return InstructionError.None;
        }

        /// <summary>
        /// Validates that the provided input is a valid start location
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateStartLocation(string value)
        {
            Regex regex = new Regex(@"^\d{1," + $"{(Settings.Default.MemorySize - 1).ToString().Length}" + "}$");
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Checks a string to make sure all of its characters are digits (0-9). 
        /// </summary>
        /// <param name="strToCheck">The string to check, must be of valid length</param>
        /// <returns>Returns true if all of the characters are digits</returns>
        public static bool AllDigits(string value)
        {
            // Instantiate a Regex object to check for all digits (using instruction size - 1 
            // to determine number of characters to check).
            Regex regex = new Regex(@"^\d{" + $"{Settings.Default.InstructionSize-1}" + "}$");
            if (!regex.IsMatch(value))
            {
                regex = new Regex(@"^\d{" + $"{Settings.Default.SixDigitSize - 1}" + "}$");
            }
            return regex.IsMatch(value);
        }
    }
}
