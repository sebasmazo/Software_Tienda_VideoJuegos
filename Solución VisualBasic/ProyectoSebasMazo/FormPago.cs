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
using Microsoft.VisualBasic;

namespace ProyectoSebasMazo
{
    public partial class FormPago : Form
    {
        int contador2 = 0;
        public int y, devolucion;
        public FormPago()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int contador = 0;
                if (ID.Text == "")
                {
                    MessageBox.Show("Escriba su ID para continuar");
                }
                else
                {
                    string x = ID.Text;
                    using (var fd = new FolderBrowserDialog())
                    {
                        if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                        {
                            Ruta2.Text = fd.SelectedPath + "//factura" + "ID-" + x + ".txt";
                        }
                    }
                    string path = Ruta2.Text;
                    string linea;
                    StreamReader file = null;

                    string path1 = Ruta2.Text;
                    if (File.Exists(path) == false)
                    {
                        MessageBox.Show("No se encontró el ID");
                    }
                    else
                    {
                        file = new StreamReader(path);

                        while ((linea = file.ReadLine()) != null)
                        {
                            contador++;
                            Facturatxt.Text = Facturatxt.Text + "\n" + linea;
                            pagar.Text = linea;
                            contador2 = 1;
                        }
                        file.Close();
                    }

                    

                   

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void FormPago_Load(object sender, EventArgs e)
        {

        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;

            try
            {
                
                if (contador2 == 0)
                {
                    MessageBox.Show("Por favor ingrese su factura");
                }
                else
                {
                    int x = Int32.Parse(Interaction.InputBox("Ingrese el dinero disponible", "Dinero Usuario", " ", -1, -1));
                    bool suficientedinero;
                    if (Convert.ToInt32(pagar.Text) > x)
                    {
                        suficientedinero = false;
                    }
                    else
                    {
                        suficientedinero = true;
                    }
                    switch (suficientedinero)
                    {
                        case (true):
                            MessageBox.Show("Tiene suficiente dinero, continuando con el proceso...");

                            devolucion = x - Convert.ToInt32(pagar.Text);
                            contador++;

                            break;
                        case (false):
                            MessageBox.Show("No tiene suficiente dinero");
                            break;
                    }
                    Random random = new Random();
                    int codigojuego = random.Next(1000, 9999);
                    if (contador == 1)
                    {
                        for (int z = 0; z < 100; z++)
                        {
                            progressBar1.Increment(1);
                            if (progressBar1.Value == 100)
                            {

                                MessageBox.Show("Compra Realizada \n Código para reclamar juego = " + "CDT - " + codigojuego);
                                MessageBox.Show("Dinero a devolver: " + Convert.ToString(devolucion));
                                MessageBox.Show("Gracias por su compra");                               
                                
                                System.Windows.Forms.Application.Exit();

                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vuelva a empezar el proceso de pago");
                        System.Windows.Forms.Application.Exit();
                    }

                    
                   
                }



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
