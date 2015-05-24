using System;
using System.Drawing;
using System.Windows.Forms;
using CSharpMagistrProject.Input.InputForms;
using CSharpMagistrProject.Output.OutputForm;

namespace CSharpMagistrProject.MVC
{
    /// <summary>
    /// Главная форма
    /// </summary>
    public partial class View : Form, IView
    {
        /// <summary>
        /// Форма ввода данных
        /// </summary>
        private InputForm _inputForm;

        /// <summary>
        /// Форма вывода результатов
        /// </summary>
        private OutputForm _outputForm;

        /// <summary>
        /// Контроллер (MVC)
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Конструктор по контроллеру (MVC)
        /// </summary>
        /// <param name="controller">Контроллер (MVC)</param>
        public View(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        private void View_Load(object sender, EventArgs e)
        {
            _inputForm = new InputForm(Controller);
            _outputForm = new OutputForm(Controller);
        }

        /// <summary>
        /// Событие нажатия на кнопку формы ввода данных
        /// </summary>
        private void showInputFormButton_Click(object sender, EventArgs e)
        {
            _inputForm.Location = new Point(Location.X + (Width - _inputForm.Width) / 2, Location.Y + (Height - _inputForm.Height) / 2);
            _inputForm.Show();
        }

        /// <summary>
        /// Событие нажатия на кноку вывода результатов
        /// </summary>
        private void showOutputFormButton_Click(object sender, EventArgs e)
        {
            _outputForm.Location = new Point(Location.X + (Width - _outputForm.Width) / 2, Location.Y + (Height - _outputForm.Height) / 2);
            _outputForm.Show();
        }
    }
}
