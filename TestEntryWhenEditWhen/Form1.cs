using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using IMan = Com.Interwoven.WorkSite.iManage;
using Com.Interwoven.WorkSite.iManAdmin;
using AttributeID = Com.Interwoven.WorkSite.iManAdmin.AttributeID;
using AccessRight = Com.Interwoven.WorkSite.iManAdmin.AccessRight;

using static System.Diagnostics.Debug;

namespace TestEntryWhenEditWhen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //Note: Date issue with Trusted Login using Hosted DMS

            string serverName = txtServerName.Text;
            string libName = txtLibName.Text;
            bool trustLogin = chkTrustLogin.Checked;
            string userid = txtUserId.Text; //must set this - also used for Author and Operator and ACL list
            string password = txtPassword.Text; //Not required if use trusted login

            string localfilePath = txtFilePath.Text; //document full path to be imported
            //string docType;

            //prj_id in Projects table to put the document in
            string strFolderID = txtFolderID.Text;
            int folderID;
            if (!int.TryParse(strFolderID, out folderID))
                folderID = -1;

            NRTSession adminSes = null;
            INRTDatabase4 wsDatabase = null;

            IMan.IManSession ses = null;
            IMan.IManDatabase db = null;

            string detailMessage = string.Empty;
            string tempMessage = string.Empty;

            try
            {
                if (File.Exists(localfilePath) )
                {
                    //Create admin connection
                    Com.Interwoven.WorkSite.iManAdmin.NRTDMS admindms = new Com.Interwoven.WorkSite.iManAdmin.NRTDMS();
                    adminSes = admindms.Sessions.Add(serverName);

                    //Admin Connect                                        
                    if (trustLogin)
                        adminSes.TrustedLogin();
                    else
                        adminSes.Login(userid, password);

                    if (!adminSes.Connected)
                    {
                        WriteLine(String.Format(CultureInfo.CurrentCulture,
                                                      "Cannot connect (admin) to server {0} with trusted login: {1}, userId: {2}, password: {3}",
                                                      serverName, trustLogin, userid, password), "Error");
                    }
                    else
                    {
                        //WriteLine(String.Format(CultureInfo.CurrentCulture,
                        //                              "(Admin) Connected to server {0} using UserID: {1}", 
                        //                              adminSes.ServerName, adminSes.UserID), "Connected admin session");
                    }

                    //Getting library
                    int count = adminSes.Databases.Count;
                    int index = 1;
                    while (index <= count || wsDatabase != null)
                    {
                        INRTDatabase4 tempDb = (INRTDatabase4)adminSes.Databases.Item(index);
                        if (String.Compare(tempDb.Name, libName, true) == 0)
                        {
                            wsDatabase = tempDb;
                            break;
                        }
                        index++;
                    }

                    //Create connection
                    IMan.ManDMS dms = new IMan.ManDMS();
                    ses = dms.Sessions.Add(serverName);
                    //Connect                                        
                    if (trustLogin)
                        ses.TrustedLogin();
                    else
                        ses.Login(userid, password);

                    if (!ses.Connected)
                    {
                        //WriteLine(String.Format(CultureInfo.CurrentCulture,
                        //                              "Cannot connect to server {0} with trusted login: {1}, userId: {2}, password: {3}",
                        //                              serverName, trustLogin, userid, password), "Error");
                    }
                    else
                    {
                        //WriteLine(String.Format(CultureInfo.CurrentCulture,
                                                      //"Connected to server {0} using UserID: {1}",
                                                      //ses.ServerName, ses.UserID), "Connected session");
                        db = ses.Databases.ItemByName(libName);
                    }
                    
                    //Create document with date fields using IManAdmin's SupervisedImportIntoFolder
                    if (wsDatabase == null)
                    {
                        WriteLine(String.Format(CultureInfo.CurrentCulture,
                                                      "Cannot find the admin library {2} from server {0} using UserID: {1}",
                                                      adminSes.ServerName, adminSes.UserID, libName),
                                        "Error");
                    }
                    else if (db == null)
                    {
                        WriteLine(String.Format(CultureInfo.CurrentCulture,
                                                      "Cannot find the library {2} from server {0} using UserID: {1}",
                                                      ses.ServerName, ses.UserID, libName),
                                        "Error");
                    }
                    else
                    {
                        //local time
                        DateTime editdate = DateTime.Now;
                        DateTime entrydate = editdate.AddHours(-2.0);
                        DateTime customdate = editdate.AddHours(-5.0);
                        DateTime sysEditDate = editdate.AddDays(-1.0);
                        DateTime sysEntryDate = sysEditDate.AddHours(-2.0);

                        tempMessage = String.Format(CultureInfo.CurrentCulture,
                                                      "Local times\nEdit date: {0}\nEntry date: {1}\nSystem edit date: {2}\nSystem entry date: {3}\n"
                                                      + "Profile date: {4}\nCustom Date: {5}\n",
                                                      editdate, entrydate, sysEditDate, sysEntryDate, sysEditDate, customdate);
                        detailMessage = tempMessage;
                        WriteLine(tempMessage, "Local datetimes");

                        string utcFileEditDate = ConvertDateToUTC(editdate);
                        string utcFileEntryDate = ConvertDateToUTC(entrydate);
                        string utcCustomDate = ConvertDateToUTC(customdate);
                        string utcSysEditDate = ConvertDateToUTC(sysEditDate);
                        string utcSysEntryDate = ConvertDateToUTC(sysEntryDate);
                        tempMessage = String.Format(CultureInfo.CurrentCulture,
                                                      "Convert to UTC\nEdit date: {0}\nEntry date: {1}\nSystem edit date: {2}\nSystem entry date: {3}\n" +
                                                      "Profile date: {4}\nCustom Date: {5}\n",
                                                      utcFileEditDate, utcFileEntryDate, utcSysEditDate, utcSysEntryDate, utcSysEditDate, utcCustomDate);
                        detailMessage += Environment.NewLine + tempMessage;
                        WriteLine(tempMessage, "Set profile UTC datetimes");

                        IMan.IManDocumentType docType = db.GetDocumentTypeFromPath(localfilePath);

                        NRTProfileEx adminProfile = new NRTProfileEx();
                        {
                            adminProfile.SetAttributeByID(AttributeID.nrName, Path.GetFileName(localfilePath));
                            adminProfile.SetAttributeByID(AttributeID.nrDescription, localfilePath);
                            adminProfile.SetAttributeByID(AttributeID.nrClass, "DOC");
                            adminProfile.SetAttributeByID(AttributeID.nrType, docType.Name);
                            adminProfile.SetAttributeByID(AttributeID.nrAuthor, adminSes.UserID);
                            adminProfile.SetAttributeByID(AttributeID.nrOperator, adminSes.UserID);
                            adminProfile.SetAttributeByID(AttributeID.nrDefaultSecurity, "X"); //private
                            adminProfile.SetAttributeByID(AttributeID.nrSystemCreateDate, utcSysEntryDate);
                            adminProfile.SetAttributeByID(AttributeID.nrSystemModifyDate, utcSysEditDate);
                            adminProfile.SetAttributeByID(AttributeID.nrFileCreateDate, utcFileEntryDate);
                            adminProfile.SetAttributeByID(AttributeID.nrFileModifyDate, utcFileEditDate);
                            adminProfile.SetAttributeByID(AttributeID.nrEditProfileTime, utcSysEditDate);
                            adminProfile.SetAttributeByID(AttributeID.nrCustom21, utcCustomDate);

                            tempMessage = String.Format(CultureInfo.CurrentCulture,
                                                          "Profile Dates\nEdit date: {0}\nEntry date: {1}\nSystem edit date: {2}\nSystem entry date: {3}\n"
                                                          + "Profile edit date: {4}\nCustom Date: {5}\n",
                                                          adminProfile.GetAttributeByID(AttributeID.nrFileModifyDate),
                                                          adminProfile.GetAttributeByID(AttributeID.nrFileCreateDate),
                                                          adminProfile.GetAttributeByID(AttributeID.nrSystemModifyDate),
                                                          adminProfile.GetAttributeByID(AttributeID.nrSystemCreateDate),
                                                          adminProfile.GetAttributeByID(AttributeID.nrEditProfileTime),
                                                          adminProfile.GetAttributeByID(AttributeID.nrCustom21)
                                                        );
                            detailMessage += "\n" + tempMessage;
                            WriteLine(tempMessage, "Profile datetimes");
                        }
                        NRSupervisedImportSpecifier spec = NRSupervisedImportSpecifier.eNEW_DOC_NUM;
                        NRTTrusteeAccessList usersList = wsDatabase.CreateTrusteeAccessList();
                        usersList.Add("U", AccessRight.nrRightAll, "65535", adminSes.UserID, "", nrAccessLevel.eReadWrite);

                        NRTFieldList errs = new NRTFieldList();
                        string newDocnum;
                        string newVersion;

                        wsDatabase.SupervisedImportIntoFolder(localfilePath,
                                                              adminProfile,
                                                              usersList,
                                                              wsDatabase.CreateTrusteeAccessList(),
                                                              wsDatabase.CreateHistoryList(),
                                                              folderID,
                                                              spec,
                                                              true,
                                                              out newDocnum,
                                                              out newVersion,
                                                              out errs);

                        if (errs != null && errs.Count() > 0)
                        {
                            string errMsg = string.Empty;
                            index = 1;
                            while (index <= errs.Count())
                            {
                                errMsg += errs.ErrorAttributeId(index) + "-" + errs.ErrorCode(index).ToString();
                                index++;
                            }
                            WriteLine("Error checking in document: " + errMsg, "Error");
                        }
                        else
                        {
                            WriteLine(string.Format(CultureInfo.CurrentCulture,
                                                          "Created new document: #{0}v{1}", newDocnum, newVersion), "Successful check in");

                            //get document and check date fields
                            IMan.IManDocument doc = db.GetDocument( Convert.ToInt32(newDocnum), Convert.ToInt32(newVersion));
                            if (doc == null)
                            {
                                WriteLine(string.Format(CultureInfo.CurrentCulture,
                                                              "Error getting the document: #{0}v{1}", newDocnum, newVersion), "Error");
                            }
                            else
                            {
                                tempMessage = String.Format(CultureInfo.CurrentCulture,
                                                              "Document datetimes\nEdit date:\t\t\t{0}\nEntry date:\t\t{1}\nSystem edit date:\t{2}\nSystem entry date:\t{3}\n"
                                                              + "Profile edit date:\t{4}\nCustom Date:\t\t{5}\n",
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileFileModifyDate),
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileFileCreateDate),
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileSystemModifyDate),
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileSystemCreateDate),
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileEditProfileTime),
                                                              doc.GetAttributeByID(IMan.imProfileAttributeID.imProfileCustom21)
                                                            );
                                detailMessage += "Document v" + newDocnum + "_" + newVersion + "\n" + tempMessage;
                                WriteLine(detailMessage, "Details");
                            }
                        }
                    }
                } else
                {
                    WriteLine("Cannot find the document " + localfilePath, "Error");
                }
            } catch (Exception ex)
            {
                WriteLine(ex.ToString(), "Error");
            }
            finally
            {
                try
                {
                    if (adminSes != null && adminSes.Connected)
                    {
                        adminSes.Logout();
                    }
                    wsDatabase = null;

                    if (ses != null && ses.Connected)
                    {
                        ses.Logout();
                    }
                    db = null;
                }
                catch (COMException ex)
                {
                    throw (ex);
                    //do nothing
                }               
            }

        }

        private string ConvertDateToUTC(DateTime date)
        {
            string strDate = date.ToUniversalTime().ToString("MM/dd/yyyy HH:mm:ss").Replace(".", "/");
            return strDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //var sr = new StreamReader(openFileDlg.FileName);
                    //SetText(sr.ReadToEnd());
                    txtFilePath.Text = openFileDlg.FileName;
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }   
}
