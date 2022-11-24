using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BattlePlanner
{
	public class Saving
	{
		private const string DefaultPath = @"C:\BattlePlannerSaves";
		private const string DefaultFileName = "BattlePlannerSave.JSON"; 

		public static string GenerateJSON(Object subject)
		{
			return JsonSerializer.Serialize(subject);
		}

		public static void InitializeJSONFile()
		{
			if (!Directory.Exists(DefaultPath))
				Directory.CreateDirectory(DefaultPath);

			if (!File.Exists(DefaultPath + DefaultFileName))
				File.Create(DefaultPath + DefaultFileName);

		}
	}
}