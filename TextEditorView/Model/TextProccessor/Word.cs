using System.Collections.Generic;
using System.Text;

namespace ParserWithList {
	public class Word {
		public List<Symbol> Symbols { get; set; }
		public int Length { get; private set; }
		public string Value { 
			get{
				StringBuilder val = new StringBuilder(10);
				foreach (Symbol s in Symbols) {
					val.Append(s.Value);
				}
				return val.ToString();
			}
		}
		public Word (string txt) {
			Symbols=new List<Symbol>();
			Length = txt.Length;
			foreach(char c in txt){
				Symbols.Add(new Symbol(c));
			}
		}
	}
}