// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 16:11:29
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
    public class RoutineNode : Node
    {
        public Port inRoutinePort;
        public Port outRoutinePort;
        public Port inParameterPort;
        public Port outParameterPort;

        public virtual void Start()
        {

            inRoutinePort=new Port(this, PropertyType.Routine, IOType.INPUT);
            outRoutinePort = new Port(this, PropertyType.Routine, IOType.OUTPUT);
            inParameterPort = new Port(this, PropertyType.Paramter, IOType.INPUT);
            outParameterPort = new Port(this, PropertyType.Paramter, IOType.OUTPUT);

            FindPort(inRoutinePort, "RoutineGroup/RoutineInPort");
            FindPort(outRoutinePort, "RoutineGroup/RoutineOutPort");
            FindPort(inParameterPort, "ParameterGroup/ParameterInPort");
            FindPort(outParameterPort, "ParameterGroup/ParameterOutPort");

            if(inRoutinePort.isShow)
                EventTriggerListener.Get(inRoutinePort.gameObject).onClick += In_Routine_Port_OnClick;
            if(outRoutinePort.isShow)
                EventTriggerListener.Get(outRoutinePort.gameObject).onClick += Out_Routine_Port_OnClick;
            if(inParameterPort.isShow)
                EventTriggerListener.Get(inParameterPort.gameObject).onClick += In_Parameter_Port_OnClick;
            if(outParameterPort.isShow)
                EventTriggerListener.Get(outParameterPort.gameObject).onClick += Out_Parameter_Port_OnClick;

        }

        private void In_Routine_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(inRoutinePort);
        }

        private void Out_Routine_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(outRoutinePort);
        }

        private void In_Parameter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(inParameterPort);
        }

        private void Out_Parameter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(outParameterPort);
        }
    }


}
