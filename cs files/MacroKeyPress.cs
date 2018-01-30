using System;
using TwitchPlaysSharp.Utilities;

namespace RLGO
{
    public class MacroKeyPress
    {
        //static IRCBot Bot;
        static MacroKeys mk = new MacroKeys();

        public void keyInput(string key, double secAfter, double transLength, double btwTrans, string rKey)
        {
            mk.BuildKeyList();

            if(mk.IsValidKey(key))
            {                
                System.Threading.Thread.Sleep(Convert.ToInt32(secAfter*1000)); //wait 1 sec
                /*Attempt to press the key multiple times in case a user presses a key during the process*/
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(key);
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength*1000));    //Wait 3 sec
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(rKey);
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(btwTrans*1000));
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(key);
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength * 1000));
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(rKey);
                }
            }
        }        
    }
}
