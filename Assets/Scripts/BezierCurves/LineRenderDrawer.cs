// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 16:16:10
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
    public class LineRenderDrawer
    {
        #region 公开字段
        public LineRenderer m_line;
        public int smooth = 30;

        public Vector3 startPosition;
        public Vector3 endPosition;

        public bool isStartDraw;
        public bool isEndDraw;

        public GameObject dot;

        public NodeBase fromNode;
        public NodeBase toNode;

        private LineType lineType;
        #endregion

        #region 私有字段
        private Vector3[] linepoints;
        private Vector3 prePointerpPostion=new Vector3(-9999,-9999,-9999);

        #endregion

        public LineRenderDrawer(NodeBase fromNode,LineType lineType)
        {
            this.fromNode = fromNode;
            this.lineType = lineType;

            startPosition = fromNode.curClickTrans.position;
            isStartDraw = true;
            //生成dot
            dot = GameObject.Instantiate<GameObject>(fromNode.dotImg, fromNode.dotImg.transform.parent);
            dot.SetActive(true);

            //
            m_line = GameObject.Instantiate<GameObject>(LineRenderDrawerController.Instance.m_lineRender).GetComponent<LineRenderer>();
            m_line.positionCount = smooth;

            //
            LineRenderDrawerController.Instance.isEndClicked = true;
        }
 

        public void DrawLineInUpdate()
        {
            //
            if(m_line==null)
            {
                Debug.LogError("生成linerender失败");
                return;
            }
            //
            if (prePointerpPostion==Input.mousePosition)
            {
                return;
            }
            prePointerpPostion = Input.mousePosition;
            //
            if (isStartDraw)
            {
                if(isEndDraw)
                {
                    endPosition = LineRenderDrawerController.Instance.curClickPort.gameObject.transform.position;
                    isStartDraw = false;
                    dot.SetActive(false);
                }
                else
                {
                    endPosition = ToolUtility.ScreenPointToLocalPointInRectangle(Input.mousePosition);
                    dot.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(Input.mousePosition);
                }
                DrawBezierCurver_ThreeOrder();
            }
        }

        public void DrawBezierCurver_ThreeOrder()
        {
            float offsetX = Mathf.Abs(startPosition.x - endPosition.x) / 3;
            //Debug.Log(startPoint+"::"+endPoint);
            Vector3[] tempV3s = new Vector3[4];
            tempV3s[0] = startPosition;
            tempV3s[1] = startPosition + new Vector3(offsetX, 0, 0);
            tempV3s[2] = endPosition - new Vector3(offsetX, 0, 0);
            tempV3s[3] = endPosition;

            linepoints = BezierCurversMathf.GetBezierCurvesVertex(tempV3s, 4, 1f / smooth);
            m_line.SetPositions(linepoints);
        }

        public void ReDrawWhenOnScroll()
        {
            DrawBezierCurver_ThreeOrder();
        }
    }
}
