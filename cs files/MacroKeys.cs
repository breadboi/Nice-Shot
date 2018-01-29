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
            LimitedKeys.Add("start");


            MappedKeys["ctrl"] = Key.ControlLeft;
            MappedKeys["0"] = Key.Num0;            
            MappedKeys["-"] = Key.DashHyphonKey;
            MappedKeys["="] = Key.PlusEqualsKey;   

            MappedKeys["enter"] = Key.Enter;
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
