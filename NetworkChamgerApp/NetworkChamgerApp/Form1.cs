using System.Net.NetworkInformation;
using NetworkChamgerApp.Model;
using Newtonsoft.Json;

namespace NetworkChamgerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Load Network Adapters
            var adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (var adapter in adapters)
            {
                cboNetworAdapters.Items.Add(adapter.Name);
            }

            //Load Network Profile
            var profiles = JsonConvert.DeserializeObject<cProfileModel.Root>(System.IO.File.ReadAllText("profile.json"));
            foreach (var profile in profiles)
            {
                cboProfiles.Items.Add(profile.Name);
            }
        }

        private void cboNetworAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get Network Adapter Information
            string adaptername = cboNetworAdapters.SelectedItem.ToString();

            var adapter = NetworkInterface.GetAllNetworkInterfaces().Single(s => s.Name == adaptername);

            txtNetworkAdapterSettings.Clear();
            txtNetworkAdapterSettings.AppendText($"Interface Name : {adapter.Name} {Environment.NewLine}");
            txtNetworkAdapterSettings.AppendText($"Status : {adapter.OperationalStatus}{Environment.NewLine}");
            txtNetworkAdapterSettings.AppendText($"MAC Address : {adapter.GetPhysicalAddress()}{Environment.NewLine}");
            foreach (var ipaddr in adapter.GetIPProperties().UnicastAddresses)
            {
                txtNetworkAdapterSettings.AppendText($"IP Address : {ipaddr.Address}{Environment.NewLine}");
                txtNetworkAdapterSettings.AppendText($"Network Mask : {ipaddr.IPv4Mask}{Environment.NewLine}");
            }

        }
    }
}