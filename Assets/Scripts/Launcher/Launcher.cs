// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/25 21:42:59
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
    public class Launcher : MonoBehaviour
    {
        public GameObject MainPanel;
        public StartNode startNode;
        void Start()
        {
            
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                for(int i = 0; i < startNode.lines.Count; i++)
                {
                    Debug.Log(startNode.lines[i].outPort.belongToNode.gameObject.name);
                }
              
            }
        }
    }
}
