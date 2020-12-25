// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 16:11:38
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class ParameterNode : Node
    {
        public Port outParameterPort;

        public virtual void Start()
        {
            outParameterPort = new Port(this, PropertyType.Paramter, IOType.OUTPUT);
            FindPort(outParameterPort, "ParameterGroup/ParameterOutPort");

            if(outParameterPort.isShow)
                EventTriggerListener.Get(outParameterPort.gameObject).onClick += Out_Parameter_Port_OnClick;

        }

        private void Out_Parameter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(outParameterPort);
        }
    }
    
}
