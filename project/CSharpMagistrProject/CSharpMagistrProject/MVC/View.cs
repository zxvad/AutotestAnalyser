using System;
using System.Windows.Forms;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Events;

namespace CSharpMagistrProject.MVC
{

    public partial class View : Form, IView
    {
        public const int ESCAPE = 8;

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
            try
            {
                controller.ShowEvents(resultQueryGridView);

            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                controller.AddEvent(textBoxNameToAdd.Text);
                controller.ShowEvents(resultQueryGridView);
                textBoxNameToAdd.Clear();
            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                controller.DelEvent(Convert.ToInt32(textBoxIDToDel.Text));
                controller.ShowEvents(resultQueryGridView);
                textBoxIDToDel.Clear();
            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
            }
        }
        
        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.UpdateNameEvent(Convert.ToInt32(textBoxIDToUpdate.Text), textBoxNameToUpdate.Text);
                controller.ShowEvents(resultQueryGridView);
                textBoxIDToUpdate.Clear();
                textBoxNameToUpdate.Clear();
            }
            catch (Exception exception)
            {
                Controller.ShowMsg(exception.Message);
            }
        }

        //puts only numbers and backspace in textbox
		private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == false && ch!=ESCAPE)
            {
                e.Handled = true;
            }
        }
    }
}
