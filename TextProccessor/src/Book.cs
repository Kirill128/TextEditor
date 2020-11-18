using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ParserWithList
{
    class Book{
        public string FilePath{get;set;}
        public int maxLinesInPage{get;set;}
        public LinkedList<Page> Pages;
        public Book(string filePath,int linesInPage){
            FilePath=filePath;
            maxLinesInPage=linesInPage;
            Pages=divideToPages(readFileByLines(filePath),maxLinesInPage);
        }

        
        public static LinkedList<Page> divideToPages(LinkedList<Line> allLines,int maxLinesInPage){
            LinkedList<Page> pages = new LinkedList<Page>();
            LinkedList<Line> linesForOnePage;
            LinkedListNode<Line> line = allLines.First;
            int maxPages = (allLines.Count / maxLinesInPage) + (allLines.Count % 2);
            for (int pageCount=0;pageCount<maxPages;pageCount++)
            {
                linesForOnePage = new LinkedList<Line>();
                for (int lineCount = 0;lineCount<maxLinesInPage && line!=null;lineCount++) {
                    linesForOnePage.AddLast( line.Value);
                    line = line.Next;
                }
                pages.AddLast(new Page(linesForOnePage,pageCount+1));
            }

            return pages;
        }
        public static LinkedList<Line> readFileByLines(string filePath){
            LinkedList<Line> allLines=new LinkedList<Line>();
            try{
                StreamReader file=new StreamReader(filePath);
                int lineNum = 0;
                for(string l = file.ReadLine();l!=null;l = file.ReadLine()){
                    lineNum++;
                    allLines.AddLast(new Line(l,lineNum));
                } 
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return allLines;
        }
        
    }
}