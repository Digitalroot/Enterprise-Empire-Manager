using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.Adapters;
using EEM.Common.PluginInterface;
using EEM.Common.Protocol;

namespace EEM.Plugin.Notifications
{
    public partial class MainScreen : Form
    {
        private readonly IEnterpriseEmpireManager _enterpriseEmpireManager;
        private readonly List<CityResponseToBeFixed> _cities = new List<CityResponseToBeFixed>();
        private readonly List<AllianceAttack> _attacks = new List<AllianceAttack>();
        private readonly LoUAdapter _loUAdapter;
        public int NumIncoming;
        public int EmailInterval;
        public MainScreen(IEnterpriseEmpireManager enterpriseEmpireManager)
        {
            InitializeComponent();
            _enterpriseEmpireManager = enterpriseEmpireManager;
            _loUAdapter = LoUAdapter.Instance;
            PopulateSettings();
        }

        private void PopulateSettings()
        {
            txt_EmailTo.Text = Properties.Settings.Default.EmailTo;
            txt_EmailFrom.Text = Properties.Settings.Default.EmailFrom;
            cb_AuthRequired.Checked = Properties.Settings.Default.AuthRequired;
            if (Properties.Settings.Default.AuthRequired)
            {
                txt_EmailUser.Text = Properties.Settings.Default.AuthUserName;
                txt_EmailUser.Visible = true;
                txt_EmailPass.Text = Properties.Settings.Default.AuthPassword;
                txt_EmailPass.Visible = true;
                lbl_pass.Visible = true;
                lbl_user.Visible = true;
            }
            else
            {
                txt_EmailUser.Visible = false;
                txt_EmailPass.Visible = false;
                lbl_pass.Visible = false;
                lbl_user.Visible = false;
            }
            txt_SMTPServer.Text = Properties.Settings.Default.SMTPServer;
            cb_SSL.Checked = Properties.Settings.Default.SSL;
            cb_SendEmail.Checked = Properties.Settings.Default.SendEmail;
            if (Properties.Settings.Default.SendEmail)
            {
                lbl_NotificationInterval.Visible = true;
                num_NotificationInterval.Visible = true;
                lbl_NotificationHelp.Visible = true;
            }
            else
            {
                lbl_NotificationInterval.Visible = false;
                num_NotificationInterval.Visible = false;
                lbl_NotificationHelp.Visible = false;
            }

            var x = Convert.ToDecimal(Properties.Settings.Default.NotificationInterval);
            num_NotificationInterval.Value = x;

        }

        internal void UpdatePlayerList(PlayerResponse response)
        {
            //textBox2.Text = response.ToString();
            _cities.Clear();
            foreach (var x in response.Cities)
            {
                _cities.Add(x);
            }
            //Debug.Write(response);
        }

        internal void UpdateAttackList(ALLATResponse response)
        {
            //textBox1.Text = "City :\t\t # of Attacks @\t First Incoming" + Environment.NewLine;
            _attacks.Clear();
            NumIncoming = 0;
            foreach (AllianceAttack attack in response.AttackList)
            {
                if (attack.TargetPlayerName == _loUAdapter.CurrentPlayer.Name)
                {
                    NumIncoming++;
                }
                _attacks.Add(attack);


            }
            //Logger.Log("Number Incoming: " + numIncoming);
            if (NumIncoming > 0)
            {
                lbl_Incoming.Text = NumIncoming + " Incoming Attacks!";
                lbl_Incoming.ForeColor = System.Drawing.Color.Red;
                var x = SendEmail();
                if (!x)
                {
                    lbl_emailerror.Text += "Problem sending email";
                }
            }
            else
            {
                lbl_Incoming.Text = "Coast is Clear";
                lbl_Incoming.ForeColor = System.Drawing.Color.Blue;
                EmailInterval = 0;
                //var x = SendEmail(); //TODO Remove after testing
            }
        }


        private bool SendEmail()
        {

            if (Properties.Settings.Default.SendEmail)
            {
                //numIncoming = 1; // for testing purposes
                //NumIncoming = Convert.ToInt32(num_TestIncoming.Value);
                var x = NumIncoming / num_NotificationInterval.Value;
                var xx = Math.Floor(x);
               
                if (num_NotificationInterval.Value == 0)
                {
                    EmailInterval = 999999;
                }
                else
                {
                    if (EmailInterval == 0)
                    {
                        EmailInterval = Convert.ToInt32(Math.Floor(NumIncoming / num_NotificationInterval.Value));
                    }
                }
                Logger.Log("Debugging Interval:");
                Logger.Log("Number of Incoming: " + NumIncoming);
                Logger.Log("Notification Interval: " + num_NotificationInterval.Value);
                Logger.Log("Email Count:" + EmailInterval);
                if (EmailInterval <= xx)
                {
                    try
                    {
                        FormatAttacksAll();
                        FormatAttacksPlayer();
                        FormatAllianceSummaryTab();
                        string body = FormatPlayerSummaryTab(false);
                        body = body.Replace("\t", " ");
                        string emailbody = DateTime.Now.ToShortTimeString() + "\r\nYou have " + NumIncoming + " incoming attacks!\r\n" + body;
                        if (emailbody.Length > 130)
                        {
                            emailbody = emailbody.Substring(0, 130) + "...";
                        }
                        MailMessage message = new MailMessage(Properties.Settings.Default.EmailFrom, Properties.Settings.Default.EmailTo, "Incoming", emailbody);
                        SmtpClient client = new SmtpClient(Properties.Settings.Default.SMTPServer);
                        if (Properties.Settings.Default.SSL)
                        {
                            client.EnableSsl = true;
                        }
                        else
                        {
                            client.EnableSsl = false;
                        }
                        if (Properties.Settings.Default.AuthRequired)
                        {
                            System.Net.NetworkCredential basicCrenntial = new System.Net.NetworkCredential(Properties.Settings.Default.AuthUserName, Properties.Settings.Default.AuthPassword);
                            client.UseDefaultCredentials = false;
                            client.Credentials = basicCrenntial;
                        }
                        client.Send(message);
                        Logger.Log(message.Body);
                    }
                    catch (Exception exception)
                    {
                        lbl_emailerror.Text = exception.Message;
                        //log error message
                        Logger.Log(exception.Message);
                    }
                    if (EmailInterval == 0)
                    {
                        EmailInterval = Convert.ToInt32(Math.Ceiling(NumIncoming/num_NotificationInterval.Value));
                    }
                    else
                    {
                        EmailInterval++;
                    }
                    

                }
            }
            return true;
        }

        private void FormatAttacksAll()
        {
            //foreach (var allianceAttack in _attacks)
            //{
            //    var x = allianceAttack.es;
                
            //    DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //    double xx = timeService.RefrencePoint / 1000;
            //    var xxx = ConversionUtil.ConvertFromUnixTimestamp(xx);
            //    origin = origin.AddSeconds(xx);
            //    var attacktime = origin.AddSeconds(x);
            //    var l = 1;

            //}
            var timeService = _loUAdapter.TimeService;
            var ds = (from x in _attacks
                      select new
                      {
                          TargetPlayerName = x.TargetPlayerName,
                          TargetCityName = x.TargetCityName,
                          AttackPlayerName = x.AttackingPlayerName,
                          AttackCityName = x.AttackingCityName,
                          AttackAllianceName = x.AttackingAllianceName,
                          AttackTime = ConversionUtil.ConvertFromUnixTimestamp(timeService.RefrencePoint / 1000).AddHours(timeService.ServerTimeZoneOffset).AddSeconds(x.es).ToString(), 
                          AttackType = x.AttackType
                      }).ToArray();

            
            grid_All.Columns.Clear();
            //grid_All.DataSource = null;
            grid_All.AutoGenerateColumns = false;
            grid_All.AutoSize = true;
            BindingSource bindingSource1 = new BindingSource();
            grid_All.DataSource = ds;

            DataGridViewColumn column = new DataGridViewTextBoxColumn
                                          {
                                            DataPropertyName = "TargetPlayerName",
                                            Name = "TargetPlayerName"
                                          };
          grid_All.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "TargetCityName",
                                             Name = "TargetCityName"
                                           };
          grid_All.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackPlayerName",
                                             Name = "AttackPlayerName"
                                           };
          grid_All.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackCityName",
                                             Name = "AttackCityName"
                                           };
          grid_All.Columns.Add(column4);

            DataGridViewColumn column5 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackTime",
                                             Name = "AttackTime"
                                           };
          grid_All.Columns.Add(column5);

            DataGridViewColumn column6 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackType",
                                             Name = "AttackType"
                                           };
          grid_All.Columns.Add(column6);

            DataGridViewColumn column7 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackAllianceName",
                                             Name = "AttackAllianceName"
                                           };
          grid_All.Columns.Add(column7);

            //string coords = "";
            //if (attack.TargetPlayerName == _loUAdapter.CurrentPlayer.Name)
            //{
            //    coords = (from x in Cities
            //              where x.Id.Equals(attack.TargetCityId)
            //              select x.Location).First();
            //}
            //else
            //{
            //    //have to find coords other way
            //    coords = "N/A";
            //}
            //StringBuilder attackData = new StringBuilder(attack.AttackingPlayerName)
            //  .Append("@")
            //  .Append(attack.AttackingAllianceName)
            //  .Append(" is attacking ")
            //  .Append(coords)
            //  .Append(" ")
            //  .Append(attack.TargetCityName)
            //  .Append(" (")
            //  .Append(attack.TargetPlayerName)
            //  .Append(") from ")
            //  .Append(attack.AttackingCityName)
            //  .Append(Environment.NewLine);
            //textBox1.Text = textBox1.Text + attackData;
        }

        private void FormatAttacksPlayer()
        {
            var timeService = _loUAdapter.TimeService;
            var ds = (from x in _attacks
                      where x.TargetPlayerName == _loUAdapter.CurrentPlayer.Name
                      select new
                      {
                          TargetPlayerName = x.TargetPlayerName,
                          TargetCityName = x.TargetCityName,
                          AttackPlayerName = x.AttackingPlayerName,
                          AttackCityName = x.AttackingCityName,
                          AttackAllianceName = x.AttackingAllianceName,
                          AttackTime = ConversionUtil.ConvertFromUnixTimestamp(timeService.RefrencePoint / 1000).AddHours(timeService.ServerTimeZoneOffset).AddSeconds(x.es).ToString(), // TODO Convert to actual server time
                          AttackType = x.AttackType
                      }).ToList();

            grid_Player.Columns.Clear();

            grid_Player.AutoGenerateColumns = false;
            grid_Player.AutoSize = true;
            BindingSource bindingSource1 = new BindingSource();
            if (ds.Count > 0)
            {
                grid_Player.DataSource = ds;
            }
            else
            {
                grid_Player.DataSource = null;
            }

            //DataGridViewColumn column = new DataGridViewTextBoxColumn();
            //column.DataPropertyName = "TargetPlayerName";
            //column.Name = "TargetPlayerName";
            //grid_Player.Columns.Add(column);

            DataGridViewColumn column2 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "TargetCityName",
                                             Name = "TargetCityName"
                                           };
          grid_Player.Columns.Add(column2);

            DataGridViewColumn column3 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackPlayerName",
                                             Name = "AttackPlayerName"
                                           };
          grid_Player.Columns.Add(column3);

            DataGridViewColumn column4 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackCityName",
                                             Name = "AttackCityName"
                                           };
          grid_Player.Columns.Add(column4);

            DataGridViewColumn column5 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackTime",
                                             Name = "AttackTime"
                                           };
          grid_Player.Columns.Add(column5);

            DataGridViewColumn column6 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackType",
                                             Name = "AttackType"
                                           };
          grid_Player.Columns.Add(column6);

            DataGridViewColumn column7 = new DataGridViewTextBoxColumn
                                           {
                                             DataPropertyName = "AttackAllianceName",
                                             Name = "AttackAllianceName"
                                           };
          grid_Player.Columns.Add(column7);
        }

        private void FormatAllianceSummaryTab()
        {
            var timeService = _loUAdapter.TimeService;
            txt_Summary.Text = "Player:\t City :\t # of Attacks @\t First Incoming" + Environment.NewLine;
            Dictionary<int, int> attackedCities = new Dictionary<int, int>();
            var incomingAttacksbyDateTime = from l in _attacks
                                            orderby l.es descending
                                            select l;
            foreach (var x in incomingAttacksbyDateTime)
            {
                if (!attackedCities.Keys.Contains(x.TargetCityId))
                {
                    attackedCities.Add(x.TargetCityId, x.es);
                }
                //txt_incoming.Text += x.TargetCity + " at " + x.ArrivalTime + " from " + x.SourcePlayer + Environment.NewLine;
            }

            foreach (var x in attackedCities)
            {
                int attackcount = (from i in incomingAttacksbyDateTime
                                   where i.TargetCityId.Equals(x.Key)
                                   select i).Count();
                var attackinfo = (from t in incomingAttacksbyDateTime
                                  where t.TargetCityId == x.Key
                                  select new
                                  {
                                      PlayerName = t.TargetPlayerName,
                                      CityName = t.TargetCityName, // TODO Get Coords from Public List / Lookup
                                      FirstAttack = ConversionUtil.ConvertFromUnixTimestamp(timeService.RefrencePoint / 1000).AddHours(timeService.ServerTimeZoneOffset).AddSeconds(t.es).ToString() 
                                  }).First();
                txt_Summary.Text += attackinfo.PlayerName + ":\t" + attackinfo.CityName + ":\t" + attackcount + " @\t" + attackinfo.FirstAttack + Environment.NewLine;
            }
        }

        private string FormatPlayerSummaryTab(bool withTime)
        {
            var timeService = _loUAdapter.TimeService;
            if (withTime)
            {
                txt_PlayerSummary.Text = "City :\t # of Attacks @\t First Incoming" + Environment.NewLine;
            }
            else
            {
                txt_PlayerSummary.Text = "City :\t # of Attacks" + Environment.NewLine;
            }
            Dictionary<int, int> attackedCities = new Dictionary<int, int>();
            var incomingAttacksbyDateTime = from l in _attacks
                                            where l.TargetPlayerName == _loUAdapter.CurrentPlayer.Name
                                            orderby l.es
                                            select l;
            foreach (var x in incomingAttacksbyDateTime)
            {
                if (!attackedCities.Keys.Contains(x.TargetCityId))
                {
                    attackedCities.Add(x.TargetCityId, x.es);
                }
                //txt_incoming.Text += x.TargetCity + " at " + x.ArrivalTime + " from " + x.SourcePlayer + Environment.NewLine;
            }

            foreach (var x in attackedCities)
            {
                int attackcount = (from i in incomingAttacksbyDateTime
                                   where i.TargetCityId.Equals(x.Key)
                                   select i).Count();
                var attackinfo = (from t in incomingAttacksbyDateTime
                                  where t.TargetCityId == x.Key
                                  select new
                                  {
                                      CityName = t.TargetCityName, // TODO Get Coords from Public List / Lookup
                                      FirstAttack = ConversionUtil.ConvertFromUnixTimestamp(timeService.RefrencePoint / 1000).AddHours(timeService.ServerTimeZoneOffset).AddSeconds(t.es).ToString()
                                  }).First();
                if (withTime)
                {
                    txt_PlayerSummary.Text += attackinfo.CityName + ":\t" + attackcount + " @\t" + attackinfo.FirstAttack + Environment.NewLine;

                }
                else
                {
                    txt_PlayerSummary.Text += attackinfo.CityName + ":\t" + attackcount + Environment.NewLine;
                }
            }
            return txt_PlayerSummary.Text;
        }

        private void cb_AuthRequired_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_AuthRequired.Checked)
            {
                txt_EmailUser.Visible = true;
                txt_EmailPass.Visible = true;
                lbl_pass.Visible = true;
                lbl_user.Visible = true;
            }
            else
            {
                txt_EmailUser.Visible = false;
                txt_EmailPass.Visible = false;
                lbl_pass.Visible = false;
                lbl_user.Visible = false;
            }
            Properties.Settings.Default.AuthRequired = cb_AuthRequired.Checked;
            Properties.Settings.Default.Save();
        }

        private void txt_EmailTo_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmailTo = txt_EmailTo.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_EmailFrom_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EmailFrom = txt_EmailFrom.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_SMTPServer_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SMTPServer = txt_SMTPServer.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_EmailUser_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AuthUserName = txt_EmailUser.Text;
            Properties.Settings.Default.Save();
        }

        private void txt_EmailPass_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AuthPassword = txt_EmailPass.Text;
            Properties.Settings.Default.Save();
        }

        private void cb_SendEmail_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SendEmail = cb_SendEmail.Checked;
            Properties.Settings.Default.Save();
            if (cb_SendEmail.Checked)
            {
                lbl_NotificationInterval.Visible = true;
                num_NotificationInterval.Visible = true;
                lbl_NotificationHelp.Visible = true;
            }
            else
            {
                lbl_NotificationInterval.Visible = false;
                num_NotificationInterval.Visible = false;
                lbl_NotificationHelp.Visible = false;
            }
            //Properties.Settings.Default.NotificationInterval = num_NotificationInterval.Value.ToString();
            //Properties.Settings.Default.Save();
        }

        private void btn_TestEmail_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(Properties.Settings.Default.EmailFrom, Properties.Settings.Default.EmailTo, "Test Successful", DateTime.Now.ToShortTimeString() + "\r\nThis is a test from PS-LOU Notifier Plugin");
                SmtpClient client = new SmtpClient(Properties.Settings.Default.SMTPServer);
                if (Properties.Settings.Default.SSL)
                {
                    client.EnableSsl = true;
                }
                else
                {
                    client.EnableSsl = false;
                }
                if (Properties.Settings.Default.AuthRequired)
                {
                    System.Net.NetworkCredential basicCrenntial = new System.Net.NetworkCredential(Properties.Settings.Default.AuthUserName, Properties.Settings.Default.AuthPassword);
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCrenntial;
                }
                client.Send(message);
                Logger.Log(message.Body);
            }
            catch (Exception exception)
            {
                lbl_emailerror.Text = exception.Message;
                Debug.Write(exception.Message);
            }
            finally
            {
                lbl_emailerror.Text = "Email Successfully Sent";
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            FormatAttacksAll();
            FormatAttacksPlayer();
            FormatAllianceSummaryTab();
            string x = FormatPlayerSummaryTab(true);
        }

        private void num_NotificationInterval_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.NotificationInterval = num_NotificationInterval.Value.ToString();
            Properties.Settings.Default.Save();
        }

        private void cb_SSL_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.SSL = cb_SSL.Checked;
            Properties.Settings.Default.Save();
        }


    }
}
