namespace UI
{
    partial class HashControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Check = new System.Windows.Forms.CheckBox();
            this.Text = new System.Windows.Forms.TextBox();
            this.Button = new System.Windows.Forms.Button();
            this.PanelTable = new System.Windows.Forms.TableLayoutPanel();
            this.PanelTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.AutoSize = true;
            this.Check.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Check.Location = new System.Drawing.Point(2, 2);
            this.Check.Margin = new System.Windows.Forms.Padding(2);
            this.Check.MaximumSize = new System.Drawing.Size(73, 29);
            this.Check.MinimumSize = new System.Drawing.Size(73, 29);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(73, 29);
            this.Check.TabIndex = 0;
            this.Check.Text = "Check";
            this.Check.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Check.UseVisualStyleBackColor = true;
            this.Check.CheckedChanged += new System.EventHandler(this.Check_CheckedChanged);
            // 
            // Text
            // 
            this.Text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Text.Location = new System.Drawing.Point(79, 2);
            this.Text.Margin = new System.Windows.Forms.Padding(2);
            this.Text.MaximumSize = new System.Drawing.Size(332, 22);
            this.Text.MinimumSize = new System.Drawing.Size(332, 22);
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            this.Text.Size = new System.Drawing.Size(332, 22);
            this.Text.TabIndex = 0;
            // 
            // Button
            // 
            this.Button.AutoSize = true;
            this.Button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Button.Location = new System.Drawing.Point(415, 2);
            this.Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 5);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(100, 26);
            this.Button.TabIndex = 0;
            this.Button.UseVisualStyleBackColor = false;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // PanelTable
            // 
            this.PanelTable.ColumnCount = 3;
            this.PanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.PanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.PanelTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.PanelTable.Controls.Add(this.Check, 0, 0);
            this.PanelTable.Controls.Add(this.Text, 1, 0);
            this.PanelTable.Controls.Add(this.Button, 2, 0);
            this.PanelTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelTable.Location = new System.Drawing.Point(3, 1);
            this.PanelTable.Margin = new System.Windows.Forms.Padding(0);
            this.PanelTable.Name = "PanelTable";
            this.PanelTable.RowCount = 1;
            this.PanelTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.PanelTable.Size = new System.Drawing.Size(517, 28);
            this.PanelTable.TabIndex = 0;
            // 
            // HashControl
            // 
            this.Controls.Add(this.PanelTable);
            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(0, 30);
            this.MinimumSize = new System.Drawing.Size(0, 30);
            this.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Size = new System.Drawing.Size(523, 30);
            this.PanelTable.ResumeLayout(false);
            this.PanelTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Check;
        private System.Windows.Forms.TextBox Text;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.TableLayoutPanel PanelTable;
    }
}
