using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string textoCortado;
        string textoCopiado;

        int contadorGuardados = 0;
        int columna = 0;
        int fila = 0;

        String texto;
        String paraVolverAEmpezar;
        Boolean buscado = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            archivoNuevo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArchivo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guardarArchivo();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cortarTexto();
            
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pegarTexto();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copiarTexto();
        }

        private void txtBuscar_Click(object sender, EventArgs e)
        {

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorTexto();
        }

        private void fuenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fuenteTexto();
        }

        public void archivoNuevo()
        {
            if (richTxt.TextLength > 0)
            {
                if (MessageBox.Show("¿Desea guardar el documento antes?", "Guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    System.IO.StreamWriter saveFile1 = null;


                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        saveFile1 = new System.IO.StreamWriter(saveFile.FileName);
                        saveFile1.WriteLine(richTxt.Text);
                        saveFile1.Close();

                    }
                    contadorGuardados++;
                }
                else
                {
                    richTxt.Clear();
                }
            }
        }


        public void abrirArchivo()
        {
            System.IO.StreamReader openFile1 = null;

            if (openFile.ShowDialog() == DialogResult.OK)
            {

                openFile1 = new System.IO.StreamReader(openFile.FileName);


                    richTxt.Text = openFile1.ReadToEnd();
                    openFile1.Close();
                
            }
        }


        public void guardarArchivo()
        {
            System.IO.StreamWriter saveFile1=null;
            

            if (contadorGuardados == 0)
            {
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    saveFile1= new System.IO.StreamWriter(saveFile.FileName);
                    saveFile1.WriteLine(richTxt.Text);
                    saveFile1.Close();


                }
                contadorGuardados++;
                
            }
            else
            {
                    saveFile1 = new System.IO.StreamWriter(saveFile.FileName);

                    saveFile1.WriteLine(richTxt.Text);
                    saveFile1.Close();

            }
        }


        public void cortarTexto()
        {
            textoCortado = richTxt.SelectedText;
            richTxt.Clear();
        }


        public void pegarTexto()
        {
            if (textoCortado != null)
            {
                richTxt.Text = richTxt.Text + textoCortado;
                textoCortado = null;
                textoCopiado = null;
            }
            if (textoCopiado != null)
            {
                richTxt.Text = richTxt.Text + textoCopiado;

            }
        }


        public void copiarTexto()
        {
            if (richTxt.SelectionLength > 0)
            {
                textoCopiado = richTxt.SelectedText;
            }
            else
            {
                textoCopiado = richTxt.Text;
            }
        }


        public void colorTexto()
        {
            var colores = colorDialog1.ShowDialog();

            if (colores == DialogResult.OK)
            {
                if (richTxt.SelectedText != null)
                {
                    richTxt.SelectionColor = colorDialog1.Color;
                }
                else
                {
                    richTxt.ForeColor = colorDialog1.Color;
                }
            }
        }


        public void fuenteTexto()
        {
            var fuente = fontDialog1.ShowDialog();

            if (fuente == DialogResult.OK)
            {
                if (richTxt.SelectedText != null)
                {
                    richTxt.SelectionFont = fontDialog1.Font;
                }
                else
                {
                    richTxt.Font = fontDialog1.Font;

                }
            }
        }


        public void buscarTexto()
        {

            paraVolverAEmpezar=richTxt.Text;
            richTxt.Clear();
            richTxt.Text = paraVolverAEmpezar;


                int indice=0;

                for(int i = 0; i < richTxt.Text.LastIndexOf(txtBuscar.Text); i++)
                {
                    richTxt.Find(txtBuscar.Text, indice, richTxt.TextLength, RichTextBoxFinds.None);
                    richTxt.SelectionBackColor = Color.Yellow;
                    indice = richTxt.Text.IndexOf(txtBuscar.Text, indice) + 1;
                    buscado = true;
                }




        }


        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            archivoNuevo();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            abrirArchivo();
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            guardarArchivo();
        }

        private void cortarToolStripButton_Click(object sender, EventArgs e)
        {
            cortarTexto();
        }

        private void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            copiarTexto();
        }

        private void pegarToolStripButton_Click(object sender, EventArgs e)
        {
            pegarTexto();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fuenteTexto();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            colorTexto();
        }

        private void richTxt_TextChanged(object sender, EventArgs e)
        {
            columna = richTxt.SelectionStart - richTxt.GetFirstCharIndexOfCurrentLine();
            fila = richTxt.GetLineFromCharIndex(richTxt.GetCharIndexFromPosition(Cursor.Position));
            lblLinea.Text = "Linea: " + (fila+1) + " , Columna: " + (columna+1);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            buscarTexto();
        }

        private void richTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelAcerca pnlAcerca = new PanelAcerca();

            if (pnlAcerca.ShowDialog() == DialogResult.OK)
            {
                pnlAcerca.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTxt_Click(object sender, EventArgs e)
        {
            if (buscado)
            {
                richTxt.Clear();
                richTxt.Text = paraVolverAEmpezar;
                richTxt.BackColor = Color.White;
                buscado = false;
            }
            

        }
    }
}
