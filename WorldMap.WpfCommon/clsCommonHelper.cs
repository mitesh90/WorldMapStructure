#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Diagnostics;
#endregion

namespace WorldMap.WpfCommon
{
    public class StringValueAttribute : System.Attribute
    {
        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

    public class clsCommonHelper
    {
        #region Variables
        private static double _timeDifference;
        private static DateTime _serverDateTime;
        #endregion

        #region Entities Name
        public const string TrustMasterSecurityEntities = "TrustMasterSecurityEntities";
        public const string DB_SOFTCON_DATAEntities = "DB_SOFTCON_DATAEntities";
        #endregion

        /// <summary>
        /// Get Server Datetime
        /// </summary>
        public static DateTime ServerDateTime
        {
            get
            {
                return DateTime.Now.AddMilliseconds(_timeDifference);
            }
            set
            {
                _serverDateTime = value;
                _timeDifference = (_serverDateTime - DateTime.Now).TotalMilliseconds;
            }
        }

        /// <summary>
        /// Convert to specific type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objVal"></param>
        /// <returns></returns>
        public static T ConvertTo<T>(object objVal)
        {
            if (typeof(T) == typeof(IPAddress))
            {
                throw new NotSupportedException("Conversion to IP Address is not supported");
            }
            if (objVal != null)
                return (T)Convert.ChangeType(objVal, typeof(T));
            if (typeof(T) == typeof(string))
                return (T)(object)string.Empty;
            return default(T);
        }

        /// <summary>
        /// Convert to IPAddress
        /// </summary>
        /// <param name="ipAddressValue">IPAddress</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public static IPAddress ConvertToIPAddress(object ipAddressValue)
        {
            IPAddress ipAddress;
            if (ipAddressValue == null || ipAddressValue.ToString().Trim().Length == 0 || !IPAddress.TryParse(ipAddressValue.ToString(), out ipAddress))
                throw new ArgumentNullException("IPAddress can not be null");
            return ipAddress;
        }

        public static MemoryStream GetMemoryStreamFromString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return null;
            MemoryStream m = new MemoryStream();
            StreamWriter sw = new StreamWriter(m);
            sw.Write(s);
            sw.Flush();
            return m;
        }


        /// <summary>
        /// Get string value from enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStringValuefromEnum(Enum value)
        {
            string output = null;
            Type type = value.GetType();
            {
                //Look for our 'StringValueAttribute' 
                //in the field's custom attributes
                FieldInfo fi = type.GetField(value.ToString());
                StringValueAttribute[] attrs =
                   fi.GetCustomAttributes(typeof(StringValueAttribute),
                                           false) as StringValueAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    output = attrs[0].Value;
                }
            }

            return output;
        }

        /// <summary>
        /// Get app configuration value
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="appKey">App Configuration Key</param>
        /// <returns>App configuration value in specified type</returns>
        /// <exception cref="ArgumentNullException">ArgumentNullException</exception>
        public static T GetAppConfig<T>(string appKey)
        {
            var objVal = System.Configuration.ConfigurationManager.AppSettings[appKey];

            if (objVal == null)
                throw new ArgumentNullException("Configuration key is not found.");
            return ConvertTo<T>(objVal);
        }
        /// <summary>
        /// Check IPAddress is valid or not
        /// </summary>
        /// <param name="ipAddress">IP Address</param>
        /// <returns></returns>
        public static bool IsValidIPAddress(string ipAddress)
        {
            System.Text.RegularExpressions.Regex ipRegex = new System.Text.RegularExpressions.Regex(@"^(([01]?\d\d?|2[0-4]\d|25[0-5])\.){3}([01]?\d\d?|25[0-5]|2[0-4]\d)$");
            return ipRegex.IsMatch(ipAddress);
        }
        /// <summary>
        /// Get Local IP Address
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {
            var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Ping specified IP
        /// </summary>
        /// <param name="ipAddress">IPAddress</param>
        /// <param name="pingTimeoutInMS">Ping TImeout in milliseconds</param>
        ///<exception cref="SocketException">SocketException</exception>
        ///<exception cref="Exception">Exception</exception>
        public static PingReply MakePing(IPAddress ipAddress, int pingTimeoutInMS)
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    return ping.Send(ipAddress, pingTimeoutInMS);
                }
            }
            catch (SocketException sEx)
            {
                throw sEx;
                //LogWriter.WriteLogEntry(string.Format("Failed to ping-{0}{1}Error-{2}", ipAddress.ToString(), Environment.NewLine, sEx.Message), LogWriter.Modules.SecurityManager, System.Diagnostics.EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                throw ex;
                //LogWriter.WriteLogEntry(string.Format("Failed to ping-{0}{1}Error-{2}", ipAddress.ToString(), Environment.NewLine, ex.Message), LogWriter.Modules.SecurityManager, System.Diagnostics.EventLogEntryType.Error);
            }
        }


        /// <summary>
        /// Function to create a file is does not exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileData"></param>
        public static void CreateFileIfNotExist(string fileName, byte[] fileData)
        {
            if (!File.Exists(fileName))
            {
                //Not exists then create it from database                                
                string directoryPhysical = Path.GetDirectoryName(fileName);
                if (directoryPhysical != null && !Directory.Exists(directoryPhysical))
                    Directory.CreateDirectory(directoryPhysical);
                File.WriteAllBytes(fileName, fileData.ToArray());
            }
        }

        /// <summary>
        /// Bind model combo
        /// </summary>
        public static void BindComboBox(ref ComboBox combo, dynamic dataSource, string displayMemberPath, string selectedValuePath, string extraText, string extraValue)
        {
            if (extraText != String.Empty)
            {
                var type = dataSource[0].GetType();
                string[] args = { extraText, extraValue };
                var obj = Activator.CreateInstance(type, args);
                dataSource.Add(obj);
            }
            combo.DisplayMemberPath = displayMemberPath;
            combo.SelectedValuePath = selectedValuePath;
            combo.DataContext = dataSource;
        }

        public static Color GetColorFromHexString(string s)
        {
            byte a = Convert.ToByte("FF", 16);//Alpha should be 255
            byte r = Convert.ToByte(s.Substring(0, 2), 16);
            byte g = Convert.ToByte(s.Substring(2, 2), 16);
            byte b = Convert.ToByte(s.Substring(4, 2), 16);
            return Color.FromArgb(a, r, g, b);
        }
        /// <summary>
        /// Create Tab Item
        /// </summary>
        /// <param name="tabHeaderIconUri">Header Icon Uri</param>
        /// <param name="tooltip">Tooltip Text</param>
        /// <param name="content">Content control</param>
        /// <returns></returns>
        public static TabItem CreateTabItem(Uri tabHeaderIconUri, string tooltip, Control content)
        {
            Image imgHeader = new Image();
            imgHeader.Height = 22;
            imgHeader.Source = new BitmapImage(tabHeaderIconUri);
            imgHeader.ToolTip = tooltip;

            Border brd = new Border();
            brd.BorderThickness = new Thickness(0, 0, 0, 1);
            brd.BorderBrush = new SolidColorBrush(GetColorFromHexString("c1c1c1"));
            brd.Height = (double)40;
            brd.Width = (double)40;
            brd.Margin = new Thickness(0);
            brd.Padding = new Thickness(0);

            Grid grd1 = new Grid();
            grd1.Children.Add(imgHeader);
            brd.Child = grd1;

            TabItem item = new TabItem();
            item.Header = brd;
            item.Content = content;
            return item;
        }

        /// <summary>
        /// Convert date time to relative time
        /// </summary>
        /// <param name="dt">DateTIme</param>
        /// <returns></returns>
        public static string ConvertToRelativeTime(DateTime dt)
        {
            var ts = ServerDateTime - dt;
            var delta = ts.TotalSeconds;

            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;
            if (delta < 0)
            {
                return "not yet";
            }
            if (delta < 1 * MINUTE)
            {
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";
            }
            if (delta < 2 * MINUTE)
            {
                return "a minute ago";
            }
            if (delta < 45 * MINUTE)
            {
                return ts.Minutes + " minutes ago";
            }
            if (delta < 90 * MINUTE)
            {
                return "an hour ago";
            }
            if (delta < 24 * HOUR)
            {
                return ts.Hours + " hours ago";
            }
            if (delta < 48 * HOUR)
            {
                return "yesterday";
            }
            if (delta < 30 * DAY)
            {
                return ts.Days + " days ago";
            }
            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        //public static BitmapImage byteArrayToBitmapImage(byte[] byteArrayIn)
        //{
        //    return clsImageUrisHelper.GetBitmapImage(byteArrayIn);


        //}

        //public static byte[] bitmapImageToByteArray(BitmapImage imageC)
        //{
        //    MemoryStream memStream = new MemoryStream();
        //    JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        //    encoder.Frames.Add(BitmapFrame.Create(imageC));
        //    encoder.Save(memStream);
        //    return memStream.GetBuffer();
        //}


        /// <summary>
        /// Get List of connection strings
        /// </summary>
        /// <returns></returns>
        public static List<string> GetConnectionStrings()
        {
            var connectionStrings = new List<string>();
            connectionStrings.Add("DB_SOFTCON_DATAEntities");
            connectionStrings.Add("TrustMasterSecurityEntities");
            return connectionStrings;
        }

        /// <summary>
        /// Get 3D Point from specified arguments
        /// </summary>
        /// <param name="x">X Coordinate</param>
        /// <param name="y">Y Coordinate</param>
        /// <param name="z">Z Coordinate</param>
        /// <returns></returns>
        public static System.Windows.Media.Media3D.Point3D Get3DPoint(decimal? x, decimal? y, decimal? z)
        {
            var point3D = new System.Windows.Media.Media3D.Point3D();
            if (x.HasValue)
                point3D.X = Convert.ToDouble(x.Value);
            if (y.HasValue)
                point3D.Y = Convert.ToDouble(y.Value);
            if (z.HasValue)
                point3D.Z = Convert.ToDouble(z.Value);
            return point3D;
        }

        internal static string GetDeviceModelDirectoryName()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            exePath = GetBackgroundWorkerDirPath(exePath);
            return exePath;
            //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        public static string GetBackgroundWorkerDirPath(string dirPath)
        {
            var temp = dirPath.Replace("TrustMasterSecurity.Client", "TrustMasterSecurity.BackgroundWorker");
            return temp;
        }
    }
}
