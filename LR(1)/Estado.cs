using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1_
{
    class Estado
    {
        private List<Produccion> _listProd;
        public List<Produccion> listProd
        {
            get { return _listProd; }
        }
        private List<Arista> _listAristas;
        public List<Arista> listAristas
        {
            get { return _listAristas; }
        }
        private int _id;
        public int id
        {
            get { return _id; }
        }

        
        public Estado(int id)
        {
            this._listProd = new List<Produccion>();
            this._listAristas = new List<Arista>();
            this._id = id;
        }

        public Estado(Produccion p, int id):this(id)
        {
            Produccion prodAux = new Produccion(p);
            
            this.init(prodAux);
        }

        public Estado(List<Produccion> listProd, int id): this(id)
        {
            Produccion prodAux;

            foreach (Produccion p in listProd)
            {
                prodAux = new Produccion(p);
                this.init(prodAux);
            }
        }

        private void init(Produccion p)
        {
            this._listProd.Add(p); // agrega la primera prod del estado
            if (this.id == 0)
            {
                p.agregaTokenBusqueda(new Term("$"));
            }
            this.inicializaEdo(p);
            this.verificaProduccionesEdo();
        }

        /// <summary>
        /// Agrega la primera produccion del estado obtiene su lista de busqueda
        /// y verifica si en la posicion del punto existe un NT. Si Existe agrega las
        /// producciones de inicio de ese NT.
        /// </summary>
        /// <param name="prodAux">Copia de la primera produccion del estado</param>
        private void inicializaEdo(Produccion prodAux)
        {
            List<Term> listTokenBusq = new List<Term>();

            if (prodAux.punto < prodAux.listProd.Count) //si el punto no ha llegado al final
            {
                if (prodAux.listProd[prodAux.punto].GetType().Name.Equals("NoTerm")) // si en la posicion del punto hay un NT
                {
                    listTokenBusq = prodAux.regresaPrimeroProd();
                    this.agregaProduccionesInicio(((NoTerm)prodAux.listProd[prodAux.punto]),listTokenBusq); //Agrega al estado las producciones de inicio de ese NT
                }
            }
        }

        private void inicializaEdo(Produccion prodAux, List<Term> listTokenBusq)
        {
//            List<Term> listTokenBusq = new List<Term>();

            if (prodAux.punto < prodAux.listProd.Count) //si el punto no ha llegado al final
            {
                if (prodAux.listProd[prodAux.punto].GetType().Name.Equals("NoTerm")) // si en la posicion del punto hay un NT
                {
                    listTokenBusq = listTokenBusq.Union(prodAux.regresaPrimeroProd()).ToList();
                    this.agregaProduccionesInicio(((NoTerm)prodAux.listProd[prodAux.punto]), listTokenBusq); //Agrega al estado las producciones de inicio de ese NT
                }
            }
        }

        /// <summary>
        /// Agrega las producciones de inicio del NT recibido
        /// Calculando los tokens de busqueda de cada producción
        /// </summary>
        /// <param name="NT">No Terminal que agregara sus Producciones al estado</param>
        private void agregaProduccionesInicio(NoTerm NT,List<Term>listTokenBusq)
        {
            Produccion prodAux;

            foreach (Produccion p in NT.listProdInicio)
            {
                prodAux = new Produccion(p);
                if (prodAux.listProd[prodAux.punto].GetType().Name.Equals("NoTerm"))
                {
                    listTokenBusq = listTokenBusq.Union(prodAux.regresaPrimeroProd()).ToList();
                }
                    prodAux.agregaTokenBusqueda(listTokenBusq);
                    this._listProd.Add(prodAux);
            }
        }

        private void verificaProduccionesEdo()
        {
            Produccion prodAux;

            for (int i = 0; i < this.listProd.Count; i++)
            {
                prodAux = this.listProd[i];
                if (prodAux.punto < prodAux.listProd.Count)
                {
                    if (prodAux.listProd[prodAux.punto].GetType().Name.Equals("NoTerm"))
                    {

                        if (!this.listProd.Skip(1).ToList().Exists(a => a.nT.token.Equals(prodAux.listProd[prodAux.punto].token)))
                        {
                            this.inicializaEdo(new Produccion(prodAux),prodAux.listTokenBusq);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Agrega una Arista al estado
        /// </summary>
        /// <param name="ar">Arista nueva</param>
        public void agregaArista(Arista ar)
        {
            this._listAristas.Add(ar);
        }

        /// <summary>
        /// Regresa la lista de producciones contenidas en el estado
        /// que tengan el mismo token a buscar en la posción del punto
        /// </summary>
        /// <param name="t">Token de busqueda </param>
        /// <returns></returns>
        public List<Produccion> regresaListaDePRod(Token t)
        {
            List<Produccion> listProduc = new List<Produccion>();

            foreach (Produccion p in this.listProd)
            {
                if (p.punto < p.listProd.Count)
                    if (p.listProd[p.punto].token.Equals(t.token))
                    {
                        listProduc.Add(p);
                    }
            }

            return listProduc;
        }

/*
        public Estado(Produccion prod, int id) : this(id)
        {
            this.agregaProduccion(prod, null);
            if (prod.punto < prod.listProd.Count)
            {
                if (prod.listProd[prod.punto].GetType().Name.Equals("NoTerm"))
                {
                    foreach (Produccion p in ((NoTerm)prod.listProd[prod.punto]).listProdInicio)
                    {
                        this.agregaProduccion(p, prod.listTokenBusq);
                    }
                }
            }
            this.inicializaEdoPrimero(prod);
        }

        public Estado(List<Produccion>listProd,int id):this(id)
        {
            List<Term> listTokenBusq = new List<Term>();

            foreach (Produccion p in listProd)
            {
                this.agregaProduccion(p, null);
                if (p.punto < p.listProd.Count)
                {
                    if (p.listProd[p.punto].GetType().Name.Equals("NoTerm"))
                    {
                        listTokenBusq = listTokenBusq.Union(p.regresaPrimeroProd()).ToList();
                        foreach (Produccion prod in ((NoTerm)p.listProd[p.punto]).listProdInicio)
                        {
                            this.agregaProduccion(prod,listTokenBusq);
                        }
                    }
                }
                this.inicializaEdoPrimero(p);
            }
        }

        private void inicializaEdo(Produccion prod)
        {
            List<Term> listTokenBusq = new List<Term>();

            this.agregaProduccionSec(prod, null);
            if (prod.punto < prod.listProd.Count)
            {
                if (prod.listProd[prod.punto].GetType().Name.Equals("NoTerm"))
                {
                    listTokenBusq = prod.regresaPrimeroProd();
                    for (int i = 0; i < this._listProd.Count; i++)
                    {
                        if (this._listProd[i].punto < this._listProd[i].listProd.Count)
                        {
                            if (this._listProd[i].listProd[this._listProd[i].punto].GetType().Name.Equals("NoTerm"))
                            {
                                foreach (Produccion p in ((NoTerm)this._listProd[i].listProd[this._listProd[i].punto]).listProdInicio)
                                {
                                    this.agregaProduccionSec(p, listTokenBusq);
                                    if (p.listProd[p.punto].GetType().Name.Equals("NoTerm"))
                                    {
                                        listTokenBusq = listTokenBusq.Union(p.regresaPrimeroProd()).ToList();
                                        foreach (Produccion p2 in ((NoTerm)p.listProd[p.punto]).listProdInicio)
                                        {
                                            this.agregaProduccionSec(p2, listTokenBusq);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
        }

        public void inicializaEdoPrimero(Produccion prod)
        {
            List<Term> listTokenBusq = new List<Term>();

            
            for (int i = 1; i < this._listProd.Count; i++)
            {
                if (this._listProd[i].listProd[this._listProd[i].punto].GetType().Name.Equals("NoTerm"))
                {
                    listTokenBusq = this._listProd[i].listTokenBusq.Union(this._listProd[i].regresaPrimeroProd()).ToList();
                    foreach (Produccion p in ((NoTerm)this._listProd[i].listProd[this._listProd[i].punto]).listProdInicio)
                    {
                        this.agregaProduccion(p, listTokenBusq);
                    }
                }
            }
        }

        private void agregaProduccionSec(Produccion p, List<Term> listTokenBusq)
        {
            Produccion prodAux;

            prodAux = new Produccion(p);
            if (listTokenBusq == null || listTokenBusq.Count == 0)
            {
                //prodAux.agregaTokenBusqueda(new Term("$"));
                this._listProd.Add(prodAux); //Falta hacer recorrido para var si las demas producciones tienen un NT en el punto
            }
            else
            {
                if (this._listProd.Exists(a => a.completa().Equals(prodAux.completa())))
                {
                    prodAux = this._listProd.Find(a => a.completa().Equals(prodAux.completa()));
                    prodAux.agregaTokenBusqueda(listTokenBusq);
                }
                else
                {
                    prodAux.agregaTokenBusqueda(listTokenBusq);
                    this._listProd.Add(prodAux);
                }
            }
        }
        
        private void agregaProduccion(Produccion p,List<Term>listTokenBusq)
        {
            Produccion prodAux;

            prodAux = new Produccion(p);
            if (listTokenBusq == null || listTokenBusq.Count==0)
            {
                prodAux.agregaTokenBusqueda(new Term("$"));
                this._listProd.Add(prodAux);
            }
            else
            {
                if (this._listProd.Exists(a => a.completa().Equals(prodAux.completa())))
                {
                    prodAux = this._listProd.Find(a => a.completa().Equals(prodAux.completa()));
                    prodAux.agregaTokenBusqueda(listTokenBusq);
                }
                else
                {
                    prodAux.agregaTokenBusqueda(listTokenBusq);
                    this._listProd.Add(prodAux);
                }
            }
        }


        

 
 */
 
    }
}
