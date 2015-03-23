using System;
using System.Windows.Forms;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;
using CSharpMagistrProject.Input.InputForms;
using CSharpMagistrProject.Output.OutputForm;

namespace CSharpMagistrProject.MVC
{

    public partial class View : Form, IView
    {
        public const int ESCAPE = 8;
        public InputForm InputForm;
        public OutputForm OutputForm;

        private Controller controller;
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            InputForm = new InputForm();
            OutputForm = new OutputForm();
            InputForm.Controller = this.Controller;
            OutputForm.Controller = this.Controller;
        }

        private void showInputFormButton_Click(object sender, EventArgs e)
        {
            InputForm.Show();
        }

        private void showOutputFormButton_Click(object sender, EventArgs e)
        {
            OutputForm.Show();
        }
    }
}
