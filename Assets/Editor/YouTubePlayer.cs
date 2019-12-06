using System.Reflection;
using UnityEditor;
using UnityEngine;

public class YouTubePlayer : ScriptableObject {

    static BindingFlags Flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy;
	
    [MenuItem("Tools/YouTubePlayer")]
    static void Open()
    {
        Debug.Log("Open");
        //var type = System.Type.GetType("UnityEditor.Web.WebViewEditorWindow");
        // UnityEditor.dllのUnityEditor.Web.WebViewEditorWindow型をリフレクションで所得
        var type = Assembly.Load("UnityEditor.dll").GetType("UnityEditor.Web.WebViewEditorWindowTabs");
        
        // WebViewEditorWindowのCreateメソッドの情報を取得
        var methodInfo = type.GetMethod ("Create", Flags);
        // CreateのGeneric型引数を指定
        methodInfo = methodInfo.MakeGenericMethod (type);
        // InvokeでCreateを呼び出す
        methodInfo.Invoke (null, new object[]{
            "YouTubePlayer",
            "D:/Dev/src/UnityProjects/_PlayGround/VideoPlayer/Assets/video.html", 
            427, 240, 1920, 1080
        });
    }
}
