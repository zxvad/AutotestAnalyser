using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    /// <summary>
    /// Форма для редактирования списка событий
    /// </summary>
    public partial class EventInput : Form, IView
    {
        /// <summary>
        /// Контроллер (MVC)
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Конструктор по контроллеру
        /// </summary>
        /// <param name="controller">Контроллер</param>
        public EventInput(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

		/// <summary>
        /// Событие при загрузке формы 
		/// </summary>
        private void View_Load(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            // ВОПРОС:
            //А как тогда делать? Ведь и при выполнении операций могут возникнуть исключения, и при записи в лог они могут возникнуть
            try
            {
                Controller.ShowEvents(eventsGridView);

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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ВОПРОС:
                    //Как условия (if) могут помочь мне в обработке исключений ?
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку добавления события
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                Controller.AddEvent(textBoxNameToAdd.Text);
                Controller.ShowEvents(eventsGridView);
                textBoxNameToAdd.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку удаления события
        /// </summary>
        private void delButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                Controller.DelEvent(Convert.ToInt32(textBoxIDToDel.Text));
                Controller.ShowEvents(eventsGridView);
                textBoxIDToDel.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку изменения события
        /// </summary>
        private void updateButton_Click(object sender, EventArgs e)
        {
			//try/catch в 2 этажа это не решение а костыль, который ни к чему хорошему не приведет
            try
            {
                Controller.UpdateNameEvent(Convert.ToInt32(textBoxIDToUpdate.Text), textBoxNameToUpdate.Text);
                Controller.ShowEvents(eventsGridView);
                textBoxIDToUpdate.Clear();
                textBoxNameToUpdate.Clear();
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
					//нельзя такого допускать!!!
					//вместо этого необходимо сторожевые условия использовать
                    // ignored
                }
            }
        }

        /// <summary>
        /// Событие при вводе символа в textbox
        /// </summary>
        private void CheckKeyPressedIsDigit(object sender, KeyPressEventArgs e)
        {
            //Разрешается ввод только цифр и backspace
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == false && ch != (int)KeysEnum.Backspace)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Событие при закрытии окна
        /// </summary>
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
