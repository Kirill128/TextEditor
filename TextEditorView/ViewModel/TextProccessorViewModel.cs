using ParserWithList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Documents;
using TextEditorView.Model;

namespace TextEditorView.ViewModel
{
    public class TextProccessorViewModel: INotifyPropertyChanged
    {
        //public FlowDocumentBox FlowDocBoxesForProccess { get; set; }

        private FlowDocumentBox selectedToProccess;
        public FlowDocumentBox SelectedToProccess {
            get { return selectedToProccess; }
            set {
                selectedToProccess = value;
                OnPropertyChanged("SelectedToProccess");
            } 
        }

        public TextProccessorViewModel() { 
            
        }

        public static LinkedList<WordBox> Find(FlowDocumentBox DocBox,string patternOfRegex) {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            Regex reg = new Regex(@patternOfRegex);
            MatchCollection matches = reg.Matches(new TextRange(DocBox.Document.ContentStart, DocBox.Document.ContentEnd).Text);
            foreach (Match m in matches) {
                result.AddLast(new WordBox());


            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
