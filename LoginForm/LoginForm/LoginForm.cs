using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LoginForm
{
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
            Btn_Submit.Click += new EventHandler(SubmitButton_Click);
            Log.SetupLogFiles(@"c:\LoginLogs\", "LoginForm", 4);
        }
        private readonly string DbConString = ConfigurationManager.ConnectionStrings["employeeDB"].ToString();
        LoggerDLL.Logger Log = new LoggerDLL.Logger();
        string userName = "";

        private void Login()
        {
            bool isUserFound = false;
            bool isPasswordFound = false;
            userName = TxtBox_Username.Text;
            string password = TxtBox_Pword.Text;
            int userquery = 0;
            int passwordquery = 0;
            using (SqlConnection DbCon = new SqlConnection(DbConString))
            {
                SqlCommand usercmd = new SqlCommand();
                SqlCommand passwordcmd = new SqlCommand();
                usercmd.Connection = DbCon;
                passwordcmd.Connection = DbCon;
                usercmd.CommandText = "SELECT 1 FROM tb_Login WHERE Uname = @Uname";
                passwordcmd.CommandText = $"SELECT Password FROM tb_Login WHERE Uname = @Uname";
                usercmd.Parameters.AddWithValue("@Uname", userName);
                passwordcmd.Parameters.AddWithValue("@Uname", userName);
                try
                {
                    DbCon.Open();
                    if (Convert.ToInt16(usercmd.ExecuteScalar()) == 1)
                    {
                        if (Convert.ToString(passwordcmd.ExecuteScalar()) == password)
                        {
                            MessageBox.Show("Login Successful");
                            SetIsLoggedIn(userName, 1);
                            SetLoginTime(userName);
                            ResetFailedLoginAttempts(userName);
                        }
                        else
                        {
                            MessageBox.Show("Invalid Password");
                            SetFailedLoginAttempts(userName);
                            if (getFailedLoginAttempts(userName) == 3)
                            {
                                LockAccount(userName);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    DbCon.Close();
                }
            }
        }

        private void SetIsLoggedIn(string _userName, int isLoggedIn)
        {
            using (var dbCon = new SqlConnection(DbConString))
            {
                var dbCmd = new SqlCommand();
                dbCmd.CommandText = "update tb_Login set isLoggedIn = @isLoggedIn where Uname = @Uname";
                dbCmd.Parameters.AddWithValue("@isLoggedIn", isLoggedIn);
                dbCmd.Parameters.AddWithValue("@Uname", _userName);
                dbCmd.Connection = dbCon;

                try
                {
                    dbCon.Open();
                    dbCmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    dbCon.Close();
                }
            }
        }

        private void SetLoginTime(string _userName)
        {
            var LastLoggedInTime = DateTime.Now;
            using (var dbCon = new SqlConnection(DbConString))
            {
                var dbCmd = new SqlCommand();
                dbCmd.CommandText = "update tb_Login set LastLogInTime = @LastLogInTime where Uname = @Uname";
                dbCmd.Parameters.AddWithValue("@LastLogInTime", LastLoggedInTime);
                dbCmd.Parameters.AddWithValue("@Uname", _userName);
                dbCmd.Connection = dbCon;
                try
                {
                    dbCon.Open();
                    dbCmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    dbCon.Close();
                }
            }
        }

        private int getFailedLoginAttempts(string _userName)
        {
            int getLoggedInAttempts = 0;
            using (var dbCon = new SqlConnection(DbConString))
            {
                var dbCmd = new SqlCommand();
                dbCmd.CommandText = "select FailedLoginAttempts from tb_Login where Uname = @Uname";
                dbCmd.Parameters.AddWithValue("@Uname", _userName);
                dbCmd.Connection = dbCon;

                try
                {
                    dbCon.Open();
                    getLoggedInAttempts = Convert.ToInt16(dbCmd.ExecuteScalar());
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    dbCon.Close();
                }
            }
            return getLoggedInAttempts;
        }

        private void SetFailedLoginAttempts(string _userName)
        {
            int getFailedLoginAttemptCount = getFailedLoginAttempts(_userName);
            if (getFailedLoginAttemptCount < 3)
            {
                getFailedLoginAttemptCount += 1;
                using (var dbCon = new SqlConnection(DbConString))
                {
                    var dbCmd = new SqlCommand();
                    dbCmd.CommandText = "update tb_Login set FailedLoginAttempts = @FailedLoginAttempts where Uname = @Uname";
                    dbCmd.Parameters.AddWithValue("@FailedLoginAttempts", getFailedLoginAttemptCount);
                    dbCmd.Parameters.AddWithValue("@Uname", _userName);
                    dbCmd.Connection = dbCon;

                    try
                    {
                        dbCon.Open();
                        dbCmd.ExecuteNonQuery();
                    }
                    catch(Exception e)
                    {
                        Log.Error(e.ToString());
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
        }

        private void LockAccount(string _userName) //TODO set to public to be used by the admin form
        {
            if (getFailedLoginAttempts(_userName) >= 3)
            {
                using (var dbCon = new SqlConnection(DbConString))
                {
                    var dbCmd = new SqlCommand();
                    dbCmd.CommandText = "update tb_Login set isLocked = 1 where Uname = @Uname";
                    dbCmd.Parameters.AddWithValue("@Uname", _userName);
                    dbCmd.Connection = dbCon;

                    try
                    {
                        dbCon.Open();
                        dbCmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Log.Error(e.ToString());
                    }
                    finally
                    {
                        dbCon.Close();
                    }
                }
            }
        }

        private void ResetFailedLoginAttempts(string _userName) //TODO set to public to be used by the admin form
        {
            using (var dbCon = new SqlConnection(DbConString))
            {
                var dbCmd = new SqlCommand();
                dbCmd.CommandText = @"update tb_Login set FailedLogInAttempts = 0 where Uname = @Uname";
                dbCmd.Parameters.AddWithValue("@Uname", _userName);
                dbCmd.Connection = dbCon;

                try
                {
                    dbCon.Open();
                    dbCmd.ExecuteNonQuery();
                }
                catch(Exception e)
                {
                    Log.Error(e.ToString());
                }
                finally
                {
                    dbCon.Close();
                }
            }
        }

        public void SubmitButton_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
