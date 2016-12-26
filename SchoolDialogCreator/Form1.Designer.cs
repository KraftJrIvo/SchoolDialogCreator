namespace SchoolDialogCreator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.addSpeechButton = new System.Windows.Forms.Button();
            this.charsList = new System.Windows.Forms.ListBox();
            this.addCharButton = new System.Windows.Forms.Button();
            this.mainCharText = new System.Windows.Forms.TextBox();
            this.setMainCharButton = new System.Windows.Forms.Button();
            this.newCharText = new System.Windows.Forms.TextBox();
            this.newFlagText = new System.Windows.Forms.TextBox();
            this.addFlagButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.flagsList = new System.Windows.Forms.CheckedListBox();
            this.speechesTree = new System.Windows.Forms.TreeView();
            this.speechText = new System.Windows.Forms.TextBox();
            this.charChooseBox = new System.Windows.Forms.ComboBox();
            this.spriteChooseBox = new System.Windows.Forms.ComboBox();
            this.questionCheckBox = new System.Windows.Forms.CheckBox();
            this.choice1FlagCheckBox = new System.Windows.Forms.CheckBox();
            this.choice1FlagName = new System.Windows.Forms.ComboBox();
            this.nextSpeechID = new System.Windows.Forms.NumericUpDown();
            this.choice1gotoID = new System.Windows.Forms.NumericUpDown();
            this.choice3gotoID = new System.Windows.Forms.NumericUpDown();
            this.choice2gotoID = new System.Windows.Forms.NumericUpDown();
            this.pseudonymText = new System.Windows.Forms.TextBox();
            this.endCheckBox = new System.Windows.Forms.CheckBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.mainCharID = new System.Windows.Forms.NumericUpDown();
            this.newCharID = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nextSpeechID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice1gotoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice3gotoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice2gotoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCharID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCharID)).BeginInit();
            this.SuspendLayout();
            // 
            // addSpeechButton
            // 
            this.addSpeechButton.Location = new System.Drawing.Point(11, 447);
            this.addSpeechButton.Name = "addSpeechButton";
            this.addSpeechButton.Size = new System.Drawing.Size(667, 23);
            this.addSpeechButton.TabIndex = 1;
            this.addSpeechButton.Text = "Add Speech";
            this.addSpeechButton.UseVisualStyleBackColor = true;
            this.addSpeechButton.Click += new System.EventHandler(this.addSpeechButton_Click);
            // 
            // charsList
            // 
            this.charsList.FormattingEnabled = true;
            this.charsList.Location = new System.Drawing.Point(685, 41);
            this.charsList.Name = "charsList";
            this.charsList.Size = new System.Drawing.Size(193, 69);
            this.charsList.TabIndex = 2;
            // 
            // addCharButton
            // 
            this.addCharButton.Location = new System.Drawing.Point(827, 116);
            this.addCharButton.Name = "addCharButton";
            this.addCharButton.Size = new System.Drawing.Size(51, 23);
            this.addCharButton.TabIndex = 3;
            this.addCharButton.Text = "Add Char";
            this.addCharButton.UseVisualStyleBackColor = true;
            this.addCharButton.Click += new System.EventHandler(this.addCharButton_Click);
            // 
            // mainCharText
            // 
            this.mainCharText.Location = new System.Drawing.Point(686, 13);
            this.mainCharText.Name = "mainCharText";
            this.mainCharText.Size = new System.Drawing.Size(89, 20);
            this.mainCharText.TabIndex = 5;
            // 
            // setMainCharButton
            // 
            this.setMainCharButton.Location = new System.Drawing.Point(827, 12);
            this.setMainCharButton.Name = "setMainCharButton";
            this.setMainCharButton.Size = new System.Drawing.Size(44, 23);
            this.setMainCharButton.TabIndex = 6;
            this.setMainCharButton.Text = "Set Main Char";
            this.setMainCharButton.UseVisualStyleBackColor = true;
            this.setMainCharButton.Click += new System.EventHandler(this.setMainCharButton_Click);
            // 
            // newCharText
            // 
            this.newCharText.Location = new System.Drawing.Point(685, 118);
            this.newCharText.Name = "newCharText";
            this.newCharText.Size = new System.Drawing.Size(90, 20);
            this.newCharText.TabIndex = 7;
            // 
            // newFlagText
            // 
            this.newFlagText.Location = new System.Drawing.Point(685, 249);
            this.newFlagText.Name = "newFlagText";
            this.newFlagText.Size = new System.Drawing.Size(100, 20);
            this.newFlagText.TabIndex = 9;
            // 
            // addFlagButton
            // 
            this.addFlagButton.Location = new System.Drawing.Point(791, 248);
            this.addFlagButton.Name = "addFlagButton";
            this.addFlagButton.Size = new System.Drawing.Size(87, 23);
            this.addFlagButton.TabIndex = 10;
            this.addFlagButton.Text = "Add Flag";
            this.addFlagButton.UseVisualStyleBackColor = true;
            this.addFlagButton.Click += new System.EventHandler(this.addFlagButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(700, 312);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(781, 312);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 12;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // flagsList
            // 
            this.flagsList.FormattingEnabled = true;
            this.flagsList.Location = new System.Drawing.Point(686, 145);
            this.flagsList.Name = "flagsList";
            this.flagsList.Size = new System.Drawing.Size(192, 94);
            this.flagsList.TabIndex = 13;
            this.flagsList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.flagsList_ItemCheck);
            // 
            // speechesTree
            // 
            this.speechesTree.Location = new System.Drawing.Point(12, 12);
            this.speechesTree.Name = "speechesTree";
            this.speechesTree.Size = new System.Drawing.Size(667, 323);
            this.speechesTree.TabIndex = 14;
            this.speechesTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.speechesTree_AfterSelect);
            // 
            // speechText
            // 
            this.speechText.Location = new System.Drawing.Point(12, 368);
            this.speechText.Multiline = true;
            this.speechText.Name = "speechText";
            this.speechText.Size = new System.Drawing.Size(666, 77);
            this.speechText.TabIndex = 15;
            // 
            // charChooseBox
            // 
            this.charChooseBox.FormattingEnabled = true;
            this.charChooseBox.Location = new System.Drawing.Point(12, 341);
            this.charChooseBox.Name = "charChooseBox";
            this.charChooseBox.Size = new System.Drawing.Size(121, 21);
            this.charChooseBox.TabIndex = 16;
            this.charChooseBox.SelectedIndexChanged += new System.EventHandler(this.charChooseBox_SelectedIndexChanged);
            // 
            // spriteChooseBox
            // 
            this.spriteChooseBox.FormattingEnabled = true;
            this.spriteChooseBox.Location = new System.Drawing.Point(140, 341);
            this.spriteChooseBox.Name = "spriteChooseBox";
            this.spriteChooseBox.Size = new System.Drawing.Size(121, 21);
            this.spriteChooseBox.TabIndex = 17;
            // 
            // questionCheckBox
            // 
            this.questionCheckBox.AutoSize = true;
            this.questionCheckBox.Location = new System.Drawing.Point(268, 344);
            this.questionCheckBox.Name = "questionCheckBox";
            this.questionCheckBox.Size = new System.Drawing.Size(82, 17);
            this.questionCheckBox.TabIndex = 18;
            this.questionCheckBox.Text = "isAQuestion";
            this.questionCheckBox.UseVisualStyleBackColor = true;
            // 
            // choice1FlagCheckBox
            // 
            this.choice1FlagCheckBox.AutoSize = true;
            this.choice1FlagCheckBox.Location = new System.Drawing.Point(792, 404);
            this.choice1FlagCheckBox.Name = "choice1FlagCheckBox";
            this.choice1FlagCheckBox.Size = new System.Drawing.Size(44, 17);
            this.choice1FlagCheckBox.TabIndex = 24;
            this.choice1FlagCheckBox.Text = "true";
            this.choice1FlagCheckBox.UseVisualStyleBackColor = true;
            // 
            // choice1FlagName
            // 
            this.choice1FlagName.FormattingEnabled = true;
            this.choice1FlagName.Location = new System.Drawing.Point(768, 377);
            this.choice1FlagName.Name = "choice1FlagName";
            this.choice1FlagName.Size = new System.Drawing.Size(89, 21);
            this.choice1FlagName.TabIndex = 27;
            // 
            // nextSpeechID
            // 
            this.nextSpeechID.Location = new System.Drawing.Point(357, 342);
            this.nextSpeechID.Name = "nextSpeechID";
            this.nextSpeechID.Size = new System.Drawing.Size(47, 20);
            this.nextSpeechID.TabIndex = 30;
            // 
            // choice1gotoID
            // 
            this.choice1gotoID.Location = new System.Drawing.Point(685, 368);
            this.choice1gotoID.Name = "choice1gotoID";
            this.choice1gotoID.Size = new System.Drawing.Size(47, 20);
            this.choice1gotoID.TabIndex = 31;
            // 
            // choice3gotoID
            // 
            this.choice3gotoID.Location = new System.Drawing.Point(686, 421);
            this.choice3gotoID.Name = "choice3gotoID";
            this.choice3gotoID.Size = new System.Drawing.Size(47, 20);
            this.choice3gotoID.TabIndex = 33;
            // 
            // choice2gotoID
            // 
            this.choice2gotoID.Location = new System.Drawing.Point(685, 394);
            this.choice2gotoID.Name = "choice2gotoID";
            this.choice2gotoID.Size = new System.Drawing.Size(47, 20);
            this.choice2gotoID.TabIndex = 32;
            // 
            // pseudonymText
            // 
            this.pseudonymText.Location = new System.Drawing.Point(410, 342);
            this.pseudonymText.Name = "pseudonymText";
            this.pseudonymText.Size = new System.Drawing.Size(100, 20);
            this.pseudonymText.TabIndex = 34;
            // 
            // endCheckBox
            // 
            this.endCheckBox.AutoSize = true;
            this.endCheckBox.Location = new System.Drawing.Point(791, 428);
            this.endCheckBox.Name = "endCheckBox";
            this.endCheckBox.Size = new System.Drawing.Size(44, 17);
            this.endCheckBox.TabIndex = 35;
            this.endCheckBox.Text = "end";
            this.endCheckBox.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(686, 447);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 36;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // mainCharID
            // 
            this.mainCharID.Location = new System.Drawing.Point(781, 12);
            this.mainCharID.Name = "mainCharID";
            this.mainCharID.Size = new System.Drawing.Size(40, 20);
            this.mainCharID.TabIndex = 37;
            // 
            // newCharID
            // 
            this.newCharID.Location = new System.Drawing.Point(781, 119);
            this.newCharID.Name = "newCharID";
            this.newCharID.Size = new System.Drawing.Size(40, 20);
            this.newCharID.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 476);
            this.Controls.Add(this.newCharID);
            this.Controls.Add(this.mainCharID);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.endCheckBox);
            this.Controls.Add(this.pseudonymText);
            this.Controls.Add(this.choice3gotoID);
            this.Controls.Add(this.choice2gotoID);
            this.Controls.Add(this.choice1gotoID);
            this.Controls.Add(this.nextSpeechID);
            this.Controls.Add(this.choice1FlagName);
            this.Controls.Add(this.choice1FlagCheckBox);
            this.Controls.Add(this.questionCheckBox);
            this.Controls.Add(this.spriteChooseBox);
            this.Controls.Add(this.charChooseBox);
            this.Controls.Add(this.speechText);
            this.Controls.Add(this.speechesTree);
            this.Controls.Add(this.flagsList);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addFlagButton);
            this.Controls.Add(this.newFlagText);
            this.Controls.Add(this.newCharText);
            this.Controls.Add(this.setMainCharButton);
            this.Controls.Add(this.mainCharText);
            this.Controls.Add(this.addCharButton);
            this.Controls.Add(this.charsList);
            this.Controls.Add(this.addSpeechButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nextSpeechID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice1gotoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice3gotoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.choice2gotoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainCharID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newCharID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addSpeechButton;
        private System.Windows.Forms.ListBox charsList;
        private System.Windows.Forms.Button addCharButton;
        private System.Windows.Forms.TextBox mainCharText;
        private System.Windows.Forms.Button setMainCharButton;
        private System.Windows.Forms.TextBox newCharText;
        private System.Windows.Forms.TextBox newFlagText;
        private System.Windows.Forms.Button addFlagButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TreeView speechesTree;
        private System.Windows.Forms.TextBox speechText;
        private System.Windows.Forms.ComboBox charChooseBox;
        private System.Windows.Forms.ComboBox spriteChooseBox;
        private System.Windows.Forms.CheckBox questionCheckBox;
        private System.Windows.Forms.CheckBox choice1FlagCheckBox;
        private System.Windows.Forms.ComboBox choice1FlagName;
        private System.Windows.Forms.NumericUpDown nextSpeechID;
        private System.Windows.Forms.NumericUpDown choice1gotoID;
        protected System.Windows.Forms.CheckedListBox flagsList;
        private System.Windows.Forms.NumericUpDown choice3gotoID;
        private System.Windows.Forms.NumericUpDown choice2gotoID;
        private System.Windows.Forms.TextBox pseudonymText;
        private System.Windows.Forms.CheckBox endCheckBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.NumericUpDown mainCharID;
        private System.Windows.Forms.NumericUpDown newCharID;
    }
}

