using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    /// <summary>
    /// 1.每个node只能有一个运行逻辑入口,但一个入口可以被多个node连接
    /// 2.每个node只能有一个运行逻辑出口,但一个出口可以连接多个node
    /// </summary>
    public class Node : MonoBehaviour
    {

        public NodeType nodeType { get; protected set; }

        /// <summary>
        /// 该节点所有的连线
        /// </summary>
        public List<LineRenderDrawer> lines=new List<LineRenderDrawer>();

        /// <summary>
        /// 描述
        /// </summary>
        public Description description;



        public void FindPort(Port outRoutinePort, string path)
        {
            if(outRoutinePort.gameObject == null)
            {
                outRoutinePort.gameObject = this.transform.Find(path).gameObject;
                if(!outRoutinePort.gameObject)
                    DebugOnWeb.LogErrorFormat("在[{0}]上没有找到 \"{1}\" ", this.gameObject.name, path);
                else
                {
                    outRoutinePort.gameObject.SetActive(outRoutinePort.isShow);
                }
            }
        }

        public void PortOnClick(Port port)
        {
            if( LineRenderDrawerController.Instance.curLine!=null)
            {
                LineRenderDrawer line = LineRenderDrawerController.Instance.curLine;
                line.isEndDraw = true;
                line.belongToNode = this;
                line.outPort = port;
                LineRenderDrawerController.Instance.curClickPort = port;
            }
            else
            {
                LineRenderDrawer line = new LineRenderDrawer(port);
                lines.Add(line);
            }
        }
          
    }



}
