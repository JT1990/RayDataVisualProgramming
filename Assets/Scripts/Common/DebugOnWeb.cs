// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 16:54:08
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public static class DebugOnWeb
    {

        public static void Log(object msg)
        {
#if UNITY_EDITOR
            Debug.Log(msg);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }


        public static void LogWarning(object msg)
        {
#if UNITY_EDITOR
            Debug.LogWarning(msg);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }



        public static void LogError(object msg)
        {
#if UNITY_EDITOR
            Debug.LogError(msg);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }


        public static void LogFormat(string msg, params object[] args)
        {
#if UNITY_EDITOR
            Debug.LogFormat(msg, args);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }


        public static void LogWarningFormat(string msg, params object[] args)
        {
#if UNITY_EDITOR
            Debug.LogWarningFormat(msg, args);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }


        public static void LogErrorFormat(string msg, params object[] args)
        {
#if UNITY_EDITOR
            Debug.LogErrorFormat(msg, args);
#else   
            Debug.Log(msg);
            //在UI上Debug

#endif

        }
    }
}
