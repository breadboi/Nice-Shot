using TwitchPlaysSharp.Utilities;

namespace RLGO
{
    public class MacroKeyPress
    {
        //static IRCBot Bot;
        static MacroKeys mk = new MacroKeys();

        public void keyInput(string key)
        {
            mk.BuildKeyList();

            if(mk.IsValidKey(key))
            {
                /*Attempt to press the key multiple times in case a user presses a key during the process*/
                mk.DoKeypress(key);
                mk.DoKeypress(key);
                mk.DoKeypress(key);
                mk.DoKeypress(key);
                mk.DoKeypress(key);
                mk.DoKeypress(key);
                System.Threading.Thread.Sleep(3000);    //Wait 3 sec
                mk.DoKeypress("0");
                mk.DoKeypress("0");
                mk.DoKeypress("0");
                mk.DoKeypress("0");
                mk.DoKeypress("0");
                mk.DoKeypress("0");
            }
        }        
    }
}
