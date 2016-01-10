using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class Token
    {
        private string _token;
        public string token
        {
            get { return _token; }
        }


        public Token(string token)
        {
            this._token = token;
        }

    public virtual void calculaTuPinxesPrimero(){}
    }
}
