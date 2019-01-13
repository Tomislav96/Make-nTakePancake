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
    public partial class Tjedna : Form
    {
        public string connect = "Data Source=desktop-neiglp9;Initial Catalog=ProjektZavrsno;Integrated Security=True";
        public Tjedna()
        {
            InitializeComponent();
        }

        private void Izlaz_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Tjedna_Load(object sender, EventArgs e)
        {

        }

        private void Natrag_Click(object sender, EventArgs e)
        {
            new Main().Show();
            this.Hide();
        }

        private void Nastavi_Click(object sender, EventArgs e)
        {
            new Pregled().Show();
            this.Hide();
        }

        private void Nastavi_Tjedna(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            
            string zadatak = "insert into Narudzbenica (Vrsta, Kolicina) values ( 'Americka palacinka sa bananama i preljevom'  , " + this.textBoxx.Text + ");";
            SqlCommand napravi = new SqlCommand(zadatak, cnn);
            SqlDataReader citac = napravi.ExecuteReader();

            cnn.Close();
            PregledOdabranih otvori = new PregledOdabranih();
            otvori.Show();
            this.Close();
        }

        private void Natrag_Click1(object sender, EventArgs e)
        {
            Main otvori = new Main();
            otvori.Show();
            this.Close();
        }
    }
}
