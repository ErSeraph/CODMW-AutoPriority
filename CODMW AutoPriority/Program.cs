using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CODMW_AutoPriority
{
    class Program
    {
		static async Task Main(string[] args)
		{
            if (anotherIstance()) return;
            
			[DllImport("kernel32.dll")]
			static extern IntPtr GetConsoleWindow();
			[DllImport("user32.dll")]
			static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
			var handle = GetConsoleWindow();
			ShowWindow(handle, 0);

			while(true)
			{
				{
					Process[] game = Process.GetProcessesByName("ModernWarfare");
					if (game.Length != 0)
					{
						try
						{
							game[0].PriorityClass = ProcessPriorityClass.Normal;
						}
						catch (Exception e)
						{
						}
					}
				}
				await Sleep(10000);
			}
		}
		private static async Task Sleep(int seconds)
		{
			await Task.Delay(seconds);
		}

		private static Boolean anotherIstance()
        {
			Process[] p = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
			return p.Length > 1;
        }
	}
}
