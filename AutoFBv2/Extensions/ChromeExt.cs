using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFB.Extensions
{
    public static class ChromeExt
    {
        public static void DonDriver()
        {
            try
            {
                string[] Process_name_list = { "chromedriver" };
                int count = 0;
                foreach (string Process_name in Process_name_list)
                {
                    foreach (var process in Process.GetProcessesByName(Process_name))
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Không phát hiện task điều khiển chrome (chromedriver.exe) ! \nBật task manager để kiểm tra");
                    return;
                }
                DialogResult dr = MessageBox.Show("Đã phát hiện " + count +
                    " trình điều khiển Chrome (chromedriver.exe) đang chạy (Có thể xem trong Task Manager)\n" +
                    "Xác nhận xóa để nhẹ máy (có thể lẫn trình điều khiển của phần mềm khác) ?" +
                    "\n (Chỉ dùng nút này khi đã dừng Chrome)",
                        "Xác nhận dọn các trình điều khiển Chrome", MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Information);
                if (dr != DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    int index = 0;
                    foreach (string Process_name in Process_name_list)
                    {
                        foreach (var process in Process.GetProcessesByName(Process_name))
                        {
                            process.Kill();
                            index++;
                        }
                    }
                    // MessageBox.Show("Đã dọn " + index + " task chromedriver.exe !");
                }

            }
            catch (Exception)
            {

            }
        }
    }
}
