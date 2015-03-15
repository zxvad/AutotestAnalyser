using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpMagistrProject.DB;
using CSharpMagistrProject.Input.Event;

namespace CSharpMagistrProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DataBase db=new DataBase("","","Admin","");
            //string testSQL = "INSERT INTO EventTable(idEvent,name) VALUES(30,'namename')";
            string testSQL = "SELECT * FROM EventTable";
           
            try
            {
                Event listEvent = new Event(db, "EventTable");
                listEvent.Show(resultQueryGridView);
                db.Connect();
                db.Close();
            }
            catch (Exception exception)
            {
                CommonMethods.ShowMsg(exception.Message);
            }


        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase("", "", "Admin", "");
            try
            {
                Event listEvent = new Event(db, "EventTable");
                db.Connect();
                listEvent.Add(textBoxNameToAdd.Text);
                listEvent.Show(resultQueryGridView);
                db.Close();
                textBoxNameToAdd.Clear();
            }
            catch (Exception exception)
            {
                CommonMethods.ShowMsg(exception.Message);
            }
        }

        private void delButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase("", "", "Admin", "");
            try
            {
                Event listEvent = new Event(db, "EventTable");
                db.Connect();
                listEvent.Del(Convert.ToInt32(textBoxIDToDel.Text));
                listEvent.Show(resultQueryGridView);
                db.Close();
                textBoxIDToDel.Clear();
            }
            catch (Exception exception)
            {
                CommonMethods.ShowMsg(exception.Message);
            }
        }

        
        private void updateButton_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase("", "", "Admin", "");
            try
            {
                Event listEvent = new Event(db, "EventTable");
                db.Connect();
                listEvent.Update(Convert.ToInt32(textBoxIDToUpdate.Text),textBoxNameToUpdate.Text);
                listEvent.Show(resultQueryGridView);
                db.Close();
                textBoxIDToUpdate.Clear();
                textBoxNameToUpdate.Clear();
            }
            catch (Exception exception)
            {
                CommonMethods.ShowMsg(exception.Message);
            }
        }

        //puts only numbers and backspace in textbox
        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (char.IsDigit(ch) == false && ch!=8)
            {
                e.Handled = true;
            }
        }
    }
}
