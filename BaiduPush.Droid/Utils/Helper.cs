using System.Collections.Generic;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;

namespace BaiduPush.Droid.Utils
{
    public class Helper
    {
        public const string Tag = "PushDemoActivity";
        public const string ResponseMethod = "method";
        public const string ResponseContent = "content";
        public const string ResponseErrcode = "errcode";
        protected const string ActionLogin = "com.baidu.pushdemo.action.LOGIN";
        public const string ActionMessage = "com.baiud.pushdemo.action.MESSAGE";
        public const string ActionResponse = "bccsclient.action.RESPONSE";
        public const string ActionShowMessage = "bccsclient.action.SHOW_MESSAGE";
        protected const string ExtraAccessToken = "access_token";
        public const string ExtraMessage = "message";

        public static string LogStringCache = "";

        // 获取ApiKey
        public static string GetMetaValue(Context context, string metaKey)
        {
            Bundle metaData = null;
            string apiKey = null;
            if (context == null || metaKey == null)
            {
                return null;
            }
            try
            {
                ApplicationInfo ai = context.PackageManager.GetApplicationInfo(context.PackageName,
                    PackageInfoFlags.MetaData);
                if (null != ai)
                {
                    metaData = ai.MetaData;
                }
                if (null != metaData)
                {
                    apiKey = metaData.GetString(metaKey);
                }
            }
            catch (PackageManager.NameNotFoundException e)
            {

            }
            return apiKey;
        }

        public static List<string> GetTagsList(string originalText)
        {
            if (originalText == null || originalText.Equals(""))
            {
                return null;
            }
            List<string> tags = new List<string>();
            int indexOfComma = originalText.IndexOf(',');
            string tag;
            while (indexOfComma != -1)
            {
                tag = originalText.Substring(0, indexOfComma);
                tags.Add(tag);

                originalText = originalText.Substring(indexOfComma + 1);
                indexOfComma = originalText.IndexOf(',');
            }

            tags.Add(originalText);
            return tags;
        }

        public static string GetLogText(Context context)
        {
            ISharedPreferences sp = PreferenceManager
                    .GetDefaultSharedPreferences(context);
            return sp.GetString("log_text", "");
        }

        public static void SetLogText(Context context, string text)
        {
            ISharedPreferences sp = PreferenceManager.GetDefaultSharedPreferences(context);
            var editor = sp.Edit();
            editor.PutString("log_text", text);
            editor.Commit();
        }

    }
}