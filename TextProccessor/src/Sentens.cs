
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ParserWithList
{
	class Sentens{
        public List<Word> Words{get;set;}
		public List<PunctuationSymbol> PunctuationSymbols{get;set;}
		

		public string Value{
			get {
				StringBuilder val = new StringBuilder(40);
				IEnumerator ieW = Words.GetEnumerator();
				IEnumerator ieP = PunctuationSymbols.GetEnumerator();
				int wordCount=0;
				for (bool playW = ieW.MoveNext(),playP = ieP.MoveNext(); playW ; playW = ieW.MoveNext()) {
					if (playW) {
						val.Append(((Word)ieW.Current).Value);
						wordCount++;
					}
					while(playP && wordCount == ((PunctuationSymbol)ieP.Current).PositionByWord){
						val.Append(((PunctuationSymbol)ieP.Current).Value);
						playP=ieP.MoveNext();
					}
					val.Append('/');
					
				}
				return val.ToString();
			}
		}

		public Sentens(string txt) {
			PunctuationSymbols = new List<PunctuationSymbol>();
			Words = new List<Word>();
			StringBuilder word = new StringBuilder("");
			for (int i = 0; i < txt.Length; i++)
			{
					if (PunctuationSymbol.IsPunctuationSymbol(txt[i]) || txt[i] == '/')
					{
						if (word.Length != 0) Words.Add(new Word(word.ToString()));
						PunctuationSymbols.Add(new PunctuationSymbol(txt[i], Words.Count));
						word.Remove(0, word.Length);
					}
					else
					{
						word.Append(txt[i]);
					}
			}
			List<PunctuationSymbol> punctSymb = new List<PunctuationSymbol>();
			foreach (PunctuationSymbol p in PunctuationSymbols) {
				if (p.Value != '\0')
					punctSymb.Add(p);
			}
			PunctuationSymbols = punctSymb;

		}
		public Sentens(List<Word> words,List<PunctuationSymbol> punct) {
			PunctuationSymbols = new List<PunctuationSymbol>();
			Words = new List<Word>();
			foreach (Word w in words) {
				Words.Add(new Word(w.Value));
			}
			foreach (PunctuationSymbol p in punct) {
				PunctuationSymbols.Add(new PunctuationSymbol(p.Value,p.PositionByWord));
			}
		}
		 
	}
}
