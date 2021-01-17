using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSAO
{

    public partial class loarding : Form
    {
        public Action Worker { get; set; }
        public loarding(Action worker)
        {
            InitializeComponent();
            if (worker == null)
                throw new ArgumentException();
            Worker = worker;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void gunaWinCircleProgressIndicator1_Load(object sender, EventArgs e)
        {

        }

        private void gunaWinCircleProgressIndicator1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
