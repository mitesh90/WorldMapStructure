using System;
using System.Globalization;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows;

using System.Drawing;
using System.Windows.Threading;

namespace WorldMap.WpfCommon
{
    public class clsImageUrisHelper
    {
        private static readonly string _imageUriStringFormat = "pack://application:,,,/WpfTimeManagement;component/Images/{0}";

        //Application Images
        private static readonly Uri _accessDeniedIconUri = GetImageUri("AccessDenied.png");
        private static readonly Uri _successIconUri = GetImageUri("Success.png");
        private static readonly Uri _deviceIconUri = GetImageUri("Device.png");
        private static readonly Uri _deviceInfoUri = GetImageUri("ic-feed-info.png");
        private static readonly Uri _fingerprintIconUri = GetImageUri("Fingerprint.png");
        private static readonly Uri _securityCameraIconUri = GetImageUri("SecurityCamera.jpg");
        private static readonly Uri _onIT1LogoUri = GetImageUri("OnIT1Logo.png");
        private static readonly Uri _warningIconUri = GetImageUri("Warning.png");
        private static readonly Uri _deviceFeedAlarmIconUri = GetImageUri("ic-feed-alarm.png");
        private static readonly Uri _deviceFeedIconUri = GetImageUri("ic-feed-player.png");
        private static readonly Uri _deviceFeedTranIconUri = GetImageUri("ic-feed-transaction.png");
        private static readonly Uri _monitorIconUri = GetImageUri("Monitor.png");
        private static readonly Uri _contactCardIconUri = GetImageUri("ContactCard.png");
        private static readonly Uri _enrollmentHandsUri = GetImageUri("Hands.png");
        private static readonly Uri _unPinIconUri = GetImageUri("Unpin.gif");
        private static readonly Uri _overrideIconUri = GetImageUri("ic-override.png");
        private static readonly Uri _noPhotoAvailableUri = GetImageUri("NoPhotoAvailable.png");
        private static readonly Uri _sliderMainUri = GetImageUri("SliderMain.png");
        private static readonly Uri _sliderMiddleUri = GetImageUri("SliderMiddle.png");
        private static readonly Uri _active = GetImageUri("active.png");
        private static readonly Uri _inActive = GetImageUri("inactive.png");
        private static readonly Uri _cog = GetImageUri("Cog.gif");
        private static readonly Uri _btnCollapse = GetImageUri("btn-collaps.png");
        private static readonly Uri _LoadFeed = GetImageUri("ic-load-feed.png");
        private static readonly Uri _Stop = GetImageUri("btn-stop.png");
        private static readonly Uri _SkipBegin = GetImageUri("btn-begin.png");
        private static readonly Uri _SkipBack = GetImageUri("btn-back.png");
        private static readonly Uri _Pause = GetImageUri("btn-pause.png");
        private static readonly Uri _Play = GetImageUri("btn-play.png");
        private static readonly Uri _SkipForward = GetImageUri("btn-forward.png");
        private static readonly Uri _SkipEnd = GetImageUri("btn-end.png");
        private static readonly Uri _liveFeed = GetImageUri("ic-live-feed.png");
        private static readonly Uri _RecordedFeed = GetImageUri("ic-record-feed.png");
        private static readonly Uri _Open = GetImageUri("ic-open-video.png");
        private static readonly Uri _Export = GetImageUri("ic-export-video.png");
        private static readonly Uri _Capture = GetImageUri("ic-capture-video.png");
        private static readonly Uri _PTZClose = GetImageUri("dir-close.png");
        private static readonly Uri _PTZBackgroung = GetImageUri("ic-direction-bg.png");

        private static readonly Uri _DirectionBox = GetImageUri("ic-direction-box.png");
        private static readonly Uri _softconExternalLinkActive = GetImageUri("ic-running.png");
        private static readonly Uri _softconExternalLinkLoading = GetImageUri("ic-checking.png");
        private static readonly Uri _softconExternalLinkStopped = GetImageUri("ic-stoped.png");

        private static readonly Uri _presetDelete = GetImageUri("pre-delete.gif");
        private static readonly Uri _presetLoad = GetImageUri("pre-load.gif");
        private static readonly Uri _presetNew = GetImageUri("pre-new.gif");
        private static readonly Uri _presetRotateOn = GetImageUri("pre-reset-main.gif");
        private static readonly Uri _presetRotateOff = GetImageUri("pre-reset.gif");
        private static readonly Uri _nancy = GetImageUri("nancy.gif");

        public static Uri PresetDelete { get { return _presetDelete; } }
        public static Uri PresetLoad { get { return _presetLoad; } }
        public static Uri PresetNew { get { return _presetNew; } }
        public static Uri PresetRotateOn { get { return _presetRotateOn; } }
        public static Uri PresetRotateOff { get { return _presetRotateOff; } }
        public static Uri Nancy { get { return _nancy; } }

        public static Uri SuccessIconUri { get { return _successIconUri; } }
        public static Uri PTZClose { get { return _PTZClose; } }
        public static Uri PTZBackgroung { get { return _PTZBackgroung; } }
        public static Uri DirectionBox { get { return _DirectionBox; } }

        public static Uri AccessDeniedIconUri { get { return _accessDeniedIconUri; } }
        public static Uri DeviceIconUri { get { return _deviceIconUri; } }
        public static Uri DeviceInfoUri { get { return _deviceInfoUri; } }
        public static Uri DeviceFeedIconUri { get { return _deviceFeedIconUri; } }
        public static Uri DeviceFeedTranIconUri { get { return _deviceFeedTranIconUri; } }
        public static Uri FingerprintIconUri { get { return _fingerprintIconUri; } }
        public static Uri SecurityCameraIconUri { get { return _securityCameraIconUri; } }
        public static Uri OnIT1LogoUri { get { return _onIT1LogoUri; } }

        public static Uri WarningIconUri { get { return _warningIconUri; } }
        public static Uri DeviceFeedAlarmIconUri { get { return _deviceFeedAlarmIconUri; } }
        public static Uri MonitorIconUri { get { return _monitorIconUri; } }
        public static Uri ContactCardIconUri { get { return _contactCardIconUri; } }
        public static Uri EnrollmentHandsUri { get { return _enrollmentHandsUri; } }
        public static Uri UnpinIconUri { get { return _unPinIconUri; } }
        public static Uri OverrideIconUri { get { return _overrideIconUri; } }
        public static Uri NoPhotoAvailableUri { get { return _noPhotoAvailableUri; } }
        public static Uri SliderMiddleUri { get { return _sliderMiddleUri; } }
        public static Uri SliderMainUri { get { return _sliderMainUri; } }
        public static Uri Active { get { return _active; } }
        public static Uri InActive { get { return _inActive; } }
        public static Uri Cog { get { return _cog; } }
        public static Uri BtnCollapse { get { return _btnCollapse; } }
        public static Uri Capture { get { return _Capture; } }
        public static Uri Export { get { return _Export; } }
        public static Uri Open { get { return _Open; } }
        public static Uri RecordedFeed { get { return _RecordedFeed; } }
        public static Uri LiveFeed { get { return _liveFeed; } }
        public static Uri SkipEnd { get { return _SkipEnd; } }
        public static Uri SkipForward { get { return _SkipForward; } }
        public static Uri Play { get { return _Play; } }
        public static Uri LoadFeed { get { return _LoadFeed; } }
        public static Uri Stop { get { return _Stop; } }
        public static Uri SkipBegin { get { return _SkipBegin; } }
        public static Uri SkipBack { get { return _SkipBack; } }
        public static Uri Pause { get { return _Pause; } }
        public static Uri SoftconExternalLinkActive { get { return _softconExternalLinkActive; } }
        public static Uri SoftconExternalLinkLoading { get { return _softconExternalLinkLoading; } }
        public static Uri SoftconExternalLinkStopped { get { return _softconExternalLinkStopped; } }

        /// <summary>
        /// Get Image Uri
        /// </summary>
        /// <param name="imageFileName">Image name with extension</param>
        /// <returns></returns>
        public static Uri GetImageUri(string imageFileName)
        {
            return new Uri(string.Format(CultureInfo.InvariantCulture, _imageUriStringFormat, imageFileName));
        }

        /// <summary>
        /// Get Image Source by image path
        /// </summary>
        /// <param name="ImagePath"></param>
        /// <returns></returns>
        public static ImageSource GetImageSource(string ImagePath)
        {
            ImageSourceConverter imgConv = new ImageSourceConverter();
            ImageSource imageSource = (ImageSource)imgConv.ConvertFromString(ImagePath);
            return imageSource;
        }

        /// <summary>
        /// Get Image Source by image path
        /// </summary>
        /// <param name="Image"></param>
        /// <returns></returns>
        public static ImageSource GetImageSource(byte[] Image)
        {
            ImageSourceConverter imgConv = new ImageSourceConverter();
            ImageSource imageSource = (ImageSource)imgConv.ConvertFrom(Image);
            return imageSource;
        }

        /// <summary>
        /// Get Bitmap image
        /// </summary>
        ///<param name="buffer">Image Buffer- byte array</param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(byte[] buffer)
        {
            BitmapImage mainImageBitmap;
            using (MemoryStream ms = new MemoryStream(buffer))
            {
                mainImageBitmap = GetBitmapImage(ms);
            }
            return mainImageBitmap;
        }

        /// <summary>
        /// Get Bitmap image
        /// </summary>
        ///<param name="ms">Image Stream</param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(Stream ms)
        {
            BitmapImage mainImageBitmap = new BitmapImage();
            mainImageBitmap.BeginInit();
            mainImageBitmap.CacheOption = BitmapCacheOption.OnLoad;
            mainImageBitmap.StreamSource = ms;

            mainImageBitmap.DecodePixelWidth = 300;
            mainImageBitmap.DecodePixelHeight = 272;

            mainImageBitmap.EndInit();
            mainImageBitmap.Freeze();

            return mainImageBitmap;
        }

        /// <summary>
        /// Get Bitmap image
        /// </summary>
        /// <param name="imageUri">Image Uri</param>
        /// <returns></returns>
        public static BitmapImage GetBitmapImage(Uri imageUri)
        {
            BitmapImage mainImageBitmap = new BitmapImage();
            mainImageBitmap.BeginInit();
            mainImageBitmap.CacheOption = BitmapCacheOption.OnLoad;
            mainImageBitmap.UriSource = imageUri;

            mainImageBitmap.DecodePixelWidth = 300;
            mainImageBitmap.DecodePixelHeight = 272;

            mainImageBitmap.EndInit();
            mainImageBitmap.Freeze();

            return mainImageBitmap;
        }
        //public static BitmapImage GetBitmapImage(byte[] byteArrayIn)//byteArrayToBitmapImage
        //{
        //    return clsImageUrisHelper.GetBitmapImage(byteArrayIn);

        //}
        public static byte[] GetByteArray(Uri imageUri)//GetByteArray
        {
            return GetByteArray(GetBitmapImage(imageUri));
        }
        public static byte[] GetByteArray(BitmapImage imageC)//GetByteArray
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.GetBuffer();
        }
    }
}
