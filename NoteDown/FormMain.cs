using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NoteDown
{
    public partial class FormMain : Form
    {
        private TreeNode root = new TreeNode();
        private string fileFullPath = Application.StartupPath + "\\notedown.md";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadTreeView();
            TreeViewList.NodeMouseClick += (sv, ev) => HighlightContent(ev.Node);
            Content.KeyDown += (sv, ev) => SetHotKeyOnContent(ev);
            ReadConfig();
            SyntaxHighlight();
        }

        //TODO : Some Default Setting
        private void ReadConfig()
        {
            Content.Multiline = true;
            Content.WordWrap = true;
            Content.BackColor = SolarizedColors.BackGroundColor;
            this.WindowState = FormWindowState.Maximized;
            TreeViewList.Width = 300;
        }

        private void LoadTreeView()
        {
            Content.Clear();
            Content.Text = File.ReadAllText(fileFullPath, Encoding.UTF8);
            for (int i = 0; i < Content.Lines.Length; i++)
            {
                string line = Content.Lines[i];
                AddNodeOnTreeView(line);
            }
            TreeViewList.ExpandAll();
        }

        private void HighlightContent(TreeNode currentNode)
        {
            Content.SelectAll();
            Content.SelectionBackColor = SolarizedColors.BackGroundColor;
            Content.SelectionStart = Content.Text.IndexOf(currentNode.Text);
            Content.SelectionLength = currentNode.Text.Length;
            Content.SelectionBackColor = Color.White;
            Content.ScrollToCaret();
        }

        private void SyntaxHighlight()
        {
            string text = Content.Text;
            int start = 0;
            for (int index = 0; index < text.Length; index++)
            {
                if (text[index] == (char)10)
                {
                    Content.Select(start, index - start);
                }
                else if (text[index] == (char)32)
                {
                    if (start > 0 && text[start] == '#' && text[start - 1] != (char)32) continue;
                    else Content.Select(start, index - start);
                }
                else if (index == text.Length - 1)
                {
                    Content.Select(start, index + 1 - start);
                }
                else continue;
                Content.SelectionColor = SolarizedColors.GetHightightColor(Content.SelectedText);
                Content.SelectionFont = Markup.GetFont(Content.SelectedText);
                start = index + 1;
            }
        }

        private void SetHotKeyOnContent(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                File.WriteAllText(fileFullPath, Content.Text, Encoding.UTF8);
                TreeViewList.Nodes.Clear();
                LoadTreeView();
                ReadConfig();
                SyntaxHighlight();
                Content.DeselectAll();
            }
            else if (e.KeyCode == Keys.Escape) this.Close();
        }

        private void AddNodeOnTreeView(string line)
        {
            MarkdownTag header = Markup.GetStyle(line);
            if (header == MarkdownTag.FirstHeader)
            {
                root = new TreeNode(line);
                root.Name = line;
                TreeViewList.Nodes.Add(root);
            }
            else if (header == MarkdownTag.SecondHeader)
            {
                if (root == null)
                {
                    root = new TreeNode("notedown");
                    root.Name = "notedown";
                }
                TreeNode subNode = new TreeNode(line);
                subNode.Text = line;
                root.Nodes.Add(subNode);
            }
            else return;
        }
    }
}