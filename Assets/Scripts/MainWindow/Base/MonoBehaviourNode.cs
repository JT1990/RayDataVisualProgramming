// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 16:29:45
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
    public class MonoBehaviourNode : Node
    {
        public RoutinePort outRoutinePort;

        public virtual void Start()
        {
            outRoutinePort = new RoutinePort(this, PropertyType.Routine, IOType.OUTPUT);
            FindPort(outRoutinePort, "RoutineGroup/RoutineOutPort");
            if(outRoutinePort.isShow)
                EventTriggerListener.Get(outRoutinePort.gameObject).onClick += Out_Routine_Port_OnClick;
        }

        public virtual void Out_Routine_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            PortOnClick(outRoutinePort);
        }
   }
}
