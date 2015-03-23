namespace CSharpMagistrProject.Input.InputForms
{
    partial class InputForm
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
            this.showEventInputFormButton = new System.Windows.Forms.Button();
            this.showNeedEventInputFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showEventInputFormButton
            // 
            this.showEventInputFormButton.Location = new System.Drawing.Point(12, 102);
            this.showEventInputFormButton.Name = "showEventInputFormButton";
            this.showEventInputFormButton.Size = new System.Drawing.Size(125, 111);
            this.showEventInputFormButton.TabIndex = 0;
            this.showEventInputFormButton.Text = "Ввод событий";
            this.showEventInputFormButton.UseVisualStyleBackColor = true;
            this.showEventInputFormButton.Click += new System.EventHandler(this.showEventInputFormButton_Click);
            // 
            // showNeedEventInputFormButton
            // 
            this.showNeedEventInputFormButton.Location = new System.Drawing.Point(143, 102);
            this.showNeedEventInputFormButton.Name = "showNeedEventInputFormButton";
            this.showNeedEventInputFormButton.Size = new System.Drawing.Size(129, 111);
            this.showNeedEventInputFormButton.TabIndex = 1;
            this.showNeedEventInputFormButton.Text = "Ввод необходимых событий";
            this.showNeedEventInputFormButton.UseVisualStyleBackColor = true;
            this.showNeedEventInputFormButton.Click += new System.EventHandler(this.showNeedEventInputFormButton_Click);
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.showNeedEventInputFormButton);
            this.Controls.Add(this.showEventInputFormButton);
            this.Name = "InputForm";
            this.Text = "Ввод данных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InputForm_FormClosing);
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showEventInputFormButton;
        private System.Windows.Forms.Button showNeedEventInputFormButton;
    }
}