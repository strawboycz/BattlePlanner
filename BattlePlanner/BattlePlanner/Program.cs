using System;
using System.Collections.Generic;

namespace BattlePlanner
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<MilitaryResource> militaryResources = new List<MilitaryResource>();
			while (true)
			{
				Console.WriteLine($"Choose an action ({Texts.HelpPrefix} for help): ");
				string act = Console.ReadLine();
				#region Help 
					if (act == Texts.HelpPrefix)
						DisplayHelp();
				#endregion

				#region Exit
					if (act == Texts.ExitPrefix)
						return;
				#endregion

				#region Clear
					if (act == Texts.ClearScreenPrefix)
						Console.Clear();
				#endregion

				#region List
					if (act == Texts.ListPrefix)
						ListResources(militaryResources);
				#endregion

				#region Add
					if (act == Texts.AddPrefix)
					{
						Console.WriteLine("Provide the new resource name: ");
						string name = Console.ReadLine();
						AddResource(militaryResources, name);
						
					}
				#endregion

				#region Rename
					if (act == Texts.RenamePrefix)
					{
						Console.WriteLine("Provide the existing resource name: ");
						string name = Console.ReadLine();
						Console.WriteLine("Provide the new name: ");
						string newName = Console.ReadLine();
						MilitaryResource temp = GetResourceByName(militaryResources, name);
						RenameResource(temp, newName);
					}
				#endregion

				#region Delete
					if (act == Texts.DeletePrefix)
					{
						if (militaryResources.Count != 0)
						{
							Console.WriteLine("Provide name of the resource you want to delete: ");
							string name = Console.ReadLine();
							MilitaryResource temp = GetResourceByName(militaryResources, name);
							DeleteResource(temp, militaryResources);
							
						}
						else
						{
							Console.WriteLine("There is nothing to delete, add some resources first");
						}

					}
				#endregion

				#region Edit
					if (act == Texts.EditPrefix)
					{
						Console.WriteLine("Provide name of the resource you want to edit: ");
						string name = Console.ReadLine();
						MilitaryResource temp = GetResourceByName(militaryResources, name);
						if (temp.Name != null)
						{
							#region Edit Menu 
							while (true)
							{
								Console.WriteLine($"(Editing {name})Choose an action ({Texts.EditMenuHelpPrefix} for help): ");
								string editMenuAct = Console.ReadLine();
								if (editMenuAct == Texts.EditMenuHelpPrefix)
									DisplayEditMenuHelp();
								if (editMenuAct == Texts.EditMenuExitPrefix)
									break;
								if (editMenuAct == Texts.EditMenuListPrefix) PrintRequirements(temp);

								if (editMenuAct == Texts.ClearScreenPrefix)
									Console.Clear();
								if (editMenuAct == Texts.EditMenuAddPrefix)
								{
									Console.WriteLine("Provide the name of the added requirement: ");
									string scan1 = Console.ReadLine();
									Console.WriteLine("Provide the value of the added requirement: ");
									int scan2 = int.Parse(Console.ReadLine());
									TryToAddRequirement(temp, scan1, scan2);
								}

								if (editMenuAct == Texts.EditMenuDeletePrefix)
								{
									Console.WriteLine("Provide the name of the requirement you want to delete: ");
									string scan1 = Console.ReadLine();
									TryToDeleteRequirement(temp, scan1);
								}

								if (editMenuAct == Texts.EditMenuRenamePrefix)
								{
									Console.WriteLine("Provide the name of the requirement you want to rename: ");
									string scan1 = Console.ReadLine();
									Console.WriteLine("Provide the new name: ");
									string scan2 = Console.ReadLine();
									TryToRenameRequirement(temp, scan1, scan2);
								}

								if (editMenuAct == Texts.EditMenuEditPrefix)
								{
									Console.WriteLine("Provide the name of the requirement you want to edit the value of: ");
									string scan1 = Console.ReadLine();
									Console.WriteLine("Provide the new value: ");
									int scan2 = int.Parse(Console.ReadLine());
									TryToEditValueOfRequirement(temp, scan1, scan2);
								}
							}
							#endregion

						}
						else
						{
							Console.WriteLine("There's no such resource");
						}
					}
				#endregion

			}

			

		}

		private static void TryToEditValueOfRequirement(MilitaryResource temp, string scan1, int scan2)
		{
			if (temp.EditRequirement(scan1, scan2))
			{
				Console.WriteLine("Requirement edited.");
			}
			else
			{
				Console.WriteLine("Invalid values entered.");
			}
		}

		private static void TryToRenameRequirement(MilitaryResource temp, string scan1, string scan2)
		{
			if (temp.RenameRequirement(scan1, scan2))
			{
				Console.WriteLine("Requirement renamed.");
			}
			else
			{
				Console.WriteLine("Invalid names entered");
			}
		}

		private static void TryToDeleteRequirement(MilitaryResource temp, string scan1)
		{
			if (temp.DeleteRequirement(scan1))
			{
				Console.WriteLine("Requirement deleted.");
			}
			else
			{
				Console.WriteLine("No such requirement.");
			}
		}

		private static void TryToAddRequirement(MilitaryResource temp, string scan1, int scan2)
		{
			if (temp.AddRequirement(scan1, scan2))
				Console.WriteLine("Requitement added.");
			else
				Console.WriteLine("Reuqirement of this name already exists.");
		}

		private static void PrintRequirements(MilitaryResource temp)
		{
			foreach (var keyValuePair in temp.Requirements)
			{
				Console.WriteLine($"{keyValuePair.Key}");
			}
		}

		private static void DeleteResource(MilitaryResource temp, List<MilitaryResource> militaryResources)
		{
			if (temp.Name != null)
			{
				militaryResources.Remove(temp);
			}
			else
			{
				Console.WriteLine("No such resource");
			}
		}

		private static void RenameResource(MilitaryResource temp, string newName)
		{
			if (temp.Name != null)
				temp.ChangeName(newName);
			else
			{
				Console.WriteLine("There's no such resource");
			}
		}

		private static MilitaryResource GetResourceByName(List<MilitaryResource> militaryResources, string name)
		{
			foreach (var militaryResource in militaryResources)
			{
				if (militaryResource.Name == name)
				{
					return militaryResource;
				}
			}
			return new MilitaryResource(null);
		}

		private static void AddResource(List<MilitaryResource> militaryResources, string name)
		{
			militaryResources.Add(new MilitaryResource(name));
		}

		private static void ListResources(List<MilitaryResource> militaryResources)
		{
			militaryResources.ForEach(militaryResource => Console.WriteLine(militaryResource));
		}

		private static void DisplayHelp()
		{
			Console.WriteLine(Texts.HelpText);
		}
		private static void DisplayEditMenuHelp()
		{
			Console.WriteLine(Texts.EditMenuHelpText);
		}
	}
}
