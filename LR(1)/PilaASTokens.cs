using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class PilaASTokens
    {
        private string _token;
        public string token
        {
            get { return _token; }
        }
        private int _numEdo;
        public int numEdo
        {
            get { return _numEdo; }
        }
        private string _pila;
        public string pila
        {
            get { return _pila; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">token que se analizó</param>
        /// <param name="idEdo">numero de estado</param>
        /// <param name="pila">la primera columna de la tabla</param>
        public PilaASTokens(string token, int idEdo,string pila)
        {
            this._token = token;
            this._numEdo = idEdo;
            this._pila = pila;
        }
    }
}
