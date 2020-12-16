using ParserWithList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
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

        //public LinkedList<WordBox> LastFindedWordsBoxes { get; set; }

        public TextProccessorViewModel() { 
            
        }
        #region Find and filter  methods 
        public static LinkedList<WordBox> Find(FlowDocument Doc,string patternOfRegex) {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            Regex reg = new Regex(@patternOfRegex);
            MatchCollection matches = reg.Matches(new TextRange(Doc.ContentStart, Doc.ContentEnd).Text);
            foreach (Match m in matches) {
                result.AddLast(new WordBox(new Word(m.Value),m.Index));
            }
            return result;
        }
        public static LinkedList<WordBox> Find(string fontFamily,FlowDocument Doc)
        {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            StringBuilder build = new StringBuilder();
            TextPointer end = Doc.ContentStart;
            
            TextPointer wordStart =null;
            for (int i = 1; end.GetPositionAtOffset(i) != null; i++)
            {
                TextRange range = new TextRange(end.GetPositionAtOffset(i-1), end.GetPositionAtOffset(i));
                if (fontFamily.Equals(range.GetPropertyValue(Inline.FontFamilyProperty))) {
                    wordStart = end.GetPositionAtOffset(i-1);
                }
                else {
                    if (wordStart!=null) {
                        result.AddLast(new WordBox(new Word(new TextRange(wordStart,end).Text),i-1));
                    }
                    wordStart = null;
                
                }
                build.Append(range.Text);
            }
            MessageBox.Show(build.ToString());


            return result;
        }
        public static LinkedList<WordBox> Find(FlowDocument Doc,int fontSize)
        {
            
                LinkedList<WordBox> result = new LinkedList<WordBox>();
                return result;

        }

        public static LinkedList<WordBox> FilterWordsByRegex(LinkedList<WordBox> database,string pattern) {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            foreach (WordBox w in database) {
                if (Regex.IsMatch(w.Word.Value,pattern)) {
                    result.AddLast(w);
                }
            }
            return result;
        }
        public static LinkedList<WordBox> FilterWordsByFontFamily(LinkedList<WordBox> database, FontFamily family)
        {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            foreach (WordBox w in database)
            {
                object temp = w.Range.GetPropertyValue(Inline.FontFamilyProperty);
                if (temp.Equals(family))
                {
                    result.AddLast(w);
                }
            }
            return result;
        }

        #endregion

        public static TextPointer GetTextPointerAtOffset(FlowDocument document, int offset)
        {
            var navigator = document.ContentStart;
            int cnt = 0;

            while (navigator.CompareTo(document.ContentEnd) < 0)
            {
                switch (navigator.GetPointerContext(LogicalDirection.Forward))
                {
                    case TextPointerContext.ElementStart:
                        break;
                    case TextPointerContext.ElementEnd:
                        if (navigator.GetAdjacentElement(LogicalDirection.Forward) is Paragraph)
                            cnt += 2;
                        break;
                    case TextPointerContext.EmbeddedElement:
                        // TODO: Find out what to do here?
                        cnt++;
                        break;
                    case TextPointerContext.Text:
                        int runLength = navigator.GetTextRunLength(LogicalDirection.Forward);

                        if (runLength > 0 && runLength + cnt < offset)
                        {
                            cnt += runLength;
                            navigator = navigator.GetPositionAtOffset(runLength);
                            if (cnt > offset)
                                break;
                            continue;
                        }
                        cnt++;
                        break;
                }

                if (cnt > offset)
                    break;

                navigator = navigator.GetPositionAtOffset(1, LogicalDirection.Forward);

            } // End while.

            return navigator;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
