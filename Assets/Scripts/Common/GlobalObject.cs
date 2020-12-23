// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 15:07:57
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
    class GlobalObject :SingleMono<GlobalObject>
    {
        public RectTransform m_RectTrans;

        public RectTransform m_ChoosabilityNodeGroupRect;
        [HideInInspector]
        public Vector2 m_OffsetRectSize_ChoosabilityNodeGroup;



        private void Start()
        {
            m_OffsetRectSize_ChoosabilityNodeGroup = new Vector2(m_ChoosabilityNodeGroupRect.sizeDelta.x/2,-m_ChoosabilityNodeGroupRect.sizeDelta.y / 2);
        }

    }
}
