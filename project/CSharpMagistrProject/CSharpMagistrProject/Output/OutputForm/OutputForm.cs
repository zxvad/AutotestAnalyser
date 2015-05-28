using System;
using System.Data;
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
                ResultTextBox.Text = string.Format("Качество ПО контроллера: {0:0.##} %",
                    ResultEffectPoByGridView(resultGridView));
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
        /// Вычисление результата эффективности работы ПО контроллера
        /// </summary>
        /// <param name="resultGridView">DataGridView с результатами</param>
        /// <returns>Эффективность</returns>
        private float ResultEffectPoByGridView(DataGridView resultGridView)
        {
            int countOkEvent = 0;
            foreach (DataGridViewRow row in resultGridView.Rows)
            {
                if (Equals(row.Cells["Выполнено"].Value, true))
                    countOkEvent++;
            }
            if (countOkEvent != 0)
                return countOkEvent/(float)resultGridView.RowCount* 100;
            return 0;
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
