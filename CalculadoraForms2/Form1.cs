using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalculadoraForms2
{
    public partial class Form1 : Form

    {
        int numero1;
        string ultimoOp;
        bool pressOP;




        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAuxiliar.Clear();
        }
        private void Numero_Click(object sender, EventArgs e)
        {
            var botao = (Button)sender;
            txbTela.Text += botao.Text;

            pressOP = false;

        }
        private void Operador_Click(object sender, EventArgs e)
        {

            // Obter o botão que está chamando o evento
            var botao = (Button)sender;



            if (pressOP == false && txbTela.Text != "" && txbAuxiliar.Text == "")
            {
                numero1 = int.Parse(txbTela.Text);
                txbTela.Clear();
                txbAuxiliar.Text = numero1.ToString() + botao.Text;
                ultimoOp = botao.Text;
                pressOP = true;
            }
            else
            {

                //Verificar se txbAux não está vazio
                if (txbAuxiliar.Text != "" && txbTela.Text != "")
                {
                    //Simular pressionar botão:
                    btnIgual.PerformClick();
                    txbAuxiliar.Text = txbTela.Text + botao.Text;
                    numero1 = int.Parse(txbTela.Text);
                    txbTela.Text = "";
                    ultimoOp = botao.Text;
                }
            }

        }
        private void btnIgual_Click(object sender, EventArgs e)
        {



            switch (ultimoOp)
            {
                case "+":

                    txbAuxiliar.Clear();
                    txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();

                    break;

                case "-":
                    txbAuxiliar.Clear();
                    txbTela.Text = (numero1 - int.Parse(txbTela.Text)).ToString();
                    break;

                case "x":
                    txbAuxiliar.Clear();
                    txbTela.Text = (numero1 * int.Parse(txbTela.Text)).ToString();
                    break;

                case "/":
                    txbAuxiliar.Clear();
                    if (numero1 == 0)
                    {
                        txbTela.Text = (numero1 / int.Parse(txbTela.Text)).ToString();
                        
                    }
                    else
                    {

                        MessageBox.Show("Impossível dividir por 0") ;
                    }
                    break;            



            }



            pressOP = false;



        }
    }
}

