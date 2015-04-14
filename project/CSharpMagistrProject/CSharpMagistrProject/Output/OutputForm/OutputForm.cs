using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpMagistrProject.MVC;

namespace CSharpMagistrProject.Output.OutputForm
{
    public partial class OutputForm : Form, IView
    {
        private Controller controller;

        public Controller Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public OutputForm(Controller controller)
        {
            InitializeComponent();
            this.Controller = controller;
        }

    }
}
