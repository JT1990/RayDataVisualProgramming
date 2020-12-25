using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    /// <summary>
    /// 1.每个node只能有一个运行逻辑入口,但一个入口可以被多个node连接
    /// 2.每个node只能有一个运行逻辑出口,但一个出口可以连接多个node
    /// </summary>
    public abstract class NodeBase : MonoBehaviour
    {
        /// <summary>
        /// 运行逻辑入口
        /// </summary>
        public PortModel inRoutinePort;

        /// <summary>
        /// 接收的运行逻辑列表,可以有多个连接线
        /// </summary>
        public List<NodeBase> receiveNodes;

        /// <summary>
        /// 运行逻辑出口
        /// </summary>
        public PortModel outRoutinePort;

        /// <summary>
        /// 运行逻辑出口连接列表
        /// </summary>
        public List<NodeBase> gotoNodes;

        /// <summary>
        /// 接收参数的入口,在这个点上接收参数,等同于方法的参数
        /// </summary>
        public PortModel inParamterPort;

        /// <summary>
        /// 传出参数的出口,在这个点上传出参数,等同于方法的返回值
        /// </summary>
        public PortModel outParamterPort;

        /// <summary>
        /// 线的终点,点击箭头表示画线结束
        /// </summary>
        public GameObject dotImg;
          
        /// <summary>
        /// 
        /// </summary>
        [HideInInspector]
        public Transform curClickTrans;
        private LineRenderDrawer linedrawer;


        /// <summary>
        /// 初始化Node port类型 ::: [[必须]]
        /// </summary>
        /// 初始化模板
        ///inRoutinePort = new PortModel(false);
        ///outRoutinePort = new PortModel(false);
        ///inParamterPort = new PortModel(false);
        ///outParamterPort = new PortModel(false); 
        public abstract void InitPortData();

        /// <summary>
        /// 将逻辑储存为文本
        /// </summary>
        public abstract void SaveProgrammingToFile();
        
        
        public virtual void Awake()
        {
            InitPortData();
            FindObejctAddListener();
        }


        private void FindObejctAddListener()
        {
            if(transform.Find("RoutinePort/RoutineInPort"))
            {
                if(inRoutinePort == null) Debug.LogError("inRoutinePort 没有初始化");
                else
                {
                    inRoutinePort.gameObject = transform.Find("RoutinePort/RoutineInPort").gameObject;
                    inRoutinePort.gameObject.SetActive(inRoutinePort.isShow);
                    if(inRoutinePort.isShow)EventTriggerListener.Get(inRoutinePort.gameObject).onClick += In_Routine_Port_OnClick;
                }
            }

            if(transform.Find("RoutinePort/RoutineOutPort"))
            {
                if(outRoutinePort == null) Debug.LogError("RoutineOutPort 没有初始化");
                else
                {
                    outRoutinePort.gameObject = transform.Find("RoutinePort/RoutineOutPort").gameObject;
                    outRoutinePort.gameObject.SetActive(outRoutinePort.isShow);
                    if(outRoutinePort.isShow) EventTriggerListener.Get(outRoutinePort.gameObject).onClick += Out_Routine_Port_OnClick;
                }
            }

            if(transform.Find("ParamPort/ParamInPort"))
            {
                if(inParamterPort == null) Debug.LogError("ParamInPort 没有初始化");
                else
                {
                    inParamterPort.gameObject = transform.Find("ParamPort/ParamInPort").gameObject;
                    inParamterPort.gameObject.SetActive(inParamterPort.isShow);
                    if(inParamterPort.isShow) EventTriggerListener.Get(inParamterPort.gameObject).onClick += In_Paramter_Port_OnClick;
                }
            }

            if(transform.Find("ParamPort/ParamOutPort"))
            {
                if(outParamterPort == null) Debug.LogError("ParamOutPort 没有初始化");
                else
                {
                    outParamterPort.gameObject = transform.Find("ParamPort/ParamOutPort").gameObject;
                    outParamterPort.gameObject.SetActive(outParamterPort.isShow);
                    if(outParamterPort.isShow) EventTriggerListener.Get(outParamterPort.gameObject).onClick += Out_Paramter_Port_OnClick;
                }
            }

            if(!dotImg) dotImg = transform.Find("Dot").gameObject;
        }


        private void ClickAction(PortModel port, LineType linetype,NodeBase node)
        {
            if(LineRenderDrawerController.Instance.isEndClicked)
            {
                LineRenderDrawerController.Instance.curLine.isEndDraw = true;
                LineRenderDrawerController.Instance.curClickPort = port;
                LineRenderDrawerController.Instance.curLine.endPosition = port.gameObject.transform.position;
                LineRenderDrawerController.Instance.isEndClicked = false;
                switch(linetype)
                {
                    case LineType.Routine:
                        //通过当前绘制的线确定fromNode和toNode,并为Node添加相关的数据
                        LineRenderDrawerController.Instance.curLine.fromNode.gotoNodes.Add(this);
                        break;
                    case LineType.Paramter:

                        break;
                    default:
                        break;
                }
            
            }
            else
            {
                curClickTrans = port.gameObject.transform;
                linedrawer = new LineRenderDrawer(this, linetype);
                LineRenderDrawerController.Instance.AddLine(linedrawer,this);
            }
        }

        public virtual void In_Routine_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("InRoutine_PortBtn_OnClick");
            ClickAction(inRoutinePort,LineType.Routine,this);
        }

        public virtual void Out_Routine_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("OutRoutine_PortBtn_OnClick");
            ClickAction(outRoutinePort, LineType.Routine,this);
        }

        public virtual void In_Paramter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("InParamter_PortBtn_OnClick");
            ClickAction(inParamterPort, LineType.Paramter,this);
        }

        public virtual void Out_Paramter_Port_OnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("OutParamter_PortBtn_OnClick");
            ClickAction(outParamterPort, LineType.Paramter,this);
        }


      
    }



}
