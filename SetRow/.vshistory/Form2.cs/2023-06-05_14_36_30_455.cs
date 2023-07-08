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
using cni.plcdebug.forms;
using log4net.Util;
using Microsoft.Extensions.Logging;



namespace SoftConsConfig
{
    public partial class Form2 : Form
    {

        private static string SetValue;
        private static bool errore = false;
        private static string titolo = "SoftConsole Configurator  ";
        private PlcHsd plcHsd2000;
        private string strNomeHost = "Localhost";
        private bool connessione_in_corso;

        public Form2()
        {
            InitializeComponent();
        }
        [STAThread]
        private static void Main()
        {
         
                //ApplicationConfiguration.Initialize();
                Application.Run(new Form2());
            //this.plcHsd2000.PlcHsd_InitOggetti(null, null, null, null, null);
   
        }
        private void StopPlc()
        {
            this.plcHsd2000.PlcHsd_HaltPLC();
        }

        private void StartPlc()
        {
            this.plcHsd2000.PlcHsd_GoPLC();
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
                            text2 = "ModoFila="+SetValue;
                            streamWriter.WriteLine(text2);
                        }
                        else
                        {
                            bool FF2 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT009") != -1;
                            if (FF2)
                            {
                                text2 = "ModoFila="+SetValue;
                                streamWriter.WriteLine(text2);
                            }
                            else
                            {
                                bool FF3 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT010") != -1;
                                if (FF3)
                                {
                                    text2 = "ModoFila=" + SetValue;
                                    streamWriter.WriteLine(text2);
                                }
                                else
                                {
                                    bool FF4 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT011") != -1;
                                    if (FF4)
                                    {
                                        text2 = "ModoFila=" + SetValue;
                                        streamWriter.WriteLine(text2);
                                    }
                                    else
                                    {
                                        streamWriter.WriteLine(text2);
                                    }

                                }
                            }
                        }
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
                File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
                File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old", false);
                File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini");
                FileInfo fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
                StreamReader streamReader = fileInfo.OpenText();
                StreamWriter streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini");
                string text="";
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
                        bool FF1 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT{8}") != -1;
                        if (FF1)
                        {
                            text2 = "ModoFila="+SetValue;
                            streamWriter.WriteLine(text2);
                        }
                        else
                        {
                            bool FF2 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT{9}") != -1;
                            if (FF2)
                            {
                                text2 = "ModoFila="+SetValue;
                                streamWriter.WriteLine(text2);
                            }
                            else
                            {
                                bool FF3 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT{10}") != -1;
                                if (FF3)
                                {
                                    text2 = "ModoFila="+SetValue;
                                    streamWriter.WriteLine(text2);
                                }
                                else
                                {
                                    bool FF4 = text2.IndexOf("ModoFila=") != -1 && text.IndexOf("FILEBAT{11}") != -1;
                                    if (FF4)
                                    {
                                        text2 = "ModoFila="+SetValue;
                                        streamWriter.WriteLine(text2);
                                    }
                                    else
                                    {
                                        streamWriter.WriteLine(text2);
                                    }

                                }
                            }
                        }
                    }
                    while (text2 != null);
                    //do
                    //{
                    //    text = streamReader.ReadLine();
                    //    bool flag22 = text == null;
                    //    if (flag22)
                    //    {
                    //        break;
                    //    }
                    //    bool flag23 = text.IndexOf("[") != -1;
                    //    if (flag23)
                    //    {
                    //        text2 = text;
                    //        streamWriter.WriteLine(text);
                    //    }
                    //    else
                    //    {
                    //        bool flag24 = text.IndexOf("ModoFila=") != -1 || text.IndexOf("ModoFila=") != -1;
                    //        if (flag24)
                    //        {
                    //            bool flag25 = false;
                    //            for (int i = 1; i <= 12; i++)
                    //            {
                    //                string text3 = "FILEBAT";
                    //                bool flag26 = i <= 10;
                    //                if (flag26)
                    //                {
                    //                    text3 = text3 + "";
                    //                }
                    //                else
                    //                {
                    //                    text3 = text3 + "0" + (i - 1).ToString();
                    //                }
                    //                string value = text3 + "{" + (i - 1).ToString() + "}";

                    //                bool flag27 = text.IndexOf("Modofila=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
                    //                if (flag27)
                    //                {
                    //                    //text = "I_LEDpc=" + i.ToString();
                    //                    text = "ModoFila=" + SetValue;
                    //                    streamWriter.WriteLine(text);
                    //                    flag25 = true;
                    //                    break;
                    //                }
                    //                //bool flag28 = text.IndexOf("O_LEDpc=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
                    //                //if (flag28)
                    //                //{
                    //                //	text = "O_LEDpc=" + i.ToString();
                    //                //	streamWriter.WriteLine(text);
                    //                //	flag25 = true;
                    //                //	break;
                    //                //}
                    //            }
                    //            bool flag29 = flag25;
                    //            if (flag29)
                    //            {
                    //                break;
                    //            }
                    //        }
                    //        streamWriter.WriteLine(text);
                    //    }

                    //}
                    //while (text != null);
                    streamReader.Close();
                    streamWriter.Close();
                    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_filebat.dat.ini_old");
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
            SetValue = "1";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetValue= "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (SetValue == null)
            {
                MessageBox.Show("Välj alternativ och fortsätt");
            }
            else if (SetValue != null) 
            {
                SetModofila();
                RTDBModoFila();
            }

            DialogResult result = MessageBox.Show("Slutfört, HALT och Run PLC ", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                StopPlc();
                Task.Delay(3000);
                StartPlc();

                // Close the application
                this.plcHsd2000.PlcHsd_DisconnectFromHost();
                Application.Exit();
            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.strNomeHost = "LOCALHOST";
            this.plcHsd2000.PlcHsd_ConnectToHost(this.strNomeHost);
            this.connessione_in_corso = true;
            MessageBox.Show("Connected="+connessione_in_corso);
        }
    }
}
