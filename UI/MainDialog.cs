using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckSumLib;
using Algorithm;

namespace UI
{
    public partial class MainDialog : Form
    {
        const bool NoMoreHashAllowed = true;
        string InputString = "";
        Stream InputStream { get; set; }

        Task.Progress Progress { get; set; }
        HashControl MD5Field;
        HashControl SHA1Field;
        HashControl SHA256Field;
        HashControl SHA512Field;
        List<HashProcesser> HashList = new List<HashProcesser>();



        public MainDialog()
        {
            InitializeComponent();
            //custom control setting
            MD5Field = new HashControl("MD5");
            MD5Field.CheckChanged += ChangeHandler;
            HashContainer.Controls.Add(MD5Field);
            SHA1Field = new HashControl("SHA-1");
            SHA1Field.CheckChanged += ChangeHandler;
            HashContainer.Controls.Add(SHA1Field);
            SHA256Field = new HashControl("SHA-256");
            SHA256Field.CheckChanged += ChangeHandler;
            HashContainer.Controls.Add(SHA256Field);
            SHA512Field = new HashControl("SHA-512");
            SHA512Field.CheckChanged += ChangeHandler;
            HashContainer.Controls.Add(SHA512Field);

            //FileDialog setting
            FileBrowseDialog.CheckFileExists = true;
            FileBrowseDialog.CheckPathExists = true;
            //Hash Algorithm loading
            HashList.Add(new MD5());
            HashList.Add(new SHA1());
            HashList.Add(new SHA256());
            HashList.Add(new SHA512());
        }
        
        public void Execute()
        {
            StatusBarProgress.Maximum = HashList.Where(arg => arg.Enable).Count();
            StatusBarProgress.Value = 0;
            StatusBarText.Text = "Checking";
            if (!TextCheckBox.Checked)
            {
                try
                {
                    InputStream = new FileStream(FileTextbox.Text.ToString(), FileMode.Open, FileAccess.Read);
                }catch(ArgumentException e)
                {
                    MessageBox.Show("Invaild file path. Please select a vaild file.\n"+e.Message);
                    return;
                }
            }
            else
            {
                InputStream = new MemoryStream(Encoding.ASCII.GetBytes(TextTextbox.Text));
            }
            foreach (HashProcesser processer in HashList.Where(arg => arg.Enable))
            {
                
                foreach(HashControl field in HashContainer.Controls)
                {
                    processer.Run(InputStream);
                    if (field.HashEnable && (field.HashName == processer.Name))
                    {
                        field.SetText(processer.OutString);
                        break;
                    }else if (!field.HashEnable)
                    {
                        field.SetText("");
                    }
                }
                StatusBarProgress.Value += 1;
                InputStream.Position = 0;
            }
            StatusBarText.Text = "Completed";
        }

        private void Verify()
        {
            StatusBarProgress.Maximum = HashList.Where(arg => arg.Enable).Count();
            StatusBarProgress.Value = 0;
            StatusBarText.Text = "Verifying";
            foreach (HashProcesser processer in HashList.Where(arg => arg.Enable))
            {
                if (HashTextbox.Text == processer.OutString)
                {
                    MessageBox.Show(processer.Name + " matched.");
                }
            }
            StatusBarText.Text = "Verifying";
        }

        public bool ChangeHandler(string name,bool check)
        {
            foreach(HashProcesser processer in HashList)
            {
                if (name == processer.Name)
                {
                    processer.Enable = check;
                }
            }


            return true;
        }
        
        //TODO:Drag&Drop fuction waiting
        private void MainDialog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
                var data = e.Data;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        void MainDialog_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            FileTextbox.Text = files[0];
            Execute();
        }

        private void MainDialog_Load(object sender, EventArgs e)
        {
            
        }

        #region Button Clicked
        private void FileButton_Click(object sender, EventArgs e)
        {
            if (FileBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                FileTextbox.Text=FileBrowseDialog.FileName;
            }
          
        }

        private void ControlButton_Check_Click(object sender, EventArgs e)
        {
            Execute();
        }

        private void ControlButton_Verify_Click(object sender, EventArgs e)
        {
            Verify();
        }

        private void ControlButton_Both_Click(object sender, EventArgs e)
        {
            Execute();
            Verify();
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            TextTextbox.Text = Clipboard.GetText();
        }

        private void HashButton_Click(object sender, EventArgs e)
        {
            HashTextbox.Text = Clipboard.GetText();
        }

        #endregion

        #region Checkbox Changed
        private void TextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FileButton.Enabled = !TextCheckBox.Checked;
            FileTextbox.Enabled = !TextCheckBox.Checked;
            TextButton.Enabled = TextCheckBox.Checked;
            TextTextbox.Enabled = TextCheckBox.Checked;
        }

        #endregion

        
    }
}
