using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    /// <summary>
    /// Форма для редактирования списка необходимых событий
    /// </summary>
    public partial class NeedEventInput : Form, IView
    {
        /// <summary>
        /// Контроллер (MVC)
        /// </summary>
        public Controller Controller { get; set; }

        /// <summary>
        /// Конструктор по контроллеру
        /// </summary>
        /// <param name="controller">Контроллер</param>
        public NeedEventInput(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        /// <summary>
        /// Событие при закрытии окна
        /// </summary>
        private void NeedEventInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        /// <summary>
        /// Событие при загрузке окна
        /// </summary>
        private void NeedEventInput_Load(object sender, EventArgs e)
        {
            try
            {
                Controller.ShowNeedEvents(needEventGridView);

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
        /// Событие нажатия на кнопку добавления необходимого события
        /// </summary>
        private void addNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.AddNeedEvent(Convert.ToInt32(textBoxIdNeedEventToAdd.Text));
                Controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToAdd.Clear();
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
        /// Событие нажатия на кнопку удаления необходимого события
        /// </summary>
        private void deleteNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.DelNeedEvent(Convert.ToInt32(textBoxIdNeedEventToDel.Text));
                Controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToDel.Clear();
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
        /// Событие нажатия на кнопку изменения необходимого события
        /// </summary>
        private void updateNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.UpdateNeedEvent(Convert.ToInt32(textBoxIdNeedEventToUpdate.Text), Convert.ToInt32(textBoxNewIdNeedEvent.Text));
                Controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToUpdate.Clear();
                textBoxNewIdNeedEvent.Clear();
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
    }
}
