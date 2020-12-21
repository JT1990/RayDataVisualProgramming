using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Raydata.NodeGraph
{
    public class BezierCurversDrawer
    {
        public Vector3[] Points;
        public bool isStartDraw;
        public bool isEndDraw;
        private RectTransform uiRect;
        private NodeUIBase eventUI;
        private float smoothness = 30;

        private Vector3 startPoint, endPoint;

        public BezierCurversDrawer(NodeUIBase eventUI)
        {
            Init(eventUI);
        }

        private void Init(NodeUIBase eventUI)
        {
            this.eventUI = eventUI;
            uiRect = GameObject.Find("Panel").GetComponent<RectTransform>();
            GLDrawLineController.instance.AddLine(this);
            eventUI.outArrowBtn.gameObject.SetActive(true);
            startPoint = ToolUtility.WorldToScreenPoint(eventUI.outPortBtn.transform.position);
            isStartDraw = true;
        }

        public void DrawLineInUpdate()
        {
            if(isStartDraw)
            {
                if(isEndDraw)
                {
                    endPoint = ToolUtility.WorldToScreenPoint(eventUI.outArrowBtn.transform.position);
                    isStartDraw = false;
                }
                else
                {
                    endPoint = Input.mousePosition;
                    eventUI.outArrowBtn.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(uiRect, Input.mousePosition);
                }

                DrawBezierCurver_ThreeOrder(startPoint, endPoint);
            }
        }

        public void DrawBezierCurver_ThreeOrder(Vector3 startPoint, Vector3 endPoint)
        {
            float offsetX = Mathf.Abs(startPoint.x - endPoint.x) / 3;

            Vector3[] points = new Vector3[4];

            points[0] = startPoint;
            points[1] = startPoint + new Vector3(offsetX, 0, 0);
            points[2] = endPoint - new Vector3(offsetX, 0, 0);
            points[3] = endPoint;

            Points = BezierCurversMathf.DrawBezierCurves(points, 4, 1 / smoothness);
        }
    }
}