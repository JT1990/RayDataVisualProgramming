// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 15:30:09
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
    public class ParameterPort : Port
    {
        public ParameterPort(Node belongToNode,  PropertyType property, IOType iO, bool isShow = true) : base(belongToNode, property, iO, isShow)
        {
        }
    }
}
