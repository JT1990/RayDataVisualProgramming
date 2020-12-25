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
    public class PortModel
    {
        /// <summary>
        /// 对象本体
        /// </summary>
        public GameObject gameObject;

        /// <summary>
        /// 每个node默认有四个port: inRoutinePort , outRoutinePort , inParamterPort ,outParamterPort
        /// 可以根据需求自由配置,
        /// 在Show的情况下,才会显示和注册事件.
        /// </summary>
        public bool isShow=true;

        /// <summary>
        /// 输出LineType
        /// </summary>
        public LineType lineType;

        /// <summary>
        /// ParamPort可以接收的参数的列表
        /// </summary>
        public List<ParamType> receiveParamsType;

        /// <summary>
        /// ParamPort 接收的参数列表
        /// </summary>
        public List<object> receiveParams;

        /// <summary>
        /// ParamPort输出参数类型
        /// </summary>
        public ParamType outputParamType;

        /// <summary>
        /// ParamPort输出的参数
        /// </summary>
        public object outputParam;

        public List<LineRenderDrawer> connectLines;

        public PortModel()
        {

        }

        /// <summary>
        /// 当node不包含这个port,可以直接传入false进行隐藏操作
        /// </summary>
        /// <param name="isshow"></param>
        public PortModel(bool isshow)
        {
            this.isShow= isshow;
        }

       
    }
}
