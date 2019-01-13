using Main;
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
    public partial class Registracija : Form
    {

        public string connect = "Data Source=desktop-neiglp9;Initial Catalog=ProjektZavrsno;Integrated Security=True";

        public Registracija()
        {
            InitializeComponent();
        }

      



        private void Izlaz_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void Registriraj(object sender, EventArgs e)
        {
            SqlConnection cnn = new SqlConnection(connect);
            cnn.Open();
            string zadatak = "insert into Registracija(Ime,Prezime,Email,KorisnickoIme,Lozinka) values ( '" + this.textBoxIme.Text + "', '" + textBoxPrezime.Text + "','" + this.textBoxEmail.Text + "', '" + textBoxKorIme.Text + "','" + textBoxLozinka.Text + "');";
            SqlCommand napravi = new SqlCommand(zadatak, cnn);
            SqlDataReader citac = napravi.ExecuteReader();

            cnn.Close();

            new Form1().Show();
            this.Hide();
        }
    }
}
