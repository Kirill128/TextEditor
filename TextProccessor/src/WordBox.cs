using System;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList
{
    class WordBox
    {
        public int Count { get; set; }
        public LinkedList<int> MeetInLines { set; get; }
        public Word Word { get; set; }
    
        public WordBox(Word w)
        {
            this.Count = 1;
            this.Word = w;
        }
        public WordBox(Word w,int meetInLines):this(w){
            this.MeetInLines = new LinkedList<int>();
            this.MeetInLines.AddLast(meetInLines);
        }
    }
}
