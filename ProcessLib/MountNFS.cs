﻿using System.Net.NetworkInformation;
using StringLib;

namespace ProcessLib
{
	public class MountNFS
	{
		private CMD cmd = new CMD();

		public static async Task<bool> IsAlive(string ip)
		{
			Ping ping = new();
			PingReply reply = await ping.SendPingAsync(ip);
			if (reply.Status == IPStatus.Success)
			{
				return true;
			}

			return false;
		}
		public static async Task WaitUntilAlive(string ip)
		{
			while (true)
			{
				try
				{
					if (await IsAlive(ip))
					{
						break;
					}
				}
				catch
				{
					Console.WriteLine("异常");
				}

				await Task.Delay(2000);
			}
		}

		#region 挂载方法的重载
		public async Task Mount(string ip)
		{
			Console.WriteLine("正在检查网络连接");
			await WaitUntilAlive(ip);
			Console.WriteLine("正在挂载");
			try
			{
				string cmdResult = await cmd.RunCommandAsync($"showmount -e {ip}");
				cmdResult = cmdResult.RemoveFirstLine();
				int startIndex = cmdResult.IndexOf('/');
				int endIndex = cmdResult.IndexOf(' ', startIndex);
				cmdResult = cmdResult.Substring(startIndex, endIndex - startIndex);
				Console.WriteLine($"即将挂载：{ip}:{cmdResult}");
				// -o mtype=hard
				cmdResult = await cmd.RunCommandAsync($"mount {ip}:{cmdResult} *");
				Console.WriteLine(cmdResult);
			}
			catch
			{
				Console.WriteLine("异常");
			}
		}

		public async Task Mount(string[] ips)
		{
			List<Task> tasks = new List<Task>();
			foreach (string ip in ips)
			{
				tasks.Add(Mount(ip));
			}

			await Task.WhenAll(tasks);
		}
		#endregion
	}
}
