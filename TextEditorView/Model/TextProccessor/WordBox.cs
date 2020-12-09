using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace ParserWithList
{
    public class WordBox
    {
        public int Count { get; set; }
        public LinkedList<int> MeetInLines { set; get; }
        public Word Word { get; set; }
        public int  StartInText{ get; set; }
        public int  EndInText {
            get { return  StartInText+this.Word.Value.Length; }    
        }
        

        public WordBox(Word w)
        {
            this.Count = 1;
            this.Word = w;
        }
        public WordBox(Word w, int  start) : this(w)
        {
            this.StartInText = start;
        }
        public WordBox(int meetInLines, Word w) :this(w){
            this.MeetInLines = new LinkedList<int>();
            this.MeetInLines.AddLast(meetInLines);
        }
        public WordBox(Word w,int meetInLines,int  start) : this(w,meetInLines)
        {
            this.StartInText = start;
        }
    }
}
