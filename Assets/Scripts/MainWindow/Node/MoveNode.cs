// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 18:04:15
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using DG.Tweening;
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


        private float x, y, z;
        private float duration;
        public override void Start()
        {
            base.Start();
            inputField_X.onEndEdit.AddListener(inputField_X_OnEndEdit);
            inputField_y.onEndEdit.AddListener(inputField_Y_OnEndEdit);
            inputField_z.onEndEdit.AddListener(inputField_Z_OnEndEdit);
            inputField_time.onEndEdit.AddListener(inputField_Time_OnEndEdit);
        }

        private void inputField_X_OnEndEdit(string arg0)
        {
            x = float.Parse(arg0);
        }

        private void inputField_Y_OnEndEdit(string arg0)
        {
            y = float.Parse(arg0);
        }

        private void inputField_Z_OnEndEdit(string arg0)
        {
            z = float.Parse(arg0);
        }

        private void inputField_Time_OnEndEdit(string arg0)
        {
            duration = float.Parse(arg0);
        }

        public override void HandleNodeAction()
        {
            UserDefinedObject = ((SelectObjectNode)inParameterPort.belongToLine.inPort.belongToNode).UserDefinedObject;
            Debug.Log(UserDefinedObject.name);
            UserDefinedObject.transform.DOMove(new Vector3(x, y, z), duration);
        }
    }
}
