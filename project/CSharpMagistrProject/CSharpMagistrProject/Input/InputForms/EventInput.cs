using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    
    public partial class EventInput : Form, IView
    {
        private Controller controller;
        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public EventInput()
        {
            InitializeComponent();
            
        }

        private void View_Load(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                controller.ShowEvents(eventsGridView);

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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                controller.AddEvent(textBoxNameToAdd.Text);
                controller.ShowEvents(eventsGridView);
                textBoxNameToAdd.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                controller.DelEvent(Convert.ToInt32(textBoxIDToDel.Text));
                controller.ShowEvents(eventsGridView);
                textBoxIDToDel.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                controller.UpdateNameEvent(Convert.ToInt32(textBoxIDToUpdate.Text), textBoxNameToUpdate.Text);
                controller.ShowEvents(eventsGridView);
                textBoxIDToUpdate.Clear();
                textBoxNameToUpdate.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        //puts only numbers and backspace in textbox
        public void CheckKeyPressedIsDigit(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == false && ch != (int)Keys.Escape)
            {
                e.Handled = true;
            }
        }

        private void EventInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
