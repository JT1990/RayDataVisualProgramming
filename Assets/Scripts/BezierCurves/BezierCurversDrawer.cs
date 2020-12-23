using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class BezierCurversDrawer
    {
        public Vector3[] Points;
        public bool isStartDraw;
        public bool isEndDraw;
        private NodeUIBase eventUI;
        private float smoothness = 30;
        private Transform startbtnNew;
        private GameObject dotBtnNew;
        private Vector3 startPoint, endPoint;

        public BezierCurversDrawer(NodeUIBase eventUI)
        {
            Init(eventUI);
        }

        private void Init(NodeUIBase eventUI)
        {
            this.eventUI = eventUI;
            GLDrawLineController.instance.AddLine(this);
            startbtnNew = eventUI.curClickTrans;
            startPoint = ToolUtility.WorldToScreenPoint(eventUI.curClickTrans.position);
            isStartDraw = true;
            //生成一个
            dotBtnNew = GameObject.Instantiate<GameObject>(eventUI.dotBtn, eventUI.dotBtn.transform.parent);
            EventTriggerListener.Get(dotBtnNew).onClick += DotBtnOnClick;
            dotBtnNew.gameObject.SetActive(true);
       
        }


        public virtual void DotBtnOnClick(GameObject go, PointerEventData eventData)
        {
            Debug.Log("DotBtnOnClick    "+ eventData.pointerEnter.name);

            isEndDraw = true;
            dotBtnNew.gameObject.SetActive(false);

            //出点连接入点

            //入点连接出点

            //弹出选择Node

            //GlobalObject.Instance.m_ChoosabilityNodeGroupRect.gameObject.SetActive(true);
            //GlobalObject.Instance.m_ChoosabilityNodeGroupRect.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(
            //    Input.mousePosition + new Vector3(
            //        GlobalObject.Instance.m_ChoosabilityNodeGroupRect.transform.GetComponent<RectTransform>().rect.width / 2,
            //        -GlobalObject.Instance.m_ChoosabilityNodeGroupRect.transform.GetComponent<RectTransform>().rect.height / 2));
        }

        public virtual void DotBtnOnEnter(GameObject go, PointerEventData eventData)
        {
            Debug.Log("DotBtnOnEnter    " + eventData.pointerEnter); 
        }

        public void DrawLineInUpdate()
        {
            if(isStartDraw)
            {
                if(isEndDraw)
                {
                    endPoint = ToolUtility.WorldToScreenPoint(dotBtnNew.transform.position);
                    isStartDraw = false;
                }
                else
                {
                    endPoint = Input.mousePosition;
                    dotBtnNew.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(Input.mousePosition);
                }

                DrawBezierCurver_ThreeOrder();
            }
        }

        public void DrawBezierCurver_ThreeOrder()
        {
            float offsetX = Mathf.Abs(startPoint.x - endPoint.x) / 3;
            //Debug.Log(startPoint+"::"+endPoint);
            Vector3[] points = new Vector3[4];

            points[0] = startPoint;
            switch(eventUI.dotType)
            {
                case DotType.INDOT:
                    points[1] = startPoint - new Vector3(offsetX, 0, 0);
                    points[2] = endPoint + new Vector3(offsetX, 0, 0);
                    break;
                case DotType.OUTDOT:
                    points[1] = startPoint + new Vector3(offsetX, 0, 0);
                    points[2] = endPoint - new Vector3(offsetX, 0, 0);
                    break;
                default:
                    break;
            }
           
            points[3] = endPoint;
            Points = BezierCurversMathf.DrawBezierCurves(points, 4, 1 / smoothness);
        }

        public void Refresh()
        {
            startPoint = ToolUtility.WorldToScreenPoint(startbtnNew.transform.position);
            endPoint = ToolUtility.WorldToScreenPoint(dotBtnNew.transform.position);
        }

       
    }
}