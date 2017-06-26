namespace SerialDebugParser
{
  partial class DebugWindows
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
      this.button1 = new System.Windows.Forms.Button();
      this.show_userland = new System.Windows.Forms.CheckBox();
      this.show_kernel = new System.Windows.Forms.CheckBox();
      this.debug_log = new System.Windows.Forms.ListBox();
      this.debug_tree = new System.Windows.Forms.TreeView();
      this.pause = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(447, 474);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "clear";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // show_userland
      // 
      this.show_userland.AutoSize = true;
      this.show_userland.Checked = true;
      this.show_userland.CheckState = System.Windows.Forms.CheckState.Checked;
      this.show_userland.Location = new System.Drawing.Point(12, 474);
      this.show_userland.Name = "show_userland";
      this.show_userland.Size = new System.Drawing.Size(68, 17);
      this.show_userland.TabIndex = 1;
      this.show_userland.Text = "Userland";
      this.show_userland.UseVisualStyleBackColor = true;
      this.show_userland.CheckedChanged += new System.EventHandler(this.show_userland_CheckedChanged);
      // 
      // show_kernel
      // 
      this.show_kernel.AutoSize = true;
      this.show_kernel.Checked = true;
      this.show_kernel.CheckState = System.Windows.Forms.CheckState.Checked;
      this.show_kernel.Location = new System.Drawing.Point(98, 474);
      this.show_kernel.Name = "show_kernel";
      this.show_kernel.Size = new System.Drawing.Size(56, 17);
      this.show_kernel.TabIndex = 2;
      this.show_kernel.Text = "Kernel";
      this.show_kernel.UseVisualStyleBackColor = true;
      this.show_kernel.CheckedChanged += new System.EventHandler(this.show_kernel_CheckedChanged);
      // 
      // debug_log
      // 
      this.debug_log.FormattingEnabled = true;
      this.debug_log.Location = new System.Drawing.Point(12, 12);
      this.debug_log.Name = "debug_log";
      this.debug_log.Size = new System.Drawing.Size(510, 446);
      this.debug_log.TabIndex = 3;
      // 
      // debug_tree
      // 
      this.debug_tree.Location = new System.Drawing.Point(528, 12);
      this.debug_tree.Name = "debug_tree";
      this.debug_tree.Size = new System.Drawing.Size(493, 446);
      this.debug_tree.TabIndex = 4;
      // 
      // pause
      // 
      this.pause.Location = new System.Drawing.Point(528, 474);
      this.pause.Name = "pause";
      this.pause.Size = new System.Drawing.Size(75, 23);
      this.pause.TabIndex = 5;
      this.pause.Text = "pause";
      this.pause.UseVisualStyleBackColor = true;
      this.pause.Click += new System.EventHandler(this.pause_Click);
      // 
      // DebugWindows
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1033, 509);
      this.Controls.Add(this.pause);
      this.Controls.Add(this.debug_tree);
      this.Controls.Add(this.debug_log);
      this.Controls.Add(this.show_kernel);
      this.Controls.Add(this.show_userland);
      this.Controls.Add(this.button1);
      this.Name = "DebugWindows";
      this.Text = "DebugWindows";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox show_userland;
    private System.Windows.Forms.CheckBox show_kernel;
    private System.Windows.Forms.ListBox debug_log;
    private System.Windows.Forms.TreeView debug_tree;
    private System.Windows.Forms.Button pause;
  }
}