using System;
using System.Configuration;
using System.Windows.Forms;
using NationalInstruments.VeriStand.ClientAPI;
using NationalInstruments.VeriStand;

namespace MacroPlayer
{
    class Play_NIVS_Macro
    {

        static void Main(string[] args)
        {
            try
            {
                Factory FacRef = new Factory();
                PlayModeEnum TimingSetting;
                IMacroPlayer MyPlayer = FacRef.GetIMacroPlayer(ConfigurationManager.AppSettings["Gateway"]);

                MyPlayer.OnMacroErrorMessage += new DOnMacroErrorMessage(MyPlayer_OnMacroErrorMessage);

                string PlayWithTiming = ConfigurationManager.AppSettings["PlayWithTiming?"];

                if (PlayWithTiming.ToLower() == "true")
                    TimingSetting = PlayModeEnum.UseTiming;
                else
                    TimingSetting = PlayModeEnum.IgnoreTiming;

                ErrChk(MyPlayer.LoadMacro(args[0]));
                ErrChk(MyPlayer.PlayMacro(TimingSetting));
                ErrChk(MyPlayer.Wait());
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error Playing Macro");
            }
        }

        private static void MyPlayer_OnMacroErrorMessage(uint code, string message)
        {
            if (MessageBox.Show("Error Code: " + String.Format("{0:X}", code) + "\n\n" + message + "Quit playback due to error?", "Error Playing Macro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Environment.Exit(0);
        }

        private static void ErrChk(Error error)
        {
            if (error.IsError)
                throw new Exception(String.Format("{0:X}", error.Code) + ": " + error.Message);
        }

    }
}