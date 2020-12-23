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

        private Vector3 startPosition;
        private Vector3 endPosition;

        private bool isStartDraw;
        private bool isEndDraw;

        private GameObject dot;

        private NodeUIBase node;
        #endregion

        #region 私有字段
        private Vector3[] linepoints;

        #endregion

        public LineRenderDrawer(NodeUIBase node)
        {
            Debug.Log("new ");
            this.node = node;
            Init();
        }

        void Init()
        {
            startPosition = node.curClickTrans.position;
            isStartDraw = true;
            //生成dot
            dot = GameObject.Instantiate<GameObject>(node.dotImg, node.dotImg.transform.parent);
            dot.SetActive(true);

            //
            m_line = GameObject.Instantiate<GameObject>(LineRenderDrawerController.Instance.m_lineRender).GetComponent<LineRenderer>();
            m_line.positionCount = 4;

          

        }

        Vector3 temp;
        public void DrawLineInUpdate()
        {
            if(isStartDraw)
            {
                if(m_line==null)
                {
                    Debug.LogError("生成linerender失败");
                    return;
                }
                RectTransformUtility.ScreenPointToWorldPointInRectangle(
                    GlobalObject.Instance.m_RectTrans, Input.mousePosition, GlobalObject.Instance.mainCamera, out endPosition); ;
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
            linepoints  = BezierCurversMathf.GetBezierCurvesVertex(tempV3s, 4, 1 / 10);
            m_line.SetPositions(tempV3s);
        }
    }
}
