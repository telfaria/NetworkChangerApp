using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkChamgerApp.Model
{
    public class cProfileModel
    {
        public cProfileModel()
        {

        }

        public class Root
        {
            public List<Profile> Profiles { get; set; }
        }

        public class Profile
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string AdapterName { get; set; }
            public string IPAddress { get; set; }
            public string NetMask { get; set; }
            public string GatewayAddress { get; set; }
            public List<string> DNS { get; set; }

        }
    }
}
