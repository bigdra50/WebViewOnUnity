using System.Reflection;
using UnityEditor;

namespace Editor
{
    public class WebViewTweetDeck : EditorWindow
    {
        [MenuItem("Tools/TweetDeck")]
        static void Open()
        {
            var type = typeof(UnityEditor.Editor)
                .Assembly
                .GetType("UnityEditor.Web.WebViewEditorWindowTabs");

            var attr = BindingFlags.Public |
                       BindingFlags.Static |
                       BindingFlags.FlattenHierarchy;

            var methodInfo = type
                .GetMethod("Create", attr)
                .MakeGenericMethod(type);

            methodInfo.Invoke(null, new object[]
            {
                "deck",
                "https://tweetdeck.twitter.com/",
                300,    // 横幅(最小)
                300,    // 縦幅(最小)
                1000,    // 横幅(最大)
                1000    // 縦幅(最大)
            });
        }
    }
}
