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
    public partial class Form1 : Form
    {

   

        public Form1()
        {
            InitializeComponent();
        }




        private void prijava(object sender, EventArgs e)
        {
            var cnn = SQLStatic.GetSqlkonekcija();
            cnn.Open();

            SqlDataAdapter zadatak = new SqlDataAdapter("select count (*) from Registracija where KorisnickoIme= '" + korime.Text + "' and  Lozinka = '" + lozime.Text + " '", cnn);
            DataTable tablica_provjere = new DataTable();
            zadatak.Fill(tablica_provjere);
            if (tablica_provjere.Rows[0][0].ToString() == "1")
            {
                new Main().Show();
                this.Hide();
            }
            else MessageBox.Show(" Pogresan username ili lozinka");
            cnn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Registracija().Show();
            this.Hide();
        }

        private void isprazni(object sender, EventArgs e)
        {
            lozime.Text = " ";
        }


    }
}
