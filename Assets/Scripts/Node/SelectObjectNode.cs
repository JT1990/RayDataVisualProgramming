// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 18:11:37
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
    public class SelectObjectNode : NodeBase
    {
        public GameObject nameText;
        public TransportationHub hub;
        public GameObject UserDefinedObject;

     

        public override void InitPortData()
        {
            inRoutinePort = new PortModel(false); 
            outRoutinePort = new PortModel(false);
            inParamterPort = new PortModel(false);

            outParamterPort = new PortModel();
            outParamterPort.outputParamType = ParamType.GameObject;
            outParamterPort.outputParam = UserDefinedObject;
           
        }

        public override void Awake()
        {
            base.Awake();
            //注册事件
            hub.SendArgumentEvent += GetGameobject;

        }

        private void GetGameobject(object go)
        {
            UserDefinedObject = (GameObject)go;
            nameText.GetComponent<Text>().text = UserDefinedObject.name;
            Debug.Log("用户定义的物体为 : " + go);
        }


        public override void SaveProgrammingToFile()
        {
            
        }
    }
}
