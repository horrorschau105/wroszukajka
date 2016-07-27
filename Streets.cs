using System;
using System.Windows.Forms;
using System.Xml.Linq;
namespace dlakamilka
{
    public class MyBase
    {
        public XElement baza;
        public MyBase(string path)
        {
            try
            {
                baza = XElement.Load(path);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(-16);
            }
        }
    }
}
