# niceshot
##Configuration
1. Open the MacroKeys.cs file.
2. In the BuildKeyList method, you want to type MappedKeys["Your desired keyname"] = Key.keyname; 
   Available keynames are listed in WinAPI.cs so just type Key.anything that exists in that file. Example: Key.Backspace
3. Open MacroKeyPress.cs and in the keyInput method, you can code how you want your macro to work. By default I have it so it presses the    desired key 5 times to ensure it is pressed. After this, it waits 3 seconds until it presses the key to go back to the default scene.      The value you put inside the mk.DoKeypress("Your desired keyname"), is the name you gave MappedKeys above in quotes. You can hard code    this in or use the key input parameter called key.
4. In Form1.cs, find the below sections 
  if (BlueGoals + 1 == m.readInt(rlgs.blueGoalPointer))
  if (OrangeGoals + 1 == m.readInt(rlgs.orangeGoalPointer))
5. In these if statements, type Macro("Your desired keyname"); This will type the desired key for the desired goal.
