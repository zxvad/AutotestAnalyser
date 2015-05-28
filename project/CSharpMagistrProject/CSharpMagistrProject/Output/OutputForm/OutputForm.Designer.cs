namespace CSharpMagistrProject.Output.OutputForm
{
    partial class OutputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eventGridView = new System.Windows.Forms.DataGridView();
            this.needEventGridView = new System.Windows.Forms.DataGridView();
            this.resultGridView = new System.Windows.Forms.DataGridView();
            this.ResultTextBox = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.needEventGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "События";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Необходимые события";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Результаты";
            // 
            // eventGridView
            // 
            this.eventGridView.AllowUserToAddRows = false;
            this.eventGridView.AllowUserToDeleteRows = false;
            this.eventGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventGridView.Location = new System.Drawing.Point(12, 69);
            this.eventGridView.MaximumSize = new System.Drawing.Size(250, 400);
            this.eventGridView.Name = "eventGridView";
            this.eventGridView.ReadOnly = true;
            this.eventGridView.Size = new System.Drawing.Size(250, 400);
            this.eventGridView.TabIndex = 3;
            // 
            // needEventGridView
            // 
            this.needEventGridView.AllowUserToAddRows = false;
            this.needEventGridView.AllowUserToDeleteRows = false;
            this.needEventGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.needEventGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.needEventGridView.Location = new System.Drawing.Point(270, 69);
            this.needEventGridView.Name = "needEventGridView";
            this.needEventGridView.ReadOnly = true;
            this.needEventGridView.Size = new System.Drawing.Size(250, 400);
            this.needEventGridView.TabIndex = 4;
            // 
            // resultGridView
            // 
            this.resultGridView.AllowUserToAddRows = false;
            this.resultGridView.AllowUserToDeleteRows = false;
            this.resultGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGridView.Location = new System.Drawing.Point(528, 69);
            this.resultGridView.Name = "resultGridView";
            this.resultGridView.ReadOnly = true;
            this.resultGridView.Size = new System.Drawing.Size(250, 400);
            this.resultGridView.TabIndex = 5;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.Location = new System.Drawing.Point(0, 511);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(834, 25);
            this.ResultTextBox.TabIndex = 6;
            this.ResultTextBox.Text = "Качество ПО контроллера: ";
            this.ResultTextBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(834, 536);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.resultGridView);
            this.Controls.Add(this.needEventGridView);
            this.Controls.Add(this.eventGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OutputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Результаты";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OutputForm_FormClosing);
            this.Load += new System.EventHandler(this.OutputForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.needEventGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView eventGridView;
        private System.Windows.Forms.DataGridView needEventGridView;
        private System.Windows.Forms.DataGridView resultGridView;
        private System.Windows.Forms.Label ResultTextBox;
    }
}