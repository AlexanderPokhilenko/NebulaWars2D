#if UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SmartMergeRegistrar
{
    private const int Version = 1;
    private static string VersionKey = $"{Version}_{Application.unityVersion}";
    private const string SmartMergeRegistratorEditorPrefsKey = "smart_merge_installed";

    private static string ExecuteGitWithParams(string param)
    {
        var processInfo = new System.Diagnostics.ProcessStartInfo("git");

        processInfo.UseShellExecute = false;
        processInfo.WorkingDirectory = Environment.CurrentDirectory;
        processInfo.RedirectStandardOutput = true;
        processInfo.RedirectStandardError = true;
        processInfo.CreateNoWindow = true;

        var process = new System.Diagnostics.Process();
        process.StartInfo = processInfo;
        process.StartInfo.FileName = "git";
        process.StartInfo.Arguments = param;
        process.Start();
        process.WaitForExit();

        if (process.ExitCode != 0)
            throw new Exception(process.StandardError.ReadLine());

        return process.StandardOutput.ReadLine();
    }

    [MenuItem("Tools/Git/SmartMerge registration")]
    static void SmartMergeRegister()
    {
        try
        {
            string unityYamlMergePath = EditorApplication.applicationContentsPath + "/Tools" + "/UnityYAMLMerge.exe";
            ExecuteGitWithParams("config merge.unityyamlmerge.name \"Unity SmartMerge (UnityYamlMerge)\"");
            ExecuteGitWithParams($"config merge.unityyamlmerge.driver \"\\\"{unityYamlMergePath}\\\" merge -h -p --force --fallback none %O %B %A %A\"");
            ExecuteGitWithParams("config merge.unityyamlmerge.recursive binary");
            EditorPrefs.SetString(SmartMergeRegistratorEditorPrefsKey, VersionKey);
            Debug.Log($"Succesfuly registered UnityYAMLMerge with path {unityYamlMergePath}");
        }
        catch (Exception e)
        {
            Debug.Log($"Fail to register UnityYAMLMerge with error: {e}");
        }
    }

    //Unity calls the static constructor when the engine opens
    static SmartMergeRegistrar()
    {
        string installedVersionKey = EditorPrefs.GetString(SmartMergeRegistratorEditorPrefsKey);
        if (installedVersionKey != VersionKey)
        {
            SmartMergeRegister();            
        }
    }
}

#endif