// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 14:29:14
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
    public class LineRenderDrawLineController : SingleMono<LineRenderDrawLineController>
    {
        #region 公开字段
        #endregion

        #region 私有字段
        private GameObject lineRendererPrefab ;

        private List<BezierCurversDrawer> lines = new List<BezierCurversDrawer>();

        #endregion

        void Start()
        {

            lineRendererPrefab = Resources.Load<GameObject>("Prefab/LineRender/LineRenderPrefab");
        }

        public void   AddLine(BezierCurversDrawer line)
        {
            lines.Add(line);
        }
        public void RemoveLine(BezierCurversDrawer line)
        {
            if(lines.Contains(line))
            {
                lines.Remove(line);
            }
        }
    }
}
