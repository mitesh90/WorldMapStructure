namespace WorldMap.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>To define constants</summary>
    public static class AppConstants
    {
        /// <summary>The line break</summary>
        public const string LineBreak = "</br>";

        /// <summary>The page number</summary>
        public const string Pagenumber = "PageNo";

        /// <summary>The page size</summary>
        public const string Pagesize = "PageSize";

        /// <summary>The PageSize with Size 15</summary>
        public const string Pagesize2 = "PageSize_2";

        /// <summary>The max string length</summary>
        public const string Maxstringlength = "MaxStringLength";

        /// <summary>The max days length</summary>
        public const string Maxdayslength = "MaxDaysLength";

        /// <summary>The sort by</summary>
        public const string Sortby = "SortBy";

        /// <summary>The sort by order id</summary>
        public const string Sortbyorderid = "SortByOrderId";

        /// <summary>The sort by group</summary>
        public const string Sortbygroup = "GroupName";

        /// <summary>The sort by expiry date</summary>
        public const string Sortbyexpirydate = "ExpiryDate";

        /// <summary>The sort by assigned</summary>
        public const string Sortbyassigned = "UserName";

        /// <summary>The sort order</summary>
        public const string Sortorder = "SortOrder";

        /// <summary>The sort order asc</summary>
        public const string Sortorderasc = "SortOrderASC";

        /// <summary>The sort asc</summary>
        public const string Sortasc = "ASC";

        /// <summary>The temp upload path</summary>
        public const string Tempuploadpath = "TempUploadPath";

        /// <summary>The lw connection string</summary>
        public const string LwConnectionString = "LearnWiseEntities";

        /// <summary>The essay type sort by</summary>
        public const string Essaytypesortby = "EssayTypeSortBy";

        /// <summary>The meeting type identifier</summary>
        public const string MeetingTypeId = "105";

        /// <summary>The encrypt decrypt key</summary>
        public const string EncryptDecryptKey = "EncryptDecryptKey";

        /// <summary>The encrypt decrypt key</summary>
        public const string SecuritySaltSize = "SecuritySaltSize";

        /// <summary>The default identifier</summary>
        public const string DefaultId = "0";

        /// <summary>The lesson plan prefix</summary>
        public const string Lessonplanprefix = "LessonPlanPrefix";

        /// <summary>The file path</summary>
        public const string Filepath = "FilePath";

        /// <summary>The upload path</summary>
        public const string Uploadpath = "UploadPath";

        /// <summary>The route url</summary>
        public const string Routeurl = "RouteUrl";

        /// <summary>The blob url</summary>
        public const string Bloburl = "BlobUrl";

        /// <summary>The application key</summary>
        public const string AppKey = "SABasicKey";

        /// <summary>The application secret</summary>
        public const string AppSecret = "SABasicSecret";

        /// <summary>The business unit with hyphen</summary>
        public const string BusinessUnitWithHypen = "businessunit-";

        /// <summary>The user with hyphen</summary>
        public const string UserWithHypen = "user-";

        /// <summary>The client with hyphen</summary>
        public const string ClientWithHypen = "client-";

        /// <summary>The super admin</summary>
        public const string SuperAdminWithHypen = "superadmin-";

        /// <summary>The english_langcode</summary>
        public const string EnglishLangcode = "en-US";

        /// <summary>The japanse_langcode</summary>
        public const string JapanseLangcode = "ja-JP";

        /// <summary>The korean_langcode</summary>
        public const string KoreanLangcode = "ko-KR";

        /// <summary>The chinesesimplified_langcode</summary>
        public const string ChinesesimplifiedLangcode = "zh-CN";

        /// <summary>The chinesetraditional_langcode</summary>
        public const string ChinesetraditionalLangcode = "zh-TW";

        /// <summary>The spanish_langcode</summary>
        public const string SpanishLangcode = "es-ES";

        /// <summary>The french_langcode</summary>
        public const string FrenchLangcode = "fr-FR";

        /// <summary>The german_langcode</summary>
        public const string GermanLangcode = "de-DE";

        /// <summary>The italian_langcode</summary>
        public const string ItalianLangcode = "it-IT";

        /// <summary>The current culture</summary>
        public const string Currentculture = "CurrentCulture";

        /// <summary>The current user</summary>
        public const string Currentuser = "CurrentUser";

        /// <summary>The central_resource_filetypes</summary>
        public const string CentralResourceFiletypes = @"([a-zA-Z0-9\s_\\.\-:])+(.zip|.rar|.doc|.docx|.xls|.xlsx|.ppt|.pptx|.pdf|.mov|.mp4|.swf|.htm|.html)";

        /// <summary>The scorm_resource_filetypes</summary>
        public const string ScormResourceFiletypes = @"([a-zA-Z0-9\s_\\.\-:])+(.zip|.rar)";

        /// <summary>The superadmin_folder_name</summary>
        public const string SuperadminFolderName = "SuperAdmin";

        /// <summary>The unfolder_name</summary>
        public const string UnfolderName = "Default";

        /// <summary>The categories_name</summary>
        public const string CategoriesName = "My Folders";

        /// <summary>The library_folder_name</summary>
        public const string LibraryFolderName = "My Folders";

        /// <summary>The library_name</summary>
        public const string LibraryName = "Library";

        /// <summary>The favourites_folder_name</summary>
        public const string FavouritesFolderName = "Favorites";

        /// <summary>The recent_folder_name</summary>
        public const string RecentFolderName = "Recent Files";

        /// <summary>The Shared By Super Admin folder name</summary>
        public const string SharedbysuperadminFolderName = "Shared by Super Admin";

        /// <summary>The maxupload_file_size</summary>
        public const int MaxuploadFileSize = 1024;

        /// <summary>The maxupload_file_size</summary>
        public const string MaxuploadSizeType = "K";

        /// <summary>The scrom_upload_ path</summary>
        public const string ScromUploadPath = "LMS/ServiceProcessCourse.asp";

        /// <summary>The tin can file</summary>
        public const string Tincanfile = "tincan.xml";

        /// <summary>The scrom_file</summary>
        public const string ScromFile = "imsmanifest.xml";

        /// <summary>The directory_constant</summary>
        public const string DirectoryConstant = "D_";

        /// <summary>The file_hash_constant</summary>
        public const string FileHashConstant = "F_";

        public const string DirectoryMime = "directory";

        public const string ElfinderdateFormat = "MMMM dd, yyyy hh:mm";

        /// <summary>The scorm_resource_filetypes</summary>
        public const string Zipextension = ".zip";

        /// <summary>The other</summary>
        public const string Other = "Other";

        /// <summary>The phone length</summary>
        public const int PhoneLength = 7;

        /// <summary>The manage account</summary>
        public const string ManageAccount = "/Account/Manage?userId=";

        /// <summary>The manage account code</summary>
        public const string ManageAccountCode = "&code=";

        /// <summary>The PFX prefix</summary>
        public const string PfxPrefix = ".pfx";

        /// <summary>The forgot password text</summary>
        public const string ForgotPasswordText = "&isForgotPassword=true";

        /// <summary>The LRS bu identifier</summary>
        public const string LrsBuId = "buId";

        /// <summary>The LRS bu name</summary>
        public const string LrsBuName = "buName";

        /// <summary>The LRS end point</summary>
        public const string LrsEndPoint = "endPoint";

        /// <summary>The dateformate</summary>
        public const string Dateformate = "MM-dd-yyyy h:mm:ss tt";

        /// <summary>The dateonlyformate</summary>
        public const string Dateonlyformate = "MM-dd-yyyy";

        /// <summary>The dateonlyformate</summary>
        public const string Timeonlyformate = "HH:mm";

        /// <summary>The dashboard date display format</summary>
        public const string DashboardDateDisplayFormat = "MMM dd,yyyy";

        /// <summary>The allavailableformats</summary>
        public static readonly string[] Allavailableformats = {"M/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm tt",
                   "MM/dd/yyyy hh:mm:ss", "M/d/yyyy h:mm:ss",
                   "M/d/yyyy hh:mm tt", "M/d/yyyy hh tt",
                   "M/d/yyyy h:mm", "M/d/yyyy h:mm",
                   "MM/dd/yyyy hh:mm", "M/dd/yyyy hh:mm",
                               "MM/dd/yyyy hh:mm tt", "M/dd/yyyy hh:mm tt",
                               "M-d-yyyy h:mm:ss tt", "M-d-yyyy h:mm tt",
                   "MM-dd-yyyy hh:mm:ss", "M-d-yyyy h:mm:ss",
                   "M-d-yyyy hh:mm tt", "M-d-yyyy hh tt",
                   "M-d-yyyy h:mm", "M-d-yyyy h:mm",
                   "MM-dd-yyyy hh:mm", "M-dd-yyyy hh:mm",
                               "MM-dd-yyyy hh:mm tt", "M-dd-yyyy hh:mm tt"};

        /// <summary>The datedisplayformat</summary>
        public static string Datedisplayformat = "MM/dd/yyyy";
        public const string DefaultDatedisplayformat = "MMMM dd, yyyy";

        /// <summary>The usersidedatediplayformat</summary>
        public const string Usersidedatediplayformat = "MMM d,yyyy";

        /// <summary>The webex meeting date format</summary>
        public const string Webexmeetingdateformat = "{0:MM/dd/yyy HH:mm:ss}";

        /// <summary>One Hour's Minutes = 60</summary>
        public const short OneHourMinutes = 60;

        /// <summary>Percentage Symbol</summary>
        public const string PercentageText = " %";

        /// <summary>The colon_text</summary>
        public const string ColonText = ":";

        /// <summary>The userdatediplayformat</summary>
        public const string Userdatediplayformat = "{0:MMM d,yyyy}";

        /// <summary>The iltattachmentformat</summary>
        public const string Iltattachmentformat = "{0:yyyyMMddTHHmmss}";

        /// <summary>The phone pattern</summary>
        public const string PhonePattern = @"^([0-9\(\)\/\+ \-]*)$";

        /// <summary>The number and text pattern</summary>
        public const string NumberAndTextPattern = @"^(?=.*[0-9])[0-9 _ a-z A-Z]*$";

        /// <summary>The only text pattern</summary>
        public const string OnlyTextPattern = @"^[a-zA-Z ]*$";

        /// <summary>The email pattern</summary>
        public const string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        /// <summary>The domain pattern</summary>
        public const string DomainPattern = @"^(?:[-A-Za-z0-9]+\.)+[A-Za-z]{2,6}$";

        /// <summary>The date pattern</summary>
        public const string DatePattern = @"^((0?[13578]|10|12)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[01]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1}))|(0?[2469]|11)(-|\/)(([1-9])|(0[1-9])|([12])([0-9]?)|(3[0]?))(-|\/)((19)([2-9])(\d{1})|(20)([01])(\d{1})|([8901])(\d{1})))$";

        /// <summary>The numeric letter pattern</summary>
        public const string NumericLetterPattern = @"^[a-zA-Z0-9]+$";
        
        /// <summary>The azure storage connection string</summary>
        public const string AzureStorageConnectionString = "AzureStorageConnectionString";

        /// <summary>The media services account name</summary>
        public const string MediaServicesAccountName = "MediaServicesAccountName";

        /// <summary>The media services account key</summary>
        public const string MediaServicesAccountKey = "MediaServicesAccountKey";

        /// <summary>The queue name</summary>
        public const string QueueName = "QueueName";

        /// <summary>The queue count</summary>
        public const short QueueCount = 10;

        /// <summary>The BLOB URL</summary>
        public const string BlobUrl = "BlobUrl";

        /// <summary>The content expiry minutes</summary>
        public const string ContentExpiryMinutes = "ContentExpiryMinutes";

        /// <summary>The LRS service URL</summary>
        public const string LrsServiceUrl = "LRSServiceUrl";

        /// <summary>The LRS service end point</summary>
        public const string LrsServiceEndPoint = "LRSServiceEndPoint";

        /// <summary>The LRS route URL</summary>
        public const string LrsRouteUrl = "LRSRouteUrl";

        /// <summary>The super admin domain</summary>
        public const string SuperAdminDomain = "SuperAdminDomain";

        /// <summary>The is user name null</summary>
        public static bool IsUserNameNull;

        /// <summary>The administrator email</summary>
        public static string AdministratorEmail = "AdministratorEmail";

        /// <summary>The send grid API key</summary>
        public static string SendGridApiKey = "SendGridAPIKey";

        /// <summary>The encryption key</summary>
        public const string EncryptionKey = "#kl?+@<z";

        /// <summary>is sharding enable</summary>
        public const string IsShardingEnable = "IsShardingEnable";

        /// <summary>The impersonated</summary>
        public const string Impersonated = "Impersonated";

        /// <summary>The access denied</summary>
        public const string Accessdenied = "Access Denied";

        /// <summary>The certifcates floder name</summary>
        public const string CertifcatesFloderName = "certificates";

        /// <summary>The previous day</summary>
        public const int PreviousDay = -1;

        /// <summary>The previous password days</summary>
        public const string PreviousPasswordDays = "PreviousPasswordDays";

        /// <summary>The password expire days</summary>
        public const string PasswordExpireDays = "PasswordExpireDays";

        /// <summary>The logo path</summary>
        public const string LogoPath = "/Content/images/login-logo.png";

        /// <summary>The URL format</summary>
        public const string UrlFormat = "{0}://{1}.{2}";

        /// <summary>The WWW</summary>
        public const string Www = "www.";

        /// <summary>The COM</summary>
        public const string Com = ".com";

        /// <summary>The HTTP</summary>
        public const string Http = "http:";

        /// <summary>The HTTPS</summary>
        public const string Https = "https:";

        public const string Select = "Select";

        /// <summary>The sub domain count</summary>
        public const int SubDomainCount = 3;
        
    }
}