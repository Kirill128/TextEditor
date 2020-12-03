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
                OnPropertyChanged("SelectedDocuments");
            }
        }

        public FlowDocumentsViewModel() {
            FlowDocumentsBoxes = new ObservableCollection<FlowDocumentBox>() { new FlowDocumentBox( new FlowDocument(), String.Empty) };

        }

        #region
        public void FileNewInCollectionAndWindow() {
            FlowDocumentBox newDoc = new FlowDocumentBox(new FlowDocument(),String.Empty);
            FlowDocumentsBoxes.Add(newDoc);
            SelectedDocumentBox = newDoc;
        }
        public void FileOpenInCollectionAndWindow() {
            FlowDocumentBox doc = FileSystemDialogMethods.FileOpenFlowDoc();
            FlowDocumentsBoxes.Add(doc);
            SelectedDocumentBox = doc;
        }
        public void FileSaveInCollectionAndWindow() {
            FlowDocumentBox doc = FileSystemDialogMethods.SaveFileFlowDoc(SelectedDocumentBox);
            SelectedDocumentBox = doc;
        }
        public void FileSaveAsCollectionAndWindow()
        {
            FlowDocumentBox doc = FileSystemDialogMethods.SaveFileAsFlowDoc(SelectedDocumentBox.Document);
            SelectedDocumentBox = doc;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
