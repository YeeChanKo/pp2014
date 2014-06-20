using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace 공부도우미 //버튼1에 몰려있던거 버튼2로 옮겨야함(스톱워치랑 타이머 따로)
{
    public partial class Form1 : Form
    {
        int swhour = 0;
        int swmin = 0;
        int swsec = 0;
        int swmsec = 0;

        int tmhour = 0;
        int tmmin = 0;
        int tmsec = 0;
        int tmmsec = 0;

        SoundPlayer alarm = new SoundPlayer(공부도우미.Properties.Resources.alarm);
        SoundPlayer pi = new SoundPlayer(공부도우미.Properties.Resources.pi);
        SoundPlayer piping = new SoundPlayer(공부도우미.Properties.Resources.pi_ping);
        SoundPlayer on = new SoundPlayer(공부도우미.Properties.Resources.on);
        SoundPlayer trash = new SoundPlayer(공부도우미.Properties.Resources.trash);

        public Form1()
        {
            InitializeComponent();

            comboBox1.KeyUp += new KeyEventHandler(EnterKey);
            comboBox2.KeyUp += new KeyEventHandler(EnterKey);
            comboBox3.KeyUp += new KeyEventHandler(EnterKey);
            
            timer1.Interval = 1;
            timer2.Interval = 1;
            timer3.Interval = 1;
            timer4.Interval = 100;
            timer5.Interval = 100;
        }

        private void EnterKey(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (radioButton3.Checked == true && tmhour == 0 && tmmin == 0 && tmsec == 0 && tmmsec == 0)
                    button2_Click(null, null);
            }
        } 

        private void radioButton1_CheckedChanged(object sender, EventArgs e) //시계
        {
            if(radioButton1.Checked==true)
            {
                on.Play();
                groupBox2.Text = radioButton1.Text;
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                timer1.Enabled = true;
                timer2.Enabled = false;
                timer3.Enabled = false;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) //스톱워치
        {
            if(radioButton2.Checked==true)
            {
                on.Play();
                label2.Text = string.Format("{0:00}:{1:00}:{2:00}.{3}", swhour, swmin, swsec, swmsec);
                groupBox2.Text = radioButton2.Text;
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                timer1.Enabled = false;
                timer2.Enabled = true;
                timer3.Enabled = false;
                button1.Visible = true;
                button2.Visible = false;
                button3.Visible = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) //타이머
        {
            if (radioButton3.Checked == true)
            {
                on.Play();
                groupBox2.Text = radioButton3.Text;
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = true;
                comboBox1.Text = "0";
                comboBox2.Text = "0";
                comboBox3.Text = "0";
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                button1.Visible = false;
                button2.Visible = true;
                button3.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) // 시계 타이머
        {
            label2.Text = string.Format("{0:00}:{1:00}:{2:00}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        private void timer2_Tick(object sender, EventArgs e) // 스톱워치 표시 타이머
        {
            label2.Text = string.Format("{0:00}:{1:00}:{2:00}.{3}", swhour, swmin, swsec, swmsec);                        
        }

        private void timer3_Tick(object sender, EventArgs e) // 타이머 표시 타이머
        {
            label2.Text = string.Format("{0:00}:{1:00}:{2:00}.{3}", tmhour, tmmin, tmsec, tmmsec);
        }

        private void timer4_Tick(object sender, EventArgs e) // 스톱워치 계산 타이머
        {
            swmsec++;
            if (swmsec == 10)
            {
                swsec++;
                swmsec = 0;
            }
            if (swsec == 60)
            {
                swmin++;
                swsec = 0;
            }
            if (swmin == 60)
            {
                swhour++;
                swmin = 0;
            }
        }

        private void timer5_Tick(object sender, EventArgs e) // 타이머 계산 타이머
        {
            if (tmhour == 0 && tmmin == 0 && tmsec == 0 && tmmsec == 0)
            {
                alarm.Play();
                timer5.Enabled = false;
            }
            else
                tmmsec--;

            if (tmmsec == -1)
            {
                tmsec--;
                tmmsec = 9;
            }
            if (tmsec == -1)
            {
                tmmin--;
                tmsec = 59;
            }
            if (tmmin == -1)
            {
                tmhour--;
                tmmin = 59;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (timer4.Enabled == false) // 시작
            {
                piping.Play();
                timer4.Enabled = true;
                button1.Text = "중지";
            }
            else if (timer4.Enabled == true) // 중지
            {
                pi.Play();
                timer4.Enabled = false;
                button1.Text = "시작";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer5.Enabled == false) // 시작
            {
                piping.Play();
                if (tmhour == 0 && tmmin == 0 && tmsec == 0 && tmmsec == 0)
                {
                    if (comboBox1.Text == "")
                        comboBox1.Text = "0";
                    if (comboBox2.Text == "")
                        comboBox2.Text = "0";
                    if (comboBox3.Text == "")
                        comboBox3.Text = "0";
                    tmhour = Convert.ToInt32(comboBox1.Text);
                    tmmin = Convert.ToInt32(comboBox2.Text);
                    tmsec = Convert.ToInt32(comboBox3.Text);

                    if (tmhour == 0 && tmmin == 0 && tmsec == 0 && tmmsec == 0)
                    {
                        timer5.Enabled = false;
                        button2.Text = "시작";
                    }
                    else
                    {
                        timer5.Enabled = true;
                        button2.Text = "중지";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                    }
                }
                else
                {
                    timer5.Enabled = true;
                    button2.Text = "중지";
                }
            }
            else if (timer5.Enabled == true) // 중지
            {
                pi.Play();
                timer5.Enabled = false;
                button2.Text = "시작";
            }
        }

        private void button3_Click(object sender, EventArgs e) // 리셋
        {
            trash.Play();
            if (radioButton2.Checked == true)
            {
                swhour = 0; swmin = 0; swsec = 0; swmsec = 0;
                label2.Text = "00:00:00.0";
            }
            else if (radioButton3.Checked == true)
            {
                timer5.Enabled = false;
                tmhour = 0; tmmin = 0; tmsec = 0; tmmsec = 0;
                label2.Text = "00:00:00.0";
                button2.Text = "시작";
            }
        }
    }
}