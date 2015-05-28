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
            this.showInputFormButton = new System.Windows.Forms.Button();
            this.showOutputFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showInputFormButton
            // 
            this.showInputFormButton.Location = new System.Drawing.Point(30, 39);
            this.showInputFormButton.Name = "showInputFormButton";
            this.showInputFormButton.Size = new System.Drawing.Size(150, 117);
            this.showInputFormButton.TabIndex = 0;
            this.showInputFormButton.Text = "Форма ввода данных";
            this.showInputFormButton.UseVisualStyleBackColor = true;
            this.showInputFormButton.Click += new System.EventHandler(this.showInputFormButton_Click);
            // 
            // showOutputFormButton
            // 
            this.showOutputFormButton.Location = new System.Drawing.Point(231, 39);
            this.showOutputFormButton.Name = "showOutputFormButton";
            this.showOutputFormButton.Size = new System.Drawing.Size(150, 117);
            this.showOutputFormButton.TabIndex = 1;
            this.showOutputFormButton.Text = "Результаты";
            this.showOutputFormButton.UseVisualStyleBackColor = true;
            this.showOutputFormButton.Click += new System.EventHandler(this.showOutputFormButton_Click);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 191);
            this.Controls.Add(this.showOutputFormButton);
            this.Controls.Add(this.showInputFormButton);
            this.Name = "View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ ПО контроллера АСУТП";
            this.Load += new System.EventHandler(this.View_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button showInputFormButton;
        private System.Windows.Forms.Button showOutputFormButton;


    }
}

