using NetworkChamgerApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.NetworkInformation;

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
            foreach (var profile in profiles.Profiles)
            {
                cboProfiles.Items.Add(profile.Name);
            }

            cboNetworAdapters.SelectedIndex = 0;
            cboProfiles.SelectedIndex = 0;
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

        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = cboProfiles.SelectedItem.ToString();
            var profiles = JsonConvert.DeserializeObject<cProfileModel.Root>(System.IO.File.ReadAllText("profile.json"));
            var prof = profiles.Profiles.FirstOrDefault(s => s.Name == profile);

            txtProfilesDetail.Clear();
            txtProfilesDetail.AppendText($"IP Address: {prof.IPAddress}{Environment.NewLine}");
            txtProfilesDetail.AppendText($"Network Mask: {prof.IPAddress}{Environment.NewLine}");
            txtProfilesDetail.AppendText($"Gateway: {prof.IPAddress}{Environment.NewLine}");
            foreach (var dns in prof.DNS)
            {
                txtProfilesDetail.AppendText($"DNS Server: {dns}{Environment.NewLine}");
            }

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // Load Profiles
            string adaptername = cboNetworAdapters.SelectedItem.ToString();

            var profile = cboProfiles.SelectedItem.ToString();

            var profiles = JsonConvert.DeserializeObject<cProfileModel.Root>(System.IO.File.ReadAllText("profile.json"));
            var prof = profiles.Profiles.FirstOrDefault(s => s.Name == profile);

            //Execute Netsh command (IP Address)

            string command = "netsh.exe";
            string Options = " interface ipv4 set address ";

            if (profiles != null)
            {

                if (prof.IPAddress.ToLower() == "dhcp")
                {
                    Options += " \"" + adaptername + "\" ";
                    Options += $" dhcp ";
                }
                else
                {
                    //Adapter(Interface) Name
                    Options += " \"" + adaptername + "\" ";
                    Options += " static ";
                    Options += $" {prof.IPAddress} ";
                    Options += $" {prof.NetMask} ";
                    Options += $" {prof.GatewayAddress} ";

                }

            }




            txtCommandResult.AppendText($"EXEC -> {command} {Options} {Environment.NewLine}");

            ExecuteCommand($"{command} {Options}");

            //Execute Netsh command (DNS)

        }

        private void ExecuteCommand(string executeCommand)
        {
            ProcessStartInfo process_start_info_ = new ProcessStartInfo();

            process_start_info_.FileName = "cmd";

            process_start_info_.Arguments = "/c " + executeCommand;

            //コンソール開かない。
            process_start_info_.CreateNoWindow = true;

            //シェル機能使用しない。
            process_start_info_.UseShellExecute = false;

            //標準出力をリダイレクト。
            process_start_info_.RedirectStandardOutput = true;

            Process process_ = Process.Start(process_start_info_);

            //標準出力を全て取得。
            string res_ = process_.StandardOutput.ReadToEnd();

            process_.WaitForExit();
            process_.Close();

            //取得した標準出力を表示。
            txtCommandResult.AppendText(res_);

        }
    }
}