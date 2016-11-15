using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Temp.Exceptions;

namespace Temp.App
{
    public partial class App : Form
    {
        public App()
        {
            InitializeComponent();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            txtboxZipCode.Enabled = false;

            btnSearch.Text = "Loading...";

            var zipCode = txtboxZipCode.Text;

            var ow = new OpenWeatherTemperatureService(ConfigurationSettings.AppSettings["OpenWeatherAppId"]);
            var service = new TemperatureService(ow);


            var temp = await service.GetTemperatureAsync(Int32.Parse(zipCode));

            btnSearch.Enabled = true;
            txtboxZipCode.Enabled = true;
            btnSearch.Text = "Search";
            MessageBox.Show(temp.Temp.ToString());
        }

        private void lblEnterZipCode_Click(object sender, EventArgs e)
        {

        }
    }
}
