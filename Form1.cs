using Manejo_de_archivos_con_arboles_y_listas_ligadas.clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejo_de_archivos_con_arboles_y_listas_ligadas
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            renderDisco(Context.MaxValues);
        }

        private Label generateLabel()
        {
            Label label = new Label();
            label.Text = "Sector Vacio";
            label.BackColor = Color.Purple;
            label.Margin = new Padding(2, 2, 2, 2);
            label.Width = 60; // Establece el ancho del Label a 200 píxeles
            label.Height = 50; // Establece la altura del Label a 100 píxeles
            return label;
        }
        private void renderDisco(int total_slots = 10)
        {
            disco_visual.Controls.Clear();

            int rowCount = 4; // Número de filas
            int columnCount = 5; // Número de columnas

            disco_visual.ColumnCount = columnCount;
            disco_visual.Padding = new Padding(10);

            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    Label label = generateLabel();
                    // Agregar el botón a la celda correspondiente
                    disco_visual.Controls.Add(label, column, row);
                }
            }

            for (int column = 0; column < disco_visual.ColumnCount; column++)
            {
                disco_visual.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            }

        }
        private void AddToPanel(Label label)
        {
            //Debugger.Break();
            disco_visual.Controls.Add(label, Context.columnasState, Context.filasState);
            Context.columnasState++;
            if (Context.columnasState == 5)
            {
                Context.columnasState = 0;
                Context.filasState++;
            }

        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            string filename = input__file.textBox.Text;

            if (filename.Trim().Length == 0)
            {
                input__file.Focus();
                showAlert("Ingresa un nombre valido");
                return;
            }

            float numb = input__bytes.ValueNumber;

            int multiplos = (int)numb;

            if (multiplos <= 0)
            {
                input__bytes.Focus();
                showAlert("Ingresa una cantidad valida");
                return;

            }

            if (Context.MultiplosRestantes == 0)
            {
                showAlert("Sin sectores disponibles");
                return;
            }

            //Debugger.Break();

            if (multiplos > Context.MultiplosRestantes)
            {
                showAlert("Sectores insuficientes");
                return;
            }

            Context.estado_raiz = Context.agregarNodo(Context.estado_raiz, filename, multiplos, true);

            showAlert("Archivo guardado correctamente");

            Debugger.Break();

            //_ = Context.estado_raiz;

            _ = Context.MultiplosRestantes;

            RenderDiscoVirtual();

        }

        private void RenderDiscoVirtual()
        {
            disco_visual.Controls.Clear();

            Context.columnasState = 0;

            Context.filasState = 0;

            int i = 0;

            RenderDisco(Context.estado_raiz!, ref i);

            //Debugger.Break();

            for (i = i; i < Context.MaxValues; i++)
            {
                Label label = generateLabel();
                label.BackColor = Color.Purple;
                label.Text = "Sector Vacio";
                AddToPanel(label);
            }
        }
        private void render_Click(object sender, EventArgs e)
        {
            RenderDiscoVirtual();
        }

        private void RenderDisco(Arbol nodo, ref int indice)
        {

            if (nodo != null)
            {
                indice++;
                Label label = generateLabel();
                label.BackColor = Color.Blue;
                label.Text = nodo.nombre_archivo;
                AddToPanel(label);
                //Debugger.Break();
                for (int i = 0; i < nodo.sectores.Count - 1; i++)
                {
                    //Label _label = generateLabel();
                    Label _label = new Label();
                    _label.Margin = new Padding(2, 2, 2, 2);
                    _label.Height = 50;
                    _label.Width = 60;
                    _label.BackColor = Color.Yellow;
                    _label.Text = nodo.nombre_archivo + " (sector)";
                    AddToPanel(_label);
                }
                RenderDisco(nodo.izquierdo, ref indice);
                RenderDisco(nodo.derecha, ref indice);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void editableList1_Load(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void smallLabel1_Click(object sender, EventArgs e)
        {

        }

        private void airForm1_Click(object sender, EventArgs e)
        {

        }

        private void disco_visual_Paint(object sender, PaintEventArgs e)
        {

        }
        private void showAlert(string msg = "Error")
        {
            MessageBox.Show(msg, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
