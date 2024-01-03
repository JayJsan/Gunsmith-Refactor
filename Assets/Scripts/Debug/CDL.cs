using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// My own Custom Debug Logger (CDL) class used to log debug messages to the console with more features and convenience.
/// </summary>
public class CDL
{
    private static string scriptColor = "#fff700";
    private static string normalColor = "#ffffff";
    private static string successColor = "#04ff00";
    private static string warningColor = "#ff9a00";
    private static string errorColor = "#ff0000";

    public static void Log<T>(object message, UnityEngine.Object context = null)
    {
        Type type = typeof(T);
        string scriptName = Color("[" + type + "] ", scriptColor);

        Debug.Log(scriptName + Color(message, normalColor), context);
    }

    public static void LogSuccess<T>(object message, UnityEngine.Object context = null)
    {
        Type type = typeof(T);
        string scriptName = Color("[" + type + "] ", scriptColor);
        string successfullyText = Bold(" successfully!");

        Debug.Log(scriptName + Color(message, normalColor) + $"<color={successColor}>{successfullyText}</color>", context);
    }

    public static void LogWarning<T>(object message, UnityEngine.Object context = null)
    {
        Type type = typeof(T);
        string scriptName = Color("[" + type + "] ", scriptColor);
        string warningText = Bold("WARNING!: ");
        Debug.LogWarning(scriptName + $"<color={warningColor}>{warningText}{Color(message, normalColor)}</color>", context);
    }

    public static void LogError<T>(object message, UnityEngine.Object context = null)
    {
        Type type = typeof(T);
        string scriptName = Color("[" + type + "] ", scriptColor);
        string errorText = Bold("ERROR!: ");

        Debug.LogError(scriptName + $"<color={errorColor}>{errorText}{Color(message, normalColor)}</color>", context);
    }

    // modified from https://forum.unity.com/threads/easy-text-format-your-debug-logs-rich-text-format.906464/
    public static string Bold(object str)
    {
        return "<b>" + str + "</b>";
    }
    public static string Color(object str, object clr)
    {
        return string.Format("<color={0}>{1}</color>", clr,str);
    }
    public static string Italic(object str)
    {
        return "<i>" + str + "</i>";
    }
    public static string Size(object str, int size)
    {
        return string.Format("<size={0}>{1}</size>",size,str);
    }
}
