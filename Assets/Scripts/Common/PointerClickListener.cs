// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/23 17:40:12
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Raydata.VisualProgramming
{
    public class PointerClickListener : SingleMono<PointerClickListener>, IPointerClickHandler,IPointerEnterHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick  ->  "+eventData.pointerCurrentRaycast.gameObject.name);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("OnPointerEnter  ->  " + eventData.pointerCurrentRaycast.gameObject.name);
        }
    }
}
