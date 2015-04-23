using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    public partial class InputForm : Form, IView
    {
        private EventInput _eventInputForm;
        private NeedEventInput _needEventInputForm;

        public Controller Controller { get; set; }

        public InputForm(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        private void showEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            _eventInputForm.Show();
        }

        private void showNeedEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            _needEventInputForm.Show();
        }

        private void InputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void InputForm_Load(object sender, System.EventArgs e)
        {
            _needEventInputForm = new NeedEventInput(Controller);
            _eventInputForm = new EventInput(Controller);
        }
    }
}
