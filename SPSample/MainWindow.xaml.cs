using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SPSample.Common;
using System.Net;
namespace SPSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbSites_Drop(object sender, DragEventArgs e)
        {

        }

        private void cmbSites_DropDownOpened(object sender, EventArgs e)
        {

            NetworkCredential credentials = new NetworkCredential(txtUserName.Text, txtPassword.Text);
            SPContext context = new SPContext(credentials, null, new Uri(txtServer.Text.ToString()));
            SPWeb web = new SPWeb(context, new Uri(txtServer.Text.ToString()));
            List<SPSite> sites = new List<SPSite>();
            sites = web.GetSites();
            cmbSites.Items.Clear();
            foreach (var site in sites)
            {
                cmbSites.Items.Add(site.Title);
            }
        }
    }
}
