using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class Arista
    {
        private readonly Token _token;
        public Token token
        {
            get { return _token; }
        }
        private Estado _estadoDest;
        public Estado estadoDest
        {
            get { return _estadoDest; }
            set { _estadoDest = value; }
        }

        public Arista(Token token)
        {
            this._token = token;
        }

        public Arista(Token token,Estado estadoDest):this(token)
        {
            this._estadoDest = estadoDest;
        }


    }
}
