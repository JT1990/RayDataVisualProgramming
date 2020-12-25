// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/24 14:46:20
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

    public class Port
    {
        /// <summary>
        /// 对象本体
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// 对象transform
        /// </summary>
        public Transform transform { get => gameObject.transform; }

        public Node belongToNode;
        /// <summary>
        /// 可以根据需求自由配置,
        /// 在Show的情况下,才会显示和注册事件.
        /// </summary>
        public bool isShow=true;

        /// <summary>
        ///  表明是Routine还是Parameter
        /// </summary>
        public PropertyType  property { get; private set; }
  
        /// <summary>
        /// 表明是入口还是出口
        /// </summary>
        public IOType  IO;

        /// <summary>
        /// Node和Port通信桥
        /// </summary>
        public Bridge bridge;

        public Description description;

        public object receiveParameter;
        
        public object outputParameter;

        /// <summary>
        /// 连接port和node的通信
        /// </summary>
        public virtual void BridgeConnect() { }

        public Port(Node belongToNode, PropertyType property, IOType iO, bool isShow=true)
        {
            this.belongToNode = belongToNode;
            this.property = property;
            this.IO = iO;
            this.isShow = isShow;
        }
    }

    public enum IOType
    {
        NONE,
        INPUT,
        OUTPUT
    }
}
