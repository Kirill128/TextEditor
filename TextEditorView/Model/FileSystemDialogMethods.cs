using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace TextEditorView.Model
{
    public static class FileSystemDialogMethods
    {
        #region  load to richtextbox from FileDialog
        public static string FileOpen(RichTextBox Text_Container)
        {
            string File_Path_Text = String.Empty;
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                File_Path_Text = dlg.FileName;
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);

                }
                
            }
            return File_Path_Text;
        }

        public static void SaveFile(string File_Path_Text,RichTextBox Text_Container)
        {
            if (File_Path_Text == "")
            {
                SaveFileAs(Text_Container);
            }
            else
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                using (FileStream fs = new FileStream(File_Path_Text, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(File_Path_Text).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(File_Path_Text).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        public static string SaveFileAs(RichTextBox Text_Container)
        {
            string File_Path_Text = String.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Text_Container.Document.ContentStart, Text_Container.Document.ContentEnd);
                File_Path_Text = sfd.FileName;
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            return File_Path_Text;
        }
        #endregion

        #region get flow docs from file dialog
        public static FlowDocumentBox FileOpenFlowDoc()
        {
            FlowDocument Text_Container = new FlowDocument();
            string File_Path_Text = String.Empty;

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";

            if (dlg.ShowDialog() == true)
            {

                TextRange doc = new TextRange(Text_Container.ContentStart, Text_Container.ContentEnd);
                File_Path_Text = dlg.FileName;
                using (FileStream fs = new FileStream(dlg.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(dlg.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);

                }

            }
            return new FlowDocumentBox(Text_Container,File_Path_Text);
           
        }
    

        public static FlowDocumentBox SaveFileFlowDoc(FlowDocumentBox DocBox)
        { 
            if (DocBox.DocumentPathInFileSystem == String.Empty || !Regex.IsMatch(DocBox.DocumentPathInFileSystem,@"^\w:\\"))
            {
                DocBox=SaveFileAsFlowDoc(DocBox.Document);
            }
            else
            {
                TextRange doc = new TextRange(DocBox.Document.ContentStart, DocBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(DocBox.DocumentPathInFileSystem, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(DocBox.DocumentPathInFileSystem).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(DocBox.DocumentPathInFileSystem).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            return DocBox;
        }

        public static FlowDocumentBox SaveFileAsFlowDoc(FlowDocument Document)
        {
            string filePath = String.Empty;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "RichText Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Document.ContentStart, Document.ContentEnd);
                filePath = sfd.FileName;
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            return new FlowDocumentBox(Document,filePath);
        }
        #endregion
    }
}
