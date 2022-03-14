using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
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

            // Event verdrahten
            huhn.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;
            //huhn.EigenschaftGeaendert += this.AndererHandler;          

            // Huhn in die Combobox
            cbxTiere.Items.Add(huhn);
            // Huhn in der Combobox auswählen
            cbxTiere.SelectedItem = huhn;
        }

        //private void AndererHandler(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private void Gefluegel_EigenschaftGeaendert(object sender, GefluegelEventArgs e)
        {
            // Strings are immutable!
            string hallo = "Hallo";
            string welt = "Welt";

            // Ganz böse:
            string meldung = hallo + " " + welt;

            // Lösung StringBuilder (GC-freundlich):
            StringBuilder builder = new StringBuilder(hallo);
            builder.Append(" ");
            builder.Append(welt);
            string meldung2 = builder.ToString();

            // Lösung String.Format (GC-freundlich):
            string meldung4 = string.Format("{0} {1}", hallo, welt);

            // oder so (String-Konkatinierung)
            string meldung3 = $"{hallo} {welt}";

            double p = 3.1415926536;
            string meld = $"Heute ({DateTime.Now:dd.MM.yy}): PI ist {p:f2}";

            MessageBox.Show($"Tier '{((Gefluegel)sender).Name}' hat Eigenschaft '{e.GeaenderteProperty}' geändert.");
            pgdTier.SelectedObject = sender;
        }

        private void cbxTiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            pgdTier.SelectedObject = cbxTiere.SelectedItem;
        }

        private void btnNeueGans_Click(object sender, EventArgs e)
        {
            Gans gans = new Gans();

            gans.EigenschaftGeaendert += Gefluegel_EigenschaftGeaendert;
            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void btnFuettern_Click(object sender, EventArgs e)
        {
            IEiLeger tier = cbxTiere.SelectedItem as IEiLeger; // Safe-Cast: Liefert null, wenn Cast fehlschlägt
            //if (tier != null) // If tier IsNot Nothing Then
            //{
            //    tier.Fressen();

            //}
            tier?.Fressen();
            //pgdTier.SelectedObject = tier;
        }

        private void btnEiLegen_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEiLeger tier)
            {
                tier.EiLegen();
                //pgdTier.SelectedObject = tier;
            }
        }

        private void btnSpeichern_Click(object sender, EventArgs e)
        {
            if (cbxTiere.SelectedItem is IEiLeger tier)
            {
                // Benutzer nach Speicherort fragen
                SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "Huehner|*.hn|Gaense|*.gs|Alles|*.*", FilterIndex = 0, RestoreDirectory = true };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tier als XML speichern
                    XmlSerializer serializer = new XmlSerializer(tier.GetType(), new[] { typeof(HuehnerEi), typeof(GaenseEi) });
                    StreamWriter writer = new StreamWriter(saveFileDialog.FileName);
                    serializer.Serialize(writer, tier);
                }

            }
        }

        private void btnLaden_Click(object sender, EventArgs e)
        {

        }

    }
}
