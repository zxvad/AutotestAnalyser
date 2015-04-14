using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    public partial class InputForm : Form, IView
    {
        public EventInput EventInputForm;
        public NeedEventInput NeedEventInputForm;

        private Controller controller;
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public InputForm(Controller controller)
        {
            InitializeComponent();
            this.Controller = controller;
        }

        private void showEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            EventInputForm.Show();
        }

        private void showNeedEventInputFormButton_Click(object sender, System.EventArgs e)
        {
            NeedEventInputForm.Show();
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
            NeedEventInputForm = new NeedEventInput(this.Controller);
            EventInputForm = new EventInput(this.Controller);
        }
    }
}
