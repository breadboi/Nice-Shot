using System;
using TwitchPlaysSharp.Utilities;

namespace RLGO
{
    public class MacroKeyPress
    {
        //static IRCBot Bot;
        static MacroKeys mk = new MacroKeys();

        public void keyInput(string teamKey, double secAfter, double transLength, double btwTrans, string transKey, string mainKey)
        {
            mk.BuildKeyList();

            /*Check that these are all valid keys*/
            if(mk.IsValidKey(teamKey) && mk.IsValidKey(transKey) && mk.IsValidKey(mainKey))
            {                
                System.Threading.Thread.Sleep(Convert.ToInt32(secAfter*1000));  //Wait user specified time after goal.
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(teamKey); //Macro for team color scene
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength*1000));   //Wait the length of the transition animation
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(transKey);    //Macro for middle scene
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(btwTrans*1000));  //Wait length of replay cam
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(teamKey); //Macro for team scene again
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength * 1000)); //Wait length of transition animation
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(mainKey);    //Macro for main scene
                }
            }
        }        
    }
}
