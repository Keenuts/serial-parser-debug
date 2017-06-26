using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SerialDebugParser
{
  enum DebugType {
    Kernel, Userland
  };

  struct DebugEntry
  {
    public DebugType type;
    public string value;
  };
  class DebugTree {
    List<DebugTree> children;
    DebugTree parent;
    DebugEntry entry;

    public DebugTree(DebugTree parent, DebugEntry entry) {
      this.parent = parent;
      this.entry = entry;
      children = new List<DebugTree>();
    }

    public TreeNode GetTree() {
      List<TreeNode> c = new List<TreeNode>();
      
      foreach(DebugTree n in children)
        c.Add(n.GetTree());

      return new TreeNode(entry.value, c.ToArray());
    }

    public DebugTree AddChild(DebugEntry entry) {
      DebugTree t = new DebugTree(this, entry);
      children.Add(t);
      return t;
    }

    public DebugTree GetParent() {
      return parent;
    }
  }

  class DebugPrint
  {
    bool print_kernel;
    bool print_userland;

    List<DebugEntry> entries;
    List<DebugTree> kernel_tree;
    DebugTree current_kernel_node;

    ListBox list; 
    TreeView tree_view;

    public DebugPrint(ListBox list, TreeView tree)
    {
      this.list = list;
      this.tree_view = tree;
      entries = new List<DebugEntry>();
      kernel_tree = new List<DebugTree>();
    }

    public void SetKernelState(bool state)
    {
      print_kernel = state;
      refreshAll();
    }

    public void SetUserlandState(bool state)
    {
      print_userland = state;
      refreshAll();
    }

    public void Clear() {
      entries.Clear();
      tree_view.Nodes.Clear();
      kernel_tree.Clear();
      current_kernel_node = null;
      refreshAll();
    }

    void refreshAll()
    {
      list.Items.Clear();
      foreach (DebugEntry e in entries) {
        if (e.type == DebugType.Kernel && print_kernel)
          list.Items.Add(e.value);
        if (e.type == DebugType.Userland && print_userland)
          list.Items.Add(e.value);
      }
      refresh_tree();
    }
    private void refresh_tree() {
      List<TreeNode> nodes = new List<TreeNode>();
      foreach(DebugTree t in kernel_tree)
        nodes.Add(t.GetTree());

      tree_view.Nodes.Clear();
      tree_view.Nodes.AddRange(nodes.ToArray());
    }

    public void Append(DebugType type, string str) {
      DebugEntry entry;
      entry.type = type;
      entry.value = str;
      entries.Add(entry);

      if (type == DebugType.Kernel && print_kernel) {
        list.Items.Add(str);
        AddToTree(entry);
        refresh_tree();
      }
      if (type == DebugType.Userland && print_userland)
        list.Items.Add(str);
    }

    void AddToTree(DebugEntry entry) {
      bool set_current = false;

      if (!entry.value.Contains("<--->")) {
        if (entry.value.Contains("--->"))
          set_current = true;
        else if (entry.value.Contains("<---") && current_kernel_node != null)
          current_kernel_node = current_kernel_node.GetParent();
        else if (entry.value.Contains("|->")) {
          current_kernel_node = null;
          set_current = true;
        }
      }

      if (current_kernel_node == null) {
        DebugTree t = new DebugTree(null, entry);
        kernel_tree.Add(t);
        if (set_current)
          current_kernel_node = t;
      }
      else {
        DebugTree t = current_kernel_node.AddChild(entry);
        if (set_current)
          current_kernel_node = t;
      }
    }
  }
}
