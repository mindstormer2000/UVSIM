# UVSim

### Description

Basic processor for use with education of computer architecture. Runs the Basic Machine Language (BasicML) ISA.

**Contributors:**

* Riley G
* Caiden K
* Emily S
* Brad V

![Initial application startup](http://vanfleet.ddns.net/InnovatED/UVSim/raw/master/Docs/Screenshots/InitialStartup.PNG)

---

## Installation

The UVSim is a self-contained binary application that can be run without the need to install library files or configure registry keys. To run the application, copy and paste the UVSim.exe application file to a desired location and double-click to execute.

To run from source, open the UVSIM.sln file from Visual Studio 2017 and build or use the following MSBuild command

```
msbuild UVSIM.sln /target:exe
```

Once complete, you should have the UVSim.exe application binary to run.

---

## Entering Instructions

### Manually Typing in

In order to run the processor, program instructions must be entered. With the application running, Enter into a memory address space and enter a valid data (e.g. `+1002`).

![Instructions entered into the UVSim](http://vanfleet.ddns.net/InnovatED/UVSim/raw/master/Docs/Screenshots/InstructionsLoaded.PNG)

Input is strictly limited to entering the sign of the data (+/-) followed by four digits.

![User prompt for input](http://vanfleet.ddns.net/InnovatED/UVSim/raw/master/Docs/Screenshots/PromptForInput.PNG)

### Batch Load

Pressing `CTRL + L` opens the load commands window.

You may copy and paste your entire script in here. Press the "Load" button to load the instructions into memory.

The Symbol # is added in this mode. The pound key jumps to a location in memory and sequentially continues adding data till the end of file.

![User prompt for input](http://vanfleet.ddns.net/InnovatED/UVSim/raw/master/Docs/Screenshots/BulkLoad.PNG)

---

## Running a Program

Once all instructions for your BML program has been entered in, you can then press "Run" to start the processor.

![Finished program run in UVSim](http://vanfleet.ddns.net/InnovatED/UVSim/raw/master/Docs/Screenshots/ProgramFinished.PNG)

---

## Instruction set

Instructions have three key parts
A + or a - sign followed by two digits(the opcode) followed by two more digits(the operand)

### Read

```
Opcode					-	10
Operand use				-	None
Next instruction use	-	Location to store the read in data
Notes					-	Takes input from the user and stores it in memory at a given location
```

### Write

```
Opcode					-	11
Operand use				-	None
Next instruction use	-	Location of data to write
Notes					-	Takes a given location and outputs that locations data to the user
```

### Load

```
Opcode					-	20
Operand use				-	none
Next instruction use	-	Location of data to load into Accumulator
Notes					-	Loads a given locations data into the Accumulator
```

### Store

```
Opcode					-	21
Operand use				-	None
Next instruction use	-	Location to store the Accumulator
Notes					-	Stores the data within the Accumulator into the given location
```

## ArithmeticLogicUnit Notes

When performing ALU operations, values greater than what the Accumulator is set for (4 digits or 6 digits) will result in an overflow. E.g. If the Accumulator is set for 6 digits, and you add 999999 and 2 it will overflow to become 1.

### Addition

```
Opcode					-	30
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} + {number at location} = {new ACU}
```

### Subtraction

```
Opcode					-	31
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} - {number at location} = {new ACU}
```

### Division

```
Opcode					-	32
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} / {number at location} = {new ACU}		
```

### Multiplication

```
Opcode					-	33
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} * {number at location} = {new ACU}		
```

### Exponent

```
Opcode					-	34
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} ^ {number at location} = {new ACU}		
```

### Modulo

```
Opcode					-	35
Operand use				-	None
Next instruction use	-	The location of the number to add
Notes					-	{ACU} mod {number at location} = {new ACU}		
```

### Branch

```
Opcode					-	40
Operand use				-	None
Next instruction use	-	The location to branch to
Notes					-	Jumps to a location in code
```

### Branch Negative

```
Opcode					-	41
Operand use				-	None
Next instruction use	-	The location to branch to
Notes					-	Jumps to a location in code if the Accumulator < 0
```

### Branch Zero

```
Opcode					-	42
Operand use				-	None
Next instruction use	-	The location to branch to
Notes					-	Jumps to a location in code if the Accumulator = 0
```

### Halt

```
Opcode					-	43
Operand use				-	None
Next instruction use	-	None
Notes					-	Stops the program
```

---

### Support

If you encounter a bug within your application, please report them through the Issue Tracker made available at the [InnovatED Source Code Repository Site](http://vanfleet.ddns.net/InnovatED/UVSim/issues).