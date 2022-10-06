namespace lab1COP
{
    partial class Form
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
            this.buttonAddElemsListBox = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonSetNumber = new System.Windows.Forms.Button();
            this.buttonSetNull = new System.Windows.Forms.Button();
            this.buttonGetNumbFromTextBox = new System.Windows.Forms.Button();
            this.buttonFillGrid = new System.Windows.Forms.Button();
            this.buttonConfigGrid = new System.Windows.Forms.Button();
            this.buttonGetSelectedObj = new System.Windows.Forms.Button();
            this.buttonGetIndex = new System.Windows.Forms.Button();
            this.buttonSetIndex = new System.Windows.Forms.Button();
            this.buttonClearGrid = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.choiceComponent1 = new lab1COP.Components.ChoiceComponent();
            this.outputComponent1 = new lab1COP.Components.OutputComponent();
            this.inputComponent1 = new lab1COP.Components.InputComponent();
            this.SuspendLayout();
            // 
            // buttonAddElemsListBox
            // 
            this.buttonAddElemsListBox.Location = new System.Drawing.Point(454, 35);
            this.buttonAddElemsListBox.Name = "buttonAddElemsListBox";
            this.buttonAddElemsListBox.Size = new System.Drawing.Size(198, 44);
            this.buttonAddElemsListBox.TabIndex = 4;
            this.buttonAddElemsListBox.Text = "AddElements";
            this.buttonAddElemsListBox.UseVisualStyleBackColor = true;
            this.buttonAddElemsListBox.Click += new System.EventHandler(this.buttonAddElemsListBox_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(454, 102);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(198, 46);
            this.buttonClearListBox.TabIndex = 5;
            this.buttonClearListBox.Text = "Clear";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonSetNumber
            // 
            this.buttonSetNumber.Location = new System.Drawing.Point(119, 266);
            this.buttonSetNumber.Name = "buttonSetNumber";
            this.buttonSetNumber.Size = new System.Drawing.Size(106, 55);
            this.buttonSetNumber.TabIndex = 6;
            this.buttonSetNumber.Text = "SetNumber";
            this.buttonSetNumber.UseVisualStyleBackColor = true;
            this.buttonSetNumber.Click += new System.EventHandler(this.buttonSetNumber_Click);
            // 
            // buttonSetNull
            // 
            this.buttonSetNull.Location = new System.Drawing.Point(231, 266);
            this.buttonSetNull.Name = "buttonSetNull";
            this.buttonSetNull.Size = new System.Drawing.Size(106, 55);
            this.buttonSetNull.TabIndex = 7;
            this.buttonSetNull.Text = "SetNull";
            this.buttonSetNull.UseVisualStyleBackColor = true;
            this.buttonSetNull.Click += new System.EventHandler(this.buttonSetNull_Click);
            // 
            // buttonGetNumbFromTextBox
            // 
            this.buttonGetNumbFromTextBox.Location = new System.Drawing.Point(343, 266);
            this.buttonGetNumbFromTextBox.Name = "buttonGetNumbFromTextBox";
            this.buttonGetNumbFromTextBox.Size = new System.Drawing.Size(106, 55);
            this.buttonGetNumbFromTextBox.TabIndex = 8;
            this.buttonGetNumbFromTextBox.Text = "GetNumber";
            this.buttonGetNumbFromTextBox.UseVisualStyleBackColor = true;
            this.buttonGetNumbFromTextBox.Click += new System.EventHandler(this.buttonGetNumbFromTextBox_Click);
            // 
            // buttonFillGrid
            // 
            this.buttonFillGrid.Location = new System.Drawing.Point(636, 324);
            this.buttonFillGrid.Name = "buttonFillGrid";
            this.buttonFillGrid.Size = new System.Drawing.Size(128, 53);
            this.buttonFillGrid.TabIndex = 9;
            this.buttonFillGrid.Text = "FillGrid";
            this.buttonFillGrid.UseVisualStyleBackColor = true;
            this.buttonFillGrid.Click += new System.EventHandler(this.buttonFillGrid_Click);
            // 
            // buttonConfigGrid
            // 
            this.buttonConfigGrid.Location = new System.Drawing.Point(770, 324);
            this.buttonConfigGrid.Name = "buttonConfigGrid";
            this.buttonConfigGrid.Size = new System.Drawing.Size(128, 53);
            this.buttonConfigGrid.TabIndex = 10;
            this.buttonConfigGrid.Text = "ConfigGrid";
            this.buttonConfigGrid.UseVisualStyleBackColor = true;
            this.buttonConfigGrid.Click += new System.EventHandler(this.buttonConfigGrid_Click);
            // 
            // buttonGetSelectedObj
            // 
            this.buttonGetSelectedObj.Location = new System.Drawing.Point(904, 324);
            this.buttonGetSelectedObj.Name = "buttonGetSelectedObj";
            this.buttonGetSelectedObj.Size = new System.Drawing.Size(128, 53);
            this.buttonGetSelectedObj.TabIndex = 11;
            this.buttonGetSelectedObj.Text = "GetSelected   Object";
            this.buttonGetSelectedObj.UseVisualStyleBackColor = true;
            this.buttonGetSelectedObj.Click += new System.EventHandler(this.buttonGetSelectedObj_Click);
            // 
            // buttonGetIndex
            // 
            this.buttonGetIndex.Location = new System.Drawing.Point(636, 383);
            this.buttonGetIndex.Name = "buttonGetIndex";
            this.buttonGetIndex.Size = new System.Drawing.Size(128, 214);
            this.buttonGetIndex.TabIndex = 12;
            this.buttonGetIndex.Text = "GetIndex";
            this.buttonGetIndex.UseVisualStyleBackColor = true;
            this.buttonGetIndex.Click += new System.EventHandler(this.buttonGetIndex_Click);
            // 
            // buttonSetIndex
            // 
            this.buttonSetIndex.Location = new System.Drawing.Point(770, 383);
            this.buttonSetIndex.Name = "buttonSetIndex";
            this.buttonSetIndex.Size = new System.Drawing.Size(128, 182);
            this.buttonSetIndex.TabIndex = 13;
            this.buttonSetIndex.Text = "SelectByIndex";
            this.buttonSetIndex.UseVisualStyleBackColor = true;
            this.buttonSetIndex.Click += new System.EventHandler(this.buttonSetIndex_Click);
            // 
            // buttonClearGrid
            // 
            this.buttonClearGrid.Location = new System.Drawing.Point(904, 383);
            this.buttonClearGrid.Name = "buttonClearGrid";
            this.buttonClearGrid.Size = new System.Drawing.Size(128, 214);
            this.buttonClearGrid.TabIndex = 14;
            this.buttonClearGrid.Text = "Clear";
            this.buttonClearGrid.UseVisualStyleBackColor = true;
            this.buttonClearGrid.Click += new System.EventHandler(this.buttonClearGrid_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(771, 571);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 26);
            this.textBox1.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(728, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(340, 67);
            this.button1.TabIndex = 16;
            this.button1.Text = "Save as table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(728, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(340, 67);
            this.button2.TabIndex = 16;
            this.button2.Text = "Save as custom table";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(728, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(340, 67);
            this.button3.TabIndex = 16;
            this.button3.Text = "Save as histogram";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // choiceComponent1
            // 
            this.choiceComponent1.ChoosenLine = "";
            this.choiceComponent1.Location = new System.Drawing.Point(26, 13);
            this.choiceComponent1.Name = "choiceComponent1";
            this.choiceComponent1.Size = new System.Drawing.Size(421, 202);
            this.choiceComponent1.TabIndex = 3;
            // 
            // outputComponent1
            // 
            this.outputComponent1.Location = new System.Drawing.Point(26, 310);
            this.outputComponent1.Name = "outputComponent1";
            this.outputComponent1.Size = new System.Drawing.Size(604, 305);
            this.outputComponent1.TabIndex = 2;
            // 
            // inputComponent1
            // 
            this.inputComponent1.Location = new System.Drawing.Point(26, 211);
            this.inputComponent1.Name = "inputComponent1";
            this.inputComponent1.Number = null;
            this.inputComponent1.Size = new System.Drawing.Size(508, 110);
            this.inputComponent1.TabIndex = 1;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 631);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonClearGrid);
            this.Controls.Add(this.buttonSetIndex);
            this.Controls.Add(this.buttonGetIndex);
            this.Controls.Add(this.buttonGetSelectedObj);
            this.Controls.Add(this.buttonConfigGrid);
            this.Controls.Add(this.buttonFillGrid);
            this.Controls.Add(this.buttonGetNumbFromTextBox);
            this.Controls.Add(this.buttonSetNull);
            this.Controls.Add(this.buttonSetNumber);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.buttonAddElemsListBox);
            this.Controls.Add(this.choiceComponent1);
            this.Controls.Add(this.outputComponent1);
            this.Controls.Add(this.inputComponent1);
            this.Name = "Form";
            this.Text = "FormForChecking";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.InputComponent inputComponent1;
        private Components.OutputComponent outputComponent1;
        private Components.ChoiceComponent choiceComponent1;
        private System.Windows.Forms.Button buttonAddElemsListBox;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonSetNumber;
        private System.Windows.Forms.Button buttonSetNull;
        private System.Windows.Forms.Button buttonGetNumbFromTextBox;
        private System.Windows.Forms.Button buttonFillGrid;
        private System.Windows.Forms.Button buttonConfigGrid;
        private System.Windows.Forms.Button buttonGetSelectedObj;
        private System.Windows.Forms.Button buttonGetIndex;
        private System.Windows.Forms.Button buttonSetIndex;
        private System.Windows.Forms.Button buttonClearGrid;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

