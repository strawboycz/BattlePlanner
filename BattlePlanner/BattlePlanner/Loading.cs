using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace BattlePlanner
{
	public class Loading
	{
		public static bool CheckForFile()
		{
			return File.Exists(Saving.DefaultPath + "\\" + Saving.DefaultFileName);
		}

		public static string GetJSON()
		{
			if (CheckForFile())
			{
				string output = File.ReadAllText(Saving.DefaultPath + "\\" + Saving.DefaultFileName);
				return output;
			}
			return "";
		}

		public static List<MilitaryResource> LoadData(string json)
		{
			List<MilitaryResource> output = new List<MilitaryResource>();
			output = JsonSerializer.Deserialize<List<MilitaryResource>>(json)!;
						return output;
		}
	}
}
