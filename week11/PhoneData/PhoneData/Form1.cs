using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // for io, xml serialize
using System.Xml.Serialization;

namespace PhoneData
{
    public partial class Form1 : Form
    {
        PhoneBook pb;

        public Form1()
        {
            InitializeComponent();
            pb = new PhoneBook();
            //pb.add("우재우","없음","1학기솔로");
            //pb.add("김중일", "031-222-4444", "교수");
            saveFileDialog1.Filter = "저장파일 (*.xml)|*.xml|전부 (*.*)|*.*";
            openFileDialog1.Filter = "저장파일 (*.xml)|*.xml|전부 (*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader sw = new StreamReader(openFileDialog1.FileName, Encoding.GetEncoding("euc-kr"));
                XmlSerializer xs = new XmlSerializer(typeof(PhoneBook));
                pb = (PhoneBook)xs.Deserialize(sw);
                textBox1.Text = pb.GetAllData();
                sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false, Encoding.GetEncoding("euc-kr"));
                XmlSerializer xs = new XmlSerializer(typeof(PhoneBook));
                xs.Serialize(sw, pb);
                sw.Close();
            }
        }
    }
}
