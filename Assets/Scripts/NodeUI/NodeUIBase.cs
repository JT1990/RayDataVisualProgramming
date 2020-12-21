using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raydata.NodeGraph
{
    public class NodeUIBase : MonoBehaviour
    {
        public GameObject nodeGroup;
        public RectTransform uiRect;
        
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
        public Button outArrowBtn;

        BezierCurversDrawer lineDrawer;

        public virtual void Start()
        {
            outPortBtn.onClick.AddListener(StartPointBtnOnClick);
            outArrowBtn.onClick.AddListener(EndPointBtnOnClick);
        }

        public virtual void StartPointBtnOnClick()
        {
            lineDrawer = new BezierCurversDrawer(this);
        }

        public virtual void EndPointBtnOnClick()
        {
            lineDrawer.isEndDraw = true;
            nodeGroup.SetActive(true);
            nodeGroup.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(uiRect,
                Input.mousePosition + new Vector3(
                    nodeGroup.transform.GetComponent<RectTransform>().rect.width/2,
                    -nodeGroup.transform.GetComponent<RectTransform>().rect.height / 2));
        }

    }

}
