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
        /// <summary>
        /// 接收参数的入口,在这个点上接收参数,等同于方法的参数
        /// </summary>
        public Button inPortBtn;

        /// <summary>
        /// 传出参数的出口,在这个点上传出参数,等同于方法的返回值
        /// </summary>
        public Button outPortBtn;

        /// <summary>
        /// 线的终点,点击箭头表示画线结束
        /// </summary>
        public GameObject dotBtn;

        /// <summary>
        /// 当前点击的对象
        /// </summary>
        [HideInInspector]
        public Transform curClickTrans;

        /// <summary>
        /// 
        /// </summary>
        [HideInInspector]
        public DotType dotType;
        BezierCurversDrawer lineDrawer;

        public virtual void Start()
        {

            if(!inPortBtn) inPortBtn = transform.Find("ParamPort/InPort").GetComponent<Button>();
            if(!outPortBtn) outPortBtn = transform.Find("ParamPort/OutPort").GetComponent<Button>();
            if(!dotBtn) dotBtn = transform.Find("ParamPort/Dot").gameObject;
            
            //注册事件
            inPortBtn.onClick.AddListener(InPortBtnOnClick);
            outPortBtn.onClick.AddListener(OutPortBtnOnClick);

        }

        private void InPortBtnOnClick()
        {
            curClickTrans = inPortBtn.transform;
            dotType = DotType.INDOT;
            lineDrawer = new BezierCurversDrawer(this);
        }

        public virtual void OutPortBtnOnClick()
        {
            curClickTrans = outPortBtn.transform;
            dotType = DotType.OUTDOT; 
            lineDrawer = new BezierCurversDrawer(this);
        }

      
        
    }

    public enum DotType
    {
        NONE,
        INDOT,
        OUTDOT
    }

}
