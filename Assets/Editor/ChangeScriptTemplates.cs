using UnityEngine;
using System.Collections;
using System.IO;

public class ChangeScriptTemplates : UnityEditor.AssetModificationProcessor
{
    // 添加脚本注释模板
    private static string str =
    "// ========================================================\r\n"
    + "// 描 述：\r\n"
    + "// 作 者：xzf \r\n"
    + "// 创建时间：#CreateTime#\r\n"
    + "// 版 本：v 1.0\r\n"
    + "// ========================================================\r\n";

    // 创建资源调用
    public static void OnWillCreateAsset(string path)
    {
        // 只修改C#脚本
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs"))
        {
            string allText = str;
            allText += File.ReadAllText(path);
            // 替换字符串为系统时间
            allText = allText.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            File.WriteAllText(path, allText);
        }
    }
}