///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System.Collections.Generic;
using System.Linq;
using BorderlandsAdvancedConfig.INIParser;

namespace BorderlandsAdvancedConfig.SettingsManagers
{
	public class InputSettingsManager
	{
		private INIFileParser InputParser;

		private const string FOVTemplate = "(Name=\"{0}\",Command=\"FOV {1}\",Control=False,Shift=False,Alt=False)";
		private const string OrigUIListMouseLine = "(WidgetClassName=\"Engine.UIList\",WidgetStates=((StateClassName=\"Engine.UIState_Focused\",StateInputAliases=((InputAliasName=\"NextControl\",LinkedInputKeys=((InputKeyName=\"Tab\"))),(InputAliasName=\"MoveSelectionUp\",LinkedInputKeys=((InputKeyName=\"Up\"),(InputKeyName=\"Gamepad_RightStick_Up\"),(InputKeyName=\"MouseScrollUp\"))),(InputAliasName=\"MoveSelectionDown\",LinkedInputKeys=((InputKeyName=\"Down\"),(InputKeyName=\"Gamepad_RightStick_Down\"),(InputKeyName=\"MouseScrollDown\"))),(InputAliasName=\"MoveSelectionLeft\",LinkedInputKeys=((InputKeyName=\"Left\"),(InputKeyName=\"Gamepad_RightStick_Left\"))),(InputAliasName=\"MoveSelectionRight\",LinkedInputKeys=((InputKeyName=\"Right\"),(InputKeyName=\"Gamepad_RightStick_Right\"))),(InputAliasName=\"SelectFirstElement\",LinkedInputKeys=((InputKeyName=\"Home\"))),(InputAliasName=\"SelectLastElement\",LinkedInputKeys=((InputKeyName=\"End\"))),(InputAliasName=\"PageUp\",LinkedInputKeys=((InputKeyName=\"PageUp\"),(InputKeyName=\"XboxTypeS_LeftShoulder\"),(InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42))),(InputAliasName=\"PageDown\",LinkedInputKeys=((InputKeyName=\"PageDown\"),(InputKeyName=\"XboxTypeS_RightShoulder\"),(InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42))),(InputAliasName=\"SelectAllItems\",LinkedInputKeys=((InputKeyName=\"A\",ModifierKeyFlags=42))),(InputAliasName=\"SubmitListSelection\",LinkedInputKeys=((InputKeyName=\"SpaceBar\"),(InputKeyName=\"Enter\"),(InputKeyName=\"XboxTypeS_A\"),(InputKeyName=\"XboxTypeS_Start\"))),(InputAliasName=\"NavFocusUp\",LinkedInputKeys=((InputKeyName=\"XboxTypeS_DPad_Up\"),(InputKeyName=\"Gamepad_LeftStick_Up\"))),(InputAliasName=\"NavFocusDown\",LinkedInputKeys=((InputKeyName=\"XboxTypeS_DPad_Down\"),(InputKeyName=\"Gamepad_LeftStick_Down\"))),(InputAliasName=\"NavFocusLeft\",LinkedInputKeys=((InputKeyName=\"XboxTypeS_DPad_Left\"),(InputKeyName=\"Gamepad_LeftStick_Left\"))),(InputAliasName=\"NavFocusRight\",LinkedInputKeys=((InputKeyName=\"XboxTypeS_DPad_Right\"),(InputKeyName=\"Gamepad_LeftStick_Right\"))))),(StateClassName=\"Engine.UIState_Active\",StateInputAliases=((InputAliasName=\"Clicked\",LinkedInputKeys=((InputKeyName=\"LeftMouseButton\",ModifierKeyFlags=24))),(InputAliasName=\"ResizeColumn\",LinkedInputKeys=((InputKeyName=\"MouseX\",ModifierKeyFlags=0),(InputKeyName=\"MouseY\",ModifierKeyFlags=0)))))))";
		private const string OrigUIScrollFrameMouseLine = "(WidgetClassName=\"Engine.UIScrollFrame\",WidgetStates=((StateClassName=\"Engine.UIState_Focused\",StateInputAliases=((InputAliasName=\"ScrollUp\",LinkedInputKeys=((InputKeyName=\"MouseScrollUp\"),(InputKeyName=\"Up\"))),(InputAliasName=\"ScrollDown\",LinkedInputKeys=((InputKeyName=\"MouseScrollDown\"),(InputKeyName=\"Down\"))),(InputAliasName=\"ScrollTop\",LinkedInputKeys=((InputKeyName=\"Home\"))),(InputAliasName=\"ScrollBottom\",LinkedInputKeys=((InputKeyName=\"End\"))),(InputAliasName=\"PageUp\",LinkedInputKeys=((InputKeyName=\"PageUp\"),(InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42))),(InputAliasName=\"PageDown\",LinkedInputKeys=((InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42),(InputKeyName=\"PageDown\")))))))";
		private const string OrigZoomBind = "(Name=\"RightMouseButton\",Command=\"advancedbutton bAdvancedButtonAux5\")";

		private const string CrouchTemplate = "(Name=\"LeftControl\",Command=\"{0}\",Control=False,Shift=False,Alt=False,LeftTrigger=False,RightTrigger=False,bIgnoreCtrl=False,bIgnoreShift=False,bIgnoreAlt=False)";
		private const string CrouchOriginalCommand = "advancedbutton bAdvancedButtonAux1 | SwitchSeats";
		private const string CrouchToggleCommand = "Duck | SwitchSeats";

		private int? F10Fov;
		private int? F11Fov;

		public InputSettingsManager(INIFileParser inputParser)
		{
			this.InputParser = inputParser;

			IList<ConfigEntry> WillowPlayerInputBindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

			if (WillowPlayerInputBindings == null || WillowPlayerInputBindings.Count <= 0)
			{
				//Copy default bindings
				IList<ConfigEntry> WillowPlayerEngineBindings = InputParser.GetAllSettings("Engine.PlayerInput", "Bindings");

				InputParser.AddSettings("WillowGame.WillowPlayerInput", WillowPlayerEngineBindings);
			}
		}

		internal bool FovKeysEnabled()
		{
			IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

			bool F10assigned = false;
			bool F11assigned = false;

			foreach (ConfigEntry binding in bindings)
			{
				string tempValue = binding.value.Substring(1, binding.value.Length - 2);
				string[] parameters = tempValue.Split(',');

				if (parameters[0].Equals("Name=\"F10\""))
				{
					F10assigned = true;
					string[] commandValuePair = parameters[1].Split('=');
					string tempCommandValue = commandValuePair[1].Replace("\"", "");
					F10Fov = int.Parse(tempCommandValue.Substring(4, tempCommandValue.Length - 4));
				}
				if (parameters[0].Equals("Name=\"F11\""))
				{
					F11assigned = true;
					string[] commandValuePair = parameters[1].Split('=');
					string tempCommandValue = commandValuePair[1].Replace("\"", "");
					F11Fov = int.Parse(tempCommandValue.Substring(4, tempCommandValue.Length - 4));
				}
			}

			return (F10assigned && F11assigned);
		}

		internal int? GetF10Fov()
		{
			return F10Fov;
		}

		internal int? GetF11Fov()
		{
			return F11Fov;
		}

		internal void SetKeyFov(string keyCode, int ang)
		{
			IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

			bool bingdingFound = false;

			foreach (ConfigEntry binding in bindings)
			{
				string tempValue = binding.value.Substring(1, binding.value.Length - 2);
				string[] parameters = tempValue.Split(',');

				if (parameters[0].Equals(string.Format("Name=\"{0}\"", keyCode)))
				{
					binding.value = string.Format(FOVTemplate, keyCode, ang);
					bingdingFound = true;
				}
			}

			if (!bingdingFound)
			{
				InputParser.AddSetting("WillowGame.WillowPlayerInput", "Bindings", string.Format(FOVTemplate, keyCode, ang), null);
			}
		}

		internal void RemoveBinding(string keyCode)
		{
			IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

			foreach (ConfigEntry binding in bindings)
			{
				string tempValue = binding.value.Substring(1, binding.value.Length - 2);
				string[] parameters = tempValue.Split(',');

				if (parameters[0].Equals(string.Format("Name=\"{0}\"", keyCode)))
				{
					InputParser.DeleteSetting("WillowGame.WillowPlayerInput", binding);
					break;
				}
			}
		}

		internal bool EnableMouseSmoothing
		{
			get
			{
				return bool.Parse(InputParser.GetSetting("Engine.PlayerInput", "bEnableMouseSmoothing", 0).value);
			}
			set
			{
				InputParser.SetSetting("Engine.PlayerInput", "bEnableMouseSmoothing", 0, value.ToString());
			}
		}

		internal bool Console
		{
			get
			{
				return InputParser.GetSetting("Engine.Console", "ConsoleKey", 0).value.Equals("Tilde");
			}
			set
			{
				if (value)
				{
					InputParser.SetSetting("Engine.Console", "ConsoleKey", 0, "Tilde");
				}
				else
				{
					InputParser.SetSetting("Engine.Console", "ConsoleKey", 0, "None");
				}
			}
		}

		internal bool SetF9ShowHud
		{
			get
			{
				IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

				foreach (ConfigEntry binding in bindings)
				{
					string tempValue = binding.value.Substring(1, binding.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("Name=\"F9\""))
					{
						return true;
					}
				}

				return false;
			}
			set
			{
				if (value == true && !SetF9ShowHud)
				{
					InputParser.AddSetting("WillowGame.WillowPlayerInput", "Bindings", "(Name=\"F9\",Command=\"showhud\",Control=False,Shift=False,Alt=False,LeftTrigger=False,RightTrigger=False,bIgnoreCtrl=False,bIgnoreShift=False,bIgnoreAlt=False)", null);
				}
				else if (value == false)
				{
					RemoveBinding("F9");
				}
			}
		}

		internal bool SetF12ShowFPS
		{
			get
			{
				IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

				foreach (ConfigEntry binding in bindings)
				{
					string tempValue = binding.value.Substring(1, binding.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("Name=\"F12\""))
					{
						return true;
					}
				}

				return false;
			}
			set
			{
				if (value == true && !SetF12ShowFPS)
				{
					InputParser.AddSetting("WillowGame.WillowPlayerInput", "Bindings", "(Name=\"F12\",Command=\"stat fps\",Control=False,Shift=False,Alt=False,LeftTrigger=False,RightTrigger=False,bIgnoreCtrl=False,bIgnoreShift=False,bIgnoreAlt=False)", null);
				}
				else if (value == false)
				{
					RemoveBinding("F12");
				}
			}
		}

		internal bool ZoomToggle
		{
			get
			{
				IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

				bool ZoomInassigned = false;
				bool ZoomOutassigned = false;

				foreach (ConfigEntry binding in bindings)
				{
					string tempValue = binding.value.Substring(1, binding.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("Name=\"ToggleAimOn\""))
					{
						ZoomInassigned = true;
					}
					if (parameters[0].Equals("Name=\"ToggleAimOff\""))
					{
						ZoomOutassigned = true;
					}
				}

				return (ZoomInassigned && ZoomOutassigned);
			}
			set
			{
				if (value == true && !ZoomToggle)
				{
					InputParser.AddSetting("WillowGame.WillowPlayerInput", "Bindings", "(Name=\"ToggleAimOn\",Command=\"advancedbutton bAdvancedButtonAux5 | OnRelease StartAltFire | setbind RightMouseButton ToggleAimOff\")", null);
					InputParser.AddSetting("WillowGame.WillowPlayerInput", "Bindings", "(Name=\"ToggleAimOff\",Command=\"advancedbutton bAdvancedButtonAux5 | OnRelease StopAltFire | setbind RightMouseButton ToggleAimOn\")", null);

					IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

					foreach (ConfigEntry binding in bindings)
					{
						string tempValue = binding.value.Substring(1, binding.value.Length - 2);
						string[] parameters = tempValue.Split(',');

						if (parameters[0].Equals("Name=\"RightMouseButton\""))
						{
							binding.value = "(Name=\"RightMouseButton\",Command=\"ToggleAimOn\")";
						}
					}
				}
				else if (value == false) 
				{
					IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

					foreach (ConfigEntry binding in bindings)
					{
						string tempValue = binding.value.Substring(1, binding.value.Length - 2);
						string[] parameters = tempValue.Split(',');

						if (parameters[0].Equals("Name=\"RightMouseButton\""))
						{
							binding.value = OrigZoomBind;
						}
					}

					RemoveBinding("ToggleAimOn");
					RemoveBinding("ToggleAimOff");
				}
			}
		}

		internal bool CrouchToggle
		{
			get
			{
				IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

				foreach (ConfigEntry binding in bindings)
				{
					string tempValue = binding.value.Substring(1, binding.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("Name=\"LeftControl\""))
					{
						string[] commandValuePair = parameters[1].Split('=');
						string commandValue = commandValuePair[1].Replace("\"", "");

						return commandValue.Equals(CrouchOriginalCommand);
					}
				}

				return false;
			}
			set
			{

				IList<ConfigEntry> bindings = InputParser.GetAllSettings("WillowGame.WillowPlayerInput", "Bindings");

				foreach (ConfigEntry binding in bindings)
				{
					string tempValue = binding.value.Substring(1, binding.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("Name=\"LeftControl\""))
					{
						if (value == true)
						{
							binding.value = string.Format(CrouchTemplate, CrouchOriginalCommand);
						}
						else
						{
							binding.value = string.Format(CrouchTemplate, CrouchToggleCommand);
						}
					}
				}
			}
		}

		internal bool ScrollWheel
		{
			get
			{
				IList<ConfigEntry> WidgetInputAliases = InputParser.GetAllSettings("Engine.UIInputConfiguration", "WidgetInputAliases");

				bool MouseScrollUpFlag = false;
				bool MouseScrollDownFlag = false;

				foreach (ConfigEntry widgetInputAlias in WidgetInputAliases)
				{
					string tempValue = widgetInputAlias.value.Substring(1, widgetInputAlias.value.Length - 2);
					string[] parameters = tempValue.Split(',');

					if (parameters[0].Equals("WidgetClassName=\"Engine.UIList\""))
					{
						MouseScrollUpFlag = !widgetInputAlias.value.Contains("InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42");
						MouseScrollDownFlag = !widgetInputAlias.value.Contains("InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42");
					}
					if (parameters[0].Equals("WidgetClassName=\"Engine.UIScrollFrame\""))
					{
						MouseScrollUpFlag = !widgetInputAlias.value.Contains("InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42");
						MouseScrollDownFlag = !widgetInputAlias.value.Contains("InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42");
					}
				}

				return (MouseScrollUpFlag && MouseScrollDownFlag);
			}
			set
			{
				IList<ConfigEntry> WidgetInputAliases = InputParser.GetAllSettings("Engine.UIInputConfiguration", "WidgetInputAliases");

				if (value == true)
				{
					foreach (ConfigEntry widgetInputAlias in WidgetInputAliases)
					{
						string tempValue = widgetInputAlias.value.Substring(1, widgetInputAlias.value.Length - 2);
						string[] parameters = tempValue.Split(',');

						if (parameters[0].Equals("WidgetClassName=\"Engine.UIList\""))
						{
							widgetInputAlias.value = widgetInputAlias.value.Replace("InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42", "InputKeyName=\"MouseScrollUp\"");
							widgetInputAlias.value = widgetInputAlias.value.Replace("InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42", "InputKeyName=\"MouseScrollDown\"");
						}
						if (parameters[0].Equals("WidgetClassName=\"Engine.UIScrollFrame\""))
						{
							widgetInputAlias.value = widgetInputAlias.value.Replace("InputKeyName=\"MouseScrollUp\",ModifierKeyFlags=42", "InputKeyName=\"MouseScrollUp\"");
							widgetInputAlias.value = widgetInputAlias.value.Replace("InputKeyName=\"MouseScrollDown\",ModifierKeyFlags=42", "InputKeyName=\"MouseScrollDown\"");
						}
					}
				}
				else if (value == false && ScrollWheel)
				{
					foreach (ConfigEntry widgetInputAlias in WidgetInputAliases)
					{
						string tempValue = widgetInputAlias.value.Substring(1, widgetInputAlias.value.Length - 2);
						string[] parameters = tempValue.Split(',');

						if (parameters[0].Equals("WidgetClassName=\"Engine.UIList\""))
						{
							widgetInputAlias.value = OrigUIListMouseLine;
						}
						if (parameters[0].Equals("WidgetClassName=\"Engine.UIScrollFrame\""))
						{
							widgetInputAlias.value = OrigUIScrollFrameMouseLine;
						}
					}
				}
			}
		}

		internal void Save()
		{
			//InputParser.CopyReplaceSection("WillowGame.WillowPlayerInput", "WillowGame.WillowPlayerInput");
			InputParser.SaveSettings();
		}
	}
}
