using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Documents;

namespace ParserWithList
{
    class WordBox
    {
        public int Count { get; set; }
        public LinkedList<int> MeetInLines { set; get; }
        public Word Word { get; set; }
        public TextPointer StartInText{ get; set; }
        public TextPointer EndInText {
            get { return StartInText.GetPositionAtOffset(this.Word.Value.Length); }    
        }
    
        public WordBox(Word w)
        {
            this.Count = 1;
            this.Word = w;
        }
        public WordBox(Word w, TextPointer start) : this(w)
        {
            this.StartInText = start;
        }
        public WordBox(Word w,int meetInLines):this(w){
            this.MeetInLines = new LinkedList<int>();
            this.MeetInLines.AddLast(meetInLines);
        }
        public WordBox(Word w,int meetInLines,TextPointer start) : this(w,meetInLines)
        {
            this.StartInText = start;
        }
    }
}
