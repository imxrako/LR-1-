using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class Produccion
    {
//Ver si es necesario agregar una lista estatica de terminales para usar la misma memoria en todas las Prod
        private NoTerm _nT;
        public NoTerm nT
        {
            get { return _nT; }
        }
        private List<Token> _listProd;
        public List<Token> listProd
        {
            get { return _listProd; }
        }
        private List<Term> _listTokenBusq;
        public List<Term> listTokenBusq
        {
            get { return _listTokenBusq; }
        }
        private int _punto;
        public int punto
        {
            get { return _punto; }
            set { this._punto = value; }
        }

        public Produccion()
        {
            this._listProd = new List<Token>();
            this._listTokenBusq = new List<Term>();
            this._punto = 0;
        }

        public Produccion(Produccion p)
        {
            this._nT = p.nT;
            this._listProd = p._listProd;
            this._listTokenBusq = new List<Term>(p._listTokenBusq);
            this._punto = p.punto;
        }

        public Produccion(string prod) : this()
        {
            this.creaProd(prod);
        }

        public Produccion(Produccion p,List<Term>listaTokenBusq)
        {
            this._nT = p.nT;
            this._listProd = p._listProd;
            this._listTokenBusq = new List<Term>(listaTokenBusq);
            this._punto = p._punto;
        }

        private void creaProd(string prod)
        {
            string[] esplitiado;
            esplitiado = prod.Split(new string[]{"->"}, StringSplitOptions.None);
            this._nT = new NoTerm(esplitiado[0]);
            this.separaTokens(esplitiado[1]);   
        }

        private void separaTokens(string produc)
        {
            string cad ="";
            bool esNT = false;

            for(int i=0; i<produc.Length;i++)
            {
                #region  Si encuentra un No terminal levanta la bandera y pasa al sig caracter
                if (produc[i].Equals('<') && esNT == false)
                {
                    esNT = true;
                    continue;
                }
                #endregion
                #region Si termina de leer un No terminal
                else if (produc[i].Equals('>') && esNT == true)
                {
                    this._listProd.Add(new NoTerm(cad));
                    cad = "";
                    esNT = false;
                }
                #endregion
                #region si es un terminal solo lo agrega a la produccion
                else if (esNT == false)
                {
                    cad = "";
                    while (i<produc.Length && !produc[i].Equals('<'))
                    {
                        cad += produc[i];
                        i++;
                    }
                    i--;
                    this._listProd.Add(new Term(cad));
                    cad = "";
                }
                #endregion
                if (esNT==true) //Concatena un No terminal
                {
                    cad+= produc[i];
                }
            }
        }

        /// <summary>
        /// Junta los tokens de la produccion
        /// </summary>
        /// <returns>Produccion completa sin el token de busqueda</returns>
        public string completa()
        {
            string cad = "";

            cad = this._nT.token + "->";
            foreach (Token t in this._listProd)
            {
                cad += t.token;
            }

            return cad;
        }

        public string completaConPunto()
        {
            string cad = "";
            int cont = 0;

//            cad = this._nT.token + "->";
            foreach (Token t in this._listProd)
            {
                if (this.punto.Equals(cont))
                {
                    cad += "'";
                }
                cad += t.token;
                cont++;
            }
            
            cad = cad.Insert(0,this._nT.token + "->");
            return cad;
        }

        public void agregaTokenBusqueda(Term t)
        {
            if (!this._listTokenBusq.Exists(a => a.token.Equals(t.token)))
            {
                this._listTokenBusq.Add(t);
            }
        }

        public void agregaTokenBusqueda(List<Term> listTokenBusq)
        {
            this._listTokenBusq = this._listTokenBusq.Union(listTokenBusq).ToList();
        }


        public void calculaPrimero()
        {
            this._listTokenBusq = this._listTokenBusq.Union(this.regresaPrimeroProd()).ToList();
        }

        public List<Term> regresaPrimeroProd()
        {
            List<Token> listGamma = calculaGamma();
            List<Term> listPrimeroGamma = new List<Term>();

            foreach (Token t in listGamma)
            {
                if (t.GetType().Name.Equals("NoTerm"))
                {
                    listPrimeroGamma = listPrimeroGamma.Union(((NoTerm)t).listPrimero).ToList();
                    if (listPrimeroGamma.Exists(a => a.token.Equals("~")))
                    {
                        listPrimeroGamma.RemoveAll(a => a.token.Equals("~"));
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    listPrimeroGamma.Add((Term)t);
                    break;
                }
            }
            if (listPrimeroGamma.Exists(a => a.token.Equals("~")) || listPrimeroGamma.Count==0)
            {
                listPrimeroGamma.RemoveAll(a => a.token.Equals("~"));
                listPrimeroGamma = listPrimeroGamma.Union(this._listTokenBusq).ToList();
            }

            return listPrimeroGamma;
        }

        private List<Token> calculaGamma()
        {
            List<Token>listGamma = new List<Token>();

            if (this.listProd[this.punto].GetType().Name.Equals("NoTerm"))
            {
                listGamma = this.listProd.GetRange(this.punto+1,this.listProd.Count-(this.punto+1));
            }

            return listGamma;
        }

        public string tokensDeBusq()
        {
            string tokensBusq ="";

            foreach (Term t in this.listTokenBusq)
            {
                tokensBusq += t.token+",";
            }
            tokensBusq.Remove(tokensBusq.Count() - 1);

            return tokensBusq;
        }


    }
}
