using AutoFB.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoFB.Extensions
{
    public static class APIExt
    {
        public static string GetMaUuid()
        {
            string cpuInfo = string.Empty;

            cpuInfo = GetUuid();
            if (!cpuInfo.Contains("UUID"))
            {
                return null;
            }
            if (cpuInfo.Contains("\n"))
            {
                string[] arr = cpuInfo.Split('\n');
                cpuInfo = arr[1];
                cpuInfo = cpuInfo.Trim();
            }

            return cpuInfo;
        }
        private static string GetUuid()
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "CMD.exe";
            startInfo.Arguments = "/C wmic csproduct get UUID";
            startInfo.CreateNoWindow = true;
            process.StartInfo = startInfo;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
        public static string GetDiaChiMac()
        {
            string macAddresses = string.Empty;
            try
            {
                String firstMacAddress = NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();

                firstMacAddress = firstMacAddress.Trim();
                return firstMacAddress;
            }
            catch (Exception ex)
            {
            }
            return macAddresses;
        }
        public static string GetTenThietBi()
        {
            try
            {
                string pcName = System.Environment.MachineName;
                if (pcName.Length >= 100)
                {
                    pcName = pcName.Substring(0, 99);
                }
                return pcName;
            }
            catch
            {
            }
            return string.Empty;
        }
        public static IRestResponse DangNhap(ClientLogin log)
        {
            string json = JsonConvert.SerializeObject(log);
            var client = new RestClient("http://api.phanmemhay.info/v1/nguoidung/login");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public static IRestResponse CheckLicenseKey(ClientLicenseKey clientData)
        {
            string json = JsonConvert.SerializeObject(clientData);
            var client = new RestClient("http://api.phanmemhay.info/v1/licensekey/checklicensekey");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public static IRestResponse DoiMatKhau(ClientChangePass log)
        {
            string json = JsonConvert.SerializeObject(log);
            var client = new RestClient("http://api.phanmemhay.info/v1/nguoidung/doimatkhau");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            return response;
        }
        public static bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;
            if (password != null)
            {
                password = password.Trim();
            }
            if (password.Contains(" "))
            {
                ErrorMessage = "Trong mật khẩu có chứa ký tự cách";
                return false;
            }
            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorMessage = "Mật khẩu bị rỗng";
                return false;
            }
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@"^.{8,20}$");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
            if (!hasLowerChar.IsMatch(input) ||
                !hasUpperChar.IsMatch(input) ||
                !hasMiniMaxChars.IsMatch(input) ||
                !hasLowerChar.IsMatch(input) ||
                !hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ cái thường, ít nhất một chữ cái hoa, ít nhất một ký tự đặc biệt (VD: @,!,#,..., Dài từ 8-20 ký tự)";
                return false;
            }
            return true;

            //if (!hasLowerChar.IsMatch(input))
            //{
            //    ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ cái thường";
            //    return false;
            //}
            //else if (!hasUpperChar.IsMatch(input))
            //{
            //    ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ cái hoa";
            //    return false;
            //}
            //else if (!hasMiniMaxChars.IsMatch(input))
            //{
            //    ErrorMessage = "Độ dài mật khẩu phải từ 8 - 20 kí tự, hiện tại là " + password.Length;
            //    return false;
            //}
            //else if (!hasNumber.IsMatch(input))
            //{
            //    ErrorMessage = "Trong mật khẩu phải có ít nhất một chữ số";
            //    return false;
            //}

            //else if (!hasSymbols.IsMatch(input))
            //{
            //    ErrorMessage = "Trong mật khẩu phải có ít nhất một ký tự đặc biệt (VD: !,#,@,...)";
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }
    }
}
