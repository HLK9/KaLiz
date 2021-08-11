using System;

using System.Windows.Forms;

namespace Kaliz
{
    public partial class BuildConfig : Telerik.WinControls.UI.RadForm
    {
        public string PascalOp { get; set; }
        string Mode_Pascal = " -Mfpc";
        public BuildConfig()
        {
            InitializeComponent();
           
          
            
        }

        private void CheckPascal_Click(object sender, EventArgs e)
        {
            Mode_Pascal = " -Mfpc";
            //CheckPascal.CheckState = CheckState.Unchecked;
            CheckDelphi7.CheckState = CheckState.Unchecked;
            CheckFPCMode.CheckState = CheckState.Unchecked;
            CheckISO7185.CheckState = CheckState.Unchecked;
            CheckMac.CheckState = CheckState.Unchecked;
            CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void CheckFPCMode_Click(object sender, EventArgs e)
        {
            Mode_Pascal = " -Mobjfpc";
            CheckPascal.CheckState = CheckState.Unchecked;
            CheckDelphi7.CheckState = CheckState.Unchecked;
           // CheckFPCMode.CheckState = CheckState.Unchecked;
            CheckISO7185.CheckState = CheckState.Unchecked;
            CheckMac.CheckState = CheckState.Unchecked;
            CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void CheckDelphi7_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Mode_Pascal = " -Mdelphi";
            CheckPascal.CheckState = CheckState.Unchecked;
            //CheckDelphi7.CheckState = CheckState.Unchecked;
            CheckFPCMode.CheckState = CheckState.Unchecked;
            CheckISO7185.CheckState = CheckState.Unchecked;
            CheckMac.CheckState = CheckState.Unchecked;
            CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void CheckMac_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Mode_Pascal = " -Mmacpas";
            CheckPascal.CheckState = CheckState.Unchecked;
            CheckDelphi7.CheckState = CheckState.Unchecked;
            CheckFPCMode.CheckState = CheckState.Unchecked;
            CheckISO7185.CheckState = CheckState.Unchecked;
            //CheckMac.CheckState = CheckState.Unchecked;
            CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void CheckISO7185_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Mode_Pascal = " -Miso";
            CheckPascal.CheckState = CheckState.Unchecked;
            CheckDelphi7.CheckState = CheckState.Unchecked;
            CheckFPCMode.CheckState = CheckState.Unchecked;
            //CheckISO7185.CheckState = CheckState.Unchecked;
            CheckMac.CheckState = CheckState.Unchecked;
            CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void CheckTPBP_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            Mode_Pascal = "- Mtp";
            CheckPascal.CheckState = CheckState.Unchecked;
            CheckDelphi7.CheckState = CheckState.Unchecked;
            CheckFPCMode.CheckState = CheckState.Unchecked;
            CheckISO7185.CheckState = CheckState.Unchecked;
            CheckMac.CheckState = CheckState.Unchecked;
            //CheckTPBP.CheckState = CheckState.Unchecked;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            foreach(var item in checklis.CheckedItems)
            {
                try
                {
                    switch (item.Text)
                    {
                        case "Show Error":
                            {
                               // if (!PascalOp.Contains("-ve"))
                                    PascalOp += " -ve";
                                break;
                            }
                        case "Show hints":
                            {

                                //if (!PascalOp.Contains(" -vh"))
                                    PascalOp += " -vh";
                                break;
                            }
                        case "Show warnings":
                            {

                                //if (!PascalOp.Contains(" -vw"))
                                    PascalOp += " -vw";
                                break;
                            }
                        case "Show notes":
                            {

                                //if (!PascalOp.Contains(" -vn"))
                                    PascalOp += " -vn";
                                break;
                            }
                        case "Show general info":
                            {

                                //if (!PascalOp.Contains(" -vi"))
                                    PascalOp += " -vi";
                                break;
                            }
                        case "Show linenumbers":
                            {

                                //if (!PascalOp.Contains(" -vl"))
                                    PascalOp += " -vl";
                                break;
                            }
                        case "Show everything":
                            {

                                //if (!PascalOp.Contains(" -va"))
                                    PascalOp += " -va";
                                break;
                            }
                        case "Show debug info":
                            {

                                //if (!PascalOp.Contains(" -vd"))
                                    PascalOp += " -vd";
                                break;
                            }
                        case "Level 1  Optimizations":
                            {

                                //if (!PascalOp.Contains(" -O1"))
                                    PascalOp += " -O1";
                                break;
                            }
                        case "Level 2  Optimizations":
                            {

                               // if (!PascalOp.Contains("-O2"))
                                    PascalOp += " -O2";
                                break;
                            }
                        case "Level 3  Optimizations":
                            {

                                //if (!PascalOp.Contains("-O3"))
                                    PascalOp += " -O3";
                                break;
                            }
                        case "Level 4  Optimizations":
                            {

                                //if (!PascalOp.Contains("-O4"))
                                    PascalOp += " -O4";
                                break;
                            }
                        default:
                            {
                                PascalOp = string.Empty;
                                break;
                            }
                    }
                }
                catch { }
               
            }
            //ra khoi switch
            PascalOp += Mode_Pascal;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
