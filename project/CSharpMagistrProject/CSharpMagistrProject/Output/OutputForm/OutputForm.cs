using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Output.OutputForm
{
    /// <summary>
    /// Форма вывода результатов
    /// </summary>
    public partial class OutputForm : Form, IView
    {
        /// <summary>
        /// Контроллер (MVC)
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Конструктор по контроллеру
        /// </summary>
        /// <param name="controller">Контроллер (MVC)</param>
        public OutputForm(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        /// <summary>
        /// Событие при загрузке формы
        /// </summary>
        private void OutputForm_Load(object sender, EventArgs e)
        {
            try
            {
                Controller.ShowEvents(eventGridView);
                Controller.ShowNeedEvents(needEventGridView);
                Controller.ShowResults(resultGridView);
            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
                try
                {
                    Controller.AddToLog(exception);
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
        }

        /// <summary>
        /// Событие при закрытии формы
        /// </summary>
        private void OutputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

    }
}
