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

namespace ProyectoSebasMazo
{
    public partial class TiendaCore : Form
    {
        static class globales
        {
            public static int contador, precioapagar;
        }
        
        string[] catalogojuegos = new string[] { "Fifa 20", "Gears Of Wars 5", "WatchDogs 2", "Minecraft" };
        string[,] preciosjuegos = { { "fifa20", "150000" }, { "gears of war 5", "200000" }, { "WatchDogs 2", "145000" }, { "Minecraft", "35000" } };
        public TiendaCore()
        {
            InitializeComponent();

        }

        public void TiendaCore_Load(object sender, EventArgs e)
        {

        }

        


       
        private void button4_Click(object sender, EventArgs e)
        {

            if (globales.contador == 1)
            {

                Form formulario = new FormPago();
                formulario.Show();
            }
            else
            {
                MessageBox.Show("Por favor genere una factura antes");
            }
        }
      
        private void button3_Click_1(object sender, EventArgs e)
        {
            Nombre.Text = "";
            Cedula.Text = "";
        }

        private void MostrarCatalogo_Click(object sender, EventArgs e)
        {
            try
            {
                
                string linea;
                string[] juegos;
                using (var fd = new FolderBrowserDialog())
                {
                    if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                    {
                        rutab.Text = fd.SelectedPath + "//BaseDeDatos.txt";
                    }
                }
                string path = rutab.Text;
                if (File.Exists(path))
                {
                    StreamReader file = null;
                    file = new StreamReader(path);
                    linea = file.ReadToEnd();
                    juegos = linea.Split('@');
                    System.Object[] ItemObject = juegos;
                    for (int i = 0; i < juegos.Length; i = i + 2)
                    {
                        ListaCatalogo.Items.Add(juegos[i]);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese una ruta valida para la base de datos, recuerde ingresar la extensión txt");
                }
                

               







            }
            catch (Exception)
            {

                throw;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {

                string nombre, cedula;
                nombre = Nombre.Text;
                cedula = Cedula.Text;


                if (string.IsNullOrEmpty(Nombre.Text) || string.IsNullOrWhiteSpace(Nombre.Text) || string.IsNullOrEmpty(Cedula.Text) || string.IsNullOrWhiteSpace(Cedula.Text))
                {
                    MessageBox.Show("Ingrese datos por favor");
                    return;
                }
                else
                {
                    if (ListaCatalogo.CheckedItems.Count == 0)
                    {
                        
                        MessageBox.Show("Seleccione al menos un item");
                    }
                    else
                    {




                        string s = "";
                        var random = new Random();
                        int codigoserial = random.Next(1000, 9999);
                        for(int i = 0; i < ListaCatalogo.CheckedItems.Count; i++)
                        {
                            globales.precioapagar = globales.precioapagar+45000;
                        }


                        using (var fd = new FolderBrowserDialog())
                        {
                            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
                            {
                                RutaFactura.Text = fd.SelectedPath;
                            }
                        }
                        int  k = random.Next(1000, 9999);
                        
                        using (StreamWriter sw = new StreamWriter(RutaFactura.Text + "//factura"+"ID-"+k+".txt", true))
                        {
                            sw.WriteLine("***************LA CLINICA DE TOTORO***************");
                            sw.WriteLine("DATOS CLIENTE");
                            sw.WriteLine("\nNombre Cliente: " + Nombre.Text + "\nCedula: " + Cedula.Text);
                            sw.WriteLine("\n \n DATOS COMPRA");
                            sw.WriteLine("Codigo Compra= " + codigoserial);
                            sw.WriteLine("JUEGOS A COMPRAR" + "\n"); //Hacer dinamico
                            for(int i = 0; i<ListaCatalogo.CheckedItems.Count; i++)
                            {
                                s = ListaCatalogo.CheckedItems[i].ToString() +" $45.000" + "\n";
                                sw.WriteLine(s);
                            }
                            sw.WriteLine("Precio a pagar: ");
                            sw.WriteLine(globales.precioapagar);

                        }
                        MessageBox.Show("********IMPORTANTE********"+"\n"+"El ID para su factura es " + k +"\n"+"Guardelo, es necesario para después");

                        MessageBox.Show("Factura generada exitosamente");
                        globales.precioapagar = 0;
                        globales.contador = 1;
                    }
                        


                    
                    

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://upbeduco-my.sharepoint.com/:t:/g/personal/sebastian_mazo_upb_edu_co/EXC_kFeQFElHvDWtLT7BYsEBDVvzO5EcHy37osgFZGfMLg?e=AklV5f");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Para el correcto funcionamiento de la app, descargue primero la base de datos con el boton de abajo \n Guarde la ruta, la necesitará después");
        }
    }
}
