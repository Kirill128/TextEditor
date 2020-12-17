using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Documents;
using TextEditorView.Model;

namespace TextEditorView.ViewModel
{
    public class FlowDocumentsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<FlowDocumentBox> flowDocumentsBoxes;
        public ObservableCollection<FlowDocumentBox> FlowDocumentsBoxes {
            get { return flowDocumentsBoxes; }
            set {
                flowDocumentsBoxes = value;
                OnPropertyChanged("FlowDocuments");
            }
        }

        private FlowDocumentBox selectedDocumentBox;
        public FlowDocumentBox SelectedDocumentBox {
            get { return selectedDocumentBox; }
            set {
                selectedDocumentBox = value;
                OnPropertyChanged("SelectedDocumentBox");
            }
        }

        public FlowDocumentsViewModel() {
            FlowDocumentsBoxes = new ObservableCollection<FlowDocumentBox>() {};
        }

        #region selected file new, open, save, save as actions
        public void FileNewInCollectionAndWindow() {
            FlowDocumentBox newDoc = new FlowDocumentBox(new FlowDocument(), "NewFile");
            FlowDocumentsBoxes.Add(newDoc);
            SelectedDocumentBox = newDoc;
        }
        public void FileOpenInCollectionAndWindow() {
            FlowDocumentBox doc = FileSystemDialogMethods.FileOpenFlowDoc();
            if (!doc.DocumentPathInFileSystem.Equals(String.Empty)) {
                FlowDocumentBox inCollectionExist =null;
                foreach (FlowDocumentBox box in FlowDocumentsBoxes) {
                    if (box.DocumentPathInFileSystem.Equals(doc.DocumentPathInFileSystem))
                    {
                        inCollectionExist = box;
                        break;
                    } 
                }
                if (inCollectionExist==null) {
                    FlowDocumentsBoxes.Add(doc);
                    SelectedDocumentBox = doc;
                }
                else {
                    SelectedDocumentBox = inCollectionExist;
                }

            }
        }
        public void FileSaveInCollectionAndWindow()
        {
            FlowDocumentBox doc = FileSystemDialogMethods.SaveFileFlowDoc(SelectedDocumentBox);
            if (!doc.DocumentPathInFileSystem.Equals(String.Empty))
            {
                doc.ButtonToManipulateDoc = SelectedDocumentBox.ButtonToManipulateDoc; 
                string[] name = doc.DocumentPathInFileSystem.Split(new char[] { '\\' });
                doc.ButtonToManipulateDoc.ButtonFileName.Content= name[name.Length - 1]; ;
                SelectedDocumentBox = doc;
            }
        }
        public void FileSaveAsCollectionAndWindow()
        {
            FlowDocumentBox doc = FileSystemDialogMethods.SaveFileAsFlowDoc(SelectedDocumentBox.Document);
            if (!doc.DocumentPathInFileSystem.Equals(String.Empty))
            {
                doc.ButtonToManipulateDoc = SelectedDocumentBox.ButtonToManipulateDoc;
                string[] name = doc.DocumentPathInFileSystem.Split(new char[] { '\\' });
                doc.ButtonToManipulateDoc.ButtonFileName.Content = name[name.Length - 1]; ;
                SelectedDocumentBox = doc;
            }
        }
        
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
