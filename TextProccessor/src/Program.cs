using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParserWithList
{
    class Program
    { //"I:\\Practice\\C#\\ParserWithList\\data\\Text.txt"      "/home/kirill/Practice/C#/ParserWithList/data/Text.txt"
        private static string filePath="/home/kirill/Practice/C#/ParserWithList/data/Text.txt";
        static void Main(string[] args)
        {
            /*
            Text txt = new Text(ReadFile(filePath));
            foreach (Sentens s in txt.Sentenses)
            {
                Console.WriteLine(s.Value);
            }
            Console.WriteLine();

            //task 1
            Sentens[] task1 = getSortedBySentensLength(txt);
            foreach (Sentens s in task1)
            {
                Console.WriteLine(s.Value);

            }

            //task 2
            Console.WriteLine("\nTask 2\nInput length of word:");
            int wordlength = getINT();
            List<Word> words = getWordsFromQuestionSentenses(txt, wordlength);
            foreach (Word w in words)
            {
                Console.WriteLine("@ " + w.Value);
            }

            //task3              B, C, D, F, G, H, J, K, L, M, N, P, Q, R, S, T, V, W, X, Z
            Console.WriteLine("\nTask 3\nInput length of word:");
            removeWordsByLetters(txt, getINT(), new Letter[] {new Letter('z'), new Letter('b'), new Letter('c'), new Letter('d'),
            new Letter('f'),new Letter('g'),new Letter('h'),new Letter('j'),new Letter('k'),new Letter('l'),new Letter('m'), new Letter('n'),
            new Letter('p'), new Letter('q'),new Letter('r'),new Letter('s'),new Letter('t'),new Letter('v'),new Letter('w'),new Letter('x')});
            foreach (Sentens s in task1)
            {
                Console.WriteLine(s.Value);
            }
            //task 4
            Console.WriteLine("Input num of Sentens:");
            int numOfSen = getINT();
            Console.WriteLine("Input length of word:");
            int wordLength = getINT();
            Console.WriteLine("Input substring:");
            string substring = Console.ReadLine();
            Sentens newSen = replaceWordInSentens(txt.Sentenses[numOfSen - 1], wordLength, substring);
            txt.Sentenses.RemoveAt(numOfSen-1); 
            txt.Sentenses.Insert(numOfSen-1,newSen);

            foreach (Sentens s in txt.Sentenses)
            {
                Console.WriteLine(s.Value);
            }
            */
            // part 2 task 1
            Console.WriteLine("Part 2 \nInput num of max lines in page:");
            Book book=new Book(filePath,getINT());
            foreach (Page p in book.Pages) {
                Console.WriteLine("///////////////////////////////////////////////////////////////////////");
                Console.WriteLine("Page " + p.NumOfPage);
                Console.WriteLine("///////////////////////////////////////////////////////////////////////");
                LinkedList<WordBox> b = Line.sortWordsByAlphabet(p.getUniqueWordsBoxes());
                foreach (WordBox w in b) {
                    Console.Write(w.Word.Value + " " + w.Count + ": ");
                    foreach (int i in w.MeetInLines)
                    {
                        Console.Write(i + " ");
                    }
                    Console.WriteLine();
                }
            }
            
        }

        
        public static Sentens replaceWordInSentens(Sentens sentens,int wordLength,string substring) {
            int wordCounter = -1;
            List<int> wordCountArray = new List<int>();
            foreach (Word word in sentens.Words) {
                wordCounter++;
                if (word.Symbols.Count==wordLength) {
                    wordCountArray.Add(wordCounter);
                }
            }
            foreach (int i in wordCountArray)
            {
                sentens.Words.RemoveAt(i);
                sentens.Words.Insert(i, new Word(substring));
            }
            return new Sentens(sentens.Value);
        }
        public static void removeWordsByLetters(Text text, int length, Letter[] checkLetters)
        {//Сгорело из-за реализации листов. 
            //при foreach и IEnumarator нельзя менять коллекцию(даже удалять)!!
            IEnumerator ieS;//HELP, за что ты так со мной, шарп
            Symbol firstSymbol;

            foreach (Sentens sentens in text.Sentenses)
            {
                List<Word> newWords = new List<Word>();
                int wordCounter = 0;
                foreach (Word wordIter in sentens.Words)
                {
                    wordCounter++;
                    ieS = wordIter.Symbols.GetEnumerator();
                    ieS.MoveNext();

                    firstSymbol = (Symbol)ieS.Current;
                    bool correct = true;
                    foreach (Letter l in checkLetters)
                    {
                        if (l.Value == Letter.toLower(firstSymbol.Value))
                        {
                            correct = false;
                            break;
                        }
                    }

                    if (wordIter.Symbols.Count != length || correct)
                    {
                        newWords.Add(wordIter);
                    }
                    else
                        foreach (PunctuationSymbol p in sentens.PunctuationSymbols)
                        {
                            if (p.PositionByWord >= wordCounter) p.PositionByWord--;
                            wordCounter--;
                        }


                }
                sentens.Words = newWords;

            }

        }
        /*       
                public static void removeWBL(Text text, int length, Letter[] checkLetters) {
                    LinkedList<Sentens> sentenses = new LinkedList<Sentens>(text.Sentenses);
                    for (LinkedListNode<Sentens> sentens=sentenses.First;sentens.Next!=null;sentens=sentens.Next ) {
                        LinkedList<Word> words = new LinkedList<Word>(sentens.Words);
                        LinkedList<PunctuationSymbol> punctSymbols = new LinkedList<Word>(sentens.PunctuationSymbols);

                        LinkedListNode<PunctuationSymbol> punctSymbol =punctSymbols.First;
                        LinkedListNode<Word> word =words.First;
                        for(;word.Next!=null;word=word.Next){
                            IEnumerator ieS=word.Value.Symbols.GetEnumerator();
                            ieS.MoveNext();
                            bool isSameLetter=false;
                            for(int i=0;i<checkLetters.Length;i++){
                                if(checkLetters[i].Value==((Symbol)ieS.Current).Value){
                                    isCorrectLetter=true;
                                    break;
                                }
                            }
                            if(word.Value.Symbols.Count==length && isCorrectLetter){
                                sentens.Remove(word);

                            }
                        }

                    }
                    text.Sentenses=new List<Sentens>(sentenses);

                }
                public stataic LinkedList<T> addFromListToLinked<T> (List<T> list){
                    return null;
                }
                public stataic List<T> addFromListToLinked<T>(LinkedList<T> linked){
                    return null;
                }

                */
        public static Sentens[] getSortedBySentensLength(Text txt)
        {
            Sentens[] sen = txt.Sentenses.ToArray();
            for (int i = 0; i < sen.Length; i++)
            {
                for (int j = i; j < sen.Length; j++)
                {
                    if (sen[i].Words.Count > sen[j].Words.Count)
                    {
                        Sentens buf = sen[i];
                        sen[i] = sen[j];
                        sen[j] = buf;
                    }
                }
            }
            return sen;
        }
        public static List<Word> getWordsFromQuestionSentenses(Text txt, int length)
        {
            List<Word> resList = new List<Word>();
            bool isQuestionSen;
            foreach (Sentens sentens in txt.Sentenses)
            {
                //check punctSymbol   
                isQuestionSen = false;
                foreach (PunctuationSymbol p in sentens.PunctuationSymbols)
                {
                    if (p.Value == '?')
                    {
                        isQuestionSen = true;
                        break;
                    }
                }
                //checkWords
                if (isQuestionSen)
                {
                    foreach (Word word in sentens.Words)
                    {
                        //checkLengthWord
                        string wordVal = word.Value;
                        if (wordVal.Length == length)
                        {
                            //checkContain this word in res
                            bool contains = false;
                            foreach (Word w in resList)
                            {
                                if (wordVal == w.Value)
                                {
                                    contains = true;
                                    break;
                                }
                            }

                            //add if all ok
                            if (!contains) resList.Add(word);
                        }
                    }

                }
                //

            }
            return resList;

        }
        public static int getINT()
        {
            int wordlength = 0;
            try
            {
                wordlength = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return wordlength;
        }
        public static string ReadFile(string path)
        {
            try
            {
                StreamReader file = new StreamReader(path);
                return file.ReadToEnd();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //побыстрее бы ...
    }
}
