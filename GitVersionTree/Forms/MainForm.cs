using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.IO;

namespace GitVersionTree
{
    public partial class MainForm : Form
    {
        private readonly string dateSince = "2016-04-19 11:20:00";
        //private readonly string dateSince = "1999-04-19 11:20:00";
        //private readonly string dateSince = "2015-04-17 00:00:00";

        private Dictionary<string, string> DecorateDictionary = new Dictionary<string, string>();
        private List<List<string>> Nodes = new List<List<string>>();

        private string DotFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + Application.ProductName + ".dot";
        private string PdfFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + Application.ProductName + ".pdf";
        private string LogFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + Application.ProductName + ".log";
        string RepositoryName;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            GenerateButton.Select();
            Text = Application.ProductName + " - v" + Application.ProductVersion.Substring(0, 3);

            RefreshPath();
        }

        private void GitPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseOpenFileDialog = new OpenFileDialog();
            BrowseOpenFileDialog.Title = "Select git.exe";
            if (!String.IsNullOrEmpty(Reg.Read("GitPath")))
            {
                BrowseOpenFileDialog.InitialDirectory = Reg.Read("GitPath");
            }
            BrowseOpenFileDialog.FileName = "git.exe";
            BrowseOpenFileDialog.Filter = "Git Application (git.exe)|git.exe";
            if (BrowseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Reg.Write("GitPath", BrowseOpenFileDialog.FileName);
                RefreshPath();
            }
        }

        private void GraphvizDotPathBrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseOpenFileDialog = new OpenFileDialog();
            BrowseOpenFileDialog.Title = "Select dot.exe";
            if (!String.IsNullOrEmpty(Reg.Read("GraphvizPath")))
            {
                BrowseOpenFileDialog.InitialDirectory = Reg.Read("GraphvizPath");
            }
            BrowseOpenFileDialog.FileName = "dot.exe";
            BrowseOpenFileDialog.Filter = "Graphviz Dot Application (dot.exe)|dot.exe";
            if (BrowseOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                Reg.Write("GraphvizPath", BrowseOpenFileDialog.FileName);
                RefreshPath();
            }
        }

        private void GitRepositoryPathBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog BrowseFolderBrowserDialog = new FolderBrowserDialog();
            BrowseFolderBrowserDialog.Description = "Select Git repository";
            BrowseFolderBrowserDialog.ShowNewFolderButton = false;
            if (!String.IsNullOrEmpty(Reg.Read("GitRepositoryPath")))
            {
                BrowseFolderBrowserDialog.SelectedPath = Reg.Read("GitRepositoryPath");
            }
            if (BrowseFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Reg.Write("GitRepositoryPath", BrowseFolderBrowserDialog.SelectedPath);
                RefreshPath();
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Reg.Read("GitPath")) ||
                String.IsNullOrEmpty(Reg.Read("GraphvizPath")) ||
                String.IsNullOrEmpty(Reg.Read("GitRepositoryPath")))
            {
                MessageBox.Show("Please select a Git, Graphviz & Git repository.", "Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                StatusRichTextBox.Text = "";
                RepositoryName = new DirectoryInfo(GitRepositoryPathTextBox.Text).Name;
                DotFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + RepositoryName + ".dot";
                PdfFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + RepositoryName + ".pdf";
                LogFilename = Directory.GetParent(Application.ExecutablePath) + @"\" + RepositoryName + ".log";
                File.WriteAllText(LogFilename, "");
                Generate();
            }
        }

        private void HomepageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/crc8/GitVersionTree");
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshPath()
        {
            if (!String.IsNullOrEmpty(Reg.Read("GitPath")))
            {
                GitPathTextBox.Text = Reg.Read("GitPath");
            }
            if (!String.IsNullOrEmpty(Reg.Read("GraphvizPath")))
            {
                GraphvizDotPathTextBox.Text = Reg.Read("GraphvizPath");
            }
            if (!String.IsNullOrEmpty(Reg.Read("GitRepositoryPath")))
            {
                GitRepositoryPathTextBox.Text = Reg.Read("GitRepositoryPath");
            }
        }

        private void Status(string Message)
        {
            StatusRichTextBox.AppendText(DateTime.Now + " - " + Message + "\r\n");
            StatusRichTextBox.SelectionStart = StatusRichTextBox.Text.Length;
            StatusRichTextBox.ScrollToCaret();
            Refresh();
        }

        private string Execute(string Command, string Argument)
        {
            string ExecuteResult = String.Empty;
            Process ExecuteProcess = new Process();
            ExecuteProcess.StartInfo.UseShellExecute = false;
            ExecuteProcess.StartInfo.CreateNoWindow = true;
            ExecuteProcess.StartInfo.RedirectStandardOutput = true;
            ExecuteProcess.StartInfo.FileName = Command;
            ExecuteProcess.StartInfo.Arguments = Argument;
            ExecuteProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ExecuteProcess.Start();
            ExecuteResult = ExecuteProcess.StandardOutput.ReadToEnd();
            ExecuteProcess.WaitForExit();
            if (ExecuteProcess.ExitCode == 0)
            {
                return ExecuteResult;
            }
            else
            {
                return String.Empty;
            }
        }

        private void Generate()
        {
            string Result;
            string[] MergedColumns;
            string[] MergedParents;

            //Get Commits
            Status("Getting git commit(s) ...");
            Result = Execute(Reg.Read("GitPath"), "--git-dir \"" + Reg.Read("GitRepositoryPath") + "\\.git\" log --all --since \"" + dateSince + "\" --pretty=format:\"%h|%p|%d\"");
            //Result has one commit on each line with its parents and possible tag and branch names separated by '|':
            // bf39d87|d141686 cd7d12d| (develop)
            // 61f5a72 | 3aafc72 cd7d12d| (tag: OutlookClientV4.0.7, master)
            // 64ac0ef|5c7fbca| (HEAD -> feature/TransparentMapper, origin/feature/TransparentMapper)

            if (String.IsNullOrEmpty(Result))
            {
                Status("Unable to get get branch or branch empty ...");
            }
            else
            {
                File.AppendAllText(LogFilename, "[commit(s)]\r\n");
                File.AppendAllText(LogFilename, Result + "\r\n");
                //Split all commits into an array of commit lines
                string[] CommitLines = Result.Split('\n');
                foreach (string DecorateLine in CommitLines)
                {
                    //Split the commitline into commit, parent and decorations, ie
                    // "f8fb34a|bf39d87| (origin/feature/ElasticSearch)" will be split to
                    // MergedColumns = string[]{
                    //     f8fb34a
                    //     bf39d87
                    //     (origin/feature/ElasticSearch)"
                    // }
                    MergedColumns = DecorateLine.Split('|');
                    if (!String.IsNullOrEmpty(MergedColumns[2]))
                    {
                        //Add each decorated commit with its commit hash as key and the decoration as value, ie:
                        // {[f8fb34a,  (origin/feature/ElasticSearch)]}
                        DecorateDictionary.Add(MergedColumns[0], MergedColumns[2]);
                    }
                }
                Status("Processed " + DecorateDictionary.Count + " decorate(s) ...");
            }

            // Ref is named branches
            Status("Getting git ref branch(es) ...");
            Result = Execute(Reg.Read("GitPath"), "--git-dir \"" + Reg.Read("GitRepositoryPath") + "\\.git\" for-each-ref --format=\"%(objectname:short)|%(refname:short)\" ");
            //refs/heads/
            // Result now contains each branch and tag and the stash head on a separate line with its short commit hash:
            // 5927428 | origin / release / v4.2
            // 92959e9 | stash
            // 69513b7 | Json_6.0.8

            if (String.IsNullOrEmpty(Result))
            {
                Status("Unable to get get branch or branch empty ...");
            }
            else
            {
                File.AppendAllText(LogFilename, "[ref branch(es)]\r\n");
                File.AppendAllText(LogFilename, Result + "\r\n");
                string[] RefLines = Result.Split('\n');

                // Collect all first-parent nodes of each branch separately
                foreach (string RefLine in RefLines)
                {
                    if (!String.IsNullOrEmpty(RefLine))
                    {
                        string[] RefColumns = RefLine.Split('|');
                        if (!RefColumns[1].ToLower().StartsWith("refs/tags"))
                            Result = Execute(Reg.Read("GitPath"), "--git-dir \"" + Reg.Read("GitRepositoryPath") + "\\.git\" log --reverse --first-parent --since \"" + dateSince + "\" --pretty=format:\"%h\" " + RefColumns[0]);
                        //Result now has all the first-parents of the branch
                        if (String.IsNullOrEmpty(Result))
                        {
                            Status("Unable to get commit(s) ...");
                        }
                        else
                        {
                            //Add the branch commits to the graph
                            string[] HashLines = Result.Split('\n');
                            Nodes.Add(new List<string>());
                            foreach (string HashLine in HashLines)
                            {
                                Nodes[Nodes.Count - 1].Add(HashLine);
                            }
                        }
                    }
                }
            }

            //Treat all merges
            Status("Getting git merged branch(es) ...");
            Result = Execute(Reg.Read("GitPath"), "--git-dir \"" + Reg.Read("GitRepositoryPath") + "\\.git\" log --all --merges --since \"" + dateSince + "\" --pretty=format:\"%h|%p\"");
            if (String.IsNullOrEmpty(Result))
            {
                Status("Unable to get get branch or branch empty ...");
            }
            else
            {
                File.AppendAllText(LogFilename, "[merged branch(es)]\r\n");
                File.AppendAllText(LogFilename, Result + "\r\n");
                string[] MergedLines = Result.Split('\n');
                foreach (string MergedLine in MergedLines)
                {
                    MergedColumns = MergedLine.Split('|');
                    MergedParents = MergedColumns[1].Split(' ');
                    if (MergedParents.Length > 1)
                    {
                        for (int i = 1; i < MergedParents.Length; i++)
                        {
                            Result = Execute(Reg.Read("GitPath"), "--git-dir \"" + Reg.Read("GitRepositoryPath") + "\\.git\" log --reverse --first-parent --since \"" + dateSince + "\" --pretty=format:\"%h\" " + MergedParents[i]);
                            if (String.IsNullOrEmpty(Result))
                            {
                                Status("Unable to get commit(s) ...");
                            }
                            else
                            {
                                string[] HashLines = Result.Split('\n');
                                Nodes.Add(new List<string>());
                                foreach (string HashLine in HashLines)
                                {
                                    Nodes[Nodes.Count - 1].Add(HashLine);
                                }
                                Nodes[Nodes.Count - 1].Add(MergedColumns[0]);
                            }
                        }
                    }
                }
            }

            Status("Processed " + Nodes.Count + " branch(es) ...");

            Nodes = new Reducer().ReduceNodes(Nodes, DecorateDictionary);

            StringBuilder DotStringBuilder = new StringBuilder();
            Status("Generating dot file ...");
            DotStringBuilder.Append("strict digraph \"" + RepositoryName + "\" {\r\n");
            for (int i = 0; i < Nodes.Count; i++)
            {
                for (int j = 0; j < Nodes[i].Count; j++)
                {
                    DotStringBuilder.Append("  n" + Nodes[i][j] + " [label=\"" + Nodes[i][j] + "\"]\r\n");
                }
            }
            for (int i = 0; i < Nodes.Count; i++)
            {
                DotStringBuilder.Append("  node[group=\"" + (i + 1) + "\"];\r\n");
                DotStringBuilder.Append("  ");
                for (int j = 0; j < Nodes[i].Count; j++)
                {
                    //DotStringBuilder.Append("\"" + Nodes[i][j] + "\"");
                    DotStringBuilder.Append("n" + Nodes[i][j] );
                    if (j < Nodes[i].Count - 1)
                    {
                        DotStringBuilder.Append(" -> ");
                    }
                    else
                    {
                        DotStringBuilder.Append(";");
                    }
                }
                DotStringBuilder.Append("\r\n");
            }

            int DecorateCount = 0;
            foreach (KeyValuePair<string, string> DecorateKeyValuePair in DecorateDictionary)
            {
                DecorateCount++;
                DotStringBuilder.Append("  subgraph Decorate" + DecorateCount + "\r\n");
                DotStringBuilder.Append("  {\r\n");
                DotStringBuilder.Append("    rank=\"same\";\r\n");
                if (DecorateKeyValuePair.Value.Trim().Substring(0, 5) == "(tag:")
                {
                    DotStringBuilder.Append("    \"" + DecorateKeyValuePair.Value.Trim() + "\" [shape=\"box\", style=\"filled\", fillcolor=\"#ffffdd\"];\r\n");
                }
                else
                {
                    DotStringBuilder.Append("    \"" + DecorateKeyValuePair.Value.Trim() + "\" [shape=\"box\", style=\"filled\", fillcolor=\"#ddddff\"];\r\n");
                }
                DotStringBuilder.Append("    \"" + DecorateKeyValuePair.Value.Trim() + "\" -> \"n" + DecorateKeyValuePair.Key + "\" [weight=0, arrowtype=\"none\", dirtype=\"none\", arrowhead=\"none\", style=\"dotted\"];\r\n");
                DotStringBuilder.Append("  }\r\n");
            }

            DotStringBuilder.Append("}\r\n");
            File.WriteAllText(@DotFilename, DotStringBuilder.ToString());

            Status("Generating version tree ...");
            Process DotProcess = new Process();
            DotProcess.StartInfo.UseShellExecute = false;
            DotProcess.StartInfo.CreateNoWindow = true;
            DotProcess.StartInfo.RedirectStandardOutput = true;
            DotProcess.StartInfo.FileName = GraphvizDotPathTextBox.Text;
            DotProcess.StartInfo.Arguments = "\"" + @DotFilename + "\" -Tpdf -Gsize=10,10 -o\"" + @PdfFilename + "\"";
            DotProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            DotProcess.Start();
            DotProcess.WaitForExit();

            DotProcess.StartInfo.Arguments = "\"" + @DotFilename + "\" -Tps -o\"" + @PdfFilename.Replace(".pdf", ".ps") + "\"";
            DotProcess.Start();
            DotProcess.WaitForExit();
            if (DotProcess.ExitCode == 0)
            {
                if (File.Exists(@PdfFilename))
                {
#if (!DEBUG)
                    /*
                    Process ViewPdfProcess = new Process();
                    ViewPdfProcess.StartInfo.FileName = @PdfFilename;
                    ViewPdfProcess.Start();
                    //ViewPdfProcess.WaitForExit();
                    //Close();
                    */
#endif
                }
            }
            else
            {
                Status("Version tree generation failed ...");
            }

            Status("Done! ...");
            ExitButton.Select();
        }
    }
}
