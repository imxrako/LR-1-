using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class AFDLR1
    {
        private List<Estado> _listEdos;
        public List<Estado> listEdos
        {
            get { return _listEdos; }
        }
        private List<Produccion> listProd;
        private int idSig;
        private List<Term> listTerm;
        private List<NoTerm> listNoTerm; 

        public AFDLR1()
        {
            this._listEdos = new List<Estado>();
            this.listTerm = new List<Term>();
            this.listNoTerm = new List<NoTerm>();
            this.idSig = 0;
        }

        public AFDLR1(List<Produccion> listProd):this()
        {
            this.listProd = listProd;
            this.inicializaListas();
        }

        private void inicializaListas()
        {
            for (int i = 1; i < this.listProd.Count;i++)
            {
                if (!this.listNoTerm.Exists(a => a.token.Equals(this.listProd[i].nT.token)))
                {
                    this.listNoTerm.Add(this.listProd[i].nT);
                }
                foreach (Token t in this.listProd[i].listProd)
                {
                    if (t.GetType().Name.Equals("Term") == true)
                    {
                        if (!this.listTerm.Exists(a => a.token.Equals(t.token)))
                        {
                            this.listTerm.Add((Term)t);
                        }
                    }
                }
            }

        }

        public void creaAfd()
        {
            Estado papi = new Estado(this.listProd[0],this.idSig++);
            this._listEdos.Add(papi);

            this.creaAfdRec(this._listEdos[0]);
        }

        private void creaAfdRec(Estado e)
        {
            Produccion nuevaProd;
            List<Produccion> listProd;
            List<Produccion> listProdIguales;
            Arista ar;
            Estado estadoNuevo,estadoAux;
            int numPrueba = 0;

            foreach (Produccion p in e.listProd)
            {
//                numPrueba++;
                if (this.idSig == 384)
                {
                    numPrueba = 0;
                }
                if (p.punto < p.listProd.Count)
                {
                    ar = new Arista(p.listProd[p.punto]);
          //          if (ar.token.GetType().Name.Equals("NoTerm"))
          //          {
                        listProdIguales = e.regresaListaDePRod(ar.token);
                        if (listProdIguales.Count>1/*e.listProd.Exists(a => a.listProd[a.punto].token.Equals(ar.token.token))*/)
                        {
//                             = e.listProd.FindAll(a => a.listProd[a.punto].token.Equals(ar.token.token));
                            listProd = new List<Produccion>();
                            foreach (Produccion prod in listProdIguales)
                            {
                                nuevaProd = new Produccion(prod);
                                nuevaProd.punto++;
                                listProd.Add(nuevaProd);
                            }
                            estadoNuevo = new Estado(listProd, this.idSig++);
                        }
                        else
                        {
                            nuevaProd = new Produccion(p);
                            nuevaProd.punto++;
                            estadoNuevo = new Estado(nuevaProd, this.idSig++);
                        }
         //           }
         //           else
         //           {
         //               nuevaProd = new Produccion(p);
         //               nuevaProd.punto++;
         //               estadoNuevo = new Estado(nuevaProd, this.idSig++);
         //           }
                    

                    estadoAux = this.buscaEstadosIguales(estadoNuevo);
                    if (estadoAux != null)
                    {
                        this.idSig--;
                        ar.estadoDest = estadoAux;
                        if (!e.listAristas.Exists(a => a.token.token.Equals(ar.token.token) && a.estadoDest.id.Equals(ar.estadoDest.id)))
                        {
                            e.agregaArista(ar);
                        }
                    }
                    else
                    {
                        ar.estadoDest = estadoNuevo;
                        e.agregaArista(ar);
                        this._listEdos.Add(estadoNuevo);
                        this.creaAfdRec(estadoNuevo);
                    }
                }
            }
        }

        private Estado buscaEstadosIguales(Estado estadoNuevo)
        {
            Estado est=null;
            bool[] band = new bool[estadoNuevo.listProd.Count];
            bool band2 = false;;
            List<Estado> listEdo;
//            int prueba=0;

            listEdo = this.listEdos.FindAll(a=>a.listProd.Count.Equals(estadoNuevo.listProd.Count));

            foreach (Estado e in listEdo)
            {
//                if (e.id.Equals(291))
//                {
//                    prueba = 2;
//                }
                for (int i = 0; i < e.listProd.Count; i++)
                {
                    if (e.listProd[i].completa().Equals(estadoNuevo.listProd[i].completa()) && e.listProd[i].tokensDeBusq().Equals(estadoNuevo.listProd[i].tokensDeBusq()))
                    {
                        if(e.listProd[i].punto.Equals(estadoNuevo.listProd[i].punto))
                        {
                            band[i] = true;
                        }
                    }
                    else
                    {
                        band[i] = false;
                    }
                }
                foreach (bool b in band)
                {
                    if (b == false)
                    {
                        band2 = false;
                        break;
                    }
                    else
                    {
                        band2 = true;
                    }
                }
                if (band2 == true)
                {
                    est = e;
                    break;
                }
            }

            return est;
        }

        public void creaTabla(System.Windows.Forms.DataGridView dgv)
        {
            System.Windows.Forms.DataGridViewRow r;

            List<Token> listaCompleta = this.listTerm.Cast<Token>().ToList().Union(this.listNoTerm).ToList();

            listaCompleta.Add(new Token("$"));
            if (dgv != null)
            {
                foreach (Token t in listaCompleta)
                {
                    dgv.Columns.Add(t.token, t.token);
                }
                foreach (Estado e in this.listEdos)
                {
                    r = new System.Windows.Forms.DataGridViewRow();
                    r.HeaderCell.Value = e.id.ToString();
                    dgv.Rows.Add(r);
                    foreach (Produccion p in e.listProd)
                    {
                        if (p.punto >= p.listProd.Count)
                        {
                            foreach (Term t in p.listTokenBusq)
                            {
                                dgv.Rows[e.id].Cells[listaCompleta.FindIndex(x => x.token.Equals(t.token))].Value = "r" + this.listProd.FindIndex(a => a.completa().Equals(p.completa()));
                            }
                        }
                    }
                    foreach (Arista a in e.listAristas)
                    {
                        if (a.token.GetType().Name.Equals("NoTerm"))
                        {
                            dgv.Rows[e.id].Cells[listaCompleta.FindIndex(x => x.token.Equals(a.token.token))].Value = a.estadoDest.id.ToString();
                        }
                        else
                        {
                            dgv.Rows[e.id].Cells[listaCompleta.FindIndex(x => x.token.Equals(a.token.token))].Value = "s" + a.estadoDest.id.ToString();
                        }
                    }
                }
                dgv.Rows[1].Cells["$"].Value = "Aceptar";
            }
        }

        public List<string> separaPorTokens(string cad)
        {
            List<string> listTokens = new List<string>();
            List<Token> listaCompleta = this.listTerm.Cast<Token>().ToList().Union(this.listNoTerm).ToList();
            string cadAux = cad;
            string token ="";
            int i = 0;

            while(i< cadAux.Length)
            {
                token += cadAux[i];
                if (listaCompleta.Find(a => a.token.Equals(token)) != null)
                {
                    listTokens.Add(token);
                    token = "";
                    cadAux = cadAux.Remove(0, i+1);
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            if (cadAux.Length > 0)
            {
                listTokens.Add(cadAux);
            }

            return listTokens;
        }

    public int buscaIndiceCol(string cad)
        {
            int indCol =-1;
            List<Token>listaCompleta = this.listTerm.Cast<Token>().ToList().Union(this.listNoTerm).ToList();
            listaCompleta.Add(new Token("$"));

            if(listaCompleta.Exists(a=>a.token.Equals(cad)))
            {
                indCol = listaCompleta.FindIndex(a=>a.token.Equals(cad));
            }

            return indCol;
        }

        public Produccion buscaProduccion(int index)
        {
            return this.listProd.ElementAt(index);
        }
    }
}
