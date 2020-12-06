using System;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList
{
	class Line
	{
		public LinkedList<Word> Words { get; set; }
		public LinkedList<PunctuationSymbol> PunctuationSymbols { get; set; }
		
		public int NumLine { get; set; }
		public Line(string txt,int numLine):this(txt) {
			NumLine = numLine;
		}
		public Line(string txt) {
			PunctuationSymbols = new LinkedList<PunctuationSymbol>();
			Words = new LinkedList<Word>();
			StringBuilder word = new StringBuilder("");
			for (int i = 0; i < txt.Length; i++)
			{
				if (PunctuationSymbol.IsPunctuationSymbol(txt[i]) || txt[i] == ' ')
				{
					if (word.Length != 0) Words.AddLast(new Word(word.ToString()));
					PunctuationSymbols.AddLast(new PunctuationSymbol(txt[i], Words.Count));
					word.Remove(0, word.Length);
				}
				else
				{
					word.Append(Letter.toLower(txt[i]));
				}
			}
			LinkedList<PunctuationSymbol> punctSymb = new LinkedList<PunctuationSymbol>();
			foreach (PunctuationSymbol p in PunctuationSymbols)
			{
				if (p.Value != '\0')
					punctSymb.AddLast(p);
			}
			PunctuationSymbols = punctSymb;
		}
		public LinkedList<Word> getUniqeWords() {
			LinkedList<Word> uniqeWords = new LinkedList<Word>();
			bool correspond;
			foreach(Word w in this.Words)
			{
				correspond = true;
				foreach (Word uniqeWord in uniqeWords)
				{
					if (w.Value == uniqeWord.Value)
					{
						correspond = false;
						break;
					}
				}
				if (correspond )//хотел чтобы сортировало при вставке но очень много надо будет в книге Value собирать 
					uniqeWords.AddLast(w);
					
			}
			return uniqeWords;
		}

		public LinkedList<WordBox> getUniqueWordsBoxes() {
			LinkedList<WordBox> wordBoxes = new LinkedList<WordBox>();
			bool correspond;
			foreach (Word w in this.Words)
			{
				correspond = true;
				foreach (WordBox uniqeWordBox in wordBoxes)
				{
					if ( w.Value == uniqeWordBox.Word.Value)
					{
						correspond = false;
						uniqeWordBox.Count++;
						break;
					}
				}
				if (correspond)//хотел чтобы сортировало при вставке но очень много надо будет в книге Value собирать 
					wordBoxes.AddLast(new WordBox(w, NumLine));

			}
			return wordBoxes;
		}
		public static LinkedList<WordBox> sortWordsByAlphabet(LinkedList<WordBox> words)
		{

			for (LinkedListNode<WordBox> firstIter = words.First; firstIter.Next != null; firstIter = firstIter.Next)
			{
				for (LinkedListNode<WordBox> secondIter = firstIter; secondIter.Next != null; secondIter = secondIter.Next)
				{
					if (String.Compare(firstIter.Value.Word.Value, secondIter.Value.Word.Value) > 0)
					{
						WordBox buf = firstIter.Value;
						firstIter.Value = secondIter.Value;
						secondIter.Value = buf;
					}
				}
			}
			return words;
		}
		public static LinkedList<Word> sortWordsByAlphabet(LinkedList<Word> words) {
			
			for (LinkedListNode<Word> firstIter = words.First;firstIter.Next!=null;firstIter=firstIter.Next) {
				for (LinkedListNode<Word> secondIter = firstIter; secondIter.Next != null; secondIter = secondIter.Next) {
					if (String.Compare(firstIter.Value.Value,secondIter.Value.Value)>0) {
						Word buf = firstIter.Value;
						firstIter.Value = secondIter.Value;
						secondIter.Value = buf;
					}
				}
			}
			return words;
		}
	}
}
