// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/24 16:16:15
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
    public class StartNode : NodeBase
    {

        public override void InitPortData()
        {
            inRoutinePort = new PortModel(false);
            inParamterPort = new PortModel(false);
            outParamterPort = new PortModel(false);

            outRoutinePort = new PortModel();
            outRoutinePort.lineType = LineType.Routine;
            gotoNodes = new List<NodeBase>();
        }

        public override void SaveProgrammingToFile()
        {

        }
    }
}
