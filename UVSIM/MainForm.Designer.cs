/// AUTHOR: Emily Starks
/// Milestone #3
/// Date: 04/15/2018

namespace UVSIM
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.runButton = new System.Windows.Forms.Button();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.memoryLabel = new System.Windows.Forms.Label();
            this.resetFormButton = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editInstructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadInstructionsFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryGridView = new System.Windows.Forms.DataGridView();
            this.column0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionsGridView = new System.Windows.Forms.DataGridView();
            this.breakpointColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.instructionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runtimeDataLabel = new System.Windows.Forms.Label();
            this.runtimeDataPanel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.statusCodeValueLabel1 = new System.Windows.Forms.Label();
            this.acuValueLabel1 = new System.Windows.Forms.Label();
            this.pcValueLabel1 = new System.Windows.Forms.Label();
            this.statusCodeLabel1 = new System.Windows.Forms.Label();
            this.acuLabel1 = new System.Windows.Forms.Label();
            this.pcLabel1 = new System.Windows.Forms.Label();
            this.p1StartingLocationLabel = new System.Windows.Forms.Label();
            this.p2StartingLocationLabel = new System.Windows.Forms.Label();
            this.program1StartLocationTextBox = new System.Windows.Forms.TextBox();
            this.program2StartLocationTextBox = new System.Windows.Forms.TextBox();
            this.continueButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.runtimeDataPanel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.statusCodeValueLabel2 = new System.Windows.Forms.Label();
            this.acuValueLabel2 = new System.Windows.Forms.Label();
            this.pcValueLabel2 = new System.Windows.Forms.Label();
            this.statusCodeLabel2 = new System.Windows.Forms.Label();
            this.acuLabel2 = new System.Windows.Forms.Label();
            this.pcLabel2 = new System.Windows.Forms.Label();
            this.runtimeDataPanel = new System.Windows.Forms.Panel();
            this.saveInstructionsToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsGridView)).BeginInit();
            this.runtimeDataPanel1.SuspendLayout();
            this.runtimeDataPanel2.SuspendLayout();
            this.runtimeDataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(12, 42);
            this.runButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(123, 34);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.AutoSize = true;
            this.instructionsLabel.Location = new System.Drawing.Point(9, 96);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(142, 17);
            this.instructionsLabel.TabIndex = 2;
            this.instructionsLabel.Text = "Program Instructions:";
            // 
            // memoryLabel
            // 
            this.memoryLabel.AutoSize = true;
            this.memoryLabel.Location = new System.Drawing.Point(300, 351);
            this.memoryLabel.Name = "memoryLabel";
            this.memoryLabel.Size = new System.Drawing.Size(62, 17);
            this.memoryLabel.TabIndex = 4;
            this.memoryLabel.Text = "Memory:";
            // 
            // resetFormButton
            // 
            this.resetFormButton.Location = new System.Drawing.Point(140, 42);
            this.resetFormButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetFormButton.Name = "resetFormButton";
            this.resetFormButton.Size = new System.Drawing.Size(123, 34);
            this.resetFormButton.TabIndex = 9;
            this.resetFormButton.Text = "Reset";
            this.resetFormButton.UseVisualStyleBackColor = true;
            this.resetFormButton.Click += new System.EventHandler(this.resetFormButton_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(299, 133);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(55, 17);
            this.outputLabel.TabIndex = 10;
            this.outputLabel.Text = "Output:";
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputTextBox.Location = new System.Drawing.Point(300, 151);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputTextBox.Size = new System.Drawing.Size(449, 182);
            this.outputTextBox.TabIndex = 11;
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.SystemColors.Window;
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1382, 28);
            this.mainMenu.TabIndex = 12;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editInstructionsToolStripMenuItem,
            this.loadInstructionsFromFileToolStripMenuItem,
            this.saveInstructionsToFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editInstructionsToolStripMenuItem
            // 
            this.editInstructionsToolStripMenuItem.Name = "editInstructionsToolStripMenuItem";
            this.editInstructionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.editInstructionsToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.editInstructionsToolStripMenuItem.Text = "Input/Edit Instructions";
            this.editInstructionsToolStripMenuItem.Click += new System.EventHandler(this.editInstructionsToolStripMenuItem_Click);
            // 
            // loadInstructionsFromFileToolStripMenuItem
            // 
            this.loadInstructionsFromFileToolStripMenuItem.Name = "loadInstructionsFromFileToolStripMenuItem";
            this.loadInstructionsFromFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadInstructionsFromFileToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.loadInstructionsFromFileToolStripMenuItem.Text = "Load Instructions From File";
            this.loadInstructionsFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadInstructionsFromFileToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // manageSettingsToolStripMenuItem
            // 
            this.manageSettingsToolStripMenuItem.Name = "manageSettingsToolStripMenuItem";
            this.manageSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.manageSettingsToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.manageSettingsToolStripMenuItem.Text = "Manage";
            this.manageSettingsToolStripMenuItem.Click += new System.EventHandler(this.manageSettingsToolStripMenuItem_Click);
            // 
            // memoryGridView
            // 
            this.memoryGridView.AllowUserToAddRows = false;
            this.memoryGridView.AllowUserToDeleteRows = false;
            this.memoryGridView.AllowUserToResizeColumns = false;
            this.memoryGridView.AllowUserToResizeRows = false;
            this.memoryGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.memoryGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.memoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.memoryGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column0,
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5,
            this.column6,
            this.column7,
            this.column8,
            this.column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.memoryGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.memoryGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.memoryGridView.Location = new System.Drawing.Point(300, 370);
            this.memoryGridView.Margin = new System.Windows.Forms.Padding(4);
            this.memoryGridView.Name = "memoryGridView";
            this.memoryGridView.ReadOnly = true;
            this.memoryGridView.RowHeadersWidth = 60;
            this.memoryGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.memoryGridView.RowTemplate.ReadOnly = true;
            this.memoryGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.memoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.memoryGridView.ShowEditingIcon = false;
            this.memoryGridView.Size = new System.Drawing.Size(1057, 409);
            this.memoryGridView.TabIndex = 13;
            // 
            // column0
            // 
            this.column0.Frozen = true;
            this.column0.HeaderText = "0";
            this.column0.Name = "column0";
            this.column0.ReadOnly = true;
            this.column0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column0.Width = 60;
            // 
            // column1
            // 
            this.column1.Frozen = true;
            this.column1.HeaderText = "1";
            this.column1.Name = "column1";
            this.column1.ReadOnly = true;
            this.column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column1.Width = 60;
            // 
            // column2
            // 
            this.column2.HeaderText = "2";
            this.column2.Name = "column2";
            this.column2.ReadOnly = true;
            this.column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column2.Width = 60;
            // 
            // column3
            // 
            this.column3.HeaderText = "3";
            this.column3.Name = "column3";
            this.column3.ReadOnly = true;
            this.column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column3.Width = 60;
            // 
            // column4
            // 
            this.column4.HeaderText = "4";
            this.column4.Name = "column4";
            this.column4.ReadOnly = true;
            this.column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column4.Width = 60;
            // 
            // column5
            // 
            this.column5.HeaderText = "5";
            this.column5.Name = "column5";
            this.column5.ReadOnly = true;
            this.column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column5.Width = 60;
            // 
            // column6
            // 
            this.column6.HeaderText = "6";
            this.column6.Name = "column6";
            this.column6.ReadOnly = true;
            this.column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column6.Width = 60;
            // 
            // column7
            // 
            this.column7.HeaderText = "7";
            this.column7.Name = "column7";
            this.column7.ReadOnly = true;
            this.column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column7.Width = 60;
            // 
            // column8
            // 
            this.column8.HeaderText = "8";
            this.column8.Name = "column8";
            this.column8.ReadOnly = true;
            this.column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column8.Width = 60;
            // 
            // column9
            // 
            this.column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.column9.HeaderText = "9";
            this.column9.Name = "column9";
            this.column9.ReadOnly = true;
            this.column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.column9.Width = 60;
            // 
            // instructionsGridView
            // 
            this.instructionsGridView.AllowUserToAddRows = false;
            this.instructionsGridView.AllowUserToDeleteRows = false;
            this.instructionsGridView.AllowUserToResizeColumns = false;
            this.instructionsGridView.AllowUserToResizeRows = false;
            this.instructionsGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.instructionsGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.instructionsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.instructionsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.breakpointColumn,
            this.instructionColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.instructionsGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.instructionsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.instructionsGridView.Location = new System.Drawing.Point(12, 117);
            this.instructionsGridView.Margin = new System.Windows.Forms.Padding(4);
            this.instructionsGridView.Name = "instructionsGridView";
            this.instructionsGridView.RowHeadersWidth = 60;
            this.instructionsGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.instructionsGridView.RowTemplate.ReadOnly = true;
            this.instructionsGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.instructionsGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.instructionsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.instructionsGridView.ShowEditingIcon = false;
            this.instructionsGridView.Size = new System.Drawing.Size(280, 662);
            this.instructionsGridView.TabIndex = 14;
            this.instructionsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.instructionsGridView_CellContentClick);
            // 
            // breakpointColumn
            // 
            this.breakpointColumn.HeaderText = "Breakpoint";
            this.breakpointColumn.Name = "breakpointColumn";
            this.breakpointColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.breakpointColumn.Width = 60;
            // 
            // instructionColumn
            // 
            this.instructionColumn.HeaderText = "Instruction";
            this.instructionColumn.Name = "instructionColumn";
            this.instructionColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.instructionColumn.Width = 70;
            // 
            // runtimeDataLabel
            // 
            this.runtimeDataLabel.AutoSize = true;
            this.runtimeDataLabel.Location = new System.Drawing.Point(756, 133);
            this.runtimeDataLabel.Name = "runtimeDataLabel";
            this.runtimeDataLabel.Size = new System.Drawing.Size(98, 17);
            this.runtimeDataLabel.TabIndex = 15;
            this.runtimeDataLabel.Text = "Runtime Data:";
            // 
            // runtimeDataPanel1
            // 
            this.runtimeDataPanel1.AutoScroll = true;
            this.runtimeDataPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.runtimeDataPanel1.Controls.Add(this.label2);
            this.runtimeDataPanel1.Controls.Add(this.statusCodeValueLabel1);
            this.runtimeDataPanel1.Controls.Add(this.acuValueLabel1);
            this.runtimeDataPanel1.Controls.Add(this.pcValueLabel1);
            this.runtimeDataPanel1.Controls.Add(this.statusCodeLabel1);
            this.runtimeDataPanel1.Controls.Add(this.acuLabel1);
            this.runtimeDataPanel1.Controls.Add(this.pcLabel1);
            this.runtimeDataPanel1.Location = new System.Drawing.Point(4, 4);
            this.runtimeDataPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.runtimeDataPanel1.Name = "runtimeDataPanel1";
            this.runtimeDataPanel1.Size = new System.Drawing.Size(286, 173);
            this.runtimeDataPanel1.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Processor 1:";
            // 
            // statusCodeValueLabel1
            // 
            this.statusCodeValueLabel1.AutoSize = true;
            this.statusCodeValueLabel1.Location = new System.Drawing.Point(137, 112);
            this.statusCodeValueLabel1.Name = "statusCodeValueLabel1";
            this.statusCodeValueLabel1.Size = new System.Drawing.Size(24, 17);
            this.statusCodeValueLabel1.TabIndex = 22;
            this.statusCodeValueLabel1.Text = "##";
            // 
            // acuValueLabel1
            // 
            this.acuValueLabel1.AutoSize = true;
            this.acuValueLabel1.Location = new System.Drawing.Point(137, 74);
            this.acuValueLabel1.Name = "acuValueLabel1";
            this.acuValueLabel1.Size = new System.Drawing.Size(24, 17);
            this.acuValueLabel1.TabIndex = 21;
            this.acuValueLabel1.Text = "##";
            // 
            // pcValueLabel1
            // 
            this.pcValueLabel1.AutoSize = true;
            this.pcValueLabel1.Location = new System.Drawing.Point(137, 37);
            this.pcValueLabel1.Name = "pcValueLabel1";
            this.pcValueLabel1.Size = new System.Drawing.Size(24, 17);
            this.pcValueLabel1.TabIndex = 20;
            this.pcValueLabel1.Text = "##";
            // 
            // statusCodeLabel1
            // 
            this.statusCodeLabel1.AutoSize = true;
            this.statusCodeLabel1.Location = new System.Drawing.Point(20, 112);
            this.statusCodeLabel1.Name = "statusCodeLabel1";
            this.statusCodeLabel1.Size = new System.Drawing.Size(89, 17);
            this.statusCodeLabel1.TabIndex = 19;
            this.statusCodeLabel1.Text = "Status Code:";
            // 
            // acuLabel1
            // 
            this.acuLabel1.AutoSize = true;
            this.acuLabel1.Location = new System.Drawing.Point(20, 74);
            this.acuLabel1.Name = "acuLabel1";
            this.acuLabel1.Size = new System.Drawing.Size(90, 17);
            this.acuLabel1.TabIndex = 18;
            this.acuLabel1.Text = "Accumulator:";
            // 
            // pcLabel1
            // 
            this.pcLabel1.AutoSize = true;
            this.pcLabel1.Location = new System.Drawing.Point(20, 37);
            this.pcLabel1.Name = "pcLabel1";
            this.pcLabel1.Size = new System.Drawing.Size(120, 17);
            this.pcLabel1.TabIndex = 17;
            this.pcLabel1.Text = "Program Counter:";
            // 
            // p1StartingLocationLabel
            // 
            this.p1StartingLocationLabel.AutoSize = true;
            this.p1StartingLocationLabel.Location = new System.Drawing.Point(296, 95);
            this.p1StartingLocationLabel.Name = "p1StartingLocationLabel";
            this.p1StartingLocationLabel.Size = new System.Drawing.Size(189, 17);
            this.p1StartingLocationLabel.TabIndex = 17;
            this.p1StartingLocationLabel.Text = "Program 1 Starting Location:";
            // 
            // p2StartingLocationLabel
            // 
            this.p2StartingLocationLabel.AutoSize = true;
            this.p2StartingLocationLabel.Location = new System.Drawing.Point(593, 96);
            this.p2StartingLocationLabel.Name = "p2StartingLocationLabel";
            this.p2StartingLocationLabel.Size = new System.Drawing.Size(189, 17);
            this.p2StartingLocationLabel.TabIndex = 18;
            this.p2StartingLocationLabel.Text = "Program 2 Starting Location:";
            // 
            // program1StartLocationTextBox
            // 
            this.program1StartLocationTextBox.Location = new System.Drawing.Point(489, 91);
            this.program1StartLocationTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.program1StartLocationTextBox.Name = "program1StartLocationTextBox";
            this.program1StartLocationTextBox.Size = new System.Drawing.Size(91, 22);
            this.program1StartLocationTextBox.TabIndex = 19;
            // 
            // program2StartLocationTextBox
            // 
            this.program2StartLocationTextBox.Location = new System.Drawing.Point(784, 91);
            this.program2StartLocationTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.program2StartLocationTextBox.Name = "program2StartLocationTextBox";
            this.program2StartLocationTextBox.Size = new System.Drawing.Size(91, 22);
            this.program2StartLocationTextBox.TabIndex = 20;
            // 
            // continueButton
            // 
            this.continueButton.Enabled = false;
            this.continueButton.Location = new System.Drawing.Point(396, 42);
            this.continueButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(123, 34);
            this.continueButton.TabIndex = 21;
            this.continueButton.Text = "Continue";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(268, 42);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(123, 34);
            this.stopButton.TabIndex = 22;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // runtimeDataPanel2
            // 
            this.runtimeDataPanel2.AutoScroll = true;
            this.runtimeDataPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.runtimeDataPanel2.Controls.Add(this.label1);
            this.runtimeDataPanel2.Controls.Add(this.statusCodeValueLabel2);
            this.runtimeDataPanel2.Controls.Add(this.acuValueLabel2);
            this.runtimeDataPanel2.Controls.Add(this.pcValueLabel2);
            this.runtimeDataPanel2.Controls.Add(this.statusCodeLabel2);
            this.runtimeDataPanel2.Controls.Add(this.acuLabel2);
            this.runtimeDataPanel2.Controls.Add(this.pcLabel2);
            this.runtimeDataPanel2.Location = new System.Drawing.Point(304, 4);
            this.runtimeDataPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.runtimeDataPanel2.Name = "runtimeDataPanel2";
            this.runtimeDataPanel2.Size = new System.Drawing.Size(285, 173);
            this.runtimeDataPanel2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Processor 2:";
            // 
            // statusCodeValueLabel2
            // 
            this.statusCodeValueLabel2.AutoSize = true;
            this.statusCodeValueLabel2.Location = new System.Drawing.Point(137, 112);
            this.statusCodeValueLabel2.Name = "statusCodeValueLabel2";
            this.statusCodeValueLabel2.Size = new System.Drawing.Size(24, 17);
            this.statusCodeValueLabel2.TabIndex = 22;
            this.statusCodeValueLabel2.Text = "##";
            // 
            // acuValueLabel2
            // 
            this.acuValueLabel2.AutoSize = true;
            this.acuValueLabel2.Location = new System.Drawing.Point(137, 74);
            this.acuValueLabel2.Name = "acuValueLabel2";
            this.acuValueLabel2.Size = new System.Drawing.Size(24, 17);
            this.acuValueLabel2.TabIndex = 21;
            this.acuValueLabel2.Text = "##";
            // 
            // pcValueLabel2
            // 
            this.pcValueLabel2.AutoSize = true;
            this.pcValueLabel2.Location = new System.Drawing.Point(137, 37);
            this.pcValueLabel2.Name = "pcValueLabel2";
            this.pcValueLabel2.Size = new System.Drawing.Size(24, 17);
            this.pcValueLabel2.TabIndex = 20;
            this.pcValueLabel2.Text = "##";
            // 
            // statusCodeLabel2
            // 
            this.statusCodeLabel2.AutoSize = true;
            this.statusCodeLabel2.Location = new System.Drawing.Point(20, 112);
            this.statusCodeLabel2.Name = "statusCodeLabel2";
            this.statusCodeLabel2.Size = new System.Drawing.Size(89, 17);
            this.statusCodeLabel2.TabIndex = 19;
            this.statusCodeLabel2.Text = "Status Code:";
            // 
            // acuLabel2
            // 
            this.acuLabel2.AutoSize = true;
            this.acuLabel2.Location = new System.Drawing.Point(20, 74);
            this.acuLabel2.Name = "acuLabel2";
            this.acuLabel2.Size = new System.Drawing.Size(90, 17);
            this.acuLabel2.TabIndex = 18;
            this.acuLabel2.Text = "Accumulator:";
            // 
            // pcLabel2
            // 
            this.pcLabel2.AutoSize = true;
            this.pcLabel2.Location = new System.Drawing.Point(20, 37);
            this.pcLabel2.Name = "pcLabel2";
            this.pcLabel2.Size = new System.Drawing.Size(120, 17);
            this.pcLabel2.TabIndex = 17;
            this.pcLabel2.Text = "Program Counter:";
            // 
            // runtimeDataPanel
            // 
            this.runtimeDataPanel.AutoScroll = true;
            this.runtimeDataPanel.BackColor = System.Drawing.SystemColors.Window;
            this.runtimeDataPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.runtimeDataPanel.Controls.Add(this.runtimeDataPanel1);
            this.runtimeDataPanel.Controls.Add(this.runtimeDataPanel2);
            this.runtimeDataPanel.Location = new System.Drawing.Point(760, 151);
            this.runtimeDataPanel.Margin = new System.Windows.Forms.Padding(4);
            this.runtimeDataPanel.Name = "runtimeDataPanel";
            this.runtimeDataPanel.Size = new System.Drawing.Size(597, 183);
            this.runtimeDataPanel.TabIndex = 23;
            // 
            // saveInstructionsToFileToolStripMenuItem
            // 
            this.saveInstructionsToFileToolStripMenuItem.Name = "saveInstructionsToFileToolStripMenuItem";
            this.saveInstructionsToFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveInstructionsToFileToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.saveInstructionsToFileToolStripMenuItem.Text = "Save Instructions To File";
            this.saveInstructionsToFileToolStripMenuItem.Click += new System.EventHandler(this.saveInstructionsToFileToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 786);
            this.Controls.Add(this.runtimeDataPanel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.program2StartLocationTextBox);
            this.Controls.Add(this.program1StartLocationTextBox);
            this.Controls.Add(this.p2StartingLocationLabel);
            this.Controls.Add(this.p1StartingLocationLabel);
            this.Controls.Add(this.runtimeDataLabel);
            this.Controls.Add(this.instructionsGridView);
            this.Controls.Add(this.memoryGridView);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.resetFormButton);
            this.Controls.Add(this.memoryLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.mainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UVSim";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructionsGridView)).EndInit();
            this.runtimeDataPanel1.ResumeLayout(false);
            this.runtimeDataPanel1.PerformLayout();
            this.runtimeDataPanel2.ResumeLayout(false);
            this.runtimeDataPanel2.PerformLayout();
            this.runtimeDataPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label memoryLabel;
        private System.Windows.Forms.Button resetFormButton;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editInstructionsToolStripMenuItem;
        private System.Windows.Forms.DataGridView memoryGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn column0;
        private System.Windows.Forms.DataGridViewTextBoxColumn column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn column9;
        private System.Windows.Forms.DataGridView instructionsGridView;
        private System.Windows.Forms.Label runtimeDataLabel;
        private System.Windows.Forms.Panel runtimeDataPanel1;
        private System.Windows.Forms.Label statusCodeValueLabel1;
        private System.Windows.Forms.Label acuValueLabel1;
        private System.Windows.Forms.Label pcValueLabel1;
        private System.Windows.Forms.Label statusCodeLabel1;
        private System.Windows.Forms.Label acuLabel1;
        private System.Windows.Forms.Label pcLabel1;
        private System.Windows.Forms.Label p1StartingLocationLabel;
        private System.Windows.Forms.Label p2StartingLocationLabel;
        private System.Windows.Forms.TextBox program1StartLocationTextBox;
        private System.Windows.Forms.TextBox program2StartLocationTextBox;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn breakpointColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructionColumn;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageSettingsToolStripMenuItem;
        private System.Windows.Forms.Panel runtimeDataPanel2;
        private System.Windows.Forms.Label statusCodeValueLabel2;
        private System.Windows.Forms.Label acuValueLabel2;
        private System.Windows.Forms.Label pcValueLabel2;
        private System.Windows.Forms.Label statusCodeLabel2;
        private System.Windows.Forms.Label acuLabel2;
        private System.Windows.Forms.Label pcLabel2;
        private System.Windows.Forms.Panel runtimeDataPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem loadInstructionsFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveInstructionsToFileToolStripMenuItem;
    }
}

