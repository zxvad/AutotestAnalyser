using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Output.OutputForm
{
    public partial class OutputForm : Form, IView
    {
        public Controller Controller { get; set; }

        public OutputForm(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

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
