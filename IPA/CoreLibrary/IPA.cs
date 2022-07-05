using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class IPA
    {
        private string word;
        private List<string> phonetics;

        public IPA()
        {
            this.Phonetics = new List<string>();
        }

        public IPA(string word, List<string> IPAs)
        {
            this.Word = word;
            this.Phonetics = IPAs;
        }

        public string Word { get => word; set => word = value; }
        public List<string> Phonetics { get => phonetics; set => phonetics = value; }

        public static bool operator +(IPA ipa1, IPA ipa2)
        {
            if(ipa1 is not null && ipa2 is not null)
            {
                if(ipa1 == ipa2)
                {
                    foreach(string phonetic in ipa2.Phonetics)
                    {
                        if(IPA.IsInside(ipa1, phonetic))
                        {
                            ipa1.Phonetics.Add(phonetic);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsInside(IPA ipa, string phonetic)
        {
            if(ipa is not null && !String.IsNullOrEmpty(phonetic))
            {
                return true;
            }
            return false;
        }

        public static bool operator ==(IPA ipa1, IPA ipa2)
        {
            return ipa1.Word == ipa2.Word;
        }

        public static bool operator !=(IPA ipa1, IPA ipa2)
        {
            return !(ipa1 == ipa2);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Word} : {{ ");
            foreach(string phonetic in this.Phonetics)
            {
                sb.AppendLine($"{phonetic} ,");
            }
            sb.AppendLine("}");
            
            return sb.ToString();
        }
    }

}
