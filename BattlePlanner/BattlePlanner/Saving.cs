using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BattlePlanner
{
	public class Saving
	{
		public const string DefaultPath = @"C:\BattlePlannerSaves";
		public const string DefaultFileName = "BattlePlannerSave.JSON";

				public static string GenerateJSON(Object subject)
		{
			return JsonSerializer.Serialize(subject);
		}

		public static void InitializeJSONFile()
		{
			if (!Directory.Exists(DefaultPath))
				Directory.CreateDirectory(DefaultPath);

			if (!File.Exists(DefaultPath + "\\" + DefaultFileName))
				File.Create(DefaultPath + "\\" + DefaultFileName).Close();

		}

		public static bool SaveJSON(String json)
		{
			if (File.Exists(DefaultPath + "\\" + DefaultFileName))
			{
				File.WriteAllText(DefaultPath + "\\" + DefaultFileName, String.Empty);
				File.WriteAllText(DefaultPath + "\\" + DefaultFileName,json);
				return true;
			}

			return false;
		}
	}
}