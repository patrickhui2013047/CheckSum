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

        HashControl MD5Field;
        List<HashProcesser> HashList = new List<HashProcesser>();
        public MainDialog()
        {
            InitializeComponent();
            //custom control setting
            MD5Field = new HashControl("MD5");
            
            
            
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
            foreach(HashProcesser processer in HashList.Where(arg => arg.Enable))
            {
                processer.Run(InputStream);
                switch (processer.Name)
                {
                    case "MD5":
                        MD5Textbox.Text = processer.OutString;
                        break;
                    case "SHA-1":
                        SHA1Textbox.Text = processer.OutString;
                        break;
                    case "SHA-256":
                        SHA256Textbox.Text = processer.OutString;
                        break;
                    case "SHA-512":
                        SHA512Textbox.Text = processer.OutString;
                        break;
                    
                    default:
                        if (NoMoreHashAllowed)
                        {
                            throw new Exception("Unknown Hash Algorithm is processed\n" + processer.Name);
                        }
                        break;
                }
                InputStream.Position = 0;
            }
        }

        //TODO:Drag&Drop fuction waiting
        private void MainDialog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;

            }
        }

        private void MainDialog_Load(object sender, EventArgs e)
        {
            //flowLayoutPanel1.Controls.Add(MD5Field);
        }
        //TODO:Add verify button
        #region Button Clicked
        private void FileButton_Click(object sender, EventArgs e)
        {
            if (FileBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                FileTextbox.Text=FileBrowseDialog.FileName;
            }
            if (!TextCheckBox.Checked)
            {
                InputStream= new FileStream(FileTextbox.Text.ToString(), FileMode.Open, FileAccess.Read);
                Execute();
            }
            
        }
        
        private void MD5Button_Click(object sender, EventArgs e)
        {
            MD5Textbox.SelectAll();
            MD5Textbox.Copy();
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            TextTextbox.Text = Clipboard.GetText();
        }

        private void SHA1Button_Click(object sender, EventArgs e)
        {
            SHA1Textbox.SelectAll();
            SHA1Textbox.Copy();
        }

        private void SHA256Button_Click(object sender, EventArgs e)
        {
            SHA256Textbox.SelectAll();
            SHA256Textbox.Copy();
        }

        private void SHA512Button_Click(object sender, EventArgs e)
        {
            SHA512Textbox.SelectAll();
            SHA512Textbox.Copy();
        }

        private void HashButton_Click(object sender, EventArgs e)
        {
            HashTextbox.SelectAll();
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

        private void MD5CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MD5Textbox.Enabled = MD5CheckBox.Checked;
            MD5Button.Enabled = MD5CheckBox.Checked;
        }

        private void SHA1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SHA1Textbox.Enabled = SHA1CheckBox.Checked;
            SHA1Button.Enabled = SHA1CheckBox.Checked;
        }

        private void SHA256CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SHA256Textbox.Enabled = SHA256CheckBox.Checked;
            SHA256Button.Enabled = SHA256CheckBox.Checked;
        }

        private void SHA512CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SHA512Textbox.Enabled = SHA512CheckBox.Checked;
            SHA512Button.Enabled = SHA512CheckBox.Checked;
        }
        #endregion
    }
}
