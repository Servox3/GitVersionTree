namespace GitVersionTree
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ExitButton = new System.Windows.Forms.Button();
            this.TargetPathGroupBox = new System.Windows.Forms.GroupBox();
            this.GitRepositoryPathTextBox = new System.Windows.Forms.TextBox();
            this.GitRepositoryPathBrowseButton = new System.Windows.Forms.Button();
            this.GitRepositoryPathLabel = new System.Windows.Forms.Label();
            this.PathConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.GraphvizDotPathBrowseButton = new System.Windows.Forms.Button();
            this.GitPathBrowseButton = new System.Windows.Forms.Button();
            this.GraphvizDotPathTextBox = new System.Windows.Forms.TextBox();
            this.GitPathTextBox = new System.Windows.Forms.TextBox();
            this.GraphvizDotPathLabel = new System.Windows.Forms.Label();
            this.GitPathLabel = new System.Windows.Forms.Label();
            this.StatusGroupBox = new System.Windows.Forms.GroupBox();
            this.StatusRichTextBox = new System.Windows.Forms.RichTextBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.HomepageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.TargetPathGroupBox.SuspendLayout();
            this.PathConfigurationGroupBox.SuspendLayout();
            this.StatusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Location = new System.Drawing.Point(539, 409);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(100, 28);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // TargetPathGroupBox
            // 
            this.TargetPathGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetPathGroupBox.Controls.Add(this.GitRepositoryPathTextBox);
            this.TargetPathGroupBox.Controls.Add(this.GitRepositoryPathBrowseButton);
            this.TargetPathGroupBox.Controls.Add(this.GitRepositoryPathLabel);
            this.TargetPathGroupBox.Location = new System.Drawing.Point(16, 137);
            this.TargetPathGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TargetPathGroupBox.Name = "TargetPathGroupBox";
            this.TargetPathGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TargetPathGroupBox.Size = new System.Drawing.Size(623, 69);
            this.TargetPathGroupBox.TabIndex = 2;
            this.TargetPathGroupBox.TabStop = false;
            this.TargetPathGroupBox.Text = "Target Path";
            // 
            // GitRepositoryPathTextBox
            // 
            this.GitRepositoryPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitRepositoryPathTextBox.Location = new System.Drawing.Point(160, 26);
            this.GitRepositoryPathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GitRepositoryPathTextBox.Name = "GitRepositoryPathTextBox";
            this.GitRepositoryPathTextBox.ReadOnly = true;
            this.GitRepositoryPathTextBox.Size = new System.Drawing.Size(333, 22);
            this.GitRepositoryPathTextBox.TabIndex = 1;
            // 
            // GitRepositoryPathBrowseButton
            // 
            this.GitRepositoryPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GitRepositoryPathBrowseButton.Location = new System.Drawing.Point(503, 23);
            this.GitRepositoryPathBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GitRepositoryPathBrowseButton.Name = "GitRepositoryPathBrowseButton";
            this.GitRepositoryPathBrowseButton.Size = new System.Drawing.Size(100, 28);
            this.GitRepositoryPathBrowseButton.TabIndex = 2;
            this.GitRepositoryPathBrowseButton.Text = "Browse";
            this.GitRepositoryPathBrowseButton.UseVisualStyleBackColor = true;
            this.GitRepositoryPathBrowseButton.Click += new System.EventHandler(this.GitRepositoryPathBrowseButton_Click);
            // 
            // GitRepositoryPathLabel
            // 
            this.GitRepositoryPathLabel.AutoSize = true;
            this.GitRepositoryPathLabel.Location = new System.Drawing.Point(13, 30);
            this.GitRepositoryPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GitRepositoryPathLabel.Name = "GitRepositoryPathLabel";
            this.GitRepositoryPathLabel.Size = new System.Drawing.Size(139, 17);
            this.GitRepositoryPathLabel.TabIndex = 0;
            this.GitRepositoryPathLabel.Text = "Git Repository Path :";
            // 
            // PathConfigurationGroupBox
            // 
            this.PathConfigurationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathConfigurationGroupBox.Controls.Add(this.GraphvizDotPathBrowseButton);
            this.PathConfigurationGroupBox.Controls.Add(this.GitPathBrowseButton);
            this.PathConfigurationGroupBox.Controls.Add(this.GraphvizDotPathTextBox);
            this.PathConfigurationGroupBox.Controls.Add(this.GitPathTextBox);
            this.PathConfigurationGroupBox.Controls.Add(this.GraphvizDotPathLabel);
            this.PathConfigurationGroupBox.Controls.Add(this.GitPathLabel);
            this.PathConfigurationGroupBox.Location = new System.Drawing.Point(16, 15);
            this.PathConfigurationGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PathConfigurationGroupBox.Name = "PathConfigurationGroupBox";
            this.PathConfigurationGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PathConfigurationGroupBox.Size = new System.Drawing.Size(623, 105);
            this.PathConfigurationGroupBox.TabIndex = 1;
            this.PathConfigurationGroupBox.TabStop = false;
            this.PathConfigurationGroupBox.Text = "Path Configuration";
            // 
            // GraphvizDotPathBrowseButton
            // 
            this.GraphvizDotPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphvizDotPathBrowseButton.Location = new System.Drawing.Point(503, 59);
            this.GraphvizDotPathBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GraphvizDotPathBrowseButton.Name = "GraphvizDotPathBrowseButton";
            this.GraphvizDotPathBrowseButton.Size = new System.Drawing.Size(100, 28);
            this.GraphvizDotPathBrowseButton.TabIndex = 5;
            this.GraphvizDotPathBrowseButton.Text = "Browse";
            this.GraphvizDotPathBrowseButton.UseVisualStyleBackColor = true;
            this.GraphvizDotPathBrowseButton.Click += new System.EventHandler(this.GraphvizDotPathBrowseButton_Click);
            // 
            // GitPathBrowseButton
            // 
            this.GitPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GitPathBrowseButton.Location = new System.Drawing.Point(503, 26);
            this.GitPathBrowseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GitPathBrowseButton.Name = "GitPathBrowseButton";
            this.GitPathBrowseButton.Size = new System.Drawing.Size(100, 28);
            this.GitPathBrowseButton.TabIndex = 2;
            this.GitPathBrowseButton.Text = "Browse";
            this.GitPathBrowseButton.UseVisualStyleBackColor = true;
            this.GitPathBrowseButton.Click += new System.EventHandler(this.GitPathBrowseButton_Click);
            // 
            // GraphvizDotPathTextBox
            // 
            this.GraphvizDotPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GraphvizDotPathTextBox.Location = new System.Drawing.Point(160, 62);
            this.GraphvizDotPathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GraphvizDotPathTextBox.Name = "GraphvizDotPathTextBox";
            this.GraphvizDotPathTextBox.ReadOnly = true;
            this.GraphvizDotPathTextBox.Size = new System.Drawing.Size(333, 22);
            this.GraphvizDotPathTextBox.TabIndex = 4;
            // 
            // GitPathTextBox
            // 
            this.GitPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GitPathTextBox.Location = new System.Drawing.Point(160, 28);
            this.GitPathTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GitPathTextBox.Name = "GitPathTextBox";
            this.GitPathTextBox.ReadOnly = true;
            this.GitPathTextBox.Size = new System.Drawing.Size(333, 22);
            this.GitPathTextBox.TabIndex = 1;
            // 
            // GraphvizDotPathLabel
            // 
            this.GraphvizDotPathLabel.AutoSize = true;
            this.GraphvizDotPathLabel.Location = new System.Drawing.Point(19, 65);
            this.GraphvizDotPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GraphvizDotPathLabel.Name = "GraphvizDotPathLabel";
            this.GraphvizDotPathLabel.Size = new System.Drawing.Size(132, 17);
            this.GraphvizDotPathLabel.TabIndex = 3;
            this.GraphvizDotPathLabel.Text = "Graphviz Dot Path :";
            // 
            // GitPathLabel
            // 
            this.GitPathLabel.AutoSize = true;
            this.GitPathLabel.Location = new System.Drawing.Point(84, 32);
            this.GitPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GitPathLabel.Name = "GitPathLabel";
            this.GitPathLabel.Size = new System.Drawing.Size(67, 17);
            this.GitPathLabel.TabIndex = 0;
            this.GitPathLabel.Text = "Git Path :";
            // 
            // StatusGroupBox
            // 
            this.StatusGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusGroupBox.Controls.Add(this.StatusRichTextBox);
            this.StatusGroupBox.Location = new System.Drawing.Point(16, 226);
            this.StatusGroupBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusGroupBox.Name = "StatusGroupBox";
            this.StatusGroupBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusGroupBox.Size = new System.Drawing.Size(623, 175);
            this.StatusGroupBox.TabIndex = 0;
            this.StatusGroupBox.TabStop = false;
            this.StatusGroupBox.Text = "Status";
            // 
            // StatusRichTextBox
            // 
            this.StatusRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusRichTextBox.Location = new System.Drawing.Point(8, 23);
            this.StatusRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StatusRichTextBox.Name = "StatusRichTextBox";
            this.StatusRichTextBox.Size = new System.Drawing.Size(605, 143);
            this.StatusRichTextBox.TabIndex = 0;
            this.StatusRichTextBox.Text = "";
            // 
            // GenerateButton
            // 
            this.GenerateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.GenerateButton.Location = new System.Drawing.Point(16, 409);
            this.GenerateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(100, 28);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // HomepageLinkLabel
            // 
            this.HomepageLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HomepageLinkLabel.AutoSize = true;
            this.HomepageLinkLabel.Location = new System.Drawing.Point(452, 415);
            this.HomepageLinkLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HomepageLinkLabel.Name = "HomepageLinkLabel";
            this.HomepageLinkLabel.Size = new System.Drawing.Size(77, 17);
            this.HomepageLinkLabel.TabIndex = 4;
            this.HomepageLinkLabel.TabStop = true;
            this.HomepageLinkLabel.Text = "Homepage";
            this.HomepageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomepageLinkLabel_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 450);
            this.Controls.Add(this.HomepageLinkLabel);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.StatusGroupBox);
            this.Controls.Add(this.PathConfigurationGroupBox);
            this.Controls.Add(this.TargetPathGroupBox);
            this.Controls.Add(this.ExitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Git Version Tree";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TargetPathGroupBox.ResumeLayout(false);
            this.TargetPathGroupBox.PerformLayout();
            this.PathConfigurationGroupBox.ResumeLayout(false);
            this.PathConfigurationGroupBox.PerformLayout();
            this.StatusGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.GroupBox TargetPathGroupBox;
        private System.Windows.Forms.TextBox GitRepositoryPathTextBox;
        private System.Windows.Forms.Button GitRepositoryPathBrowseButton;
        private System.Windows.Forms.Label GitRepositoryPathLabel;
        private System.Windows.Forms.GroupBox PathConfigurationGroupBox;
        private System.Windows.Forms.TextBox GraphvizDotPathTextBox;
        private System.Windows.Forms.TextBox GitPathTextBox;
        private System.Windows.Forms.Label GraphvizDotPathLabel;
        private System.Windows.Forms.Label GitPathLabel;
        private System.Windows.Forms.GroupBox StatusGroupBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.Button GraphvizDotPathBrowseButton;
        private System.Windows.Forms.Button GitPathBrowseButton;
        private System.Windows.Forms.LinkLabel HomepageLinkLabel;
        private System.Windows.Forms.RichTextBox StatusRichTextBox;
    }
}

