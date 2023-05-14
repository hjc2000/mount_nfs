namespace StringLib
{
	public static class Slice
	{
		/// <summary>
		/// 对字符串进行切片，从指定的第一个字符开始到指定的最后一个字符（闭区间）<br></br>
		/// 指定的最后一个字符是从字符串末尾开始查找的，所以切下来的字符串片段会是最长的，所以叫Max
		/// 切下来的子字符串包含开始字符和结束字符<br></br>
		/// 例如字符串：“123{456}123” 如果指定 start 为 “{” ,end 为 “}”，则返回值为
		/// {456}
		/// </summary>
		/// <param name="str"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static string? SliceMaxOn(this string str, char start, char end)
		{
			int startIndex = str.IndexOf(start);
			int endIndex = str.LastIndexOf(end);
			try
			{
				return str.Substring(startIndex, endIndex - startIndex + 1);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 对字符串进行切片，从指定的第一个字符开始到指定的最后一个字符（闭区间）<br></br>
		/// 指定的最后一个字符是从字符串末尾开始查找的，所以切下来的字符串片段会是最长的，所以叫Max
		/// 切下来的子字符串包含开始字符和结束字符<br></br>
		/// 例如字符串：“123{456}123” 如果指定 start 为 “{” ,end 为 “}”，则返回值为
		/// {456}
		/// </summary>
		/// <param name="str"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static string? SliceMaxOn(this string str, string start, string end)
		{
			int startIndex = str.IndexOf(start);
			int endIndex = str.LastIndexOf(end);
			try
			{
				return str.Substring(startIndex, endIndex - startIndex + 1);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 切片不包含指定的字符（开区间）
		/// </summary>
		/// <param name="str"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static string? SliceMaxBetween(this string str, char start, char end)
		{
			int startIndex = str.IndexOf(start);
			int endIndex = str.LastIndexOf(end);
			try
			{
				return str.Substring(startIndex + 1, endIndex - startIndex - 1);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 切片不包含指定的字符（开区间）
		/// </summary>
		/// <param name="str"></param>
		/// <param name="start"></param>
		/// <param name="end"></param>
		/// <returns></returns>
		public static string? SliceMaxBetween(this string str, string start, string end)
		{
			int startIndex = str.IndexOf(start);
			int endIndex = str.LastIndexOf(end);
			try
			{
				return str.Substring(startIndex + 1, endIndex - startIndex - 1);
			}
			catch
			{
				return null;
			}
		}

		/// <summary>
		/// 从字符串中切下一行，返回这一行和剩下的部分。
		/// 如果输入字符串中不包含换行符，则linu返回空，remain返回原字符串
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static (string? line, string remain) ReadLine(this string str)
		{
			try
			{
				(string? line, string remain) result = (null, string.Empty);
				int index = str.IndexOf("\n");
				result.line = str.Substring(0, index);
				result.remain = str.Substring(index + 1);
				return result;
			}
			catch
			{
				return (null, str);
			}
		}

		public static string RemoveFirstLine(this string str)
		{
			try
			{
				string remain;
				int index = str.IndexOf("\n");
				remain = str.Substring(index + 1);
				return remain;
			}
			catch
			{
				return str;
			}
		}
	}
}