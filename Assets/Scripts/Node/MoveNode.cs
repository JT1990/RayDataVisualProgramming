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
    public class MoveNode : NodeBase
    {
        public InputField inputField_X;
        public InputField inputField_y;
        public InputField inputField_z;

        public GameObject UserDefinedObject;
        public override void InitPortData()
        {
            inRoutinePort = new PortModel();
            outRoutinePort = new PortModel();
            inParamterPort = new PortModel();
            outParamterPort = new PortModel();
        }


        public override void In_Paramter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            base.In_Paramter_Port_OnClick(go, eventData);
            SelectObjectNode scr = (SelectObjectNode)LineRenderDrawerController.Instance.curLine.fromNode;
            this.UserDefinedObject = scr.UserDefinedObject;
        }

        public override void SaveProgrammingToFile()
        {
           
        }

    }
}
