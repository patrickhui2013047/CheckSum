using System.Windows.Forms;

namespace UI
{
    public partial class HashControl : Panel
    {
        public string HashName { get; private set; }
        public bool HashEnable { get; private set; }
        public HashControl()
        {
            InitializeComponent();
        }
        public HashControl(string name, bool enable = true)
        {
            HashName = name;
            HashEnable = enable;

            InitializeComponent();
            UpdateHandler();
        }

        public void SetName(string name)
        {
            HashName = name;
            UpdateHandler();
        }

        public void SetEnable(bool enable)
        {
            HashEnable = enable;
            UpdateHandler();
        }

        private void UpdateHandler()
        {
            Check.Text = HashName+":";
            Button.Text = "Copy " + HashName;
            Check.Checked = HashEnable;
            Text.Enabled = HashEnable;
            Button.Enabled = HashEnable;
        }

        private void Check_CheckedChanged(object sender, System.EventArgs e)
        {
            HashEnable = Check.Checked;
            Text.Enabled = Check.Checked;
            Button.Enabled = Check.Checked;

        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            Text.SelectAll();
            Text.Copy();
        }
    }
}
