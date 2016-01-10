using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LR_1_
{
    public partial class Form1 : Form
    {
        AFDLR1 afd;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.inicializa();   
        }

        private void inicializa()
        {
            List<Produccion> listProd;

            listProd = this.cargaGramatica();
            if (listProd != null)
            {
                this.creaAFD(listProd);
                this.llenaAbol();
                this.afd.creaTabla(dgvTabla);
            }
        }

        /// <summary>
        /// Crea una lista de producciones
        /// </summary>
        private List<Produccion> cargaGramatica()
        {
            List<Produccion> listProd = null;
            string sProdAux;
            string fileName;
            string [] arrProd;
            string NoTerm;

            fileName = this.abreFileDialog();
            if (fileName != "")
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        listProd = new List<Produccion>();
                        while (!sr.EndOfStream)
                        {
                            sProdAux = sr.ReadLine();
                            if (sProdAux.Contains('|'))
                            {
                                arrProd = sProdAux.Split(new string[] { "|", "->" }, StringSplitOptions.None);
                                NoTerm = arrProd[0];

                                for (int i = 1; i < arrProd.Count(); i++)
                                {
                                    listProd.Add(new Produccion(NoTerm + "->" + arrProd[i]));
                                }

                            }
                            else
                            {
                                listProd.Add(new Produccion(sProdAux));
                            }
                        }
                        sr.Close();
                    }
                    this.agregaProdAumentada(listProd);
                    //                this.cargaListaNTerm();
                    this.enlazaNTprod(listProd);
//                    this.calculaPrimeros(listProd);
                    this.agregaGramaticaControl(listProd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return listProd;
        }

/*        private void calculaPrimeros(List<Produccion> listProd)
        {
            for(int i =1;i<listProd.Count;i++)
            {
                listProd[i].nT.calculaTuPinxesPrimero();
            }
        }
*/
        /// <summary>
        /// crea una lista de apunteadores a las producciones iniciales de cada no terminal
        /// </summary>
        private void enlazaNTprod(List<Produccion>listProd)
        {
            List<Token> list;
            foreach (Produccion p in listProd)
            {
                p.nT.agregaProducciones(listProd.FindAll(a => a.nT.token.Equals(p.nT.token)));
                list = p.listProd.FindAll(a => a.GetType().Name.Equals("NoTerm"));
                foreach (NoTerm nt in p.listProd.FindAll(a => a.GetType().Name.Equals("NoTerm")))
                {
                    nt.agregaProducciones(listProd.FindAll(a => a.nT.token.Equals(nt.token)));
                }
            }
        }

        /// <summary>
        /// Crea la produccion aumentada
        /// </summary>
        private void agregaProdAumentada(List<Produccion> listProd)
        {
            string cad;

            cad = listProd.ElementAt(0).nT.token + "\'-><" + listProd.ElementAt(0).nT.token+">";
            listProd.Insert(0, new Produccion(cad));
        }

/*
        private void cargaListaNTerm()
        {
            foreach (Produccion p in this.listProd)
            {
                if (!this.listNTerm.Exists(a=>a.token.Equals(p.nT.token)))
                {
                    this.listNTerm.Add(p.nT);
                }
            }
        }
*/
        /// <summary>
        /// Toma la direccion del archivo
        /// </summary>
        /// <returns>regresa la direccion del archivo</returns>
        private string abreFileDialog()
        {
            string fileName = "";

            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                op.Filter = "txt files (*.txt)| *.txt";
                op.RestoreDirectory = true;
                if (op.ShowDialog() == DialogResult.OK)
                {
                    fileName = op.FileName;
                }
            }

            return fileName;
        }

        /// <summary>
        /// Agrega al control la gramática o las producciones
        /// </summary>
        private void agregaGramaticaControl(List<Produccion> listProd)
        {
            int cont = 0;

            foreach (Produccion prod in listProd)
            {
                lbGramatica.Items.Add(cont++.ToString()+".- "+prod.completa());
            }
        }

        private void creaAFD(List<Produccion> listProd)
        {
            this.afd = new AFDLR1(listProd);
            this.afd.creaAfd();
        }

        private void llenaAbol()
        {
            TreeNode abuelo,papi,hijo;
            

            foreach (Estado e in this.afd.listEdos)
            {
                abuelo = new TreeNode(e.id.ToString());
                tvAFD.Nodes.Add(abuelo);
                papi = new TreeNode("Elementos");
                abuelo.Nodes.Add(papi);
                foreach (Produccion p in e.listProd)
                {
                    hijo = new TreeNode(p.completaConPunto());
                    papi.Nodes.Add(hijo);
                    hijo.Nodes.Add(p.tokensDeBusq());
                }
                papi = new TreeNode("Transiciones");
                abuelo.Nodes.Add(papi);
                foreach (Arista a in e.listAristas)
                {
                    hijo = new TreeNode(a.token.token +"-->" +a.estadoDest.id);
                    papi.Nodes.Add(hijo);
                }
            }
            tvAFD.ExpandAll();
        }
        
        /// <summary>
        /// Evento que se genera cuando cambia el texto de entrada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbCadena_TextChanged(object sender, EventArgs e)
        {
            dgvTAcciones.Rows.Clear();
            string cad;
            List<string> listTokens;
            
            cad = this.normalizaCadena(tbCadena.Text);            
            if (cad != "")
            {
                listTokens = this.afd.separaPorTokens(cad);
                if (this.validaCadena(listTokens))
                {
                    lRes.Text = "Valida";
                    lRes.ForeColor = Color.Green;
                }
                else
                {
                    lRes.Text = "Invalida";
                    lRes.ForeColor = Color.Red;
                }
            }
            else
            {
                lRes.Text = "";
            }
        }
        

        private string normalizaCadena(string cad)
        {
            string auxCad="";

            foreach(char c in cad)
            {
                if (!c.Equals('\n') && !c.Equals('\t'))
                {
                    auxCad += c;
                }
            }

            return auxCad;
        }
        private bool validaCadena(List<string> listTokens)
        {
            Stack<PilaASTokens> stack = new Stack<PilaASTokens>();
            string accion="";
            PilaASTokens sPila = new PilaASTokens("$",0,"$0");
            bool valido = false;
            Produccion p;
            string tabla;
            int i = 0;

            listTokens.Add("$");
            stack.Push(sPila);
            while(i<listTokens.Count && valido == false)
            {
                sPila = stack.Peek();
                accion = this.buscaEnTabla(sPila.numEdo, listTokens.ElementAt(i)/*cadValidar[0].ToString()*/);
                if (accion != "")
                {
                    dgvTAcciones.Rows.Add(stack.Peek().pila, listTokens.ElementAt(i), accion);
                    switch (accion[0])
                    {
                        case 's' : //desplazamiento
                            stack.Push(new PilaASTokens(listTokens.ElementAt(i),
                                                        int.Parse(accion.Substring(1)),stack.Peek().pila+ listTokens.ElementAt(i) + accion.Remove(0,1)));
                            i++;
                        break;
                        case 'r' : //reduccion
                            p = this.afd.buscaProduccion(int.Parse(accion.Substring(1).ToString()));
                            for(int j =0;j<p.listProd.Count;j++)
                            {
                                stack.Pop();
                            }
                            tabla =  p.nT.token + int.Parse(this.buscaEnTabla(stack.Peek().numEdo, p.nT.token));
                            stack.Push(new PilaASTokens(p.nT.token, int.Parse(this.buscaEnTabla(stack.Peek().numEdo, p.nT.token)),stack.Peek().pila+tabla));
                        break;
                        case 'A' ://aceptar
                        case 'a' :
                            valido = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }


            return valido;
        }

        private string buscaEnTabla(int fila,string col)
        {
            string cad = "";
            int indCol = this.afd.buscaIndiceCol(col);
            
            if(indCol !=-1)
            {
                if (dgvTabla.Rows[fila].Cells[indCol].Value != null)
                {
                    cad = dgvTabla.Rows[fila].Cells[indCol].Value.ToString();
                }
                else
                {
                    cad = "";
                }
            }

            return cad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Produccion> listProd;

            lbGramatica.Items.Clear();
            tvAFD.Nodes.Clear();
            dgvTabla.Rows.Clear();
            dgvTabla.Columns.Clear();
            tbCadena.Text = "";
            listProd = this.cargaGramatica();
            if (listProd != null)
            {
                this.creaAFD(listProd);
                this.llenaAbol();
                this.afd.creaTabla(dgvTabla);
            }
        }

    }
}
