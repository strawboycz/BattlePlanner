namespace BattlePlanner
{
	public class Texts
	{
		public const string ExitPrefix = "exit";

		public const string ClearScreenPrefix = "clear";

		public const string ListPrefix = "list r";

		public const string AddPrefix = "add r";

		public const string EditPrefix = "edit r";
		
		public const string RenamePrefix = "rename r";
		
		public const string DeletePrefix = "delete r";

		public const string HelpPrefix = "h";

		public static readonly string HelpText = $"{HelpPrefix} - Displays help.\n" +
		                                         $"{ListPrefix} - Prints list of all current military resources.\n" +
		                                         $"{AddPrefix} - Adds a resource.\n" +
		                                         $"{EditPrefix} - Opens the menu for editing requirements of a resource.\n" +
		                                         $"{RenamePrefix} - Renames a resource.\n" +
		                                         $"{DeletePrefix} - Deletes a resource.\n" +
		                                         $"{ClearScreenPrefix} - Clears the screen.\n" +
		                                         $"{ExitPrefix} - closes the program\n";

		public const string EditMenuHelpPrefix = "h";
		public const string EditMenuExitPrefix = "exit";
		public const string EditMenuAddPrefix = "a";
		public const string EditMenuEditPrefix = "e";
		public const string EditMenuRenamePrefix = "r";
		public const string EditMenuDeletePrefix = "d";
		public const string EditMenuListPrefix = "ls";
		public static readonly string EditMenuHelpText = $"{EditMenuHelpPrefix} - Displays help.\n" +
		                                                 $"{EditMenuListPrefix} - Prints list of all current requirements.\n" +
		                                                 $"{EditMenuAddPrefix} - Adds a requirement.\n" +
		                                                 $"{EditMenuEditPrefix} - Edits a value of a requirement.\n" +
																										 $"{EditMenuRenamePrefix} - Renames a requirement.\n" +
		                                                 $"{EditMenuDeletePrefix} - Deletes a requirement.\n" +
		                                                 $"{ClearScreenPrefix} - Clears the screen.\n" +
		                                                 $"{EditMenuExitPrefix} - Exits the edit menu.\n";
		                                                 
	}
}