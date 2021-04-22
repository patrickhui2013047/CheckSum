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
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarText = new System.Windows.Forms.ToolStripStatusLabel();
            this.HashPanel = new System.Windows.Forms.Panel();
            this.Hashtable = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.HashButton = new System.Windows.Forms.Button();
            this.HashTextbox = new System.Windows.Forms.TextBox();
            this.FileBrowseDialog = new System.Windows.Forms.OpenFileDialog();
            this.FilePanel = new System.Windows.Forms.Panel();
            this.FileTable = new System.Windows.Forms.TableLayoutPanel();
            this.FileButton = new System.Windows.Forms.Button();
            this.FileTextbox = new System.Windows.Forms.TextBox();
            this.FileLabel = new System.Windows.Forms.Label();
            this.TextPanel = new System.Windows.Forms.Panel();
            this.TextTable = new System.Windows.Forms.TableLayoutPanel();
            this.TextCheckBox = new System.Windows.Forms.CheckBox();
            this.TextButton = new System.Windows.Forms.Button();
            this.TextTextbox = new System.Windows.Forms.TextBox();
            this.HashContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.ControlTable = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.ControlButton_Check = new System.Windows.Forms.Button();
            this.ControlButton_Verify = new System.Windows.Forms.Button();
            this.ControlButton_Both = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.StatusBar.SuspendLayout();
            this.HashPanel.SuspendLayout();
            this.Hashtable.SuspendLayout();
            this.FilePanel.SuspendLayout();
            this.FileTable.SuspendLayout();
            this.TextPanel.SuspendLayout();
            this.TextTable.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.ControlTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarProgress,
            this.StatusBarText});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // StatusBarProgress
            // 
            this.StatusBarProgress.Name = "StatusBarProgress";
            resources.ApplyResources(this.StatusBarProgress, "StatusBarProgress");
            this.StatusBarProgress.Step = 1;
            // 
            // StatusBarText
            // 
            this.StatusBarText.Name = "StatusBarText";
            resources.ApplyResources(this.StatusBarText, "StatusBarText");
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
            // FilePanel
            // 
            this.FilePanel.Controls.Add(this.FileTable);
            resources.ApplyResources(this.FilePanel, "FilePanel");
            this.FilePanel.Name = "FilePanel";
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
            // 
            // HashContainer
            // 
            resources.ApplyResources(this.HashContainer, "HashContainer");
            this.HashContainer.Name = "HashContainer";
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.ControlTable);
            resources.ApplyResources(this.ControlPanel, "ControlPanel");
            this.ControlPanel.Name = "ControlPanel";
            // 
            // ControlTable
            // 
            resources.ApplyResources(this.ControlTable, "ControlTable");
            this.ControlTable.Controls.Add(this.button1, 0, 0);
            this.ControlTable.Controls.Add(this.ControlButton_Check, 1, 0);
            this.ControlTable.Controls.Add(this.ControlButton_Verify, 2, 0);
            this.ControlTable.Controls.Add(this.ControlButton_Both, 3, 0);
            this.ControlTable.Controls.Add(this.button5, 4, 0);
            this.ControlTable.Name = "ControlTable";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // ControlButton_Check
            // 
            resources.ApplyResources(this.ControlButton_Check, "ControlButton_Check");
            this.ControlButton_Check.Name = "ControlButton_Check";
            this.ControlButton_Check.UseVisualStyleBackColor = false;
            this.ControlButton_Check.Click += new System.EventHandler(this.ControlButton_Check_Click);
            // 
            // ControlButton_Verify
            // 
            resources.ApplyResources(this.ControlButton_Verify, "ControlButton_Verify");
            this.ControlButton_Verify.Name = "ControlButton_Verify";
            this.ControlButton_Verify.UseVisualStyleBackColor = false;
            this.ControlButton_Verify.Click += new System.EventHandler(this.ControlButton_Verify_Click);
            // 
            // ControlButton_Both
            // 
            resources.ApplyResources(this.ControlButton_Both, "ControlButton_Both");
            this.ControlButton_Both.Name = "ControlButton_Both";
            this.ControlButton_Both.UseVisualStyleBackColor = false;
            this.ControlButton_Both.Click += new System.EventHandler(this.ControlButton_Both_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // MainDialog
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.HashContainer);
            this.Controls.Add(this.TextPanel);
            this.Controls.Add(this.FilePanel);
            this.Controls.Add(this.HashPanel);
            this.Controls.Add(this.StatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainDialog";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Load += new System.EventHandler(this.MainDialog_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainDialog_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainDialog_DragEnter);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.HashPanel.ResumeLayout(false);
            this.Hashtable.ResumeLayout(false);
            this.Hashtable.PerformLayout();
            this.FilePanel.ResumeLayout(false);
            this.FileTable.ResumeLayout(false);
            this.FileTable.PerformLayout();
            this.TextPanel.ResumeLayout(false);
            this.TextTable.ResumeLayout(false);
            this.TextTable.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlTable.ResumeLayout(false);
            this.ControlTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Panel HashPanel;
        private System.Windows.Forms.TableLayoutPanel Hashtable;
        private System.Windows.Forms.Button HashButton;
        private System.Windows.Forms.TextBox HashTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog FileBrowseDialog;
        private System.Windows.Forms.Panel FilePanel;
        private System.Windows.Forms.TableLayoutPanel FileTable;
        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.TextBox FileTextbox;
        private System.Windows.Forms.Label FileLabel;
        private System.Windows.Forms.Panel TextPanel;
        private System.Windows.Forms.TableLayoutPanel TextTable;
        private System.Windows.Forms.CheckBox TextCheckBox;
        private System.Windows.Forms.Button TextButton;
        private System.Windows.Forms.TextBox TextTextbox;
        private System.Windows.Forms.FlowLayoutPanel HashContainer;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgress;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarText;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.TableLayoutPanel ControlTable;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button ControlButton_Both;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ControlButton_Verify;
        private System.Windows.Forms.Button ControlButton_Check;
    }
}

