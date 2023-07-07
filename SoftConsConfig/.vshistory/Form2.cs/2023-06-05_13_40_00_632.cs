using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;



namespace SoftConsConfig
{
    public partial class Form2 : Form
    {

        private static string SetValue;
        private static bool errore = false;
        private static string titolo = "SoftConsole Configurator  ";
      
        public Form2()
        {
            InitializeComponent();
        }
        [STAThread]
        private static void Main()
        {
         
                //ApplicationConfiguration.Initialize();
                Application.Run(new Form2()); 
        }

        public static void SetModofila()
        {
            try
            {
                Directory.Delete("c:\\wnc\\home\\d_xnc\\dati\\validated", true);
                File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Errore nella cancellazione di files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool flag = !File.Exists("c:\\wnc\\home\\d_xnc\\dati\\plctab");
            if (!flag)
            {
                File.Copy("c:\\wnc\\home\\d_xnc\\dati\\plctab", "c:\\wnc\\home\\d_xnc\\dati\\plctab_old", false);
                File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab");
                FileInfo fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
                StreamReader streamReader = fileInfo.OpenText();

                StreamWriter streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\plctab");
                string text = "";
                try
                {
                    string text2;
                    do
                    {
                        text2 = streamReader.ReadLine();
                        bool flag2 = text2 == null;
                        if (flag2)
                        {
                            break;
                        }
                        bool flag3 = text2.IndexOf("[") != -1;
                        if (flag3)
                        {
                            text = text2;
                        }
                        bool FF1 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT008") != -1;
                        if (FF1)
                        {
                            text2 = "ModoFila=1";
                            streamWriter.WriteLine(text2);
                        }
                        else
                        {
                            bool FF2 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT009") != -1;
                            if (FF2)
                            {
                                text2 = "ModoFila=1";
                                streamWriter.WriteLine(text2);
                            }
                            else
                            {
                                bool FF3 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT010") != -1;
                                if (FF3)
                                {
                                    text2 = "ModoFila=1";
                                    streamWriter.WriteLine(text2);
                                }
                                else
                                {
                                    bool FF4 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT011") != -1;
                                    if (FF4)
                                    {
                                        text2 = "ModoFila=1";
                                        streamWriter.WriteLine(text2);
                                    }
                                    else
                                    {
                                        streamWriter.WriteLine(text2);
                                    }

                                }
                            }
                        }
                        #region
                        //else
                        //{
                        //    bool flag5 = text2.IndexOf("SoftCons=") != -1;
                        //    if (flag5)
                        //    {
                        //        text2 = "SoftCons=1";
                        //        streamWriter.WriteLine(text2);
                        //    }
                        //    else
                        //    {
                        //        bool flag6 = Form1.simulazBsolid;
                        //        if (flag6)
                        //        {
                        //            bool flag7 = text2.IndexOf("SimulazGrafica=") != -1;
                        //            if (flag7)
                        //            {
                        //                text2 = "SimulazGrafica=1";
                        //                streamWriter.WriteLine(text2);
                        //                return;
                        //            }
                        //        }
                        //        else
                        //        {
                        //            bool flag8 = text2.IndexOf("SimulazGrafica=") != -1;
                        //            if (flag8)
                        //            {
                        //                text2 = "SimulazGrafica=0";
                        //                streamWriter.WriteLine(text2);
                        //                return;
                        //            }
                        //        }
                        //        bool flag9 = text2.IndexOf("I_Start=") != -1;
                        //        if (flag9)
                        //        {
                        //            text2 = "I_Start=17";
                        //            streamWriter.WriteLine(text2);
                        //        }
                        //        else
                        //        {
                        //            bool flag10 = text2.IndexOf("O_Start=") != -1;
                        //            if (flag10)
                        //            {
                        //                text2 = "O_Start=17";
                        //                streamWriter.WriteLine(text2);
                        //            }
                        //            else
                        //            {
                        //                bool flag11 = text2.IndexOf("I_Stop=") != -1;
                        //                if (flag11)
                        //                {
                        //                    text2 = "I_Stop=18";
                        //                    streamWriter.WriteLine(text2);
                        //                }
                        //                else
                        //                {
                        //                    bool flag12 = text2.IndexOf("I_Reset=") != -1;
                        //                    if (flag12)
                        //                    {
                        //                        text2 = "I_Reset=19";
                        //                        streamWriter.WriteLine(text2);
                        //                    }
                        //                    else
                        //                    {
                        //                        bool flag13 = text2.IndexOf("I_Clear=") != -1;
                        //                        if (flag13)
                        //                        {
                        //                            text2 = "I_Clear=20";
                        //                            streamWriter.WriteLine(text2);
                        //                        }
                        //                        else
                        //                        {
                        //                            bool flag14 = text2.IndexOf("I_Jogmen=") != -1;
                        //                            if (flag14)
                        //                            {
                        //                                text2 = "I_Jogmen=21";
                        //                                streamWriter.WriteLine(text2);
                        //                            }
                        //                            else
                        //                            {
                        //                                bool flag15 = text2.IndexOf("I_Jogfas=") != -1;
                        //                                if (flag15)
                        //                                {
                        //                                    text2 = "I_Jogfas=-1";
                        //                                    streamWriter.WriteLine(text2);
                        //                                }
                        //                                else
                        //                                {
                        //                                    bool flag16 = text2.IndexOf("I_Jogpiu=") != -1;
                        //                                    if (flag16)
                        //                                    {
                        //                                        text2 = "I_Jogpiu=22";
                        //                                        streamWriter.WriteLine(text2);
                        //                                    }
                        //                                    else
                        //                                    {
                        //                                        bool flag17 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST012") != -1;
                        //                                        if (flag17)
                        //                                        {
                        //                                            text2 = "Abil=2";
                        //                                            streamWriter.WriteLine(text2);
                        //                                        }
                        //                                        else
                        //                                        {
                        //                                            bool flag18 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST013") != -1;
                        //                                            if (flag18)
                        //                                            {
                        //                                                text2 = "Abil=2";
                        //                                                streamWriter.WriteLine(text2);
                        //                                            }
                        //                                            else
                        //                                            {
                        //                                                bool flag19 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST014") != -1;
                        //                                                if (flag19)
                        //                                                {
                        //                                                    text2 = "Abil=2";
                        //                                                    streamWriter.WriteLine(text2);
                        //                                                }
                        //                                                else
                        //                                                {
                        //                                                    bool flag20 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST015") != -1;
                        //                                                    if (flag20)
                        //                                                    {
                        //                                                        text2 = "Abil=2";
                        //                                                        streamWriter.WriteLine(text2);
                        //                                                    }
                        //                                                    else
                        //                                                    {
                        //                                                        bool flag21 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE000") != -1;
                        //                                                        if (flag21)
                        //                                                        {
                        //                                                            text2 = "Abil=0";
                        //                                                            streamWriter.WriteLine(text2);
                        //                                                        }
                        //                                                        else
                        //                                                        {
                        //                                                            bool flag22 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE001") != -1;
                        //                                                            if (flag22)
                        //                                                            {
                        //                                                                text2 = "Abil=0";
                        //                                                                streamWriter.WriteLine(text2);
                        //                                                            }
                        //                                                            else
                        //                                                            {
                        //                                                                bool flag23 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE002") != -1;
                        //                                                                if (flag23)
                        //                                                                {
                        //                                                                    text2 = "Abil=0";
                        //                                                                    streamWriter.WriteLine(text2);
                        //                                                                }
                        //                                                                else
                        //                                                                {
                        //                                                                    bool flag24 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE003") != -1;
                        //                                                                    if (flag24)
                        //                                                                    {
                        //                                                                        text2 = "Abil=0";
                        //                                                                        streamWriter.WriteLine(text2);
                        //                                                                    }
                        //                                                                    else
                        //                                                                    {
                        //                                                                        bool flag25 = false;
                        //                                                                        for (int i = 1; i <= 16; i++)
                        //                                                                        {
                        //                                                                            string text3 = "TAST";
                        //                                                                            bool flag26 = i < 11;
                        //                                                                            if (flag26)
                        //                                                                            {
                        //                                                                                text3 = text3 + "00" + (i - 1).ToString();
                        //                                                                            }
                        //                                                                            else
                        //                                                                            {
                        //                                                                                text3 = text3 + "0" + (i - 1).ToString();
                        //                                                                            }
                        //                                                                            bool flag27 = text2.IndexOf("I_LEDpc=") != -1 && text.IndexOf(text3) != -1;
                        //                                                                            if (flag27)
                        //                                                                            {
                        //                                                                                text2 = "I_LEDpc=" + i.ToString();
                        //                                                                                streamWriter.WriteLine(text2);
                        //                                                                                flag25 = true;
                        //                                                                                break;
                        //                                                                            }
                        //                                                                            bool flag28 = text2.IndexOf("O_LEDpc=") != -1 && text.IndexOf(text3) != -1;
                        //                                                                            if (flag28)
                        //                                                                            {
                        //                                                                                text2 = "O_LEDpc=" + i.ToString();
                        //                                                                                streamWriter.WriteLine(text2);
                        //                                                                                flag25 = true;
                        //                                                                                break;
                        //                                                                            }
                        //                                                                            text3 = "TASTIPLC";
                        //                                                                            bool flag29 = i <= 10;
                        //                                                                            if (flag29)
                        //                                                                            {
                        //                                                                                text3 = text3 + "00" + (i - 1).ToString();
                        //                                                                            }
                        //                                                                            else
                        //                                                                            {
                        //                                                                                text3 = text3 + "0" + (i - 1).ToString();
                        //                                                                            }
                        //                                                                            bool flag30 = text2.IndexOf("I_LEDpc=") != -1 && text.IndexOf(text3) != -1;
                        //                                                                            if (flag30)
                        //                                                                            {
                        //                                                                                text2 = "I_LEDpc=" + i.ToString();
                        //                                                                                streamWriter.WriteLine(text2);
                        //                                                                                flag25 = true;
                        //                                                                                break;
                        //                                                                            }
                        //                                                                            bool flag31 = text2.IndexOf("O_LEDpc=") != -1 && text.IndexOf(text3) != -1;
                        //                                                                            if (flag31)
                        //                                                                            {
                        //                                                                                text2 = "O_LEDpc=" + i.ToString();
                        //                                                                                streamWriter.WriteLine(text2);
                        //                                                                                flag25 = true;
                        //                                                                                break;
                        //                                                                            }
                        //                                                                        }
                        //                                                                        bool flag32 = flag25;
                        //                                                                        if (!flag32)
                        //                                                                        {
                        //                                                                            streamWriter.WriteLine(text2);
                        //                                                                        }
                        //                                                                    }
                        //                                                                }
                        //                                                            }
                        //                                                        }
                        //                                                    }
                        //                                                }
                        //                                            }
                        //                                        }
                        //                                    }
                        //                                }
                        //                            }
                        //                        }
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        #endregion
                    }
                    while (text2 != null);
                    streamReader.Close();
                    streamWriter.Close();
                    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, Form2.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Form2.errore = true;
                }
            }
        }
        private static void RTDBModoFila()
        {
            bool flag = !Directory.Exists("c:\\wnc\\home\\d_xnc\\dati\\data");
            if (!flag)
            {
                try
                {
                    Directory.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\validated", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errore nella cancellazione di file", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
                //File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old", false);
                File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini");
                FileInfo fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
                StreamReader streamReader = fileInfo.OpenText();
                StreamWriter streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini");
                try
                {
                    string text2 = "";
                    string text;

                    do
                    {
                        text = streamReader.ReadLine();
                        bool flag22 = text == null;
                        if (flag22)
                        {
                            break;
                        }
                        bool flag23 = text.IndexOf("[") != -1;
                        if (flag23)
                        {
                            text2 = text;
                            streamWriter.WriteLine(text);
                        }
                        else
                        {
                            bool flag24 = text.IndexOf("ModoFila=") != -1 || text.IndexOf("ModoFila=") != -1;
                            if (flag24)
                            {
                                bool flag25 = false;
                                for (int i = 1; i <= 12; i++)
                                {
                                    string text3 = "FILEBAT";
                                    bool flag26 = i <= 10;
                                    if (flag26)
                                    {
                                        text3 = text3 + "00" + (i - 1).ToString();
                                    }
                                    else
                                    {
                                        text3 = text3 + "0" + (i - 1).ToString();
                                    }
                                    string value = text3 + "{" + (i - 1).ToString() + "}";

                                    bool flag27 = text.IndexOf("Modofila=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
                                    if (flag27)
                                    {
                                        //text = "I_LEDpc=" + i.ToString();
                                        text = "ModoFila=" + SetValue;
                                        streamWriter.WriteLine(text);
                                        flag25 = true;
                                        break;
                                    }
                                    //bool flag28 = text.IndexOf("O_LEDpc=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
                                    //if (flag28)
                                    //{
                                    //	text = "O_LEDpc=" + i.ToString();
                                    //	streamWriter.WriteLine(text);
                                    //	flag25 = true;
                                    //	break;
                                    //}
                                }
                                bool flag29 = flag25;
                                if (flag29)
                                {
                                    break;
                                }
                            }
                            streamWriter.WriteLine(text);
                        }

                    }
                    while (text != null);
                    streamReader.Close();
                    streamWriter.Close();
                    //File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
                }
                catch (Exception ex5)
                {
                    MessageBox.Show(ex5.Message, Form2.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Form2.errore = true;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetValue = "0";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetValue= "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RTDBModoFila();
        }
    }
}
