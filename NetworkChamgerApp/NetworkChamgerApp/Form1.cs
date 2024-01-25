using NetworkChamgerApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Net.Sockets;

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
            var adapterProp = adapter.GetIPProperties();

            txtNetworkAdapterSettings.Clear();
            txtNetworkAdapterSettings.AppendText($"Interface Name : {adapter.Name} {Environment.NewLine}");
            txtNetworkAdapterSettings.AppendText($"Status : {adapter.OperationalStatus}{Environment.NewLine}");
            txtNetworkAdapterSettings.AppendText($"MAC Address : {adapter.GetPhysicalAddress()}{Environment.NewLine}");
            foreach (var ipaddr in adapter.GetIPProperties().UnicastAddresses)
            {
                if (ipaddr.Address.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtNetworkAdapterSettings.AppendText($"IP Address : {ipaddr.Address}{Environment.NewLine}");
                    txtNetworkAdapterSettings.AppendText($"Network Mask : {ipaddr.IPv4Mask}{Environment.NewLine}");
                }

            }

            foreach (var gwaddr in adapterProp.GatewayAddresses)
            {
                txtNetworkAdapterSettings.AppendText($"Gateway : {gwaddr.Address}{Environment.NewLine}");
            }

            foreach (var dnsaddr in adapterProp.DnsAddresses)
            {
                txtNetworkAdapterSettings.AppendText($"DNS : {dnsaddr}{Environment.NewLine}");
            }

        }

        private void cboProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = cboProfiles.SelectedItem.ToString();
            var profiles = JsonConvert.DeserializeObject<cProfileModel.Root>(System.IO.File.ReadAllText("profile.json"));
            var prof = profiles.Profiles.FirstOrDefault(s => s.Name == profile);

            txtProfilesDetail.Clear();
            txtProfilesDetail.AppendText($"Description: {prof.Description}{Environment.NewLine}");
            txtProfilesDetail.AppendText($"--------{Environment.NewLine}");
            txtProfilesDetail.AppendText($"IP Address: {prof.IPAddress}{Environment.NewLine}");
            txtProfilesDetail.AppendText($"Network Mask: {prof.NetMask}{Environment.NewLine}");
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
            string ipOptions = " interface ipv4 set address ";
            string dnsOptions = "interface ipv4 set dns ";

            if (profiles != null)
            {

                if (prof.IPAddress.ToLower() == "dhcp")
                {
                    //IPAddress:DHCP
                    ipOptions += " \"" + adaptername + "\" ";
                    ipOptions += $" dhcp ";
                    
                    //DNS:DHCP
                    dnsOptions += " \"" + adaptername + "\" ";
                    dnsOptions += "dhcp";

                    txtCommandResult.AppendText($"EXEC -> {command} {ipOptions} {Environment.NewLine}");
                    ExecuteCommand($"{command} {ipOptions}");

                    txtCommandResult.AppendText($"EXEC -> {command} {dnsOptions} {Environment.NewLine}");
                    ExecuteCommand($"{command} {dnsOptions}");


                }
                else
                {
                    //Adapter(Interface) Name
                    ipOptions += " \"" + adaptername + "\" ";
                    
                    //IPAddress
                    ipOptions += " static ";
                    ipOptions += $" {prof.IPAddress} ";
                    ipOptions += $" {prof.NetMask} ";
                    ipOptions += $" {prof.GatewayAddress} ";
                    
                    txtCommandResult.AppendText($"EXEC -> {command} {ipOptions} {Environment.NewLine}");
                    ExecuteCommand($"{command} {ipOptions}");


                    //DNS
                    for (int i=0;i<=prof.DNS.Count-1;i++)
                    {
                        
                        if (i==0)
                        {
                            dnsOptions = "interface ipv4 set dns ";
                            dnsOptions += " \"" + adaptername + "\" ";
                            dnsOptions += " static ";
                            dnsOptions += $"{prof.DNS[i]}";

                        }
                        else
                        {
                            dnsOptions = "interface ipv4 add dns ";
                            dnsOptions += " \"" + adaptername + "\" ";
                            dnsOptions += $"{prof.DNS[i]}";

                        }

                        txtCommandResult.AppendText($"EXEC -> {command} {dnsOptions} {Environment.NewLine}");
                        ExecuteCommand($"{command} {dnsOptions}");

                    }

                }

            }
            
        }

        private void ExecuteCommand(string executeCommand)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            psi.FileName = "cmd";

            psi.Arguments = "/c " + executeCommand;

            //コンソール開かない。
            psi.CreateNoWindow = true;

            //シェル機能使用しない。
            psi.UseShellExecute = false;

            //標準出力をリダイレクト。
            psi.RedirectStandardOutput = true;

            Process p = Process.Start(psi);

            //標準出力を全て取得。
            string res_ = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            p.Close();

            //取得した標準出力を表示。
            txtCommandResult.AppendText(res_);

        }
    }
}