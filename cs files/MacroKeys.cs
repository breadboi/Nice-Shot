using System.Collections.Generic;
using TwitchPlaysSharp.Utilities.Windows;
using SysTimers = System.Timers;

namespace TwitchPlaysSharp.Utilities
{
    public class MacroKeys
    {
        //Keys
        List<TimeoutKey> Cooldowns = new List<TimeoutKey>();
        Dictionary<string, byte> MappedKeys = new Dictionary<string, byte>();
        List<string> LimitedKeys = new List<string>();

        public void BuildKeyList()
        {
            LimitedKeys = new List<string>();
                      
            MappedKeys["1"] = Key.Num1;
            MappedKeys["2"] = Key.Num2;
            MappedKeys["3"] = Key.Num3;
            MappedKeys["4"] = Key.Num4;
            MappedKeys["5"] = Key.Num5;
            MappedKeys["6"] = Key.Num6;
            MappedKeys["7"] = Key.Num7;
            MappedKeys["8"] = Key.Num8;
            MappedKeys["9"] = Key.Num9;
            MappedKeys["0"] = Key.Num0;
            MappedKeys["-"] = Key.DashHyphonKey;
            MappedKeys["="] = Key.PlusEqualsKey;

            MappedKeys["num1"] = Key.Numpad1;
            MappedKeys["num2"] = Key.Numpad2;
            MappedKeys["num3"] = Key.Numpad3;
            MappedKeys["num4"] = Key.Numpad4;
            MappedKeys["num5"] = Key.Numpad5;
            MappedKeys["num6"] = Key.Numpad6;
            MappedKeys["num7"] = Key.Numpad7;
            MappedKeys["num8"] = Key.Numpad8;
            MappedKeys["num9"] = Key.Numpad9;
            MappedKeys["num0"] = Key.Numpad0;
        }

        bool IsLimitedKey(string key)
        {
            return LimitedKeys.Contains(key);
        }

        public bool IsValidKey(string key)
        {
            return MappedKeys.ContainsKey(key);
        }

        public void HandleKey(string key)
        {
            if (!IsLimitedKey(key))
            {
                DoKeypress(key);
            }            
        }

        public void DoKeypress(string key)
        {
            if (IsValidKey(key))
            {
                WinAPI.PressKey(MappedKeys[key]);
            }
        }        
    }

    public class TimeoutKey
    {
        public string Key; //will hold the item
        SysTimers.Timer TimeoutTimer; //will handle the expiry
        List<TimeoutKey> RefofMainList; //will be used to remove the item once it is expired

        public TimeoutKey(string key, int milisec, List<TimeoutKey> refOfList)
        {
            RefofMainList = refOfList;
            Key = key;
            TimeoutTimer = new SysTimers.Timer(milisec);
            TimeoutTimer.Elapsed += new SysTimers.ElapsedEventHandler(Elapsed_Event);
            TimeoutTimer.Start();
        }

        private void Elapsed_Event(object sender, SysTimers.ElapsedEventArgs e)
        {
            TimeoutTimer.Elapsed -= new SysTimers.ElapsedEventHandler(Elapsed_Event);
            RefofMainList.Remove(this);
        }
    }
}
