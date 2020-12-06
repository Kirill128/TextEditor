namespace ParserWithList
{
    class Letter:Symbol{
        private char val;
        public override char Value{
            get{return val;}
            set{
                if(Letter.isLetter(value))
                    this.val=value;
            }
        }
        public Letter(char symb):base(symb){
            this.Value=symb;
        }
        public static bool isLetter(char let){
            return ((int)let>=65 && (int)let<=90)||((int)let >= 97 && (int)let <= 122);
        }
        public static bool isLetter(Symbol let)
        {
            return ((int)let.Value >= 65 && (int)let.Value <= 90) || ((int)let.Value >= 97 && (int)let.Value <= 122);
        }
        public static char toLower(char l) {
            return (l>=65 && l<=90)? (char)((int)l + 32):l;
        }

    }
}