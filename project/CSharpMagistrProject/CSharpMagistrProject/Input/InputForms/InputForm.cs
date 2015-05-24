using System.Drawing;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    /// <summary>
    /// Главная форма ввода данных
    /// </summary>
    public partial class InputForm : Form, IView
    {
        /// <summary>
        /// Форма для редактирования списка событий
        /// </summary>
        private EventInput _eventInputForm;

        /// <summary>
        /// Форма для редактирования списка необходимых событий
        /// </summary>
        private NeedEventInput _needEventInputForm;

        /// <summary>
        /// Контроллер (MVC)
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Конструктор по контроллеру
        /// </summary>
        /// <param name="controller">Контроллер</param>
        public InputForm(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        /// <summary>
        /// Событие нажатия на кнопку ввода событий
        /// </summary>
        private void showEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            _eventInputForm.Location = new Point(Location.X + (Width - _eventInputForm.Width) / 2, Location.Y + (Height - _eventInputForm.Height) / 2);
            _eventInputForm.Show();
        }

        /// <summary>
        /// Событие нажатия на кнопку ввода необходимых событий
        /// </summary>
        private void showNeedEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            _needEventInputForm.Location = new Point(Location.X + (Width - _needEventInputForm.Width) / 2, Location.Y + (Height - _needEventInputForm.Height) / 2);
            _needEventInputForm.Show();
        }

        /// <summary>
        /// Событие при закрытии окна
        /// </summary>
        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Событие при загрузке окна
        /// </summary>
        private void InputForm_Load(object sender, System.EventArgs e)
        {
            _needEventInputForm = new NeedEventInput(Controller);
            _eventInputForm = new EventInput(Controller);
        }
    }
}
