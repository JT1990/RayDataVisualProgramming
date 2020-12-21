// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/18 16:13:20
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Raydata.NodeGraph
{
    public abstract class NodeBase 
    {
        #region 字段
        public string NodeName;

        /// <summary>
        /// 当前节点可以接收的参数类型
        /// </summary>
        public List<NodeType> canReceiveNodeTypes;

        /// <summary>
        /// 当前节点输出的参数类型
        /// </summary>
        public NodeType outputNodeType;

        #endregion


        #region 抽象方法
        /// <summary>
        /// 初始化数据 -- 当前节点可以接收哪些数据类型
        /// 根据这个list会过滤掉无法接收的Node
        /// </summary>
        public abstract void InitCanReceiveNodeTypeList();
        
        /// <summary>
        /// 设置当前节点输出的类型
        /// </summary>
        public abstract void SetOutPutNodeType();
       



        #endregion
    }
}
