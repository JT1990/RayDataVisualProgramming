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
    public class SelectObjectNode : ParameterNode
    {
        public GameObject nameText;
        [HideInInspector]
        public GameObject UserDefinedObject;


        public override void Start()
        {
            base.Start();
            nameText.GetComponent<Bridge>().SendArgumentEvent += GetGameobject;
        }

        private void GetGameobject(object go)
        {
            UserDefinedObject = (GameObject)go;
            nameText.GetComponent<Text>().text = UserDefinedObject.name;
            Debug.Log("用户定义的物体为 : " + go);
        }

    }
}
