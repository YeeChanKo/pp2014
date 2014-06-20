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
using System.Xml.Serialization;

namespace ImageViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "모든파일 (*.*)|*.*";
            saveFileDialog1.Filter = "XML (*.xml)|*.xml|모든파일 (*.*)|*.*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                string extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf('.')+1); // 확장자 구하기

                if(extension!="xml")
                {
                    Image img = Image.FromFile(openFileDialog1.FileName);
                    pictureBox1.Width = img.Width;
                    pictureBox1.Height = img.Height;
                    pictureBox1.Image = img;
                }
                else
                {
                    ImageData joongilkim = new ImageData();
                    XmlSerializer xs = new XmlSerializer(typeof(ImageData));
                    StreamReader sw = new StreamReader(openFileDialog1.FileName);
                    joongilkim = (ImageData)xs.Deserialize(sw);
                    sw.Close();

                    Bitmap bmp = new Bitmap(joongilkim.width,joongilkim.height);
                    for (int i = 0; i < joongilkim.height; i++)
                    {
                        for (int j = 0; j < joongilkim.width; j++)
                        {
                            bmp.SetPixel(j, i, Color.FromArgb(joongilkim.pixel[i * joongilkim.width + j]));
                        }
                    }
                    pictureBox1.Image = bmp;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            ImageData joongilkim = new ImageData();
            joongilkim.setsize(bmp.Width, bmp.Height);
            for(int i =0;i<joongilkim.height; i++)
            {
                for(int j=0;j<joongilkim.width;j++)
                {
                    joongilkim.pixel[i*joongilkim.width+j] = bmp.GetPixel(j, i).ToArgb();
                }
            }

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                XmlSerializer xs = new XmlSerializer(typeof(ImageData));
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false);
                xs.Serialize(sw, joongilkim);
                sw.Close();
            }
        }
    }
}
