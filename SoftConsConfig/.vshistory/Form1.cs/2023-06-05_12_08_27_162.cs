using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;



namespace SoftConsConfig
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : Form
	{
        // Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050

        //private readonly ILogger<Form1> logger;


        public static void SetPasswordOk(bool pwdOk)
		{
			Form1.passwordCorretta = pwdOk;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000105C
		private static void CreaLog(bool risultato)
		{
			string text = DateTime.Now.ToString().Substring(0, 10) + " - " + DateTime.Now.ToLongTimeString();
			try
			{
				string text2 = "eseguita correttamente ";
				StreamWriter streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\logfile\\SoftConsConfig.log");
				bool flag = !risultato;
				if (flag)
				{
					text2 = "NON eseguita correttamente ";
				}
				streamWriter.WriteLine(string.Concat(new string[]
				{
					"SoftConsConfig: conversione dati ",
					text2,
					"[",
					text,
					"]."
				}));
				streamWriter.Flush();
				streamWriter.Close();
			}
			catch
			{
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002114 File Offset: 0x00001114
		public Form1()
		{
			this.InitializeComponent();
			//base.Hide();



        }

		// Token: 0x06000006 RID: 6 RVA: 0x000021BC File Offset: 0x000011BC
		[STAThread]
		private static void Main(string[] args)
		{
			bool flag = args.Length != 0;
			if (flag)
			{
				for (int i = 0; i < args.Length; i++)
				{
					string text = args[i].ToUpper();
					string a = text;
					if (!(a == "-NOPWD"))
					{
						if (!(a == "-NODIALOG"))
						{
							if (a == "-SIMBSOLID")
							{
								Form1.passwordCorretta = true;
								Form1.noFinetraDialogo = true;
								Form1.simulazBsolid = true;
							}
						}
						else
						{
							Form1.noFinetraDialogo = true;
						}
					}
					else
					{
						Form1.passwordCorretta = true;
					}
				}
			}
			bool flag2 = !Form1.passwordCorretta;
			if (flag2)
			{
				PasswordForm passwordForm = new PasswordForm();
				passwordForm.ShowDialog();
			}
			bool flag3 = Form1.passwordCorretta;
			if (flag3)
			{
				//Form1.ImpostaDatiPerSimulazione();
				//Form1.ImpostaDatiRTDBPerSimulazione();
				Form1.SetModofila();
				bool flag4 = !Form1.errore;
				if (flag4)
				{
					bool flag5 = !Form1.noFinetraDialogo;
					if (flag5)
					{
						MessageBox.Show("Data configuration for software simulation completed!  ", Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					Form1.CreaLog(true);
				}
			}
			else
			{
				bool flag6 = !Form1.noFinetraDialogo;
				if (flag6)
				{
					MessageBox.Show("Data configuration for software simulation NOT executed!  ", Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				Form1.CreaLog(false);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022E8 File Offset: 0x000012E8
		private static void ImpostaDatiPerSimulazione()
		{
			try
			{
				Directory.Delete("c:\\wnc\\home\\d_xnc\\dati\\validated", true);
				File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Errore nella cancellazione di files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
						bool flag4 = text2.IndexOf("Simulaz=") != -1;
						if (flag4)
						{
							text2 = "Simulaz=8";
							streamWriter.WriteLine(text2);
						}
						else
						{
							bool flag5 = text2.IndexOf("SoftCons=") != -1;
							if (flag5)
							{
								text2 = "SoftCons=1";
								streamWriter.WriteLine(text2);
							}
							else
							{
								bool flag6 = Form1.simulazBsolid;
								if (flag6)
								{
									bool flag7 = text2.IndexOf("SimulazGrafica=") != -1;
									if (flag7)
									{
										text2 = "SimulazGrafica=1";
										streamWriter.WriteLine(text2);
										return;
									}
								}
								else
								{
									bool flag8 = text2.IndexOf("SimulazGrafica=") != -1;
									if (flag8)
									{
										text2 = "SimulazGrafica=0";
										streamWriter.WriteLine(text2);
										return;
									}
								}
								bool flag9 = text2.IndexOf("I_Start=") != -1;
								if (flag9)
								{
									text2 = "I_Start=17";
									streamWriter.WriteLine(text2);
								}
								else
								{
									bool flag10 = text2.IndexOf("O_Start=") != -1;
									if (flag10)
									{
										text2 = "O_Start=17";
										streamWriter.WriteLine(text2);
									}
									else
									{
										bool flag11 = text2.IndexOf("I_Stop=") != -1;
										if (flag11)
										{
											text2 = "I_Stop=18";
											streamWriter.WriteLine(text2);
										}
										else
										{
											bool flag12 = text2.IndexOf("I_Reset=") != -1;
											if (flag12)
											{
												text2 = "I_Reset=19";
												streamWriter.WriteLine(text2);
											}
											else
											{
												bool flag13 = text2.IndexOf("I_Clear=") != -1;
												if (flag13)
												{
													text2 = "I_Clear=20";
													streamWriter.WriteLine(text2);
												}
												else
												{
													bool flag14 = text2.IndexOf("I_Jogmen=") != -1;
													if (flag14)
													{
														text2 = "I_Jogmen=21";
														streamWriter.WriteLine(text2);
													}
													else
													{
														bool flag15 = text2.IndexOf("I_Jogfas=") != -1;
														if (flag15)
														{
															text2 = "I_Jogfas=-1";
															streamWriter.WriteLine(text2);
														}
														else
														{
															bool flag16 = text2.IndexOf("I_Jogpiu=") != -1;
															if (flag16)
															{
																text2 = "I_Jogpiu=22";
																streamWriter.WriteLine(text2);
															}
															else
															{
																bool flag17 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST012") != -1;
																if (flag17)
																{
																	text2 = "Abil=2";
																	streamWriter.WriteLine(text2);
																}
																else
																{
																	bool flag18 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST013") != -1;
																	if (flag18)
																	{
																		text2 = "Abil=2";
																		streamWriter.WriteLine(text2);
																	}
																	else
																	{
																		bool flag19 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST014") != -1;
																		if (flag19)
																		{
																			text2 = "Abil=2";
																			streamWriter.WriteLine(text2);
																		}
																		else
																		{
																			bool flag20 = text2.IndexOf("Abil=") != -1 && text.IndexOf("TAST015") != -1;
																			if (flag20)
																			{
																				text2 = "Abil=2";
																				streamWriter.WriteLine(text2);
																			}
																			else
																			{
																				bool flag21 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE000") != -1;
																				if (flag21)
																				{
																					text2 = "Abil=0";
																					streamWriter.WriteLine(text2);
																				}
																				else
																				{
																					bool flag22 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE001") != -1;
																					if (flag22)
																					{
																						text2 = "Abil=0";
																						streamWriter.WriteLine(text2);
																					}
																					else
																					{
																						bool flag23 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE002") != -1;
																						if (flag23)
																						{
																							text2 = "Abil=0";
																							streamWriter.WriteLine(text2);
																						}
																						else
																						{
																							bool flag24 = text2.IndexOf("Abil=") != -1 && text.IndexOf("OVERRIDE003") != -1;
																							if (flag24)
																							{
																								text2 = "Abil=0";
																								streamWriter.WriteLine(text2);
																							}
																							else
																							{
																								bool flag25 = false;
																								for (int i = 1; i <= 16; i++)
																								{
																									string text3 = "TAST";
																									bool flag26 = i < 11;
																									if (flag26)
																									{
																										text3 = text3 + "00" + (i - 1).ToString();
																									}
																									else
																									{
																										text3 = text3 + "0" + (i - 1).ToString();
																									}
																									bool flag27 = text2.IndexOf("I_LEDpc=") != -1 && text.IndexOf(text3) != -1;
																									if (flag27)
																									{
																										text2 = "I_LEDpc=" + i.ToString();
																										streamWriter.WriteLine(text2);
																										flag25 = true;
																										break;
																									}
																									bool flag28 = text2.IndexOf("O_LEDpc=") != -1 && text.IndexOf(text3) != -1;
																									if (flag28)
																									{
																										text2 = "O_LEDpc=" + i.ToString();
																										streamWriter.WriteLine(text2);
																										flag25 = true;
																										break;
																									}
																									text3 = "TASTIPLC";
																									bool flag29 = i <= 10;
																									if (flag29)
																									{
																										text3 = text3 + "00" + (i - 1).ToString();
																									}
																									else
																									{
																										text3 = text3 + "0" + (i - 1).ToString();
																									}
																									bool flag30 = text2.IndexOf("I_LEDpc=") != -1 && text.IndexOf(text3) != -1;
																									if (flag30)
																									{
																										text2 = "I_LEDpc=" + i.ToString();
																										streamWriter.WriteLine(text2);
																										flag25 = true;
																										break;
																									}
																									bool flag31 = text2.IndexOf("O_LEDpc=") != -1 && text.IndexOf(text3) != -1;
																									if (flag31)
																									{
																										text2 = "O_LEDpc=" + i.ToString();
																										streamWriter.WriteLine(text2);
																										flag25 = true;
																										break;
																									}
																								}
																								bool flag32 = flag25;
																								if (!flag32)
																								{
																									streamWriter.WriteLine(text2);
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
						IL_6B3:;
					}
					while (text2 != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protquo", "c:\\wnc\\home\\d_xnc\\dati\\protquo_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protquo");
					text = "";
					string text2;
					do
					{
						text2 = streamReader.ReadLine();
						bool flag33 = text2 == null;
						if (flag33)
						{
							break;
						}
						bool flag34 = text2.IndexOf("[") != -1;
						if (flag34)
						{
							text = text2;
						}
						bool flag35 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override000") != -1;
						if (flag35)
						{
							text2 = "soft=2";
							streamWriter.WriteLine(text2);
						}
						else
						{
							bool flag36 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override000") != -1;
							if (flag36)
							{
								text2 = "overplc=0";
								streamWriter.WriteLine(text2);
							}
							else
							{
								bool flag37 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override001") != -1;
								if (flag37)
								{
									text2 = "soft=2";
									streamWriter.WriteLine(text2);
								}
								else
								{
									bool flag38 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override001") != -1;
									if (flag38)
									{
										text2 = "overplc=0";
										streamWriter.WriteLine(text2);
									}
									else
									{
										bool flag39 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override002") != -1;
										if (flag39)
										{
											text2 = "soft=2";
											streamWriter.WriteLine(text2);
										}
										else
										{
											bool flag40 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override002") != -1;
											if (flag40)
											{
												text2 = "overplc=0";
												streamWriter.WriteLine(text2);
											}
											else
											{
												bool flag41 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override003") != -1;
												if (flag41)
												{
													text2 = "soft=2";
													streamWriter.WriteLine(text2);
												}
												else
												{
													bool flag42 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override003") != -1;
													if (flag42)
													{
														text2 = "overplc=0";
														streamWriter.WriteLine(text2);
													}
													else
													{
														bool flag43 = text2.IndexOf("progsel=") != -1 && text.IndexOf("DstnNomi000") != -1;
														if (flag43)
														{
															text2 = "progsel=COLLAUDO-2002";
															streamWriter.WriteLine(text2);
														}
														else
														{
															bool flag44 = text2.IndexOf("progant=") != -1 && text.IndexOf("DstnNomi000") != -1;
															if (flag44)
															{
																text2 = "progant=/WNC/home/d_xnc/p_p/prog/COLLAUDO-2002";
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
										}
									}
								}
							}
						}
					}
					while (text2 != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
				}
				catch (Exception ex3)
				{
					MessageBox.Show(ex3.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protee", "c:\\wnc\\home\\d_xnc\\dati\\protee_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protee");
					string text2;
					do
					{
						text2 = streamReader.ReadLine();
						bool flag45 = text2 == null;
						if (flag45)
						{
							break;
						}
						bool flag46 = text2.IndexOf("[") != -1;
						if (flag46)
						{
						}
						bool flag47 = text2.IndexOf("lingua=") != -1;
						if (flag47)
						{
							text2 = "lingua=ita";
							streamWriter.WriteLine(text2);
						}
						else
						{
							streamWriter.WriteLine(text2);
						}
					}
					while (text2 != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
				}
				catch (Exception ex4)
				{
					MessageBox.Show(ex4.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protax", "c:\\wnc\\home\\d_xnc\\dati\\protax_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protax");
					bool flag48 = false;
					int num = 0;
					int num2 = 0;
					string text2;
					do
					{
						text2 = streamReader.ReadLine();
						bool flag49 = text2 == null;
						if (flag49)
						{
							break;
						}
						bool flag50 = text2.IndexOf("[") != -1;
						if (flag50)
						{
						}
						bool flag51 = text2.IndexOf("linea=0") != -1;
						if (flag51)
						{
							flag48 = true;
						}
						bool flag52 = text2.IndexOf("tipo_hw=") != -1 && flag48;
						if (flag52)
						{
							streamWriter.WriteLine("tipo_hw=0");
						}
						else
						{
							bool flag53 = text2.IndexOf("addrlca=") != -1 && flag48;
							if (flag53)
							{
								int num3 = 1024 * num;
								streamWriter.WriteLine("addrlca={0}", num3);
								bool flag54 = num2 == 1;
								if (flag54)
								{
									num++;
								}
								bool flag55 = num2 == 0;
								if (flag55)
								{
									num2 = 1;
								}
								else
								{
									num2 = 0;
								}
								flag48 = false;
							}
							else
							{
								streamWriter.WriteLine(text2);
							}
						}
					}
					while (text2 != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
				}
				catch (Exception ex5)
				{
					MessageBox.Show(ex5.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
			}
		}

        public static void SetModofila()
        {
            try
            {
                Directory.Delete("c:\\wnc\\home\\d_xnc\\dati\\validated", true);
                //File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errore nella cancellazione di files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            bool flag = !File.Exists("c:\\wnc\\home\\d_xnc\\dati\\plctab");
            if (!flag)
            {
                //File.Copy("c:\\wnc\\home\\d_xnc\\dati\\plctab", "c:\\wnc\\home\\d_xnc\\dati\\plctab_old", false);
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
                        bool FF = text2.IndexOf("FILEBAT000") != -1 && text.IndexOf("ModoFila=") != -1;
                        if (FF)
                        {
                            text2 = "ModoFila=1";
                            streamWriter.WriteLine(text2);
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
                        return;
                    }
                    while (text2 != null);
                    streamReader.Close();
                    streamWriter.Close();
                    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Form1.errore = true;
                }
          
                #region
                //try
                //{
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
                //    File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protquo", "c:\\wnc\\home\\d_xnc\\dati\\protquo_old", false);
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo");
                //    fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
                //    streamReader = fileInfo.OpenText();
                //    streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protquo");
                //    text = "";
                //    string text2;
                //    do
                //    {
                //        text2 = streamReader.ReadLine();
                //        bool flag33 = text2 == null;
                //        if (flag33)
                //        {
                //            break;
                //        }
                //        bool flag34 = text2.IndexOf("[") != -1;
                //        if (flag34)
                //        {
                //            text = text2;
                //        }
                //        bool flag35 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override000") != -1;
                //        if (flag35)
                //        {
                //            text2 = "soft=2";
                //            streamWriter.WriteLine(text2);
                //        }
                //        else
                //        {
                //            bool flag36 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override000") != -1;
                //            if (flag36)
                //            {
                //                text2 = "overplc=0";
                //                streamWriter.WriteLine(text2);
                //            }
                //            else
                //            {
                //                bool flag37 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override001") != -1;
                //                if (flag37)
                //                {
                //                    text2 = "soft=2";
                //                    streamWriter.WriteLine(text2);
                //                }
                //                else
                //                {
                //                    bool flag38 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override001") != -1;
                //                    if (flag38)
                //                    {
                //                        text2 = "overplc=0";
                //                        streamWriter.WriteLine(text2);
                //                    }
                //                    else
                //                    {
                //                        bool flag39 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override002") != -1;
                //                        if (flag39)
                //                        {
                //                            text2 = "soft=2";
                //                            streamWriter.WriteLine(text2);
                //                        }
                //                        else
                //                        {
                //                            bool flag40 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override002") != -1;
                //                            if (flag40)
                //                            {
                //                                text2 = "overplc=0";
                //                                streamWriter.WriteLine(text2);
                //                            }
                //                            else
                //                            {
                //                                bool flag41 = text2.IndexOf("soft=") != -1 && text.IndexOf("Override003") != -1;
                //                                if (flag41)
                //                                {
                //                                    text2 = "soft=2";
                //                                    streamWriter.WriteLine(text2);
                //                                }
                //                                else
                //                                {
                //                                    bool flag42 = text2.IndexOf("overplc=") != -1 && text.IndexOf("Override003") != -1;
                //                                    if (flag42)
                //                                    {
                //                                        text2 = "overplc=0";
                //                                        streamWriter.WriteLine(text2);
                //                                    }
                //                                    else
                //                                    {
                //                                        bool flag43 = text2.IndexOf("progsel=") != -1 && text.IndexOf("DstnNomi000") != -1;
                //                                        if (flag43)
                //                                        {
                //                                            text2 = "progsel=COLLAUDO-2002";
                //                                            streamWriter.WriteLine(text2);
                //                                        }
                //                                        else
                //                                        {
                //                                            bool flag44 = text2.IndexOf("progant=") != -1 && text.IndexOf("DstnNomi000") != -1;
                //                                            if (flag44)
                //                                            {
                //                                                text2 = "progant=/WNC/home/d_xnc/p_p/prog/COLLAUDO-2002";
                //                                                streamWriter.WriteLine(text2);
                //                                            }
                //                                            else
                //                                            {
                //                                                streamWriter.WriteLine(text2);
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
                //    while (text2 != null);
                //    streamReader.Close();
                //    streamWriter.Close();
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protquo_old");
                //}
                //catch (Exception ex3)
                //{
                //    MessageBox.Show(ex3.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    Form1.errore = true;
                //}
                //try
                //{
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
                //    File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protee", "c:\\wnc\\home\\d_xnc\\dati\\protee_old", false);
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee");
                //    fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
                //    streamReader = fileInfo.OpenText();
                //    streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protee");
                //    string text2;
                //    do
                //    {
                //        text2 = streamReader.ReadLine();
                //        bool flag45 = text2 == null;
                //        if (flag45)
                //        {
                //            break;
                //        }
                //        bool flag46 = text2.IndexOf("[") != -1;
                //        if (flag46)
                //        {
                //        }
                //        bool flag47 = text2.IndexOf("lingua=") != -1;
                //        if (flag47)
                //        {
                //            text2 = "lingua=ita";
                //            streamWriter.WriteLine(text2);
                //        }
                //        else
                //        {
                //            streamWriter.WriteLine(text2);
                //        }
                //    }
                //    while (text2 != null);
                //    streamReader.Close();
                //    streamWriter.Close();
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protee_old");
                //}
                //catch (Exception ex4)
                //{
                //    MessageBox.Show(ex4.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    Form1.errore = true;
                //}
                //try
                //{
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
                //    File.Copy("c:\\wnc\\home\\d_xnc\\dati\\protax", "c:\\wnc\\home\\d_xnc\\dati\\protax_old", false);
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax");
                //    fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
                //    streamReader = fileInfo.OpenText();
                //    streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\protax");
                //    bool flag48 = false;
                //    int num = 0;
                //    int num2 = 0;
                //    string text2;
                //    do
                //    {
                //        text2 = streamReader.ReadLine();
                //        bool flag49 = text2 == null;
                //        if (flag49)
                //        {
                //            break;
                //        }
                //        bool flag50 = text2.IndexOf("[") != -1;
                //        if (flag50)
                //        {
                //        }
                //        bool flag51 = text2.IndexOf("linea=0") != -1;
                //        if (flag51)
                //        {
                //            flag48 = true;
                //        }
                //        bool flag52 = text2.IndexOf("tipo_hw=") != -1 && flag48;
                //        if (flag52)
                //        {
                //            streamWriter.WriteLine("tipo_hw=0");
                //        }
                //        else
                //        {
                //            bool flag53 = text2.IndexOf("addrlca=") != -1 && flag48;
                //            if (flag53)
                //            {
                //                int num3 = 1024 * num;
                //                streamWriter.WriteLine("addrlca={0}", num3);
                //                bool flag54 = num2 == 1;
                //                if (flag54)
                //                {
                //                    num++;
                //                }
                //                bool flag55 = num2 == 0;
                //                if (flag55)
                //                {
                //                    num2 = 1;
                //                }
                //                else
                //                {
                //                    num2 = 0;
                //                }
                //                flag48 = false;
                //            }
                //            else
                //            {
                //                streamWriter.WriteLine(text2);
                //            }
                //        }
                //    }
                //    while (text2 != null);
                //    streamReader.Close();
                //    streamWriter.Close();
                //    File.Delete("c:\\wnc\\home\\d_xnc\\dati\\protax_old");
                //}
                //catch (Exception ex5)
                //{
                //    MessageBox.Show(ex5.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                //    Form1.errore = true;
                //}
                #endregion
            }
        }
        // Token: 0x06000008 RID: 8 RVA: 0x00003020 File Offset: 0x00002020
        private static void ImpostaDatiRTDBPerSimulazione()
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
				File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini_old");
				File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini_old", false);
				File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini");
				FileInfo fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini_old");
				StreamReader streamReader = fileInfo.OpenText();
				StreamWriter streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini");
				try
				{
					string text;
					do
					{
						text = streamReader.ReadLine();
						bool flag2 = text == null;
						if (flag2)
						{
							break;
						}
						bool flag3 = text.IndexOf("Simulaz=") != -1;
						if (flag3)
						{
							text = "Simulaz=8";
							streamWriter.WriteLine(text);
						}
						else
						{
							bool flag4 = Form1.simulazBsolid;
							if (flag4)
							{
								bool flag5 = text.IndexOf("SimulazGrafica=") != -1;
								if (flag5)
								{
									text = "SimulazGrafica=1";
									streamWriter.WriteLine(text);
									goto IL_140;
								}
							}
							else
							{
								bool flag6 = text.IndexOf("SimulazGrafica=") != -1;
								if (flag6)
								{
									text = "SimulazGrafica=0";
									streamWriter.WriteLine(text);
									goto IL_140;
								}
							}
							streamWriter.WriteLine(text);
						}
						IL_140:;
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_infomacc.dat.ini_old");
				}
				catch (Exception ex2)
				{
					MessageBox.Show(ex2.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini");
					string text;
					do
					{
						text = streamReader.ReadLine();
						bool flag7 = text == null;
						if (flag7)
						{
							break;
						}
						bool flag8 = text.IndexOf("SoftCons=") != -1;
						if (flag8)
						{
							text = "SoftCons=1";
							streamWriter.WriteLine(text);
						}
						else
						{
							bool flag9 = text.IndexOf("I_Start=") != -1;
							if (flag9)
							{
								text = "I_Start=17";
								streamWriter.WriteLine(text);
							}
							else
							{
								bool flag10 = text.IndexOf("O_Start=") != -1;
								if (flag10)
								{
									text = "O_Start=17";
									streamWriter.WriteLine(text);
								}
								else
								{
									bool flag11 = text.IndexOf("I_Stop=") != -1;
									if (flag11)
									{
										text = "I_Stop=18";
										streamWriter.WriteLine(text);
									}
									else
									{
										bool flag12 = text.IndexOf("I_Reset=") != -1;
										if (flag12)
										{
											text = "I_Reset=19";
											streamWriter.WriteLine(text);
										}
										else
										{
											bool flag13 = text.IndexOf("I_Clear=") != -1;
											if (flag13)
											{
												text = "I_Clear=20";
												streamWriter.WriteLine(text);
											}
											else
											{
												bool flag14 = text.IndexOf("I_Jogmen=") != -1;
												if (flag14)
												{
													text = "I_Jogmen=21";
													streamWriter.WriteLine(text);
												}
												else
												{
													bool flag15 = text.IndexOf("I_Jogfas=") != -1;
													if (flag15)
													{
														text = "I_Jogfas=-1";
														streamWriter.WriteLine(text);
													}
													else
													{
														bool flag16 = text.IndexOf("I_Jogpiu=") != -1;
														if (flag16)
														{
															text = "I_Jogpiu=22";
															streamWriter.WriteLine(text);
														}
														else
														{
															streamWriter.WriteLine(text);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tasticn.dat.ini_old");
				}
				catch (Exception ex3)
				{
					MessageBox.Show(ex3.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini");
					string text;
					do
					{
						text = streamReader.ReadLine();
						bool flag17 = text == null;
						if (flag17)
						{
							break;
						}
						bool flag18 = text.IndexOf("Abil=") != -1;
						if (flag18)
						{
							text = "Abil=0";
							streamWriter.WriteLine(text);
						}
						else
						{
							bool flag19 = text.IndexOf("Abil=") != -1;
							if (flag19)
							{
								text = "Abil=0";
								streamWriter.WriteLine(text);
							}
							else
							{
								bool flag20 = text.IndexOf("Abil=") != -1;
								if (flag20)
								{
									text = "Abil=0";
									streamWriter.WriteLine(text);
								}
								else
								{
									bool flag21 = text.IndexOf("Abil=") != -1;
									if (flag21)
									{
										text = "Abil=0";
										streamWriter.WriteLine(text);
									}
									else
									{
										streamWriter.WriteLine(text);
									}
								}
							}
						}
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\OEM_OVERRIDE.dat.ini_old");
				}
				catch (Exception ex4)
				{
					MessageBox.Show(ex4.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini");
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
							bool flag24 = text.IndexOf("I_LEDpc=") != -1 || text.IndexOf("O_LEDpc=") != -1;
							if (flag24)
							{
								bool flag25 = false;
								for (int i = 1; i <= 16; i++)
								{
									string text3 = "TASTIPLC";
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
									bool flag27 = text.IndexOf("I_LEDpc=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
									if (flag27)
									{
										text = "I_LEDpc=" + i.ToString();
										streamWriter.WriteLine(text);
										flag25 = true;
										break;
									}
									bool flag28 = text.IndexOf("O_LEDpc=") != -1 && (text2.IndexOf(text3) != -1 || text2.IndexOf(value) != -1);
									if (flag28)
									{
										text = "O_LEDpc=" + i.ToString();
										streamWriter.WriteLine(text);
										flag25 = true;
										break;
									}
								}
								bool flag29 = flag25;
								if (flag29)
								{
									goto IL_722;
								}
							}
							streamWriter.WriteLine(text);
						}
						IL_722:;
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_tastiplc.dat.ini_old");
				}
				catch (Exception ex5)
				{
					MessageBox.Show(ex5.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini");
					string text;
					do
					{
						text = streamReader.ReadLine();
						bool flag30 = text == null;
						if (flag30)
						{
							break;
						}
						bool flag31 = text.IndexOf("soft=") != -1;
						if (flag31)
						{
							text = "soft=2";
							streamWriter.WriteLine(text);
						}
						else
						{
							bool flag32 = text.IndexOf("overplc=") != -1;
							if (flag32)
							{
								text = "overplc=0";
								streamWriter.WriteLine(text);
							}
							else
							{
								streamWriter.WriteLine(text);
							}
						}
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\Override.dat.ini_old");
				}
				catch (Exception ex6)
				{
					MessageBox.Show(ex6.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				try
				{
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini_old");
					File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini_old", false);
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini");
					fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini_old");
					streamReader = fileInfo.OpenText();
					streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini");
					string text;
					do
					{
						text = streamReader.ReadLine();
						bool flag33 = text == null;
						if (flag33)
						{
							break;
						}
						bool flag34 = text.IndexOf("lingua=") != -1;
						if (flag34)
						{
							text = "lingua=ita";
							streamWriter.WriteLine(text);
						}
						else
						{
							streamWriter.WriteLine(text);
						}
					}
					while (text != null);
					streamReader.Close();
					streamWriter.Close();
					File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\macc.dat.ini_old");
				}
				catch (Exception ex7)
				{
					MessageBox.Show(ex7.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Form1.errore = true;
				}
				bool flag35 = Form1.simulazBsolid;
				if (flag35)
				{
					try
					{
						File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini_old");
						File.Copy("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini", "c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini_old", false);
						File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini");
						fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini_old");
						streamReader = fileInfo.OpenText();
						streamWriter = new StreamWriter("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini");
						string text;
						do
						{
							text = streamReader.ReadLine();
							bool flag36 = text == null;
							if (flag36)
							{
								break;
							}
							bool flag37 = text.IndexOf("AntiColl=") != -1;
							if (flag37)
							{
								text = "AntiColl";
								streamWriter.WriteLine(text);
							}
							else
							{
								streamWriter.WriteLine(text);
							}
						}
						while (text != null);
						streamReader.Close();
						streamWriter.Close();
						File.Delete("c:\\wnc\\home\\d_xnc\\dati\\data\\oem_slot.dat.ini_old");
					}
					catch (Exception ex8)
					{
						MessageBox.Show(ex8.Message, Form1.titolo, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						Form1.errore = true;
					}
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private static string titolo = "SoftConsole Configurator  ";

		// Token: 0x04000002 RID: 2
		private static bool errore = false;

		// Token: 0x04000003 RID: 3
		private static bool passwordCorretta = false;

		// Token: 0x04000004 RID: 4
		private static bool noFinetraDialogo = false;

		// Token: 0x04000005 RID: 5
		private static bool simulazBsolid = false;

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo("c:\\wnc\\home\\d_xnc\\dati\\plctab_old");
            StreamReader streamReader = fileInfo.OpenText();
            richTextBox1.Text = streamReader.ReadToEnd();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1.SetModofila();

        }
    }
}
