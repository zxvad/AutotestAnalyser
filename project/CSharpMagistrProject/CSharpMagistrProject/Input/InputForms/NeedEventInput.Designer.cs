namespace CSharpMagistrProject.Input.InputForms
{
    partial class NeedEventInput
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
            this.needEventGridView = new System.Windows.Forms.DataGridView();
            this.addNeedEventButton = new System.Windows.Forms.Button();
            this.deleteNeedEventButton = new System.Windows.Forms.Button();
            this.updateNeedEventButton = new System.Windows.Forms.Button();
            this.textBoxIdNeedEventToAdd = new System.Windows.Forms.TextBox();
            this.textBoxIdNeedEventToDel = new System.Windows.Forms.TextBox();
            this.textBoxIdNeedEventToUpdate = new System.Windows.Forms.TextBox();
            this.textBoxNewIdNeedEvent = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.labelNewId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.needEventGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // needEventGridView
            // 
            this.needEventGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.needEventGridView.Location = new System.Drawing.Point(0, 0);
            this.needEventGridView.Name = "needEventGridView";
            this.needEventGridView.ReadOnly = true;
            this.needEventGridView.Size = new System.Drawing.Size(307, 358);
            this.needEventGridView.TabIndex = 0;
            // 
            // addNeedEventButton
            // 
            this.addNeedEventButton.Location = new System.Drawing.Point(546, 28);
            this.addNeedEventButton.Name = "addNeedEventButton";
            this.addNeedEventButton.Size = new System.Drawing.Size(75, 23);
            this.addNeedEventButton.TabIndex = 1;
            this.addNeedEventButton.Text = "Добавить";
            this.addNeedEventButton.UseVisualStyleBackColor = true;
            this.addNeedEventButton.Click += new System.EventHandler(this.addNeedEventButton_Click);
            // 
            // deleteNeedEventButton
            // 
            this.deleteNeedEventButton.Location = new System.Drawing.Point(546, 70);
            this.deleteNeedEventButton.Name = "deleteNeedEventButton";
            this.deleteNeedEventButton.Size = new System.Drawing.Size(75, 23);
            this.deleteNeedEventButton.TabIndex = 2;
            this.deleteNeedEventButton.Text = "Удалить";
            this.deleteNeedEventButton.UseVisualStyleBackColor = true;
            this.deleteNeedEventButton.Click += new System.EventHandler(this.deleteNeedEventButton_Click);
            // 
            // updateNeedEventButton
            // 
            this.updateNeedEventButton.Location = new System.Drawing.Point(546, 113);
            this.updateNeedEventButton.Name = "updateNeedEventButton";
            this.updateNeedEventButton.Size = new System.Drawing.Size(75, 23);
            this.updateNeedEventButton.TabIndex = 3;
            this.updateNeedEventButton.Text = "Изменить";
            this.updateNeedEventButton.UseVisualStyleBackColor = true;
            this.updateNeedEventButton.Click += new System.EventHandler(this.updateNeedEventButton_Click);
            // 
            // textBoxIdNeedEventToAdd
            // 
            this.textBoxIdNeedEventToAdd.Location = new System.Drawing.Point(354, 28);
            this.textBoxIdNeedEventToAdd.Name = "textBoxIdNeedEventToAdd";
            this.textBoxIdNeedEventToAdd.Size = new System.Drawing.Size(37, 20);
            this.textBoxIdNeedEventToAdd.TabIndex = 4;
            this.textBoxIdNeedEventToAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressedIsDigit);
            // 
            // textBoxIdNeedEventToDel
            // 
            this.textBoxIdNeedEventToDel.Location = new System.Drawing.Point(354, 70);
            this.textBoxIdNeedEventToDel.Name = "textBoxIdNeedEventToDel";
            this.textBoxIdNeedEventToDel.Size = new System.Drawing.Size(37, 20);
            this.textBoxIdNeedEventToDel.TabIndex = 5;
            this.textBoxIdNeedEventToDel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressedIsDigit);
            // 
            // textBoxIdNeedEventToUpdate
            // 
            this.textBoxIdNeedEventToUpdate.Location = new System.Drawing.Point(354, 115);
            this.textBoxIdNeedEventToUpdate.Name = "textBoxIdNeedEventToUpdate";
            this.textBoxIdNeedEventToUpdate.Size = new System.Drawing.Size(37, 20);
            this.textBoxIdNeedEventToUpdate.TabIndex = 6;
            this.textBoxIdNeedEventToUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressedIsDigit);
            // 
            // textBoxNewIdNeedEvent
            // 
            this.textBoxNewIdNeedEvent.Location = new System.Drawing.Point(429, 115);
            this.textBoxNewIdNeedEvent.Name = "textBoxNewIdNeedEvent";
            this.textBoxNewIdNeedEvent.Size = new System.Drawing.Size(35, 20);
            this.textBoxNewIdNeedEvent.TabIndex = 7;
            this.textBoxNewIdNeedEvent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeyPressedIsDigit);
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(354, 9);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(18, 13);
            this.labelId.TabIndex = 8;
            this.labelId.Text = "ID";
            // 
            // labelNewId
            // 
            this.labelNewId.AutoSize = true;
            this.labelNewId.Location = new System.Drawing.Point(429, 9);
            this.labelNewId.Name = "labelNewId";
            this.labelNewId.Size = new System.Drawing.Size(38, 13);
            this.labelNewId.TabIndex = 9;
            this.labelNewId.Text = "newID";
            // 
            // NeedEventInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 370);
            this.Controls.Add(this.labelNewId);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.textBoxNewIdNeedEvent);
            this.Controls.Add(this.textBoxIdNeedEventToUpdate);
            this.Controls.Add(this.textBoxIdNeedEventToDel);
            this.Controls.Add(this.textBoxIdNeedEventToAdd);
            this.Controls.Add(this.updateNeedEventButton);
            this.Controls.Add(this.deleteNeedEventButton);
            this.Controls.Add(this.addNeedEventButton);
            this.Controls.Add(this.needEventGridView);
            this.Name = "NeedEventInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Необходимые события";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NeedEventInput_FormClosing);
            this.Load += new System.EventHandler(this.NeedEventInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.needEventGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView needEventGridView;
        private System.Windows.Forms.Button addNeedEventButton;
        private System.Windows.Forms.Button deleteNeedEventButton;
        private System.Windows.Forms.Button updateNeedEventButton;
        private System.Windows.Forms.TextBox textBoxIdNeedEventToAdd;
        private System.Windows.Forms.TextBox textBoxIdNeedEventToDel;
        private System.Windows.Forms.TextBox textBoxIdNeedEventToUpdate;
        private System.Windows.Forms.TextBox textBoxNewIdNeedEvent;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelNewId;
    }
}