// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 14:29:14
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class LineRenderDrawerController : SingleMono<LineRenderDrawerController>
    {
        #region 公开字段
        public GameObject m_lineRender;
        /// <summary>
        /// 一条线必定有两个顶点,一个入点和一个出点.   入点确定了fromnode,出点确定了tonode
        /// </summary>
        public LineRenderDrawer curLine;
        public PortModel curClickPort;
        public PortType secondClick_OneLine = PortType.None;
        public bool isEndClicked;
        #endregion

        #region 私有字段
        /// <summary>
        /// 记录所有的线,
        /// </summary>
        private List<LineRenderDrawer> lines = new List<LineRenderDrawer>();

        #endregion

        private void Start()
        {
            if(m_lineRender == null) m_lineRender = Resources.Load<GameObject>("Prefab/LineRender/LineRenderPrefab");

        }

        public void AddLine(LineRenderDrawer line, NodeBase node)
        {
            //记录之前先清空,然后赋值
            curLine = null;
            curLine = line;
            lines.Add(line);
            curLine.fromNode = node;//
        }
        public void RemoveLine(LineRenderDrawer line)
        {
            if(lines.Contains(line))
            {
                lines.Remove(line);
            }
        }


        bool isUpdate=true;
        private void Update()
        {
            //减少Update的刷新次数,优化性能
            if(isUpdate)
            {
                for(int i = 0; i < lines.Count; i++)
                {
                    lines[i].DrawLineInUpdate();
                }
                isUpdate = false;
                StartCoroutine(draw());
            }
        }

        IEnumerator draw()
        {
            yield return new WaitForSeconds(0.01f);
            isUpdate = true;
        }




        public void UpdatePointWhenScroll()
        {
            for(int i = 0; i < lines.Count; i++)
            {
                lines[i].ReDrawWhenOnScroll();
            }
        }
    }
}
