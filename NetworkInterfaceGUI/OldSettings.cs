using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkInterfaceGUI
{
    class OldSettings
    {
        public StringBuilder oldIP { get; private set; }
        public StringBuilder oldSubnet { get; private set; }
        public StringBuilder oldGateway { get; private set; }

        static void New()
        {
            var current = new Process();
            current.StartInfo.FileName = "netsh";
            current.StartInfo.Arguments = "interface ip show address \"Ethernet\"";
            //current.StartInfo.Arguments = "interface ip show address \"Local Area Connection\"";
            current.StartInfo.UseShellExecute = false;
            current.StartInfo.RedirectStandardOutput = true;
            current.Start();

            //Wait for the process to finish, then put output stream into a string.
            current.WaitForExit();

            var netshOutput = current.StandardOutput.ReadToEnd().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //Dim oldSettings As New AddressChange
            //GetCurrentSettings()

            foreach (string line in netshOutput)
            {
                if (line.Contains("IP Address"))
                {
                    //ExtractAddress(line, oldIP);
                }
                else if (line.Contains("mask"))
                {
                    var index = line.IndexOf("mask") + 4;
                    for (int i = index; i < line.Count() - 1; i++)
                    {
                        //if (!line[i].Equals(")"))
                            //oldSubnet.Append(line[i]);
                    }
                }
                else if (line.Contains("Default Gateway"))
                {
                    //ExtractAddress(line, oldGateway);
                }
            }
            //if line.Contains("IP Address")
        }

        private static void ExtractAddress(string line, StringBuilder address)
        {
            int number;
            var index = line.IndexOf(".") - 4;
            if (!int.TryParse(line[index].ToString(), out number))
                index++;

            for (int i = index; i < line.Count() - 1; i++)
            {
                address.Append(line[i]);
            }
        }
    }
}
