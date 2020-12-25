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
        #region LineRender 外观
        /// <summary>
        /// LineRender 预制体
        /// </summary>
        public LineRenderer m_line;

        /// <summary>
        /// 平滑度
        /// </summary>
        public float smooth = 30;

        /// <summary>
        /// Linerender材质球
        /// </summary>
        public Material material;

        /// <summary>
        /// LineRender 宽度
        /// </summary>
        public float width;

        /// <summary>
        /// LineRender Color
        /// </summary>
        public Color color;

        #endregion

        /// <summary>
        /// 属性,标注 是Routine 还是 Parameter
        /// </summary>
        public PropertyType property { get; protected set; }

        /// <summary>
        /// 归属于哪个Node
        /// </summary>
        public Node belongToNode;

        /// <summary>
        /// 一条线的入点
        /// </summary>
        public Port inPort;

        /// <summary>
        /// 一条线的出点
        /// </summary>
        public Port outPort;

        public bool isStartFromInPort;

        //处理逻辑的临时变量
        private Vector3 startPosition;
        private Vector3 endPosition;
        public bool isStartDraw;
        public bool isEndDraw;
        private Vector3 prePointerpPostion=new Vector3(-99999,-99999,-99999);


        public LineRenderDrawer(Port port)
        {
            this.property = port.property;
            this.belongToNode = port.belongToNode;
            startPosition = port.transform.position;
            isStartFromInPort = port.IO == IOType.INPUT; 
            isStartDraw = true;

            MainWindowCtrl.Instance.dot.SetActive(true);
            m_line = LineRenderDrawerController.Instance.InstantiateLineRenderer((int)smooth);
            LineRenderDrawerController.Instance.AddLine(this);

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
                    MainWindowCtrl.Instance.dot.SetActive(false);
                    LineRenderDrawerController.Instance.curLine = null;
                }
                else
                {
                    endPosition = ToolUtility.ScreenPointToLocalPointInRectangle(Input.mousePosition);
                    MainWindowCtrl.Instance.dot.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(Input.mousePosition);

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

            if(isStartFromInPort)
            {
                tempV3s[1] = startPosition -new Vector3(offsetX, 0, 0);
                tempV3s[2] = endPosition + new Vector3(offsetX, 0, 0);
            }
            else
            {
                tempV3s[1] = startPosition + new Vector3(offsetX, 0, 0);
                tempV3s[2] = endPosition - new Vector3(offsetX, 0, 0);
            }
            tempV3s[3] = endPosition;

            m_line.SetPositions(BezierCurversMathf.GetBezierCurvesVertex(tempV3s, 4, 1f / smooth));
        }

        public void ReDrawWhenOnScroll()
        {
            DrawBezierCurver_ThreeOrder();
        }
    }
}
