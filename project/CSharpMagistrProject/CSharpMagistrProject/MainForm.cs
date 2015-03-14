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
                Event events = new Event(db, "EventTable");
                MessageBox.Show(events.NewID().ToString());
                db.Connect();
                db.DoQuery(testSQL,resultQueryGridView);
                db.Close();
            }
            catch (Exception exception)
            {
                CommonMethods.ShowMsg(exception.Message);
            }


        }
    }
}
