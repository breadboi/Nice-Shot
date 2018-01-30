using System;
using TwitchPlaysSharp.Utilities;

namespace RLGO
{
    public class MacroKeyPress
    {
        //static IRCBot Bot;
        static MacroKeys mk = new MacroKeys();

        public void keyInput(string transOne, double bufferStart, double transLength, double replayLength, string transTwo, string transThree, string mainScene)
        {
            mk.BuildKeyList();

            /*Check that these are all valid keys*/
            if(mk.IsValidKey(transOne) && mk.IsValidKey(transTwo) && mk.IsValidKey(transThree) && mk.IsValidKey(mainScene))
            {                
                System.Threading.Thread.Sleep(Convert.ToInt32(bufferStart*1000));  //Wait user specified time after goal.
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(transOne); //Key for First Transition
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength*1000));   //Wait the length of the transition animation
                for(int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(transTwo);    //Key for Second Transition
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(replayLength*1000));  //Wait length of replay cam
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(transThree); //Key for thrid Transition
                }
                System.Threading.Thread.Sleep(Convert.ToInt32(transLength * 1000)); //Wait length of transition animation
                for (int x = 0; x < 6; x++)
                {
                    mk.DoKeypress(mainScene);    //Key for Main scene
                }
            }
        }        
    }
}
