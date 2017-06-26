using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SerialDebugParser
{
  public partial class DebugWindows : Form
  {
    DebugPrint printer;
    SerialPort kernel;
    SerialPort userland;

    System.Threading.Thread t;

    public DebugWindows()
    {
      InitializeComponent();
      printer = new DebugPrint(debug_log, debug_tree);
      printer.SetKernelState(show_kernel.Checked);
      printer.SetUserlandState(show_userland.Checked);

      kernel = new SerialPort("COM5");
      userland = new SerialPort("COM6");
      kernel.Open();
      userland.Open();

      kernel.ReadTimeout = 10;
      userland.ReadTimeout = 10;

      t = new System.Threading.Thread(Poll);
      t.Priority = System.Threading.ThreadPriority.Lowest;
      t.Start();

#if false
      printer.Append(DebugType.Kernel, "---> F1"); 
     printer.Append(DebugType.Kernel, "---> F2"); 
     printer.Append(DebugType.Kernel, "<--- F2"); 
     printer.Append(DebugType.Kernel, "---> F3"); 
     printer.Append(DebugType.Kernel, "---> F4"); 
     printer.Append(DebugType.Kernel, "Just something"); 
     printer.Append(DebugType.Kernel, "<--- F4"); 
     printer.Append(DebugType.Kernel, "<--- F3"); 
     printer.Append(DebugType.Kernel, "<--- F1"); 
#endif
    }

    private void show_kernel_CheckedChanged(object sender, EventArgs e)
    {
      printer.SetKernelState(show_kernel.Checked);
    }

    private void show_userland_CheckedChanged(object sender, EventArgs e)
    {
      printer.SetUserlandState(show_userland.Checked);
    }

    private void button1_Click(object sender, EventArgs e)
    {
      printer.Clear();
    }

    void Poll() {
      while (!this.IsDisposed) {
        try {
          MethodInvoker kmi = delegate() {
            try {
              printer.Append(DebugType.Kernel, kernel.ReadLine());
            } catch (TimeoutException e) { }
          };
          this.Invoke(kmi);

          MethodInvoker umi = delegate() {
            try {
              printer.Append(DebugType.Userland, userland.ReadLine());
            } catch (TimeoutException e) { }
          };
          this.Invoke(umi);
          System.Threading.Thread.Sleep(100);
        } catch (Exception e) { }
      }
    }

    private void pause_Click(object sender, EventArgs e)
    {
      if (pause.Text.Contains("pause")) {
        pause.Text = "continue";
        t.Suspend();
      }
      else {
        pause.Text = "pause";
        t.Resume();
      }
    }
  }
}
