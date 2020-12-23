// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 19:25:31
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
    public class TEst : MonoBehaviour
    {
        #region 公开字段

        #endregion

        #region 私有字段


        #endregion

        private void Update()
        {

            if(Input.GetKeyDown(KeyCode.W))
            {

            Vector3 startPosition = new Vector3(0,0,0);
            Vector3 endPosition = new Vector3(10,10,10);
            float offsetX = Mathf.Abs(startPosition.x - endPosition.x) / 3;
            //Debug.Log(startPoint+"::"+endPoint);
            Vector3[] tempV3s = new Vector3[4];
            tempV3s[0] = startPosition;
            tempV3s[1] = startPosition + new Vector3(offsetX, 0, 0);
            tempV3s[2] = endPosition - new Vector3(offsetX, 0, 0);
            tempV3s[3] = endPosition;
            BezierCurversMathf.GetBezierCurvesVertex(tempV3s, 4, 1 / 10);
            }
        }
        void Start()
        {

        }

    }
}
