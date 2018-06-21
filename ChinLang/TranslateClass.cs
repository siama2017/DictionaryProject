using System.Collections.Generic;
using System.Linq;
using Microsoft.ML;

namespace ChinLang
{
    public class TranslateClass
    {
        public bool toEnglish;
        public Dictionary<string, string> chinLang;
        public Dictionary<string, Dictionary<string, string>> dictionaries;

        public TranslateClass()
        {
            this.toEnglish = true;
            chinLang = new Dictionary<string, string>(); //English to Lang
            dictionaries = new Dictionary<string, Dictionary<string, string>>();
            dictionaries.Add("Chin", chinLang);
        }
        public string TranslateString(string inp, string dict){
            string final = "";
            if(toEnglish){
                foreach(string elem in inp.Split(" ")){
                    try
                    {
                        final += dictionaries[dict][elem];
                    }
                }
            }else{
                foreach (string elem in inp)
                {
                    final += dictionaries[dict].FirstOrDefault(x => x.Value.Contains(elem)).Key;
                }
            }
            return final;
        }

        public void ChangeDirection(){
            if (this.toEnglish == true){
                this.toEnglish = false;
            }else{
                this.toEnglish = true;
            }
        }
    }
}
