using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class API
    {
        private List<IPA> dataBase;

        public API()
        {
            this.DataBase = new List<IPA>();
        }

        public List<IPA> DataBase { get => dataBase; set => dataBase = value; }

        public static bool operator +(API api, IPA ipa)
        {
            bool add = true;
            if (api is not null && ipa is not null)
            {
                for (int i = 0; i < api.DataBase.Count; i++)
                {
                    //significa que existe la palabra y le agrega una nueva fonetica
                    if (api.DataBase[i] + ipa)
                    {
                        add = false;
                        break;
                    }
                }
                if (add)
                {
                    api.DataBase.Add(ipa);
                }
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IPA ipa in this.DataBase)
            {
                sb.AppendLine(ipa.ToString());
            }
            return sb.ToString();
        }
    }
}
