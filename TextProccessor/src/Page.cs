using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ParserWithList
{
    class Page{
        public int NumOfPage{get;set;}
        public LinkedList<Line> Lines {get;set;}
        public Page(LinkedList<Line> lines){
            Lines = lines;
        }
        public Page(LinkedList<Line> lines,int pageNum):this(lines){
            NumOfPage=pageNum;
        }
        public LinkedList<WordBox> getUniqueWordsBoxes() {
            LinkedList<WordBox> mainBoxes = Lines.First.Value.getUniqueWordsBoxes();

            LinkedList<WordBox> newWords ;
            for (LinkedListNode<Line> line=Lines.First.Next; line!=null;line=line.Next) {
                LinkedList<WordBox> lineBoxes = line.Value.getUniqueWordsBoxes();
                newWords = new LinkedList<WordBox>();

                foreach (WordBox lineBoxIter in lineBoxes) {
                    bool same = false;
                    foreach (WordBox mainBoxIter in mainBoxes) { 
                        if (mainBoxIter.Word.Value == lineBoxIter.Word.Value)
                        {
                            mainBoxIter.Count = mainBoxIter.Count + lineBoxIter.Count;
                            same = true;
                            foreach(int meet in lineBoxIter.MeetInLines)
                            {
                                mainBoxIter.MeetInLines.AddLast(meet);
                            }
                            break;
                        }
                    }
                    if (!same)
                    {
                        newWords.AddLast(lineBoxIter);
                    }

                }

                foreach (WordBox newWord in newWords)
                {
                    mainBoxes.AddLast(newWord);
                }
 
            }

            return mainBoxes;
        }
        
    }
}