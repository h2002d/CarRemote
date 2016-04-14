namespace CaRemoteClientServerWindowsForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelRightDoor = new System.Windows.Forms.Panel();
            this.panelLeftDoor = new System.Windows.Forms.Panel();
            this.startEngineBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.startEngineBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelRightDoor
            // 
            this.panelRightDoor.BackColor = System.Drawing.Color.Transparent;
            this.panelRightDoor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelRightDoor.Location = new System.Drawing.Point(343, 51);
            this.panelRightDoor.Name = "panelRightDoor";
            this.panelRightDoor.Size = new System.Drawing.Size(300, 81);
            this.panelRightDoor.TabIndex = 0;
            this.panelRightDoor.Click += new System.EventHandler(this.panelRightDoor_Click);
            // 
            // panelLeftDoor
            // 
            this.panelLeftDoor.BackColor = System.Drawing.Color.Transparent;
            this.panelLeftDoor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelLeftDoor.Location = new System.Drawing.Point(343, 346);
            this.panelLeftDoor.Name = "panelLeftDoor";
            this.panelLeftDoor.Size = new System.Drawing.Size(300, 81);
            this.panelLeftDoor.TabIndex = 1;
            this.panelLeftDoor.Click += new System.EventHandler(this.panelRightDoor_Click);
            // 
            // startEngineBox
            // 
            this.startEngineBox.BackColor = System.Drawing.Color.Transparent;
            this.startEngineBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startEngineBox.BackgroundImage")));
            this.startEngineBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startEngineBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startEngineBox.ImageLocation = "";
            this.startEngineBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("startEngineBox.InitialImage")));
            this.startEngineBox.Location = new System.Drawing.Point(136, 158);
            this.startEngineBox.Name = "startEngineBox";
            this.startEngineBox.Size = new System.Drawing.Size(141, 139);
            this.startEngineBox.TabIndex = 2;
            this.startEngineBox.TabStop = false;
            this.startEngineBox.Click += new System.EventHandler(this.startEngineBox_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(905, 490);
            this.Controls.Add(this.startEngineBox);
            this.Controls.Add(this.panelLeftDoor);
            this.Controls.Add(this.panelRightDoor);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CaRemote";
            ((System.ComponentModel.ISupportInitialize)(this.startEngineBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRightDoor;
        private System.Windows.Forms.Panel panelLeftDoor;
        private System.Windows.Forms.PictureBox startEngineBox;
    }
}

