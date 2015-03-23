namespace CSharpMagistrProject.Input.InputForms
{
    partial class EventInput
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.eventsGridView = new System.Windows.Forms.DataGridView();
            this.textBoxNameToAdd = new System.Windows.Forms.TextBox();
            this.textBoxIDToDel = new System.Windows.Forms.TextBox();
            this.textBoxIDToUpdate = new System.Windows.Forms.TextBox();
            this.textBoxNameToUpdate = new System.Windows.Forms.TextBox();
            this.addEventButton = new System.Windows.Forms.Button();
            this.delEventButton = new System.Windows.Forms.Button();
            this.updateEventButton = new System.Windows.Forms.Button();
            this.idEventLabel = new System.Windows.Forms.Label();
            this.nameEventLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.eventsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // eventsGridView
            // 
            this.eventsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsGridView.Location = new System.Drawing.Point(12, 12);
            this.eventsGridView.Name = "eventsGridView";
            this.eventsGridView.Size = new System.Drawing.Size(322, 358);
            this.eventsGridView.TabIndex = 0;
            // 
            // textBoxNameToAdd
            // 
            this.textBoxNameToAdd.Location = new System.Drawing.Point(446, 24);
            this.textBoxNameToAdd.Name = "textBoxNameToAdd";
            this.textBoxNameToAdd.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameToAdd.TabIndex = 1;
            // 
            // textBoxIDToDel
            // 
            this.textBoxIDToDel.Location = new System.Drawing.Point(377, 69);
            this.textBoxIDToDel.Name = "textBoxIDToDel";
            this.textBoxIDToDel.Size = new System.Drawing.Size(47, 20);
            this.textBoxIDToDel.TabIndex = 2;
            this.textBoxIDToDel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxID_KeyPress);
            // 
            // textBoxIDToUpdate
            // 
            this.textBoxIDToUpdate.Location = new System.Drawing.Point(377, 114);
            this.textBoxIDToUpdate.Name = "textBoxIDToUpdate";
            this.textBoxIDToUpdate.Size = new System.Drawing.Size(47, 20);
            this.textBoxIDToUpdate.TabIndex = 3;
            this.textBoxIDToUpdate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxID_KeyPress);
            // 
            // textBoxNameToUpdate
            // 
            this.textBoxNameToUpdate.Location = new System.Drawing.Point(446, 114);
            this.textBoxNameToUpdate.Name = "textBoxNameToUpdate";
            this.textBoxNameToUpdate.Size = new System.Drawing.Size(100, 20);
            this.textBoxNameToUpdate.TabIndex = 4;
            // 
            // addEventButton
            // 
            this.addEventButton.Location = new System.Drawing.Point(559, 24);
            this.addEventButton.Name = "addEventButton";
            this.addEventButton.Size = new System.Drawing.Size(75, 23);
            this.addEventButton.TabIndex = 5;
            this.addEventButton.Text = "Добавить";
            this.addEventButton.UseVisualStyleBackColor = true;
            this.addEventButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delEventButton
            // 
            this.delEventButton.Location = new System.Drawing.Point(559, 69);
            this.delEventButton.Name = "delEventButton";
            this.delEventButton.Size = new System.Drawing.Size(75, 23);
            this.delEventButton.TabIndex = 6;
            this.delEventButton.Text = "Удалить";
            this.delEventButton.UseVisualStyleBackColor = true;
            this.delEventButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // updateEventButton
            // 
            this.updateEventButton.Location = new System.Drawing.Point(559, 112);
            this.updateEventButton.Name = "updateEventButton";
            this.updateEventButton.Size = new System.Drawing.Size(75, 23);
            this.updateEventButton.TabIndex = 7;
            this.updateEventButton.Text = "Обновить";
            this.updateEventButton.UseVisualStyleBackColor = true;
            this.updateEventButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // idEventLabel
            // 
            this.idEventLabel.AutoSize = true;
            this.idEventLabel.Location = new System.Drawing.Point(388, 3);
            this.idEventLabel.Name = "idEventLabel";
            this.idEventLabel.Size = new System.Drawing.Size(15, 13);
            this.idEventLabel.TabIndex = 8;
            this.idEventLabel.Text = "id";
            // 
            // nameEventLabel
            // 
            this.nameEventLabel.AutoSize = true;
            this.nameEventLabel.Location = new System.Drawing.Point(471, 2);
            this.nameEventLabel.Name = "nameEventLabel";
            this.nameEventLabel.Size = new System.Drawing.Size(51, 13);
            this.nameEventLabel.TabIndex = 9;
            this.nameEventLabel.Text = "Событие";
            // 
            // EventInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 490);
            this.Controls.Add(this.nameEventLabel);
            this.Controls.Add(this.idEventLabel);
            this.Controls.Add(this.updateEventButton);
            this.Controls.Add(this.delEventButton);
            this.Controls.Add(this.addEventButton);
            this.Controls.Add(this.textBoxNameToUpdate);
            this.Controls.Add(this.textBoxIDToUpdate);
            this.Controls.Add(this.textBoxIDToDel);
            this.Controls.Add(this.textBoxNameToAdd);
            this.Controls.Add(this.eventsGridView);
            this.Name = "EventInput";
            this.Text = "Анализ ПО контроллера АСУТП";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventInput_FormClosing);
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView eventsGridView;
        private System.Windows.Forms.TextBox textBoxNameToAdd;
        private System.Windows.Forms.TextBox textBoxIDToDel;
        private System.Windows.Forms.TextBox textBoxIDToUpdate;
        private System.Windows.Forms.TextBox textBoxNameToUpdate;
        private System.Windows.Forms.Button addEventButton;
        private System.Windows.Forms.Button delEventButton;
        private System.Windows.Forms.Button updateEventButton;
        private System.Windows.Forms.Label idEventLabel;
        private System.Windows.Forms.Label nameEventLabel;

    }
}

