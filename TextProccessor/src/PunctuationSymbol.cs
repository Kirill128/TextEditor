namespace ParserWithList
{
	class PunctuationSymbol:Symbol {
        private char val;
        private static char[] punctsSymb = new char[] { ',', ':', '!', '?', '-', '.', '\\', '_'};
        public int PositionByWord{get;set;}
        public override char Value{
            get{return val;}
            set{
                if(PunctuationSymbol.IsPunctuationSymbol(value))
                this.val=value;
            }
        }
        public PunctuationSymbol(char s,int wordsuntil):base(s){
            Value=s;
            PositionByWord=wordsuntil;
        }
        
        public static bool IsPunctuationSymbol(char value){
            foreach (char s in punctsSymb) {
                if (s==value) return true;
            }
            return false;   
        }
        public static bool IsPunctuationSymbol(PunctuationSymbol symb)
        {
            foreach (char s in punctsSymb)
            {
                if (s == symb.Value) return true;
            }
            return false;
        }
    }
}
