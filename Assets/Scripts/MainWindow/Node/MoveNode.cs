// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 18:04:15
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class MoveNode : RoutineNode
    {
        public InputField inputField_X;
        public InputField inputField_y;
        public InputField inputField_z;
        public InputField inputField_time;
        [HideInInspector]
        public GameObject UserDefinedObject;



        


    }
}
