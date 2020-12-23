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
        #endregion

        #region 私有字段
        private List<LineRenderDrawer> lines = new List<LineRenderDrawer>();

        #endregion

        private void Start()
        {
            if(m_lineRender == null) m_lineRender = Resources.Load<GameObject>("Prefab/LineRender/LineRenderPrefab");

        }

        public void AddLine(LineRenderDrawer line)
        {
            lines.Add(line);
        }
        public void RemoveLine(LineRenderDrawer line)
        {
            if(lines.Contains(line))
            {
                lines.Remove(line);
            }
        }

        private void Update()
        {
            StartCoroutine(draw());
           
        }
        IEnumerator draw()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                lines[i].DrawLineInUpdate();
                yield return new WaitForSeconds(0.1f);
            }
        }
        internal void UpdatePointWhenScroll()
        {
            for(int i = 0; i < lines.Count; i++)
            {

            }
        }
    }
}
