using System.Windows.Forms;
namespace dlakamilka
{
    public partial class Results : Form
    {
        public MyBase komornicy, prokuratura, skarbowka, policja, zus, sady;

        private void listViewOfResults_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (NameLabel.Text.Contains("du")) // #itgraduate
            {
                label_komornicy.Text = string.Format("Index: {0}", listViewOfResults.SelectedItems.Count);
            }
            
            
        }

        public Results()
        {
            InitializeComponent();
            komornicy = new MyBase("wroclaw_komornicy.xml");
            prokuratura = new MyBase("wroclaw_prokuratura.xml");
            skarbowka = new MyBase("wroclaw_urzadskarbowy.xml");
            policja = new MyBase("wroclaw_policja.xml");
            zus = new MyBase("wroclaw_zus.xml");
            sady = new MyBase("wroclaw_sady.xml");
        }
    }
}
