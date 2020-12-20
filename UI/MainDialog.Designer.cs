namespace UI
{
    partial class MainDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDialog));
            this.FileTable = new System.Windows.Forms.TableLayoutPanel();
            this.FileButton = new System.Windows.Forms.Button();
            this.FileTextbox = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.TextPanel = new System.Windows.Forms.Panel();
            this.TextTable = new System.Windows.Forms.TableLayoutPanel();
            this.TextCheckBox = new System.Windows.Forms.CheckBox();
            this.TextButton = new System.Windows.Forms.Button();
            this.TextTextbox = new System.Windows.Forms.TextBox();
            this.MD5Panel = new System.Windows.Forms.Panel();
            this.MD5Table = new System.Windows.Forms.TableLayoutPanel();
            this.MD5Button = new System.Windows.Forms.Button();
            this.MD5Textbox = new System.Windows.Forms.TextBox();
            this.MD5CheckBox = new System.Windows.Forms.CheckBox();
            this.SHA1Panel = new System.Windows.Forms.Panel();
            this.SHA1Table = new System.Windows.Forms.TableLayoutPanel();
            this.SHA1CheckBox = new System.Windows.Forms.CheckBox();
            this.SHA1Button = new System.Windows.Forms.Button();
            this.SHA1Textbox = new System.Windows.Forms.TextBox();
            this.SHA256Panel = new System.Windows.Forms.Panel();
            this.SHA256Table = new System.Windows.Forms.TableLayoutPanel();
            this.SHA256CheckBox = new System.Windows.Forms.CheckBox();
            this.SHA256Button = new System.Windows.Forms.Button();
            this.SHA256Textbox = new System.Windows.Forms.TextBox();
            this.SHA512Panel = new System.Windows.Forms.Panel();
            this.SHA512Table = new System.Windows.Forms.TableLayoutPanel();
            this.SHA512CheckBox = new System.Windows.Forms.CheckBox();
            this.SHA512Button = new System.Windows.Forms.Button();
            this.SHA512Textbox = new System.Windows.Forms.TextBox();
            this.HashPanel = new System.Windows.Forms.Panel();
            this.Hashtable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.HashButton = new System.Windows.Forms.Button();
            this.HashTextbox = new System.Windows.Forms.TextBox();
            this.FileBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            this.hashControl1 = new HashControl();
            this.hashControl2 = new HashControl();
            this.FileTable.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.TextPanel.SuspendLayout();
            this.TextTable.SuspendLayout();
            this.MD5Panel.SuspendLayout();
            this.MD5Table.SuspendLayout();
            this.SHA1Panel.SuspendLayout();
            this.SHA1Table.SuspendLayout();
            this.SHA256Panel.SuspendLayout();
            this.SHA256Table.SuspendLayout();
            this.SHA512Panel.SuspendLayout();
            this.SHA512Table.SuspendLayout();
            this.HashPanel.SuspendLayout();
            this.Hashtable.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileTable
            // 
            resources.ApplyResources(this.FileTable, "FileTable");
            this.FileTable.Controls.Add(this.FileButton, 2, 0);
            this.FileTable.Controls.Add(this.FileTextbox, 1, 0);
            this.FileTable.Controls.Add(this.FileLabel, 0, 0);
            this.FileTable.Name = "FileTable";
            // 
            // FileButton
            // 
            resources.ApplyResources(this.FileButton, "FileButton");
            this.FileButton.Name = "FileButton";
            this.FileButton.UseVisualStyleBackColor = false;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // FileTextbox
            // 
            resources.ApplyResources(this.FileTextbox, "FileTextbox");
            this.FileTextbox.Name = "FileTextbox";
            this.FileTextbox.ReadOnly = true;
            // 
            // FileLabel
            // 
            resources.ApplyResources(this.FileLabel, "FileLabel");
            this.FileLabel.Name = "FileLabel";
            // 
            // FilePanel
            // 
            this.FilePanel.Controls.Add(this.FileTable);
            resources.ApplyResources(this.FilePanel, "FilePanel");
            this.FilePanel.Name = "FilePanel";
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // TextPanel
            // 
            this.TextPanel.Controls.Add(this.TextTable);
            resources.ApplyResources(this.TextPanel, "TextPanel");
            this.TextPanel.Name = "TextPanel";
            // 
            // TextTable
            // 
            resources.ApplyResources(this.TextTable, "TextTable");
            this.TextTable.Controls.Add(this.TextCheckBox, 0, 0);
            this.TextTable.Controls.Add(this.TextButton, 2, 0);
            this.TextTable.Controls.Add(this.TextTextbox, 1, 0);
            this.TextTable.Name = "TextTable";
            // 
            // TextCheckBox
            // 
            resources.ApplyResources(this.TextCheckBox, "TextCheckBox");
            this.TextCheckBox.Name = "TextCheckBox";
            this.TextCheckBox.UseVisualStyleBackColor = true;
            this.TextCheckBox.CheckedChanged += new System.EventHandler(this.TextCheckBox_CheckedChanged);
            // 
            // TextButton
            // 
            resources.ApplyResources(this.TextButton, "TextButton");
            this.TextButton.Name = "TextButton";
            this.TextButton.UseVisualStyleBackColor = false;
            this.TextButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // TextTextbox
            // 
            resources.ApplyResources(this.TextTextbox, "TextTextbox");
            this.TextTextbox.Name = "TextTextbox";
            this.TextTextbox.ReadOnly = true;
            // 
            // MD5Panel
            // 
            this.MD5Panel.Controls.Add(this.MD5Table);
            resources.ApplyResources(this.MD5Panel, "MD5Panel");
            this.MD5Panel.Name = "MD5Panel";
            // 
            // MD5Table
            // 
            resources.ApplyResources(this.MD5Table, "MD5Table");
            this.MD5Table.Controls.Add(this.MD5Button, 2, 0);
            this.MD5Table.Controls.Add(this.MD5Textbox, 1, 0);
            this.MD5Table.Controls.Add(this.MD5CheckBox, 0, 0);
            this.MD5Table.Name = "MD5Table";
            // 
            // MD5Button
            // 
            resources.ApplyResources(this.MD5Button, "MD5Button");
            this.MD5Button.Name = "MD5Button";
            this.MD5Button.UseVisualStyleBackColor = false;
            this.MD5Button.Click += new System.EventHandler(this.MD5Button_Click);
            // 
            // MD5Textbox
            // 
            resources.ApplyResources(this.MD5Textbox, "MD5Textbox");
            this.MD5Textbox.Name = "MD5Textbox";
            this.MD5Textbox.ReadOnly = true;
            // 
            // MD5CheckBox
            // 
            resources.ApplyResources(this.MD5CheckBox, "MD5CheckBox");
            this.MD5CheckBox.Checked = true;
            this.MD5CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MD5CheckBox.Name = "MD5CheckBox";
            this.MD5CheckBox.UseVisualStyleBackColor = true;
            this.MD5CheckBox.CheckedChanged += new System.EventHandler(this.MD5CheckBox_CheckedChanged);
            // 
            // SHA1Panel
            // 
            this.SHA1Panel.Controls.Add(this.SHA1Table);
            resources.ApplyResources(this.SHA1Panel, "SHA1Panel");
            this.SHA1Panel.Name = "SHA1Panel";
            // 
            // SHA1Table
            // 
            resources.ApplyResources(this.SHA1Table, "SHA1Table");
            this.SHA1Table.Controls.Add(this.SHA1CheckBox, 0, 0);
            this.SHA1Table.Controls.Add(this.SHA1Button, 2, 0);
            this.SHA1Table.Controls.Add(this.SHA1Textbox, 1, 0);
            this.SHA1Table.Name = "SHA1Table";
            // 
            // SHA1CheckBox
            // 
            resources.ApplyResources(this.SHA1CheckBox, "SHA1CheckBox");
            this.SHA1CheckBox.Checked = true;
            this.SHA1CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SHA1CheckBox.Name = "SHA1CheckBox";
            this.SHA1CheckBox.UseVisualStyleBackColor = true;
            this.SHA1CheckBox.CheckedChanged += new System.EventHandler(this.SHA1CheckBox_CheckedChanged);
            // 
            // SHA1Button
            // 
            resources.ApplyResources(this.SHA1Button, "SHA1Button");
            this.SHA1Button.Name = "SHA1Button";
            this.SHA1Button.UseVisualStyleBackColor = false;
            this.SHA1Button.Click += new System.EventHandler(this.SHA1Button_Click);
            // 
            // SHA1Textbox
            // 
            resources.ApplyResources(this.SHA1Textbox, "SHA1Textbox");
            this.SHA1Textbox.Name = "SHA1Textbox";
            this.SHA1Textbox.ReadOnly = true;
            // 
            // SHA256Panel
            // 
            this.SHA256Panel.Controls.Add(this.SHA256Table);
            resources.ApplyResources(this.SHA256Panel, "SHA256Panel");
            this.SHA256Panel.Name = "SHA256Panel";
            // 
            // SHA256Table
            // 
            resources.ApplyResources(this.SHA256Table, "SHA256Table");
            this.SHA256Table.Controls.Add(this.SHA256CheckBox, 0, 0);
            this.SHA256Table.Controls.Add(this.SHA256Button, 2, 0);
            this.SHA256Table.Controls.Add(this.SHA256Textbox, 1, 0);
            this.SHA256Table.Name = "SHA256Table";
            // 
            // SHA256CheckBox
            // 
            resources.ApplyResources(this.SHA256CheckBox, "SHA256CheckBox");
            this.SHA256CheckBox.Checked = true;
            this.SHA256CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SHA256CheckBox.Name = "SHA256CheckBox";
            this.SHA256CheckBox.UseVisualStyleBackColor = true;
            this.SHA256CheckBox.CheckedChanged += new System.EventHandler(this.SHA256CheckBox_CheckedChanged);
            // 
            // SHA256Button
            // 
            resources.ApplyResources(this.SHA256Button, "SHA256Button");
            this.SHA256Button.Name = "SHA256Button";
            this.SHA256Button.UseVisualStyleBackColor = false;
            this.SHA256Button.Click += new System.EventHandler(this.SHA256Button_Click);
            // 
            // SHA256Textbox
            // 
            resources.ApplyResources(this.SHA256Textbox, "SHA256Textbox");
            this.SHA256Textbox.Name = "SHA256Textbox";
            this.SHA256Textbox.ReadOnly = true;
            // 
            // SHA512Panel
            // 
            this.SHA512Panel.Controls.Add(this.SHA512Table);
            resources.ApplyResources(this.SHA512Panel, "SHA512Panel");
            this.SHA512Panel.Name = "SHA512Panel";
            // 
            // SHA512Table
            // 
            resources.ApplyResources(this.SHA512Table, "SHA512Table");
            this.SHA512Table.Controls.Add(this.SHA512CheckBox, 0, 0);
            this.SHA512Table.Controls.Add(this.SHA512Button, 2, 0);
            this.SHA512Table.Controls.Add(this.SHA512Textbox, 1, 0);
            this.SHA512Table.Name = "SHA512Table";
            // 
            // SHA512CheckBox
            // 
            resources.ApplyResources(this.SHA512CheckBox, "SHA512CheckBox");
            this.SHA512CheckBox.Checked = true;
            this.SHA512CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SHA512CheckBox.Name = "SHA512CheckBox";
            this.SHA512CheckBox.UseVisualStyleBackColor = true;
            this.SHA512CheckBox.CheckedChanged += new System.EventHandler(this.SHA512CheckBox_CheckedChanged);
            // 
            // SHA512Button
            // 
            resources.ApplyResources(this.SHA512Button, "SHA512Button");
            this.SHA512Button.Name = "SHA512Button";
            this.SHA512Button.UseVisualStyleBackColor = false;
            this.SHA512Button.Click += new System.EventHandler(this.SHA512Button_Click);
            // 
            // SHA512Textbox
            // 
            resources.ApplyResources(this.SHA512Textbox, "SHA512Textbox");
            this.SHA512Textbox.Name = "SHA512Textbox";
            this.SHA512Textbox.ReadOnly = true;
            // 
            // HashPanel
            // 
            this.HashPanel.Controls.Add(this.Hashtable);
            resources.ApplyResources(this.HashPanel, "HashPanel");
            this.HashPanel.Name = "HashPanel";
            // 
            // Hashtable
            // 
            resources.ApplyResources(this.Hashtable, "Hashtable");
            this.Hashtable.Controls.Add(this.label1, 0, 0);
            this.Hashtable.Controls.Add(this.HashButton, 2, 0);
            this.Hashtable.Controls.Add(this.HashTextbox, 1, 0);
            this.Hashtable.Name = "Hashtable";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // HashButton
            // 
            resources.ApplyResources(this.HashButton, "HashButton");
            this.HashButton.Name = "HashButton";
            this.HashButton.UseVisualStyleBackColor = false;
            this.HashButton.Click += new System.EventHandler(this.HashButton_Click);
            // 
            // HashTextbox
            // 
            resources.ApplyResources(this.HashTextbox, "HashTextbox");
            this.HashTextbox.Name = "HashTextbox";
            // 
            // hashControl2
            // 
            resources.ApplyResources(this.hashControl2, "hashControl2");
            this.hashControl2.Name = "hashControl2";
            this.hashControl2.SetName("2");
            // 
            // hashControl1
            // 
            resources.ApplyResources(this.hashControl1, "hashControl1");
            this.hashControl1.Name = "hashControl1";
            this.hashControl1.SetName("1");
            // 
            // MainDialog
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hashControl1);
            this.Controls.Add(this.hashControl2);
            this.Controls.Add(this.HashPanel);
            this.Controls.Add(this.SHA512Panel);
            this.Controls.Add(this.SHA256Panel);
            this.Controls.Add(this.SHA1Panel);
            this.Controls.Add(this.MD5Panel);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.FilePanel);
            this.Controls.Add(this.StatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDialog_DragEnter);
            this.FileTable.ResumeLayout(false);
            this.FileTable.PerformLayout();
            this.FilePanel.ResumeLayout(false);
            this.TextPanel.ResumeLayout(false);
            this.TextTable.ResumeLayout(false);
            this.TextTable.PerformLayout();
            this.MD5Panel.ResumeLayout(false);
            this.MD5Table.ResumeLayout(false);
            this.MD5Table.PerformLayout();
            this.SHA1Panel.ResumeLayout(false);
            this.SHA1Table.ResumeLayout(false);
            this.SHA1Table.PerformLayout();
            this.SHA256Panel.ResumeLayout(false);
            this.SHA256Table.ResumeLayout(false);
            this.SHA256Table.PerformLayout();
            this.SHA512Panel.ResumeLayout(false);
            this.SHA512Table.ResumeLayout(false);
            this.SHA512Table.PerformLayout();
            this.HashPanel.ResumeLayout(false);
            this.Hashtable.ResumeLayout(false);
            this.Hashtable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.TableLayoutPanel FileTable;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.TextBox FileTextbox;
        private System.Windows.Forms.Panel TextPanel;
        private System.Windows.Forms.TableLayoutPanel TextTable;
        private System.Windows.Forms.Button TextButton;
        private System.Windows.Forms.TextBox TextTextbox;
        private System.Windows.Forms.Panel MD5Panel;
        private System.Windows.Forms.TableLayoutPanel MD5Table;
        private System.Windows.Forms.Button MD5Button;
        private System.Windows.Forms.TextBox MD5Textbox;
        private System.Windows.Forms.Panel SHA1Panel;
        private System.Windows.Forms.TableLayoutPanel SHA1Table;
        private System.Windows.Forms.Button SHA1Button;
        private System.Windows.Forms.TextBox SHA1Textbox;
        private System.Windows.Forms.Panel SHA256Panel;
        private System.Windows.Forms.TableLayoutPanel SHA256Table;
        private System.Windows.Forms.Button SHA256Button;
        private System.Windows.Forms.TextBox SHA256Textbox;
        private System.Windows.Forms.Panel SHA512Panel;
        private System.Windows.Forms.TableLayoutPanel SHA512Table;
        private System.Windows.Forms.Button SHA512Button;
        private System.Windows.Forms.TextBox SHA512Textbox;
        private System.Windows.Forms.Panel HashPanel;
        private System.Windows.Forms.TableLayoutPanel Hashtable;
        private System.Windows.Forms.Button HashButton;
        private System.Windows.Forms.TextBox HashTextbox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.CheckBox MD5CheckBox;
        private System.Windows.Forms.CheckBox TextCheckBox;
        private System.Windows.Forms.CheckBox SHA1CheckBox;
        private System.Windows.Forms.CheckBox SHA256CheckBox;
        private System.Windows.Forms.CheckBox SHA512CheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog FileBrowseDialog;
        private HashControl hashControl2;
        private HashControl hashControl1;
    }
}

