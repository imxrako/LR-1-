using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class NoTerm : Token
    {
        private List<Term> _listPrimero;
        public List<Term> listPrimero
        {
            get
            {
                if (this._listPrimero.Count.Equals(0))
                {
                    calculaTuPinxesPrimero();
                }
                return _listPrimero;
            }
            set { _listPrimero = value; }
        }
        private List<Produccion> _listProdInicio;
        public List<Produccion> listProdInicio
        {
            get { return _listProdInicio; }
        }

        public NoTerm(string token) : base(token)
        {
            this._listPrimero = new List<Term>();
            this._listProdInicio = new List<Produccion>();
        }

        public void agregaProducciones(List<Produccion>listProdIni)
        {
            this._listProdInicio = listProdIni;
        }

        /// <summary>
        /// Método que calcula el primero de cada No Terminal.
        /// Si una producción del No Terminal tambien contiene un No Terminal como primero
        /// obtiene el primero de ese No Terminal y si aún no se ha calculado se calcula.
        /// </summary>
        public override void calculaTuPinxesPrimero()
        {
            List<Term> listAux;
            List<Token> pinxesListaRec;

            
                foreach (Produccion p in this.listProdInicio)
                {
                    if (p.listProd[0].GetType().Name.Equals("NoTerm") && !p.listProd[0].token.Equals(this.token))
                    {
                        listAux = this._listPrimero = this._listPrimero.Union(((NoTerm)p.listProd[0]).listPrimero).ToList();
                        if (listAux.Exists(a => a.token.Equals("~")))
                        {
                            listAux.RemoveAll(a => a.token.Equals("~"));
                            foreach (Token t in p.listProd)
                            {
                                if (t.GetType().Name.Equals("Term"))
                                {
                                    listAux.Add((Term)t);
                                    break;
                                }
                                else
                                {
                                    listAux = listAux.Union(((NoTerm)t)._listPrimero).ToList();
                                    if (listAux.Exists(a => a.token.Equals("~")))
                                    {
                                        listAux.RemoveAll(a => a.token.Equals("~"));
                                    }
                                }
                            }
                        }
                        this._listPrimero = this._listPrimero.Union(listAux).ToList();
                    }
                    else
                    {
                        if (p.listProd[0].GetType().Name.Equals("NoTerm"))
                        {
                            pinxesListaRec = p.listProd.FindAll(a => !a.token.Equals(p.nT.token));
                            foreach(Token t in pinxesListaRec)
                            {
                                if (t.GetType().Name.Equals("NoTerm"))
                                {
                                    listAux = this._listPrimero = this._listPrimero.Union(((NoTerm)t).listPrimero).ToList();
                                    if (listAux.Exists(a => a.token.Equals("~")))
                                    {
                                        listAux.RemoveAll(a => a.token.Equals("~"));
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                else
                                {
                                    this._listPrimero.Add((Term)t);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this._listPrimero.Add((Term)p.listProd[0]);
                        }
                    }
                }
            
        }




    }
}
