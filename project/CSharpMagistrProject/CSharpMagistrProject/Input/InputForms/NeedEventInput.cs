﻿using System;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Input.InputForms
{
    public partial class NeedEventInput : Form, IView
    {
        private Controller controller;

        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public NeedEventInput(Controller controller)
        {
            InitializeComponent();
            this.Controller = controller;
        }

        private void NeedEventInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void NeedEventInput_Load(object sender, EventArgs e)
        {
            try
            {
                controller.ShowNeedEvents(needEventGridView);

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

        private void addNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.AddNeedEvent(Convert.ToInt32(textBoxIdNeedEventToAdd.Text));
                controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToAdd.Clear();
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

        private void deleteNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.DelNeedEvent(Convert.ToInt32(textBoxIdNeedEventToDel.Text));
                controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToDel.Clear();
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

        private void updateNeedEventButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.UpdateNeedEvent(Convert.ToInt32(textBoxIdNeedEventToUpdate.Text), Convert.ToInt32(textBoxNewIdNeedEvent.Text));
                controller.ShowNeedEvents(needEventGridView);
                textBoxIdNeedEventToUpdate.Clear();
                textBoxNewIdNeedEvent.Clear();
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
    }
}
