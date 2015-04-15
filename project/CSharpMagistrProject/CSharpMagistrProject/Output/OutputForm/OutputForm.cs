using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Output.OutputForm
{
    public partial class OutputForm : Form, IView
    {
        private Controller controller;

        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public OutputForm(Controller controller)
        {
            InitializeComponent();
            this.Controller = controller;
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {
            try
            {
                controller.ShowEvents(eventGridView);
                controller.ShowNeedEvents(needEventGridView);
                controller.ShowResults(resultGridView);
            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
                try
                {
                    controller.AddToLog(exception);

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
