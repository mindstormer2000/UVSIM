/// AUTHOR: Emily Starks
/// Milestone #3
/// Date: 04/15/2018

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UVSim.AddressSpace;
using UVSim.Threading;
using UVSim.IO;
using UVSIM.Properties;
using System.IO;

namespace UVSIM
{
    public partial class MainForm : Form
    {
        private const int GRID_INSTRUCTION_IDX = 1;
        private const int GRID_BREAK_IDX = 0;
        private IOBus bus;

        /// <summary>
        /// Instantiates a new form instance and creates a new IOBus object for use with processors
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            bus = new IOBus(ExecuteGUIAction,
                                    DisplayMemory,
                                    PromptUserForInput,
                                    PromptUserForSixDigitInput,
                                    DisplayRuntimeData,
                                    DisplayOutput);
            ResetForm();
        }

        

        #region Template Helper Methods
        /// <summary>
        /// Returns a string in the format "+000...". The number of zeros depends on <see cref="INSTRUCTION_LENGTH"/>.
        /// </summary>
        private string GetNullInstruction()
        {
            string nullInstruction = "+";
            return nullInstruction.PadRight(Settings.Default.InstructionSize, '0');
        }

        /// <summary>
        /// Returns a string in the format "+###...". The number of '#' symbols depends on <see cref="INSTRUCTION_LENGTH"/>.
        /// </summary>
        private string GetInstructionPlaceholder()
        {
            string instructionPlaceholder = "";
            return instructionPlaceholder.PadRight((Settings.Default.InstructionSize - 1), '#');
        }
        private object GetSixInstructionPlaceholder()
        {
            string instructionPlaceholder = "";
            return instructionPlaceholder.PadRight((Settings.Default.SixDigitSize - 1), '#');
        }
        /// <summary>
        /// Gets the string format for the instruction labels depending on how large <see cref="MAX_INSTRUCTION_COUNT"/> is.
        /// </summary>
        private string GetStringFormat()
        {
            string stringFormat = "";
            for (int stringFormatIdx = 0; stringFormatIdx < (Settings.Default.MemorySize - 1).ToString().Length; stringFormatIdx++)
            {
                stringFormat += "0";
            }
            return stringFormat;
        }
        #endregion

        #region Validation Methods
        /// <summary>
        /// Validates the instructions (i.e. makes sure there are no empty instructions, instructions 
        /// missing digits or signs, or instructions with invalid opcodes)
        /// </summary>
        /// <returns>False if there was an instruction validation error; else, true</returns>
        private bool InstructionsValidated()
        {
            string error = string.Empty;
            string stringFormat = GetStringFormat();

            for (int idx = 0; idx < instructionsGridView.Rows.Count; idx++)
            {
                string instruction = instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value != null ?
                    instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value.ToString().Trim() : string.Empty;
                // Don't validate instructions of length 0
                if (instruction.Length != 0)
                {
                    InstructionError instructionError = ValidationEngine.ValidateInstruction(instruction);
                    if (instructionError == InstructionError.InvalidLength)
                    {
                        error = $"Instruction at row { idx.ToString(stringFormat) } needs to be " +
                            $"{ Settings.Default.InstructionSize } characters in length.";
                    }
                    else if (instructionError == InstructionError.SignMissing)
                    {
                        error = $"Instruction at row { idx.ToString(stringFormat) } is missing its sign (+ or -).";
                    }
                    else if (instructionError == InstructionError.InvalidCharacters)
                    {
                        error = $"Instruction at row { idx.ToString(stringFormat) } contains invalid characters.";
                    }
                }
            }

            if (error != string.Empty)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates instruction lines for the load instructions and edit instructions dialogs
        /// </summary>
        /// <param name="instructionLines">The list of lines to validate.</param>
        /// <returns>An empty string if there were no errors, otherwise, the error.</returns>
        private string ValidateInstructionsFromDialog(List<string> instructionLines)
        {
            // Show error if user entered more than MAX_INSTRUCTION_COUNT instructions
            if (instructionLines.Count > Settings.Default.MemorySize)
            {
                return $"Please enter {Settings.Default.MemorySize} or fewer instructions. You entered {instructionLines.Count}.";
            }
            else
            {
                // Validate each instruction
                foreach (string instructionLine in instructionLines)
                {
                    if (string.IsNullOrWhiteSpace(instructionLine))
                    {
                        return $"Error: Please do not enter any empty lines.";
                    }
                    else if (instructionLine[0] == '#')
                    {
                        if (!ValidationEngine.ValidateStartLocation(instructionLine.Substring(1, instructionLine.Length - 1)))
                        {
                            return $"Error: One of the '#' instructions is referencing an invalid memory location.";
                        }
                    }
                    else
                    {
                        InstructionError instructionError = ValidationEngine.ValidateInstruction(instructionLine);
                        if (instructionError == InstructionError.InvalidLength)
                        {
                            return $"Error: One of the instructions isn't { Settings.Default.InstructionSize } characters in length.";
                        }
                        else if (instructionError == InstructionError.SignMissing)
                        {
                            return "Error: One of the instructions does not start with a '+' or '-' sign.";
                        }
                        else if (instructionError == InstructionError.InvalidCharacters)
                        {
                            return "Error: One of the instructions contains invalid characters.";
                        }
                    }
                } // End foreach
                return string.Empty;
            }
        }
        #endregion

        /// <summary>
        /// // Initialize data grid view for the instructions
        /// </summary>
        private void InitializeInstructionInputGridView()
        {
            instructionsGridView.Rows.Clear();
            for (int idx = 0; idx < Settings.Default.MemorySize; idx++)
            {
                // Set header cell text to memory location 
                string indexString = idx.ToString(GetStringFormat());
                instructionsGridView.Rows.Add();
                instructionsGridView.Rows[idx].HeaderCell.Value = indexString;
                instructionsGridView[GRID_BREAK_IDX, idx].ReadOnly = false;
                instructionsGridView[GRID_INSTRUCTION_IDX, idx].ReadOnly = false;
                instructionsGridView[GRID_INSTRUCTION_IDX, idx].ToolTipText = $"Instruction Format: (+/-){GetInstructionPlaceholder()}";
            }
        }

        /// <summary>
        /// Gets the instructions from the instruction grid view
        /// </summary>
        private List<Instruction> GetInstructionsFromInstructionsGrid()
        {
            List<Instruction> instructions = new List<Instruction>();
            for (int idx = 0; idx < Settings.Default.MemorySize; idx++)
            {
                string instruction = instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value != null ?
                    instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value.ToString().Trim() : string.Empty;

                bool breakpoint = instructionsGridView[GRID_BREAK_IDX, idx].Value != null ?
                    (bool)instructionsGridView[GRID_BREAK_IDX, idx].Value : false;

                /// If the instruction is not empty, add it to the list; otherwise, add a <see cref="NULL_INSTRUCTION"/> entry.
                instructions.Add(new Instruction(breakpoint, instruction != "" ? instruction : GetNullInstruction())); 
            }
            return instructions;
        }

        /// <summary>
        /// Gets program starting locations.
        /// </summary>
        /// <returns>A list containing one or two starting locations. If program #2's starting location 
        /// was blank, only one starting location (program 1's)
        /// is returned. If program #1's starting location was blank, 0 is returned for program #1's 
        /// starting location.</returns>
        private List<int> GetProgramStartingLocations()
        {
            List<int> startingLocations = new List<int>();
            if (program1StartLocationTextBox.Text == string.Empty)
            {
                startingLocations.Add(0);
            }
            else
            {
                if (ValidationEngine.ValidateStartLocation(program1StartLocationTextBox.Text))
                {
                    startingLocations.Add(Convert.ToInt32(program1StartLocationTextBox.Text));
                }
                else
                {
                    MessageBox.Show($"Please enter a valid starting location for program 1.");
                }
            }
            if (Settings.Default.MultiThreaded)
            {
                if (program2StartLocationTextBox.Text == string.Empty)
                {
                    startingLocations.Add(0);
                }
                else
                {
                    if (ValidationEngine.ValidateStartLocation(program2StartLocationTextBox.Text))
                    {
                        startingLocations.Add(Convert.ToInt32(program2StartLocationTextBox.Text));
                    }
                    else
                    {
                        MessageBox.Show($"Please enter a valid starting location for program 2.");
                    }
                }
            }
            return startingLocations;
        }

        /// <summary>
        /// Click handler for instruction grid view breakpoint clicks
        /// </summary>
        private void instructionsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Only allow this method of setting a breakpoint in the memory when the program is executing.
            // All other times a breakpoint is set, it will be initialized in memory by the run button click event handler.
            if (!runButton.Enabled)
            {
                if (e.RowIndex >= 0 && e.RowIndex < instructionsGridView.Rows.Count && e.ColumnIndex == GRID_BREAK_IDX)
                {
                    DataGridViewCell cell = instructionsGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    bool cellChecked = cell.Value != null ? (bool)cell.Value : true;
                    Memory.Set(e.RowIndex, cellChecked, Memory.Get(e.RowIndex));
                }
            }
        }

        /// <summary>
        /// Calls the function that clears the form
        /// </summary>
        private void resetFormButton_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Clears the form
        /// </summary>
        private void ResetForm()
        {
            InitializeInstructionInputGridView();

            program1StartLocationTextBox.Clear();
            program2StartLocationTextBox.Clear();

            outputTextBox.Clear();

            pcValueLabel1.Text = string.Empty;
            acuValueLabel1.Text = string.Empty;
            statusCodeValueLabel1.Text = string.Empty;
            pcValueLabel2.Text = string.Empty;
            acuValueLabel2.Text = string.Empty;
            statusCodeValueLabel2.Text = string.Empty;

            memoryGridView.Rows.Clear();

            if (Settings.Default.MultiThreaded)
            {
                p2StartingLocationLabel.Visible = true;
                program2StartLocationTextBox.Visible = true;
                runtimeDataPanel2.Visible = true;
            }
            else
            {
                p2StartingLocationLabel.Visible = false;
                program2StartLocationTextBox.Visible = false;
                runtimeDataPanel2.Visible = false;
            }
        }

        /// <summary>
        /// Set the Enabled property of controls on the form.
        /// </summary>
        /// <param name="value">True or false.</param>
        private void ControlsEnabled(bool value)
        {
            runButton.Enabled = value;
            resetFormButton.Enabled = value;
            for (int idx = 0; idx < instructionsGridView.Rows.Count; idx++)
            {
                instructionsGridView[GRID_INSTRUCTION_IDX, idx].ReadOnly = !value;
            }
            mainMenu.Enabled = value;
            stopButton.Enabled = !value;
            continueButton.Enabled = !value;

            program1StartLocationTextBox.ReadOnly = !value;
            program2StartLocationTextBox.ReadOnly = !value;
        }

        #region Processor Control Methods
        /// <summary>
        /// The event handler for the run button. Runs the BasicML program(s).
        /// </summary>
        private void runButton_Click(object sender, EventArgs e)
        {
            List<int> programStartingLocations = GetProgramStartingLocations();
            if (programStartingLocations.Count > 0 && InstructionsValidated())
            {
                // Clear processors and memory
                Memory.Clear();
                Scheduler.ClearScheduler();

                // Disable buttons and instruction grids so user can't change instructions while program is executing
                ControlsEnabled(false);

                // Initialize memory
                Memory.Initialize(GetInstructionsFromInstructionsGrid());

                // Start processor(s)  
                for (int processorIdx = 0; processorIdx < programStartingLocations.Count; processorIdx++)
                {
                    Scheduler.ScheduleProcessor(bus, processorIdx);
                    Scheduler.RunProcessor(processorIdx, programStartingLocations[processorIdx]);
                }
            }
        }

        /// <summary>
        /// Click event handler for the stop button.
        /// </summary>
        private void stopButton_Click(object sender, EventArgs e)
        {
            Scheduler.StopAllProcessors(true);
            ControlsEnabled(true);

            // Close all forms except the main form
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name != Name)
                {
                    if (form.InvokeRequired)
                    {
                        form.BeginInvoke((MethodInvoker)delegate () { form.Close(); });
                    }
                    else
                    {
                        form.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Click event handler for the continue button.
        /// </summary>
        private void continueButton_Click(object sender, EventArgs e)
        {
            Scheduler.ContinueAllProcessors();
        }
        #endregion

        #region IOBus Handler Methods
        /// <summary>
        /// Does a memory dump.
        /// </summary>
        /// <param name="runtimeData">Runtime data values (space delimited string with program counter, 
        /// ALU, and status code (in that order)).</param>
        private void DisplayMemory(string runtimeData)
        {

            // Enable buttons and instruction grid so user can enter new instructions
            ControlsEnabled(true);
            // Display runtime data
            DisplayRuntimeData(runtimeData);
            // Clear memory grid so we can display current data
            memoryGridView.Rows.Clear();
            // Display memory values
            List<Instruction> memory = Memory.Instructions;

            if (memory.Count > 0 && memory.Count <= Settings.Default.MemorySize)
            {
                string stringFormat = GetStringFormat();
                int memoryIdx = 0;
                for (int rowIdx = 0; rowIdx < Settings.Default.MemorySize / memoryGridView.Columns.Count; rowIdx++)
                {
                    string[] row = new string[memoryGridView.Columns.Count];
                    for (int columnIdx = 0; columnIdx < memoryGridView.Columns.Count; columnIdx++)
                    {
                        row[columnIdx] = (memory.Count > memoryIdx && memory[memoryIdx] != null && memory[memoryIdx].Value != null) ?
                            memory[memoryIdx++].Value : GetNullInstruction();
                    }
                    memoryGridView.Rows.Add(row);
                    memoryGridView.Rows[rowIdx].HeaderCell.Value = (rowIdx * memoryGridView.Columns.Count).ToString(stringFormat);
                }
            }
        }

        /// <summary>
        /// This function displays the runtime data.
        /// </summary>
        /// <param name="runtimeData">The processor index (0-based), the program counter, ALU, and 
        /// status code values (space delimited).</param>
        private void DisplayRuntimeData(string runtimeData)
        {
            int numOfValues = 4;
            // Display values
            if (runtimeData != null && runtimeData.Trim() != string.Empty)
            {
                string[] runtimeDataValues = runtimeData.Split(' ');
                if (runtimeDataValues.Length >= numOfValues)
                {
                    if (runtimeDataValues[0] == "0")
                    {
                        pcValueLabel1.Text = runtimeDataValues[1];
                        acuValueLabel1.Text = runtimeDataValues[2];
                        statusCodeValueLabel1.Text = runtimeDataValues[3];
                    }
                    else if (runtimeDataValues[0] == "1")
                    {
                        pcValueLabel2.Text = runtimeDataValues[1];
                        acuValueLabel2.Text = runtimeDataValues[2];
                        statusCodeValueLabel2.Text = runtimeDataValues[3];
                    }
                }
            }
        }

        /// <summary>
        /// Function that processor can call to get a value from the user
        /// </summary>
        private string PromptUserForInput()
        {
            string inputValue = string.Empty;
            string errorMessage = $"Please enter a value in the format '+{GetInstructionPlaceholder()}'" +
                $" or '-{GetInstructionPlaceholder()}'";
            // Create prompt
            Form inputPrompt = new Form()
            {
                Width = 350,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Input Value",
                StartPosition = FormStartPosition.CenterScreen
            };
            // Create prompt message label
            Label promptMessageLabel = new Label() { Left = 10, Top = 20, Width = 260, Text = $"{errorMessage}:" };
            inputPrompt.Controls.Add(promptMessageLabel);
            // Create prompt input textbox
            TextBox inputValueTextBox = new TextBox() { Left = 275, Top = 20, Width = 50 };
            inputPrompt.Controls.Add(inputValueTextBox);
            // Create event for when form X button is clicked
            inputPrompt.FormClosing += (sender, e) => {
                if (inputValue == string.Empty && !runButton.Enabled)
                {
                    promptMessageLabel.ForeColor = System.Drawing.Color.Red;
                    e.Cancel = true;
                }
            };
            // Create submit button
            Button submitButton = new Button() { Text = "Submit", Left = 150, Width = 50, Top = 50, DialogResult = DialogResult.OK };
            submitButton.Click += (sender, e) => {
                string inputValueTextBoxStr = inputValueTextBox.Text.Trim();
                if (ValidationEngine.ValidateInstruction(inputValueTextBoxStr) == InstructionError.None)
                {
                    inputValue = inputValueTextBoxStr;
                    inputPrompt.Close();
                }
                else
                {
                    promptMessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            };
            inputPrompt.Controls.Add(submitButton);
            // Show form
            inputPrompt.ShowDialog();
            // Pass callback function the value the user entered
            return inputValue;
        }
        /// <summary>
        /// Function that processor can call to get a six digit value from the user
        /// </summary>
        private string PromptUserForSixDigitInput()
        {
            string inputValue = string.Empty;
            string errorMessage = $"Please enter a value in the format '+{GetSixInstructionPlaceholder()}'" +
                $" or '-{GetSixInstructionPlaceholder()}'";
            // Create prompt
            Form inputPrompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Input Value",
                StartPosition = FormStartPosition.CenterScreen
            };
            // Create prompt message label
            Label promptMessageLabel = new Label() { Left = 10, Top = 20, Width = 290, Text = $"{errorMessage}:" };
            inputPrompt.Controls.Add(promptMessageLabel);
            // Create prompt input textbox
            TextBox inputValueTextBox = new TextBox() { Left = 300, Top = 20, Width = 75 };
            inputPrompt.Controls.Add(inputValueTextBox);
            // Create event for when form X button is clicked
            inputPrompt.FormClosing += (sender, e) => {
                if (inputValue == string.Empty && !runButton.Enabled)
                {
                    promptMessageLabel.ForeColor = System.Drawing.Color.Red;
                    e.Cancel = true;
                }
            };
            // Create submit button
            Button submitButton = new Button() { Text = "Submit", Left = 150, Width = 50, Top = 50, DialogResult = DialogResult.OK };
            submitButton.Click += (sender, e) => {
                string inputValueTextBoxStr = inputValueTextBox.Text.Trim();
                if (ValidationEngine.ValidateInstruction(inputValueTextBoxStr) == InstructionError.None)
                {
                    inputValue = inputValueTextBoxStr;
                    inputPrompt.Close();
                }
                else
                {
                    promptMessageLabel.ForeColor = System.Drawing.Color.Red;
                }
            };
            inputPrompt.Controls.Add(submitButton);
            // Show form
            inputPrompt.ShowDialog();
            // Pass callback function the value the user entered
            return inputValue;
        }

        

        /// <summary>
        /// Function that processor can call to output a message to the user in the output text box
        /// </summary>
        /// <param name="output">The output to display.</param>
        private void DisplayOutput(string output)
        {
            outputTextBox.Text += output + Environment.NewLine;
        }

        /// <summary>
        /// Function for outside parties to call in order to execute one of the GUI's display functions on the correct thread.
        /// </summary>
        /// <param name="actionToExecute">The display function to call.</param>
        /// <param name="actionParameter">The parameter for the display function (i.e. what we want to display)</param>
        private void ExecuteGUIAction(Action<string> actionToExecute, string actionParameter)
        {
            Object lockObj = new Object();
            lock (lockObj)
            {
                // Make sure we're on the right thread, then call the function
                if (InvokeRequired)
                {
                    BeginInvoke((MethodInvoker)delegate () { actionToExecute(actionParameter); });
                }
                else
                {
                    actionToExecute(actionParameter);
                }
            }
        }
        #endregion

        #region Edit/Load/Save Instructions Form Methods
        /// <summary>
        /// Displays a text box that the user can paste instructions into; once the user clicks Load then the instructions are loaded into the 
        /// individual instruction cells. (This makes it easier to run pre-composed programs.)
        /// </summary>
        private void editInstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceCommitOfLastInstructionUserTouched();

            string instructions = string.Empty;

            // Create form for instruction loading
            Form loadInstructionsForm = new Form()
            {
                Width = 495,
                Height = 500,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Load Instructions",
                StartPosition = FormStartPosition.CenterScreen
            };
            // Create label to instruct the user what to do
            Label label = new Label() { Left = 10, Top = 10, Width = 500,
                Text = $"Please enter up to { Settings.Default.MemorySize.ToString() } instructions, with one instruction per " +
                $"line in the format '+{GetInstructionPlaceholder()}' or '-{GetInstructionPlaceholder()}'." };
            loadInstructionsForm.Controls.Add(label);

            // Create error label
            Label errorLabel = new Label() { Left = 10, Top = 35, Width = 500, ForeColor = System.Drawing.Color.Red, Text = "",
                Name = "loadInstructionsErrorLabel" };
            loadInstructionsForm.Controls.Add(errorLabel);

            // Create textbox label
            Label program1Label = new Label() { Left = 10, Top = 60, Width = 150, Text = "Program Instructions:" };
            loadInstructionsForm.Controls.Add(program1Label);

            // Create instructions input textbox
            TextBox program1TextBox = new TextBox() { Left = 10, Top = 85, Width = 460, Height = 330, Multiline = true,
                ScrollBars = ScrollBars.Both, Name = "loadInstructionsProgram1Textbox", Text = GetInstructionsAsAString(),
                SelectedText = ""};
            loadInstructionsForm.Controls.Add(program1TextBox);

            // Create submit button
            Button submitButton = new Button() { Text = "Load", Left = 215, Width = 50, Top = 420, TabIndex = 0 };
            submitButton.Click += EditInstructionsSubmitButtonClick;
            loadInstructionsForm.Controls.Add(submitButton);

            loadInstructionsForm.Show();
        }

        /// <summary>
        /// Gets the current instructions from the data grid view
        /// </summary>
        /// <returns>A string of the current instructions, separated by newlines.</returns>
        private string GetInstructionsAsAString()
        {
            // Get instructions from grid
            bool loadFlagNeeded = false;
            List<string> instructionStrs = new List<string>();

            for (int idx = 0; idx < Settings.Default.MemorySize; idx++)
            {
                string instruction = instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value != null ?
                    instructionsGridView[GRID_INSTRUCTION_IDX, idx].Value.ToString().Trim() : string.Empty;

                if (instruction != string.Empty)
                {
                    if (loadFlagNeeded)
                    {
                        instructionStrs.Add("#" + idx.ToString().PadLeft((Settings.Default.MemorySize - 1).ToString().Length, '0')); // Add load instruction
                        loadFlagNeeded = false;
                    }
                    instructionStrs.Add(instruction);
                }
                else
                {
                    loadFlagNeeded = true;
                }
            }

            // If a "#" instruction is the last instruction, remove it
            if (instructionStrs.Count > 0 && instructionStrs[instructionStrs.Count - 1][0] == '#')
            {
                instructionStrs.RemoveAt(instructionStrs.Count - 1);
            }

            // Create string from list
            string instructionStr = string.Empty;
            for (int idx = 0; idx < instructionStrs.Count; idx++)
            {
                instructionStr += instructionStrs[idx] + Environment.NewLine;
            }

            return instructionStr;
        }

        /// <summary>
        /// Click event handler for the submit button on the load instructions dialog.
        /// </summary>
        private void EditInstructionsSubmitButtonClick(object sender, EventArgs e)
        {
            Form loadInstructionsForm = (sender as Button).FindForm();
            Label errorLabel = loadInstructionsForm.Controls.Find("loadInstructionsErrorLabel", false).FirstOrDefault() as Label;
            TextBox programTextBox = loadInstructionsForm.Controls.Find("loadInstructionsProgram1Textbox", false).FirstOrDefault() as TextBox;

            // Get program instructions
            string programString = programTextBox.Text.Trim();
            List<string> programLines = programString.Split(("\r\n").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            string errorString = ValidateInstructionsFromDialog(programLines);
            if (errorString == string.Empty)
            {
                LoadInstructionsIntoDataGridView(programLines);
                runButton.Focus();
                loadInstructionsForm.Close();
            }
            else
            {
                errorLabel.Text = errorString;
            }
        }

        /// <summary>
        /// Handles loading instructions from a file
        /// </summary>
        private void loadInstructionsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string instructionsFileStr = FileIO.LoadInstructions();

                // Parse program instructions
                List<string> programLines = instructionsFileStr.Trim().Split(("\r\n").ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                string errorString = ValidateInstructionsFromDialog(programLines);
                if (errorString == string.Empty)
                {
                    LoadInstructionsIntoDataGridView(programLines);
                }
                else
                {
                    MessageBox.Show(errorString, "Instruction Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }

        /// <summary>
        /// Saves instructions from the datagridview into a file
        /// </summary>
        private void saveInstructionsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ForceCommitOfLastInstructionUserTouched();
            try
            {
                FileIO.SaveInstructions(GetInstructionsAsAString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not write instructions to file. Original error: " + ex.Message);
            }
        }

        /// <summary>
        /// Takes a list of instructions as strings and populates the data grid view with them
        /// </summary>
        /// <param name="programLines">A list of instructions</param>
        private void LoadInstructionsIntoDataGridView(List<string> programLines)
        {
            // Load instructions into data grid views
            ResetForm();
            int memoryIdx = 0;
            for (int idx = 0; idx < programLines.Count; idx++)
            {
                if (programLines[idx][0] == '#')
                {
                    memoryIdx = Convert.ToInt32(programLines[idx].Substring(1, programLines[idx].Length - 1));
                }
                else
                {
                    // Check to ensure that the memory index is 0 or greater (to ensure it's within available address space).
                    if (memoryIdx >= 0 && memoryIdx < instructionsGridView.Rows.Count)
                    {
                        instructionsGridView[GRID_INSTRUCTION_IDX, memoryIdx].Value = programLines[idx];
                        memoryIdx++;
                    }
                }
            }
        }

        /// <summary>
        /// If the user clicks on this control without clicking off of a cell in the datagridview, this method ensures
        /// that the cell's contents are saved
        /// </summary>
        private void ForceCommitOfLastInstructionUserTouched()
        {
            runButton.Focus();
        }
        #endregion

        #region Settings Management Methods
        /// <summary>
        /// Click event handler for the manage settings button.
        /// </summary>
        private void manageSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create form for instruction loading
            Form settingsForm = new Form()
            {
                Width = 300,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Manage Settings",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label memorySizeLabel = new Label() { Left = 10, Top = 10, Width = 70, Text = "Memory size: " };
            settingsForm.Controls.Add(memorySizeLabel);
            
            ComboBox memorySizeDropDownBox = new ComboBox() { Left = 80, Top = 7, Width = 50, Name = "memorySizeDropDownBox" };
            memorySizeDropDownBox.Items.Add(100);
            memorySizeDropDownBox.Items.Add(1000);
            memorySizeDropDownBox.SelectedIndex = memorySizeDropDownBox.Items.IndexOf(Settings.Default.MemorySize);
            settingsForm.Controls.Add(memorySizeDropDownBox);

            CheckBox multiThreadingCheckBox = new CheckBox() { Left = 12, Top = 35, Width = 150, Checked = Settings.Default.MultiThreaded, Text = "Allow multithreading", Name = "multiThreadingCheckBox" };
            settingsForm.Controls.Add(multiThreadingCheckBox);

            // Create submit button
            Button saveButton = new Button() { Text = "Save", Left = 95, Width = 50, Top = 220 };
            saveButton.Click += ManageSettingsSaveButton_Click;
            settingsForm.Controls.Add(saveButton);

            // Create cancel button
            Button cancelButton = new Button() { Text = "Cancel", Left = 155, Width = 50, Top = 220 };
            cancelButton.Click += ManageSettingsCancelButton_Click;
            settingsForm.Controls.Add(cancelButton);

            // Show form
            settingsForm.Show();
        }

        /// <summary>
        /// Click event handler for the manage settings save button.
        /// </summary>
        private void ManageSettingsSaveButton_Click(object sender, EventArgs e)
        {
            Form settingsForm = (sender as Button).FindForm();
            ComboBox memorySizeDropDownBox = settingsForm.Controls.Find("memorySizeDropDownBox", false).FirstOrDefault() as ComboBox;
            CheckBox multiThreadingCheckBox = settingsForm.Controls.Find("multiThreadingCheckBox", false).FirstOrDefault() as CheckBox;

            Settings.Default.MemorySize = (int)memorySizeDropDownBox.SelectedItem;
            Settings.Default.MultiThreaded = multiThreadingCheckBox.Checked;
            Settings.Default.Save();

            ResetForm();

            settingsForm.Close();
        }

        /// <summary>
        /// Click event handler for the manage settings cancel button.
        /// </summary>
        private void ManageSettingsCancelButton_Click(object sender, EventArgs e)
        {
            Form settingsForm = (sender as Button).FindForm();
            settingsForm.Close();
        }
        #endregion
    }
}
