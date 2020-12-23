using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class NodeUIBase : MonoBehaviour
    {
        public GameObject inRoutinePortBtn;

        public GameObject outRoutinePortBtn;


        /// <summary>
        /// 接收参数的入口,在这个点上接收参数,等同于方法的参数
        /// </summary>
        public GameObject inParamterPortBtn;

        /// <summary>
        /// 传出参数的出口,在这个点上传出参数,等同于方法的返回值
        /// </summary>
        public GameObject outParamterPortBtn;

        /// <summary>
        /// 线的终点,点击箭头表示画线结束
        /// </summary>
        public GameObject dotImg;
          
        /// <summary>
        /// 
        /// </summary>
        [HideInInspector]
        public PortType startClickPortType;
        [HideInInspector]
        public PortType endClickPortType;
        [HideInInspector]
        public Transform curClickTrans;
        private LineRenderDrawer linedrawer;

        public virtual void Start()
        {
            FindObejct();
            AddListener();
        }


        private void FindObejct()
        {
            if(!inRoutinePortBtn) inRoutinePortBtn = transform.Find("RoutinePort/RoutineInPort").gameObject;
            if(!outRoutinePortBtn) outRoutinePortBtn = transform.Find("RoutinePort/RoutineOutPort").gameObject;

            if(!inParamterPortBtn) inParamterPortBtn = transform.Find("ParamPort/ParamInPort").gameObject;
            if(!outParamterPortBtn) outParamterPortBtn = transform.Find("ParamPort/ParamOutPort").gameObject;

            if(!dotImg) dotImg = transform.Find("ParamPort/Dot").gameObject;
        }

        private void AddListener()
        {
            EventTriggerListener.Get(inRoutinePortBtn).onClick += InRoutine_PortBtn_OnClick;
            EventTriggerListener.Get(outRoutinePortBtn).onClick += OutRoutine_PortBtn_OnClick;

            EventTriggerListener.Get(inParamterPortBtn).onClick += InParamter_PortBtn_OnClick;
            EventTriggerListener.Get(outParamterPortBtn).onClick += OutParamter_PortBtn_OnClick;

            EventTriggerListener.Get(inRoutinePortBtn).onEnter += InRoutine_PortBtn_OnEnter;
            EventTriggerListener.Get(outRoutinePortBtn).onEnter += OutRoutine_PortBtn_OnEnter;

            EventTriggerListener.Get(inParamterPortBtn).onEnter += InParamter_PortBtn_OnEnter;
            EventTriggerListener.Get(outParamterPortBtn).onEnter += OutParamter_PortBtn_OnEnter;
        }

        private void InRoutine_PortBtn_OnClick(GameObject go, PointerEventData eventData)
        {

        }

        private void OutRoutine_PortBtn_OnClick(GameObject go, PointerEventData eventData)
        {
            
        }

        private void InParamter_PortBtn_OnClick(GameObject go, PointerEventData eventData)
        {
         
        }

        private void OutParamter_PortBtn_OnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("OutParamter_PortBtn_OnClick");
            curClickTrans = outParamterPortBtn.transform;
            startClickPortType = PortType.ParamterOutPort;
            linedrawer = new LineRenderDrawer(this);
            LineRenderDrawerController.Instance.AddLine(linedrawer);
        }

        private void InRoutine_PortBtn_OnEnter(GameObject go, PointerEventData eventData)
        {
            
        }

        private void OutRoutine_PortBtn_OnEnter(GameObject go, PointerEventData eventData)
        {
           
        }

        private void InParamter_PortBtn_OnEnter(GameObject go, PointerEventData eventData)
        {
            
        }

        private void OutParamter_PortBtn_OnEnter(GameObject go, PointerEventData eventData)
        {
            Debug.Log("OutParamter_PortBtn_OnEnter");
        }
    }

    

}
