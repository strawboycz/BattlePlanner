using System.Collections.Generic;

namespace BattlePlanner
{
	public class MilitaryResource
	{
		public string Name { get; private set; }
		public Dictionary<string, int> Requirements { get; private set; } = new Dictionary<string, int>();

		public MilitaryResource(string name)
		{
			this.Name = name;
		}
		public MilitaryResource(string name, Dictionary<string , int> requirements)
		{
			
			this.Requirements = requirements;
		}

		public override string ToString()
		{
			if (Requirements.Count == 0)
			{
				return $"{this.Name} doesn't have any requirements";
			}
			string output = $"{this.Name} requires:";
			foreach (var requirement in Requirements)
			{
				output += $"  {requirement.Value} of {requirement.Key}";
			}
			return output;
		}

		public void ChangeName(string newName)
		{
			this.Name = newName;
		}
		public bool AddRequirement(string name,int value)
		{
			if (this.Requirements.ContainsKey(name))
				return false;
			this.Requirements.Add(name,value);
			return true;
		}

		public bool DeleteRequirement(string name)
		{
			if (!this.Requirements.ContainsKey(name))
				return false;
			this.Requirements.Remove(name);
			return true;
		}

		public bool EditRequirement(string existingName, int newValue)
		{
			if (!this.Requirements.ContainsKey(existingName))
				return false;
			this.Requirements[existingName] = newValue;
			return true;
		}

		public bool RenameRequirement(string existingName, string newName)
		{
			if (this.Requirements.ContainsKey(newName))
				return false;
			if (!this.Requirements.ContainsKey(existingName))
				return false;
			this.Requirements.Remove(existingName);
			return true;
		}


	}
}