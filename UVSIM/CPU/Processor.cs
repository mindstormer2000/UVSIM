/// AUTHORS: Caiden Kehrer
/// Milestone #1
/// Date: 2/15/2018

using System;
using System.Threading;
using UVSim.IO;
using UVSim.AddressSpace;

namespace UVSim.CPU
{
    /// <summary>
    /// Caiden Kehrer
    /// </summary>
    public class Processor
    {
        #region Internal Variables
        
        /// <summary>
        /// This is the IOBUS, It will be swapped out later for IObus instead of GuiInteract.
        /// </summary>
        public IOBus Bus { get; private set; }
        /// <summary>
        /// The internal registers that can be set
        /// </summary>
        protected Registers register;
        /// <summary>
        /// The ArithmeticLogicUnit is in control of all mathematical operations.
        /// </summary>
        protected ArithmeticLogicUnit ALU;

        private const int CLOCKRATE = 100;

        #endregion

        /// <summary>
        /// Instantiates a new Processor object, and start the Processor thread
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// Brad V.
        /// </remarks>
        /// <param name="bus">GUI interface for input and output of data</param>
        public Processor(IOBus bus)
        {
            // Internal component instantiation
            register.Status = 0;
            register.ProgramCounter = 0;
            register.Accumulator = 0;
            ALU = new ArithmeticLogicUnit();
            Bus = bus;
        }

        /// <summary>
        /// Instantiates a new Processor object, and start the Processor thread
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// Brad V.
        /// </remarks>
        /// <param name="pc">Starting memory address for the processor to run</param>
        /// <param name="bus">GUI interface for input and output of data</param>
        public Processor(IOBus bus, int pc)
            : this(bus)
        {
            register.ProgramCounter = pc;
        }
        
        /// <summary>
        /// Sets the Program Counter register with the line to start at
        /// </summary>
        /// <remarks>
        /// Caiden K.
        /// Brad V.
        /// </remarks>
        /// <param name="pc">Starting memory address for the processor to run</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown if the pc is not addressible</exception>
        public virtual void Run(int pc)
        {
            // Ensure pc is addressible
            if (pc < 0)
            {
                throw new ArgumentOutOfRangeException($"Program Counter address {pc} is not valid");
            }
            register.ProgramCounter = pc;
            register.IsRunning = true;
            //start the sequncer thread
            Thread sequencer = new Thread(Process);
            sequencer.Start();
        }

        /// <summary>
        /// Takes input opcode and operand and returns an <c>Action</c> to be performed
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        protected void Process()
        {
            Action command;
            string opcode;
            string param;

            while (register.IsRunning)
            {
                // if there is a breakpoint at line x, drop into a loop until the breakpoint is removed
                if (register.Status == StatusCode.Breakpoint||Memory.HasBreakpoint(register.ProgramCounter))
                {
                    Alert($"Breakpoint executed at line {register.ProgramCounter}");
                    register.Status = StatusCode.Breakpoint;
                    UpdateRuntimeData();
                    while (register.Status == StatusCode.Breakpoint)
                    {
                        Thread.Sleep(CLOCKRATE);
                    }

                }

                //get the first two digits which are the command
                opcode = Memory.Get(register.ProgramCounter).Substring(1, 2);
                //get the last two digits which are the parameters
                param = Memory.Get(register.ProgramCounter).Substring(3, 2);
                try
                {
                    UpdateRuntimeData();
                    // Decode the two digit opcode, utilizing the operand as necessary. Once a valid 
                    // operation is returned, assign it to the command action variable and execute.
                    command = Decode(opcode, param);
                    command.Invoke();
                    register.ProgramCounter++;
                    // Update GUI with the data in the registers
                    UpdateRuntimeData();
                }
                catch (InvalidOperationException ex)
                {
                    register.Status |= StatusCode.InvalidOperation;
                    Alert(ex.Message);
                    UpdateRuntimeData();
                    Bus.MemDump(register.Accumulator.ToString());
                    register.IsRunning = false;
                }
                catch (IndexOutOfRangeException ex)
                {
                    register.Status |= StatusCode.OutOfMemory;
                    UpdateRuntimeData();
                    Alert(ex.Message);
                    register.IsRunning = false;
                }
                //pause thread just to make things readable as well as for keeping up speed
                Thread.Sleep(CLOCKRATE);
            }
        }

        /// <summary>
        /// Takes input opcode and operand and returns an <c>Action</c> to be performed
        /// </summary>
        /// <remarks>
        /// Contributors:
        /// Brad V.
        /// Caiden K.
        /// </remarks>
        /// <param name="opcode">Instruction to decode</param>
        /// <param name="operand">Memory address to be used in instruction</param>
        /// <returns>Command to be executed</returns>
        /// <exception cref="System.InvalidOperationException">Thrown if the user enters and invalid opcode</exception>
        private Action Decode(string opcode, string operand)
        {
            switch (opcode)
            {
                #region Program IO Cases
                case "10": //Read - Caiden Kehrer
                    return () =>
                    {
                        string input;
                        if (operand[0] == '1')
                        {
                            input = Bus.OnReadSixDigitValue();
                            string[] inputs = FormatCodeSix(int.Parse(input));
                            Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1)), inputs[0]);
                            Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1, inputs[1]);
                        }
                        else if (operand[0] == '0')
                        {
                            input = Bus.OnReadValue();
                            Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1)), input);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                        }
                        
                       
                        register.ProgramCounter++;
                    };
                case "11": //Write - Caiden Kehrer
                    return () =>
                    {
                        if (operand[0] == '1')
                        {
                            Alert($"The 6 digit memory starting at address {int.Parse(Memory.Get(register.ProgramCounter + 1))} is {int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))))}{int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))+1).Substring(1,2))}");
                        }
                        else if (operand[0]=='0')
                        {
                            Alert($"The memory at address {int.Parse(Memory.Get(register.ProgramCounter + 1))} is {int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))))}");
                        }
                        else
                        {
                            throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                        }
                        register.ProgramCounter++;
                    };
                #endregion

                #region Memory Manipulation Cases
                case "20": //Load - Caiden Kehrer
                    
                    if (operand[0] == '1')
                    {
                        register.Accumulator = int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)))+(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2)));
                    }
                    else if (operand[0] == '0')
                    {
                        register.Accumulator = int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    register.ProgramCounter++;
                    break;
                case "21": //Store - Caiden Kehrer
                    
                    if (operand[0] == '1')
                    {
                        Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1)), $"{FormatCodeSix(register.Accumulator)[0]}");
                        Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1))+1, $"{FormatCodeSix(register.Accumulator)[1]}");
                    }
                    else if (operand[0] == '0')
                    {
                        Memory.Set(int.Parse(Memory.Get(register.ProgramCounter + 1)), $"{FormatCodeFour(register.Accumulator)}");
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    register.ProgramCounter++;
                    break;
                #endregion
                /*
                    if (operand[0] == '1')
                    {

                    }
                    else if (operand[0] == '0')
                    {

                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                */
                #region ALU Cases
                case "30": // Addition - Brad V, Caiden K.
                    if (operand[0] == '1')
                    {
                        ALU.InputB = Convert.ToInt32(int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))) + (Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2))));
                    }
                    else if (operand[0] == '0')
                    {
                        ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    ALU.InputA = register.Accumulator;
                    return () =>
                    {
                        ALU.Add();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                
                case "31": // Subtraction - Brad V, Caiden K.
                    ALU.InputA = register.Accumulator;
                    ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter+1))));
                    return () =>
                    {
                        ALU.Subtract();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                case "32": // Division - Brad V, Caiden K.
                    ALU.InputA = register.Accumulator;
                    if (operand[0] == '1')
                    {
                        ALU.InputB = Convert.ToInt32(int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))) + (Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2))));
                    }
                    else if (operand[0] == '0')
                    {
                        ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    return () =>
                    {
                        ALU.Divide();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                case "33": // Multiplication - Brad V, Caiden K.
                    ALU.InputA = register.Accumulator;
                    if (operand[0] == '1')
                    {
                        ALU.InputB = Convert.ToInt32(int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))) + (Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2))));
                    }
                    else if (operand[0] == '0')
                    {
                        ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    return () =>
                    {
                        ALU.Multiply();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                case "34": // Exponent - Brad V, Caiden K.
                    ALU.InputA = register.Accumulator;
                    if (operand[0] == '1')
                    {
                        ALU.InputB = Convert.ToInt32(int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))) + (Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2))));
                    }
                    else if (operand[0] == '0')
                    {
                        ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    return () =>
                    {
                        ALU.Exponent();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                case "35": // Modulo - Brad V, Caiden K.
                    ALU.InputA = register.Accumulator;
                    if (operand[0] == '1')
                    {
                        ALU.InputB = Convert.ToInt32(int.Parse(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))) + (Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1)) + 1).Substring(1, 2))));
                    }
                    else if (operand[0] == '0')
                    {
                        ALU.InputB = Convert.ToInt32(Memory.Get(int.Parse(Memory.Get(register.ProgramCounter + 1))));
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}: the operand Was not a 10 or a 00");
                    }
                    return () =>
                    {
                        ALU.Modulo();
                        register.Accumulator = ALU.Output;
                        register.ProgramCounter++;
                    };
                #endregion

                #region Branch Operations Cases
                case "40": // Branch
                    register.ProgramCounter = int.Parse(Memory.Get(register.ProgramCounter+1))-1;
                    break;
                case "41": //BranchNeg
                    if (register.Accumulator < 0)
                    {
                        register.ProgramCounter = int.Parse(Memory.Get(register.ProgramCounter + 1)) - 1;
                    }
                    else
                    {
                        register.ProgramCounter++;
                    }
                    break;
                case "42": //BranchZero
                    if (register.Accumulator == 0)
                    {
                        register.ProgramCounter = int.Parse(Memory.Get(register.ProgramCounter+1)) - 1;
                    }
                    else
                    {
                        register.ProgramCounter++;
                    }
                    break;
                case "43": // Halt
                    register.IsRunning = false;
                    return () =>
                    {
                        Bus.MemDump(register.Accumulator.ToString());
                        Bus.OnUpdateRuntimeData(register.Accumulator.ToString());
                    };
                #endregion

                default:
                    // If they entered in an incorrect instruction and asked the processor to process it, let it break
                    throw new InvalidOperationException($"Unable to process instruction at address {register.ProgramCounter}");
            }
            return () => { return; };
        }
        
        /// <summary>
        /// Displays the value passed to the <c>IOBus</c> for output
        /// </summary>
        /// <param name="value">Information to be displayed on Output</param>
        public virtual void Alert(string value) {
            Bus.OnDisplay(value);
        }

        /// <summary>
        /// Sends runtime data to the interface
        /// </summary>
        public virtual void UpdateRuntimeData()
        {
            Bus.OnUpdateRuntimeData($"{register.ProgramCounter} {register.Accumulator} {register.Status}");
        }

        /// <summary>
        /// This code automatically formats the given input and returns it as a formatted <c>String</c> (+/-####)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Formatted string</returns>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        internal string FormatCodeFour(int input)
        {
            const int INSTRUCTION_LENGTH = 4;
            string output = input.ToString();
            // Strips out the minus sign for the purpose of padding the data with 0's
            if (input < 0)
            {
                output = output.Substring(1,output.Length-1);
            }
            output = output.PadLeft(INSTRUCTION_LENGTH, '0');
            if (input < 0)
            {
                output = "-" + output;
            }
            else
            {
                output = "+" + output;
            }
            return output;
        }
        /// <summary>
        /// This code automatically formats the given input and returns it as a formatted <c>String</c> (+/-####)
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Formatted string</returns>
        /// Contributors:
        /// Caiden K.
        /// </remarks>
        private string[] FormatCodeSix(int input)
        {
            const int INSTRUCTION_LENGTH = 6;
            string stInput = input.ToString();
            // Strips out the minus sign for the purpose of padding the data with 0's
            if (input < 0)
            {
                stInput = stInput.Substring(1, stInput.Length - 1);
            }
            stInput = stInput.PadLeft(INSTRUCTION_LENGTH, '0');
            if (input < 0)
            {
                stInput = "-" + stInput;
            }
            else
            {
                stInput = "+" + stInput;
            }
            string[] output = { stInput.Substring(0,5) ,"+"+ stInput.Substring(5, 2) +"00"};

            return output;
        }
        /// <summary>
        /// This code allows for outside acsees to the pausing and breaking of a processor
        /// </summary>
        /// <param name="halt">Flag if the Processor should completely stop, or pause (breakpoint)</param>
        public virtual void Stop(bool halt = true) {
            if (halt)
            {
                register.IsRunning = false;
            }
            else {
                register.Status = StatusCode.Breakpoint;
            }
        }

        /// <summary>
        /// Starts the processor if it's in a Breakpoint status
        /// </summary>
        public void Continue()
        {
            if (register.Status == StatusCode.Breakpoint)
            { 
                Alert("Breakpoint continued.");
                register.Status = StatusCode.None;
            }
        }
    } // End Processor
}
