using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
public class ScriptTemplatesEditor : UnityEditor.AssetModificationProcessor {

    private static string autorCreat = SystemInfo.deviceName;
    private static string templatepath = "Assets/Editor/ScriptTemplates.cs";

    // 创建资源调用
    public static void OnWillCreateAsset (string path) {
        // 只修改C#脚本
        path = path.Replace (".meta", "");
        if (!path.EndsWith(".cs")) return;
        //避免已经创建的脚本再次修改/移动时会被重置
        if(File.ReadAllText(path).Contains("创建者")) return;
        var allText = File.ReadAllText(templatepath); 
        switch (autorCreat) {
            case "DESKTOP-5NBUIJ6":
                allText = allText.Replace("autorCreat", "张志远");
                break;
            case "DESKTOP-F0DS3UB":
                allText = allText.Replace("autorCreat", "魏国栋");
                break;
        }

        // 替换字符串为系统时间
        allText = allText.Replace ("#CreateTime#", DateTime.Now.ToString ("yyyy/MM/dd HH:mm:ss"));
        allText = allText.Replace ("__ScriptTemplates", path.Split('/')[path.Split('/').Length-1].Split('.')[0]);

        File.WriteAllText (path, allText);
        AssetDatabase.Refresh ();
    }
}
