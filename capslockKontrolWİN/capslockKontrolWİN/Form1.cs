using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hakanYusufoglu;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace capslockKontrolWİN
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            dinlenilecekTuslar();
           kontrol.unhook();
            kontrol.hook();
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (key.GetValue("capslockKontrolWİN").ToString() == "\"" + Application.ExecutablePath + "\"") //pc acılısında oto acılsın aktifse aktif işaretli
                {
                    checkBox1.Checked = true;
                    if(checkBox1.Checked)
                    {
                        this.Hide();
                    }
                   
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }
            catch
            {
               
            }



        }
        globalKeyboardHook kontrol = new globalKeyboardHook();

        public void dinlenilecekTuslar()
        {
            try
            {

                kontrol.HookedKeys.Add(Keys.CapsLock);

                kontrol.KeyDown += new KeyEventHandler(balon);
                kontrol.unhook();



            }
            catch
            {
                MessageBox.Show("Bir Sorunla karşılaşıldı KOD=2");
            }
        }
        int tester=1;
        void balon(object sender, KeyEventArgs e)
        {
           
            if (Control.IsKeyLocked(Keys.CapsLock) == true)

            {
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipTitle = "Capslock Tuşu KAPALI";
                notifyIcon1.BalloonTipText = "KÜÇÜK harflerle yazabilirsiniz. ";
                notifyIcon1.ShowBalloonTip(10); //Mesajı 10sn. görüntül0
               
                tester = 1;
                if (tester == 1)
                {
                    label1.Text = "kucuk";
                   
                }
      




                e.Handled = false;


            }



            else if (Control.IsKeyLocked(Keys.CapsLock) == false)
            {

                 notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                 notifyIcon1.BalloonTipTitle = "Capslock Tuşu AÇIK";
                 notifyIcon1.BalloonTipText = "BÜYÜK harflerle yazabilirsiniz";
                 notifyIcon1.ShowBalloonTip(10); //Mesajı 10sn. görüntüler
                
                 e.Handled = false;
                kontrol.hook();
                
                tester = 0;
                  if (tester == 0)
                {
                    label1.Text = "buyk";
                    
                }
                  
                kontrol.unhook();
            }
          
        }
    
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
          
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
                
             

            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if(checkBox1.Checked)
            {
                RegistryKey anahtar = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                anahtar.SetValue("capslockKontrolWİN", "\"" + Application.ExecutablePath + "\"");
                MessageBox.Show("Otomatik Açılma Aktif");
            }
            else
            {
                RegistryKey anahtar2= Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                anahtar2.DeleteValue("capslockKontrolWİN");
                MessageBox.Show("Otomatik Açılma Devredışı");
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            
        }

        private void pencereyiAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*this.Visible = true;*/
            this.Show();
        }

        private void programıKapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Hide();
            
        }

        private void programıKapatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon2_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
