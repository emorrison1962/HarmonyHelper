using System.Threading; // Add this if not already present
using System.Timers;

namespace ObservableObjectTest.forms
{
    public partial class Form1 : Form
    {
        private System.Threading.Timer? _timer; // Store reference to prevent GC

        public Form1()
        {
            InitializeComponent();
            // Fix: Use correct Timer constructor (callback, state, dueTime, period)
            _timer = new System.Threading.Timer(this.TimerCallback, null, 5000, Timeout.Infinite);
        }
        void TimerCallback(object? state)
        { 
            new object();
            _timer?.Dispose();
        }

        private void bnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            _timer?.Dispose();
        }

        private void bnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
