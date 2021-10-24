using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Howick_Interview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Global.machineState.initialize();
            Global.machineState.do_action();
            print_labels(vel_label, state_label, SW_label);

        }



        public interface IState
        {
            IState compare_control(MachineState machineState);
            void do_action(MachineState machineState);
            IState fault_react(MachineState machineState);
        }
        public class Global
        {
            public static Regex regex = new Regex("[0-1]{16}");
            public static UInt16 CW;
            public static MachineState machineState = new MachineState();
            public static UInt16 vel_desired;
            public static UInt16 vel_out;
            public static UInt16 sw_lbl;
            public static string st_lbl;
            public static bool fault_flag = false;
        }

        public class MachineState
        {
            private IState currentState;
            public IState State
            {
                set { currentState = value; }
            }
            private ushort statusWord;
            public ushort StatusWord
            {
                get { return statusWord; }
                set { statusWord = value; }
            }
            public void initialize()
            {
                currentState = startState;
                Global.machineState.compare_control();
                Global.machineState.compare_control();
            }
            public void compare_control()
            {
                currentState = currentState.compare_control(this);
            }

            public void do_action()
            {
                currentState.do_action(this);
            }

            public void fault_react()
            {
                currentState.fault_react(this);
            }

            public StartState startState = new StartState();
            public NotReadyOn notReadyOn = new NotReadyOn();
            public SwOnDisabled swOnDisabled = new SwOnDisabled();
            public ReadySwOn readySwOn = new ReadySwOn();
            public SwOn swOn = new SwOn();
            public OpEnabled opEnabled = new OpEnabled();
            public QckStopActive qckStopActive = new QckStopActive();
            public FaultRActive faultRActive = new FaultRActive();
            public Fault fault = new Fault();

        }

        public class StartState : IState
        {
            
            public IState compare_control(MachineState machineState)
            {
            
                if (true)
                {
                    // Next State
                    Console.WriteLine("Power-on, self-initialization");
                    machineState.StatusWord = 0b0000000000000000;
                    return machineState.notReadyOn;
                    
                }
            }
            public void do_action(MachineState machineState) { }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }

        }

        public class NotReadyOn : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (true)
                {
                    Console.WriteLine("Initialized Successfully");
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;
                    
                }
                
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Not Ready to Switch On";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }

        public class SwOnDisabled : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                UInt16 mask = 0b0000000000000111;
                if ((Global.CW & mask) == 0b0000000000000110)
                {
                    Console.WriteLine("Ready To Switch On");
                    machineState.StatusWord = 0b0000000000010001;
                    return machineState.readySwOn;

                }
                else
                {
                    return machineState.swOnDisabled;
                }
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Switch On Disabled";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }

        public class ReadySwOn : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                UInt16 mask = 0b0000000000000111;
                UInt16 mask2 = 0b0000000000000110;
                UInt16 mask3 = 0b0000000000000010;
                if ((Global.CW & mask) == 0b0000000000000111)
                {
                    Console.WriteLine("Switched On");
                    machineState.StatusWord = 0b0000000000100011;
                    return machineState.swOn;

                }
                else if ((Global.CW & mask2) == 0b0000000000000010 || (Global.CW & mask3) == 0b0000000000000000)
                {
                    Console.WriteLine("Switch On Disabled");
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;
                }
                else
                {
                    return machineState.readySwOn;
                }
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Ready to Switch On";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }

        public class SwOn : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                UInt16 mask = 0b0000000000000110;
                UInt16 mask2 = 0b0000000000001111;
                UInt16 mask3 = 0b0000000000000110;
                UInt16 mask4 = 0b0000000000000010;
                if ((Global.CW & mask2) == mask2)
                {
                    Console.WriteLine("Operation Enabled");
                    machineState.StatusWord = 0b0000000000100111;
                    return machineState.opEnabled;

                }
                else if ((Global.CW & mask3) == 0b0000000000000010 || (Global.CW & mask4) == 0b0000000000000000)
                {
                    Console.WriteLine("Switch On Disabled");
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;
                }
                else if ((Global.CW & mask)  == 0b0000000000000110)
                {
                    Console.WriteLine("Ready to Switch On");
                    machineState.StatusWord = 0b0000000000100001;
                    return machineState.readySwOn;
                }

                else
                {
                    return machineState.swOn;
                }
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Switched On";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }

        public class OpEnabled : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }

                UInt16 mask = 0b0000000000000010;
                UInt16 mask2 = 0b0000000000001111;
                UInt16 mask3 = 0b0000000000000110;
                if ((Global.CW & mask) == 0)
                {
                    Console.WriteLine("Switch On Disabled");
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;

                }
                else if ((Global.CW & mask3) == 0b0000000000000010)
                {
                    Console.WriteLine("Quick Stop Active");
                    machineState.StatusWord = 0b0000000000000111;
                    return machineState.qckStopActive;
                }
                else if ((Global.CW & mask2) == mask2 >> 1)
                {
                    Console.WriteLine("Switched On");
                    machineState.StatusWord = 0b0000000000100011;
                    return machineState.swOn;
                }

                else
                {
                    return machineState.opEnabled;
                }
            }
            public void do_action(MachineState machineState) 
            {
                Global.vel_out = Global.vel_desired;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Operation Enabled";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }


        public class QckStopActive : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                UInt16 mask = 0b0000000000000010;
                if ((Global.CW & mask) == 0)
                {
                    Console.WriteLine("Switch On Disabled");
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;

                }
                else
                {
                    return machineState.qckStopActive;
                }
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Quick Stop Active";
            }
            public IState fault_react(MachineState machineState)
            {
                return machineState.faultRActive;
            }
        }

        public class FaultRActive : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                else
                {
                    Console.WriteLine("correct");
                    machineState.StatusWord = 0b0000000000001000;
                    return machineState.fault;
                }
                
            }
            public void do_action(MachineState machineState)
            {
                machineState.StatusWord = 0b0000000000001111;
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Fault Reaction Active";
            }
            public IState fault_react(MachineState machineState)
            {
                if (!Global.fault_flag)
                {
                    return machineState.fault;
                }
                return machineState.faultRActive;
            }
        }

        public class Fault : IState
        {
            public IState compare_control(MachineState machineState)
            {
                if (Global.fault_flag)
                {
                    return machineState.faultRActive;
                }
                UInt16 mask = 0b0000000010000000;
                if ((Global.CW & mask) == mask)
                {
                    machineState.StatusWord = 0b0000000001000000;
                    return machineState.swOnDisabled;

                }
                else
                {
                    return machineState.fault;
                }
            }
            public void do_action(MachineState machineState)
            {
                Global.vel_out = 0;
                Global.sw_lbl = machineState.StatusWord;
                Global.st_lbl = "Fault";
            }
            public IState fault_react(MachineState machineState)
            {
                    return machineState.faultRActive;
                
            }
        }

        //--------------------------------------------------------------------------//
        private void print_labels(Label vel_lbl, Label st_label, Label sw_label)
        {
            //vel_lbl.Text = Convert.ToString(Global.vel_out, 2);
            st_label.Text = Global.st_lbl;
            //sw_label.Text = Convert.ToString(Global.sw_lbl, 2); 
            vel_lbl.Text = converting_labels(Global.vel_out);
            sw_label.Text = converting_labels(Global.sw_lbl);
        }


        public String converting_labels(UInt16 value)
        {
            String binaryString = Convert.ToString(value, 2);
            return binaryString.PadLeft(16, '0');
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void CW_input_TextChanged(object sender, EventArgs e)
        {
            // Extracting Control Word
            Global.machineState.do_action();
            if (Global.regex.IsMatch(CW_input.Text))
            {
                Global.CW = Convert.ToUInt16(CW_input.Text, 2);
            }
            Global.machineState.compare_control();
            Global.machineState.do_action();
            print_labels(vel_label, state_label, SW_label);
        }

        private void CW_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            
        }

        private void vel_input_TextChanged(object sender, EventArgs e)
        {
            // Extracting Desired Motor Velocity
            Global.machineState.do_action();
            if (Global.regex.IsMatch(vel_input.Text))
            {
                Global.vel_desired = Convert.ToUInt16(vel_input.Text, 2);
            }
            Global.machineState.compare_control();
            Global.machineState.do_action();
            print_labels(vel_label, state_label, SW_label);
        }

        private void FR_Active_Click(object sender, EventArgs e)
        {
            // Fault Reaction Active buttion click -> move to FR state
            Global.fault_flag = true;
            Global.machineState.compare_control();
            Global.machineState.do_action();
            print_labels(vel_label, state_label, SW_label);

        }

        private void FR_complete_Click(object sender, EventArgs e)
        {
            // Fault Reaction Complete button click -> move to Fault State
            Global.fault_flag = false;
            Global.machineState.compare_control();
            Global.machineState.do_action();
            print_labels(vel_label, state_label, SW_label);
        }

    }

}






