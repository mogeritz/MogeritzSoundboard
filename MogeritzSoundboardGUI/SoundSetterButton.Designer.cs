using System.Runtime.CompilerServices;

namespace MogeritzSoundboardGUI
{
    partial class SoundSetterButton
    {

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            volumeBar.Size = new System.Drawing.Size(10, 92);
            volumeBar.TabIndex = 1;
            volumeBar.BackColor = Color.DodgerBlue;
            volumeBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            volumeBar.Padding = new System.Windows.Forms.Padding(10);
            volumeBar.Visible = false;

            padder.Size = new System.Drawing.Size(16, 16);
            padder.TabIndex = 0;
            padder.BackColor = Color.Transparent;
            padder.Dock = System.Windows.Forms.DockStyle.Right;
            padder.Padding = new Padding(3);
            padder.Visible = true;
            padder.Controls.Add(volumeBar);

            this.Font = new System.Drawing.Font("Arial Black", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Size = new System.Drawing.Size(86, 98);
            this.Padding = new System.Windows.Forms.Padding(10);
            this.TabIndex = 0;
            this.Text = "#";
            this.BackColor = Color.LightGray;
            this.Click += OnButtonClick;
            this.MouseDown += OnRightClick;
            this.MouseWheel += OnMouseScroll;

            this.Controls.Add(padder);
            padder.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        Panel volumeBar = new Panel();
        Panel padder = new Panel();

        #endregion
    }
}
