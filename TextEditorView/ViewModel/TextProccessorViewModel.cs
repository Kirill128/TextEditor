using ParserWithList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        public FlowDocumentBox SelectedToProccess
        {
            get { return selectedToProccess; }
            set
            {
                selectedToProccess = value;
                OnPropertyChanged("SelectedToProccess");
                TextRange range = new TextRange(selectedToProccess.Document.ContentStart, selectedToProccess.Document.ContentEnd);
            }
        }
        public TextProccessorViewModel() { 
            
        }

       

        #region Find,replace,filter  methods 
        public static void Replace(LinkedList<WordBox> boxes, string ultimateStr)
        {
            foreach (WordBox w in boxes) {
                w.Range.Text = ultimateStr;
            }
        }
        public static LinkedList<WordBox> Find(FlowDocument Doc,string patternOfRegex) {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            Regex reg = new Regex(@patternOfRegex,RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(new TextRange(Doc.ContentStart, Doc.ContentEnd).Text);
            foreach (Match m in matches) {
                WordBox word=new WordBox(new Word(m.Value), m.Index);
                TextPointer start = TextProccessorViewModel.GetTextPointerAtOffset(Doc, word.StartInText);
                TextPointer end = TextProccessorViewModel.GetTextPointerAtOffset(Doc, word.EndInText);
                word.Range = new TextRange(start, end);
                result.AddLast(word);
            }
            return result;
        }
        public static LinkedList<WordBox> Find(FlowDocument Doc,FontFamily family)
        {
            LinkedList<WordBox> result = new LinkedList<WordBox>();
            StringBuilder build = new StringBuilder();
            TextPointer end = Doc.ContentStart;
            TextPointer wordStart =null;
            MessageBox.Show("Start");
            for (int i = 1,start=0; end.GetPositionAtOffset(i) != null; i++)
            {
                TextRange range = new TextRange(end.GetPositionAtOffset(i-1), end.GetPositionAtOffset(i));
                if (family.Equals(range.GetPropertyValue(Inline.FontFamilyProperty))) {
                    if (wordStart==null) { 
                        wordStart = end.GetPositionAtOffset(i - 1);
                        start = i - 1;
                    }   
                }
                else {
                    if (wordStart != null) {
                        TextRange rng = new TextRange(wordStart, end);
                        WordBox box = new WordBox(new Word(rng.Text), start);
                        result.AddLast(box);
                        box.Range = rng;
                    }
                    wordStart = null;
                    start = 0;
                }
                
            }

            foreach (WordBox w in result) {
                build.Append(w.Word.Value);
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


        #region Sort,get Unique WOrds,Concordance,Sentenses
        public static string SortSelected(TextRange allselected)
        {
            ParserWithList.Line line = new ParserWithList.Line(allselected.Text);
            LinkedList<Word> resWords = ParserWithList.Line.SortWords(line.getUniqeWords(), (Word a, Word b) => String.Compare(a.Value, b.Value) > 0);
            StringBuilder builder = new StringBuilder();
            foreach (Word w in resWords) builder.Append(w.Value + System.Environment.NewLine);
            return builder.ToString();
        }
        public static string GetUniqueWords(TextRange allselected)
        {
            ParserWithList.Line line = new ParserWithList.Line(allselected.Text);
            LinkedList<Word> resWords = line.getUniqeWords();
            StringBuilder builder = new StringBuilder();
            foreach (Word w in resWords) builder.Append(w.Value + System.Environment.NewLine);
            return builder.ToString();
        }
        public static string GetConcordance(TextRange oldrange)
        {
            StringBuilder build = new StringBuilder();
            Book CurrentBook = new Book(oldrange.Text);
            LinkedList<WordBox> b = ParserWithList.Line.sortWordsByAlphabet(CurrentBook.Pages.First.Value.getUniqueWordsBoxes());
            foreach (WordBox w in b)
            {
                build.Append(w.Word.Value + " " + w.Count + ": ");
                foreach (int i in w.MeetInLines)
                {
                    build.Append(i + " ");
                }
                build.Append(System.Environment.NewLine);
            }
            return build.ToString();
        }
        public static string GetSentenses(TextRange oldrange) 
        {
            StringBuilder build = new StringBuilder();
            Text text = new Text(oldrange.Text);
            foreach (Sentens s in text.Sentenses)
            {
                build.Append(s.Value + System.Environment.NewLine);
            }
            return build.ToString();
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
