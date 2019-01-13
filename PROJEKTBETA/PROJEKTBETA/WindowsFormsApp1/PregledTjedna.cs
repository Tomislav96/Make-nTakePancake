using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Main

{
    public partial class PregledTjedna: Form
    {
        public string connect = "Data Source=desktop-neiglp9;Initial Catalog=ProjektZavrsno;Integrated Security=True";
        int pocetna_cijena = 15; int kolicina;
        public PregledTjedna()
        {
            InitializeComponent();
            prikazi();
        }

        private void Izlaz_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Narudžba uspješno poslana");
        }
    

        private void prikazi()
        {
            {
                SqlConnection cnn = new SqlConnection(connect);
                cnn.Open();



                string zadatak = "SELECT * FROM Narudzbenica WHERE Rednibroj = (SELECT MAX(Rednibroj) FROM Narudzbenica)";

                SqlCommand cmm = new SqlCommand(zadatak, cnn);
                SqlDataReader rd = cmm.ExecuteReader();
                if (rd.Read())
                {
                    textBox9.Text = (rd["Vrsta"].ToString());
                   
                    textBox5.Text = (rd["Kolicina"].ToString());
                    kolicina = int.Parse(textBox5.Text);
                    
                    textBox4.Text = (pocetna_cijena * kolicina).ToString();

                }
                cnn.Close();
            }


        }

        private void NatragPregledTjedna(object sender, EventArgs e)
        {
            Tjedna otvori = new Tjedna();
            otvori.Show();
            this.Close();
        }
    }
}
