using System;
using System.Windows.Forms;
using CSharpMagistrProject.Input.InputForms;
using CSharpMagistrProject.Output.OutputForm;

namespace CSharpMagistrProject.MVC
{

    public partial class View : Form, IView
    {
        private InputForm _inputForm;
        private OutputForm _outputForm;

        public Controller Controller { get; set; }

        public View(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        private void View_Load(object sender, EventArgs e)
        {
            _inputForm = new InputForm(Controller);
            _outputForm = new OutputForm(Controller);
        }

        private void showInputFormButton_Click(object sender, EventArgs e)
        {
            _inputForm.Show();
        }

        private void showOutputFormButton_Click(object sender, EventArgs e)
        {
            _outputForm.Show();
        }
    }
}
