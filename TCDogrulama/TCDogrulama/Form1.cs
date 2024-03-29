﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCDogrulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long kimlikNo = Convert.ToInt64(txtTC.Text);
            int yil = Convert.ToInt16(txtYil.Text);
            bool durum;
            
            try
            {
                using(TCDogrula.KPSPublicSoapClient service = new TCDogrula.KPSPublicSoapClient { })
                {
                    durum = service.TCKimlikNoDogrula(kimlikNo, txtAd.Text, txtSoyad.Text, yil);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (durum==true)
            {
                MessageBox.Show("Kayıt var.");
            }
            else
            {
                MessageBox.Show("Böyle bir kişi bulunmamaktadır.");
            }

        }
    }
}
