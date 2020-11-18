
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ParserWithList {
	class Text {
		public List<Sentens> Sentenses { get; set; }
		public string Value {
			get {
				StringBuilder val = new StringBuilder(100);
				foreach (Sentens s in Sentenses) {
					val.Append(s.Value);
				}
				return val.ToString();
			}
		}

		public Text(string txt) {
			Sentenses = new List<Sentens>();
			int position = 0;
			int start = 0;
			// Extract sentences from the string.
			do {
				position = txt.IndexOfAny(new char[] { '.', '!', '?' }, start);
				if (position >= 0) {
					string subStr = txt.Substring(start, position - start + 1).Trim();
					subStr = Regex.Replace(subStr, @"\s+", "/");
					if (subStr != " ") Sentenses.Add(new Sentens(subStr));
					start = position + 1;
				}
			} while (position > 0);
			//

		}
		

	}
}