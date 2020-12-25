// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 17:16:18
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
    public enum ParameterType
    {
        GameObject,
        Transform,
        String,
        Int,
        Double,
        Float,
        List,
        Object,
    }

    public enum PropertyType
    {
        None,
        /// <summary>
        /// 执行顺序的线
        /// </summary>
        Routine,
        /// <summary>
        /// 传递参数的线
        /// </summary>
        Paramter,
    }


    public enum NodeType
    {
        MonoBehaviour,
        Routine,
        Parameter
    }
}
