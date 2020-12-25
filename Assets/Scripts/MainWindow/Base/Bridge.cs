// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 15:23:31
// 挂载对象: port对象上
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class Bridge : MonoBehaviour
    {

        public delegate void SendArgument(object go);
        public event SendArgument SendArgumentEvent;

        public void Send(object go)
        {
            SendArgumentEvent(go);
        }


    }
}
