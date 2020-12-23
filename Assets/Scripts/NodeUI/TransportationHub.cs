// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/22 15:05:27
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class TransportationHub : MonoBehaviour
    {
        public delegate void SendArgument(object go);
        public event SendArgument SendArgumentEvent;
 
        public void Send(object go)
        {
            SendArgumentEvent(go);
        }
       
    }
}
