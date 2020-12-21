using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raydata.NodeGraph
{

    /// <summary>
    /// GL 画线公共控制器
    /// -必须挂载在摄影机上
    /// -
    /// </summary>
    public class GLDrawLineController : MonoBehaviour
    {
        public static GLDrawLineController instance;

        /// <summary>
        /// 
        /// </summary>
        public Material lineMaterial;

        /// <summary>
        /// 
        /// </summary>
        private List<BezierCurversDrawer> lines = new List<BezierCurversDrawer>();

        public Camera mainCamera;

        void Awake()
        {
            //单例
            instance = this;
        }

        private void Start()
        {
            mainCamera = Camera.main;
            if(!lineMaterial) lineMaterial = Resources.Load<Material>("Material/LineMaterial");
        }
        public void AddLine(BezierCurversDrawer line)
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

        #region OnPostRender

        void OnPostRender()
        {
            if(lines.Count <= 0)
                return;

            for(int i = 0; i < lines.Count; i++)
            {
                GLDraw(lines[i].Points);
            }

        }

        /// <summary>
        /// 画线方法
        /// </summary>
        /// <param name="v3s">每条线的点数组</param>
        /// <param name="isDottedLine">是否是虚线</param>
        private void GLDraw(Vector3[] v3s, bool isDottedLine = false)
        {
            GL.PushMatrix(); //保存当前Matirx (矩阵) 
            lineMaterial.SetPass(0); //刷新当前材质  
            GL.LoadPixelMatrix();//设置pixelMatrix  
            GL.Color(Color.blue);
            GL.Begin(GL.LINES);
            //传递顶点数据
            for(int j = 0; j < v3s.Length - 1; j++)
            {
                if(isDottedLine)
                    GL.Vertex3(v3s[j].x, v3s[j].y, v3s[j].z);
                else
                {
                    GL.Vertex3(v3s[j].x, v3s[j].y, v3s[j].z);
                    GL.Vertex3(v3s[j + 1].x, v3s[j + 1].y, v3s[j + 1].z);
                }
            }

            GL.End();
            GL.PopMatrix();//读取之前的Matrix  
        }

        #endregion


        #region Update
        private void Update()
        {
            for(int i = 0; i < lines.Count; i++)
            {
                lines[i].DrawLineInUpdate();
            }
        }
        #endregion

    }
}
