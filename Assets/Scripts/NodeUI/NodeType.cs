// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/18 16:20:20
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Raydata.NodeGraph
{
    public enum NodeType
    {
        //C# 常用数据类型
        String,
        Int,
        Float,
        Double,
        Long,
        List,
        Array,

        //Unity 常用数据类型
        GameObject,
        Transform,
        Vector3,
        Vector2,


    }
}
