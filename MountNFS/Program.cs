using ProcessLib;

#region 挂载
//MountNFS mount = new MountNFS();
//string[] hosts = new string[]
//{
//	//"192.168.1.2",
//	"192.168.8.8",
//	"192.168.8.2",
//};

//await mount.Mount(hosts);
#endregion

#region 测试区
CMD cmd = new();
string[] cmdStrs = new string[3];
for (int i = 0; i < cmdStrs.Length; i++)
{
	cmdStrs[i] = $"ping 192.168.1.1";
}

string[] results = await cmd.RunCommandAsync(cmdStrs);
foreach (string result in results)
{
	Console.WriteLine(result);
}
#endregion

// 让主线程不要退出
Console.ReadLine();