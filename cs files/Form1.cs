using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Memory;

namespace RLGO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Runs Background worker so that ui is responsive.
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }
        // Creates a new Memory reader/writer object using a library called memory.dll which can be found here: https://github.com/erfg12/memory.dll/wiki
        public Mem m = new Mem();
        // Creates a new object which stores a your lifx token and a memory pointer to each goal.
        public RLGameSettings rlgs = new RLGameSettings();
        // Sets each goals value to -2(having it at 0 or - 1 causes problems if there is already 1 or 0 goals on either side).
        public int BlueGoals = -2;
        public int OrangeGoals = -2;
        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                int pID = m.getProcIDFromName("RocketLeague"); // Get proc ID of game

                bool openProc = false; //Is process open?

                if (pID > 0) //Try opening process
                {
                    openProc = m.OpenProcess("RocketLeague");
                    label2.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = pID.ToString();
                    });
                } else
                {
                    label2.Invoke((MethodInvoker)delegate
                    {
                        label2.Text = "#";
                    });
                }

                if (openProc) //Run if Rocket League is Open
                {
                    // Display in the ui of the program that Rocket League is Open.
                    label4.Invoke((MethodInvoker)delegate
                    {
                        label4.Text = "Open";
                        label4.ForeColor = Color.Green;
                    });

                    // Displays in the programs ui the amount of goals that orange currently have.
                    label6.Invoke((MethodInvoker)delegate
                    {
                        label6.Text = m.readInt(rlgs.orangeGoalPointer).ToString();
                    });
                    // Displays in the programs ui the amount of goals that blue currently have.
                    label8.Invoke((MethodInvoker)delegate
                    {
                        label8.Text = m.readInt(rlgs.blueGoalPointer).ToString();
                    });

                    //If amount of goals on blue team + 1 = memory reading of blue goals run this code (Runs if blue scores).
                    if (BlueGoals + 1 == m.readInt(rlgs.blueGoalPointer))
                    {
                        try
                        {
                            string s1 = textBox1.Text.ToLower();
                            double bufferToStart = Convert.ToDouble(textBox3.Text);
                            double transLength = Convert.ToDouble(textBox4.Text);
                            double replayTime = Convert.ToDouble(textBox5.Text);
                            string s3 = textBox8.Text.ToLower();
                            string mainScene = textBox6.Text.ToLower();
                            if (checkBox1.Checked)
                            {
                                string s2 = textBox7.Text.ToLower();
                                //Send the desired key to be pressed for this event
                                Macro(s1, bufferToStart, transLength, replayTime, s2, s3, mainScene);
                            }
                            else
                            {
                                string s2 = textBox6.Text.ToLower();
                                //Send the desired key to be pressed for this event
                                Macro(s1, bufferToStart, transLength, replayTime, s2, s3, mainScene);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("You most likely left a field blank.\n\nError: " + ex);
                        }
                    }
                    //If amount of goals on orange team + 1 = memory reading of blue goals run this code (Runs if orange scores).
                    if (OrangeGoals + 1 == m.readInt(rlgs.orangeGoalPointer))
                    {
                        try
                        {
                            string s1 = textBox1.Text.ToLower();
                            double bufferToStart = Convert.ToDouble(textBox3.Text);
                            double transLength = Convert.ToDouble(textBox4.Text);
                            double replayTime = Convert.ToDouble(textBox5.Text);
                            string s3 = textBox8.Text.ToLower();
                            string mainScene = textBox6.Text.ToLower();
                            if (checkBox1.Checked)
                            {
                                string s2 = textBox7.Text.ToLower();
                                //Send the desired key to be pressed for this event
                                Macro(s1, bufferToStart, transLength, replayTime, s2, s3, mainScene);
                            }
                            else
                            {
                                string s2 = textBox6.Text.ToLower();
                                //Send the desired key to be pressed for this event
                                Macro(s1, bufferToStart, transLength, replayTime, s2, s3, mainScene);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("You most likely left a field blank.\n\nError: " + ex);
                        }
                    }

                    //Set goal variables = memory reading of each goal.
                    BlueGoals = m.readInt(rlgs.blueGoalPointer);
                    OrangeGoals = m.readInt(rlgs.orangeGoalPointer);

                } else // Runs if Rocket League is Closed.
                {
                    // Display in the ui of the program that Rocket League is Closed.
                    label4.Invoke((MethodInvoker)delegate
                    {
                        label4.Text = "Closed";
                        label4.ForeColor = Color.DarkRed;
                    });
                }
            }
        }
        public void Macro(string transOne, double bufferStart, double transLength, double replayLength, string transTwo, string transThree, string mainScene)
        {
            MacroKeyPress mcp = new MacroKeyPress();
            mcp.keyInput(transOne, bufferStart, transLength, replayLength, transTwo, transThree, mainScene);
        }
        public class RLGameSettings
        {            
            // Pointer to each goal in the memory.
            public string blueGoalPointer = "base+0x019CBB24,0xAC,0x294,0x4DC,0x0,0x20C";
            public string orangeGoalPointer = "base+0x019CBB24,0xAC,0x294,0x4DC,0x4,0x20C";

        }

    }
}
