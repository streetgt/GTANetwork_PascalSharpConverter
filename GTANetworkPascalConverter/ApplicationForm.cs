using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GTANetworkPascalConverter
{
    public partial class ConverterForm : Form
    {
        public ConverterForm()
        {
            InitializeComponent();
            richTextBox1.Text = "Steps: (only .cs files are converted)\n- Select your gamemode folder.\n- Convertion goes into YourInputPath/convertion\n- Enjoy\n\nRemember:\n- Always backup your files.\n- If you find bugs, report them to StreetGT";
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Length == 0)
            {
                MessageBox.Show("Select the input path!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            richTextBox1.Text = "";

            var inputPath = txtInput.Text;

            List<FileInfo> filesFound = new List<FileInfo>();
            EnumerateCSharpFiles(inputPath, filesFound);

            if (filesFound.Count == 0)
            {
                MessageBox.Show("That path don't have any files to be converted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            String convertionDir = inputPath + "\\convertion";

            if (Directory.Exists(convertionDir))
            {
                DeleteDirectory(convertionDir, true);
            }

            foreach (var file in filesFound)
            {
                richTextBox1.AppendText("Converting: " + file.FullName + "\n");

                var fileName = convertionDir + file.FullName.Substring(inputPath.Length);

                FileInfo fi = new FileInfo(fileName);
                if (!fi.Directory.Exists)
                {
                    Directory.CreateDirectory(fi.DirectoryName);
                }


                using (var tw = new StreamWriter(fileName))
                {

                    var lines = File.ReadLines(file.FullName);
                    foreach (var line in lines)
                    {
                        tw.WriteLine(ConvertLineToPascalCase(line));
                    }
                    tw.Close();
                }

                richTextBox1.AppendText("Converted to: " + fileName + "\n");

            }

            MessageBox.Show("All files were converted!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBox1.AppendText("All files were converted!");

        }

        private void BtnInput_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                txtInput.Text = folderBrowserDialog.SelectedPath;
            }

        }


        private String ConvertLineToPascalCase(String line)
        {
            
            StringBuilder sb = new StringBuilder();

            var replaced = Regex.Replace(line, "(API\\.[^(?+]*)", (match) =>
            {
                String group = match.Groups[0].Value;

                if (group.Contains(".shared."))
                {
                    return group.Substring(0, 4) + "Shared." + Char.ToUpper(group[11]) + group.Substring(12);
                }
                else
                {
                    return group.Substring(0, 4) + Char.ToUpper(group[4]) + group.Substring(5);
                }
            });
            sb.Append(replaced);

            return sb.ToString();
        }

        public void DeleteDirectory(string path, bool recursive)
        {
            if (recursive)
            {
                var subfolders = Directory.GetDirectories(path);
                foreach (var s in subfolders)
                {
                    DeleteDirectory(s, recursive);
                }
            }
            var files = Directory.GetFiles(path);
            foreach (var f in files)
            {
                try
                {
                    var attr = File.GetAttributes(f);
                    if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                    {
                        File.SetAttributes(f, attr ^ FileAttributes.ReadOnly);
                    }
                    File.Delete(f);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(ex.Message, "Exception in Helper.DeleteDirectory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            Directory.Delete(path);
        }

        internal static void EnumerateCSharpFiles(string sFullPath, List<FileInfo> fileInfoList)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(sFullPath);
                FileInfo[] files = di.GetFiles();

                foreach (FileInfo file in files)
                {
                    if (file.Name.Substring(file.Name.Length -3 ).Equals(".cs") && !file.DirectoryName.Contains("convertion"))
                    {
                        fileInfoList.Add(file);
                    }
                }
                    

                DirectoryInfo[] dirs = di.GetDirectories();
                if (dirs == null || dirs.Length < 1)
                    return;
                foreach (DirectoryInfo dir in dirs)
                    EnumerateCSharpFiles(dir.FullName, fileInfoList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception in Helper.EnumerateFiles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GithubURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/streetgt/GTANetwork_PascalSharpConverter");
        }
    }
}
