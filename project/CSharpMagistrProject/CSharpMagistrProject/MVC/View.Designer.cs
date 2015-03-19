namespace CSharpMagistrProject.MVC
{
    partial class View
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
            this.resultQueryGridView = new System.Windows.Forms.DataGridView();
            this.textBoxNameToAdd = new System.Windows.Forms.TextBox();
            this.textBoxIDToDel = new System.Windows.Forms.TextBox();
            this.textBoxIDToUpdate = new System.Windows.Forms.TextBox();
            this.textBoxNameToUpdate = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.delButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.idEventLabel = new System.Windows.Forms.Label();
            this.nameEventLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultQueryGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // resultQueryGridView
            // 
            this.resultQueryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultQueryGridView.Location = new System.Drawing.Point(12, 12);
            this.resultQueryGridView.Name = "resultQueryGridView";
            this.resultQueryGridView.Size = new System.Drawing.Size(322, 358);
            this.resultQueryGridView.TabIndex = 0;
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
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(559, 24);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(559, 69);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(75, 23);
            this.delButton.TabIndex = 6;
            this.delButton.Text = "Удалить";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(559, 112);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(75, 23);
            this.updateButton.TabIndex = 7;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 490);
            this.Controls.Add(this.nameEventLabel);
            this.Controls.Add(this.idEventLabel);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.delButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.textBoxNameToUpdate);
            this.Controls.Add(this.textBoxIDToUpdate);
            this.Controls.Add(this.textBoxIDToDel);
            this.Controls.Add(this.textBoxNameToAdd);
            this.Controls.Add(this.resultQueryGridView);
            this.Name = "MainForm";
            this.Text = "Анализ ПО контроллера АСУТП";
            this.Load += new System.EventHandler(this.View_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultQueryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView resultQueryGridView;
        private System.Windows.Forms.TextBox textBoxNameToAdd;
        private System.Windows.Forms.TextBox textBoxIDToDel;
        private System.Windows.Forms.TextBox textBoxIDToUpdate;
        private System.Windows.Forms.TextBox textBoxNameToUpdate;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button delButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label idEventLabel;
        private System.Windows.Forms.Label nameEventLabel;

    }
}

