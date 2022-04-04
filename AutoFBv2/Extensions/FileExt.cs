using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.Extensions
{
    public static class FileExt
    {
        public static bool CreateFolder(string foldername)
        {
            if (!Directory.Exists(foldername))
            {
                Directory.CreateDirectory(foldername);
            }
            if (!Directory.Exists(foldername))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static string createDialogChonFileEXE()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Chọn một file chrome.exe",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "exe files (*.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string f = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(f))
                {
                    return f;
                }

            }
            return null;
        }
        public static string[] createDialogChonNhieuFile_IMAGE_MP4()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Chọn một vài file hình ảnh hoặc mp4",
                Multiselect=true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Image Files (*.jpg;*.jpeg,*.png,*.mp4)|*.JPG;*.JPEG;*.PNG;*.MP4",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] f = openFileDialog1.FileNames;
                if (f.Length > 0)
                {
                    return f;
                }

            }
            return null;
        }
        public static string createDialogChonFileTXT()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Chọn một file .txt",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string f = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(f))
                {
                    return f;
                }

            }
            return null;
        }
        public static string createDialogChonThuMuc()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = folderDlg.SelectedPath;
                if (!string.IsNullOrEmpty(path))
                {
                    return path;
                }
            }
            return null;
        }
        public static List<string> ImagesInFolder(string thumucanh)
        {
            List<string> list = new List<string>();
            try
            {
                if (!string.IsNullOrEmpty(thumucanh))
                {
                    if (Directory.Exists(thumucanh))
                    {
                        string[] patterns = new[] { "*.jpg", "*.jpeg", "*.jpe", "*.jif", "*.jfif", "*.jfi", "*.webp", "*.gif", "*.png", "*.apng", "*.bmp", "*.dib", "*.tiff", "*.tif", "*.svg", "*.svgz", "*.ico", "*.xbm" };
                        string[] images = GetFiles(thumucanh, patterns, SearchOption.AllDirectories);
                        if (images != null)
                        {
                            return images.ToList<string>();
                        }
                    }
                }
            }
            catch
            {

            }
            return list;
        }
        public static string[] GetFiles(string path, string[] patterns = null, SearchOption options = SearchOption.TopDirectoryOnly)
        {
            if (patterns == null || patterns.Length == 0)
                return Directory.GetFiles(path, "*", options);
            if (patterns.Length == 1)
                return Directory.GetFiles(path, patterns[0], options);
            return patterns.SelectMany(pattern => Directory.GetFiles(path, pattern, options)).Distinct().ToArray();
        }
        public static List<string> PhanTichFileText(string text)
        {
            if (text.Contains("\n"))
            {
                text = text.Replace("\n", string.Empty);
            }
            string[] arr = text.Split('|');
            string result = string.Empty;
            List<string> lstUid = new List<string>();
            foreach (string a in arr)
            {
                if (string.IsNullOrEmpty(a))
                {
                    continue;
                }
                string txt = string.Empty;
                txt = a;
                txt = txt.Trim();
                if (string.IsNullOrEmpty(txt))
                {
                    continue;
                }
                lstUid.Add(txt);
            }
            return lstUid;
        }
        public static List<string> PhanTichFileTextNotTrim(string text)
        {
            if (text.Contains("\n"))
            {
                text = text.Replace("\n", string.Empty);
            }
            string[] arr = text.Split('|');
            string result = string.Empty;
            List<string> lstUid = new List<string>();
            foreach (string a in arr)
            {
                if (string.IsNullOrEmpty(a))
                {
                    continue;
                }
                string txt = string.Empty;
                txt = a;
                if (string.IsNullOrEmpty(txt))
                {
                    continue;
                }
                lstUid.Add(txt);
            }
            return lstUid;
        }
        public static bool isFileExist(string filename)
        {
            if (File.Exists(filename))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isFolderExist(string folder)
        {
            if (Directory.Exists(folder))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GetFileExtension(string filename)
        {
            try
            {
                string ext = Path.GetExtension(filename);
                return ext;
            }
            catch
            {

            }
            return null;
        }
        public static string LoadFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string savedText = sr.ReadToEnd();
                        return savedText;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        public static bool WriteFile(string fileName, string txt)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
                using (TextWriter tw = new StreamWriter(fileName))
                {
                    tw.WriteLine(txt);
                }
                if (File.Exists(fileName))
                {
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }
        public static void DeleteFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch
            {

            }
        }
        public static string CopyAndPasteFile(string sourceFile, string targetFolder)
        {
            try
            {
                string filename = Path.GetFileName(sourceFile);
                Directory.CreateDirectory(targetFolder);
                string targetFile = Path.Combine(targetFolder, filename);
                File.Copy(sourceFile, targetFile,true);
                return targetFile;
            }
            catch
            {

            }
            return null;
        }
    }
}
