/// AUTHOR: Emily Starks
/// Milestone #3
/// Date: 04/15/2018

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace UVSIM
{
    public static class FileIO
    {
        /// <summary>
        /// Loads instructions from a file
        /// </summary>
        /// <returns>The instructions</returns>
        public static string LoadInstructions()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "BML files (*.bml)|*.bml";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Open the text file using a stream reader.
                using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
                {
                    // Read the stream to a string
                    string instructionsFileStr = streamReader.ReadToEnd();
                    return instructionsFileStr;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Saves a string of instructions to a file
        /// </summary>
        /// <param name="instructions">The instructions</param>
        public static void SaveInstructions(string instructions)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "BML files (*.bml)|*.bml";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    // Get program instructions
                    streamWriter.Write(instructions);
                }
            }
        }
    }
}
