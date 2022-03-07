using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EierfamBl;

namespace EierfarmGui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, EventArgs e)
        {
            // neues Huhn erzeugen
            Huhn huhn = new Huhn("Neues Huhn");
            // Huhn in die Combobox
            cbxTiere.Items.Add(huhn);
            // Huhn in der Combobox auswählen
            cbxTiere.SelectedItem = huhn;
        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new Gans();

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            Gefluegel tier = cbxTiere.SelectedItem as Gefluegel; // Safe-Cast: Liefert null, wenn Cast fehlschlägt
            //if (tier != null) // If tier IsNot Nothing Then
            //{
            //    tier.Fressen();

            //}
            tier?.Fressen();
            pgdTier.SelectedObject = tier;
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is Gefluegel tier)
            {
                tier.EiLegen();
                pgdTier.SelectedObject = tier;
            }
        }
    }
}
