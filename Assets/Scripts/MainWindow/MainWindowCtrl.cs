// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 14:11:47
// 挂载对象: MainWindowPanel
// 功能: 
//
// 版 本：v 1.2.0
// *************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Raydata.VisualProgramming
{
    public class MainWindowCtrl : MonoBehaviour,IPointerClickHandler,IBeginDragHandler,IDragHandler,IEndDragHandler,IScrollHandler
    {
        #region 实现接口
        public void OnPointerClick(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Right) RightBtnOnClick(eventData.selectedObject, eventData.position);
            if(eventData.button == PointerEventData.InputButton.Left) LeftBtnOnClick(eventData.selectedObject, eventData.position);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Middle) MiddleBtnOnBeginDrag(eventData.selectedObject, eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Middle) MiddleBtnOnDrag(eventData.selectedObject, eventData.position);
        }


        public void OnEndDrag(PointerEventData eventData)
        {
            if(eventData.button == PointerEventData.InputButton.Middle) MiddleBtnOnEndDrag(eventData.selectedObject, eventData.position);
        }

        public void OnScroll(PointerEventData eventData)
        {
            MiddleBtnOnScroll(eventData.scrollDelta.y);
        }
        #endregion

        #region 公开字段
        public GameObject choosabilityNodeGroup;
        public Transform MainPanel;
        public Transform inport;
        #endregion

        #region 公开字段


        #endregion

        private void Start()
        {
          
        }
         

     


        private void LeftBtnOnClick(GameObject selectedObject,Vector2 position)
        {
            Debug.LogWarning("LeftBtnOnClick --> "+ selectedObject .name+ "  :::  "+position);
            choosabilityNodeGroup.SetActive(false);
        }

        private void RightBtnOnClick(GameObject selectedObject, Vector2 position)
        {
            Debug.LogWarning("RightBtnOnClick --> " + selectedObject.name + " ::: " + position);
            choosabilityNodeGroup.transform.position = ToolUtility.ScreenPointToLocalPointInRectangle(position + GlobalObject.Instance.m_OffsetRectSize_ChoosabilityNodeGroup);
            choosabilityNodeGroup.SetActive(true);
        }

     

        private void MiddleBtnOnBeginDrag(GameObject selectedObject, Vector2 position)
        {
            Debug.LogWarning("MiddleBtnOnDeginDrag --> " + selectedObject.name + " ::: " + position);
        }

      
        private void MiddleBtnOnDrag(GameObject selectedObject, Vector2 position)
        {
            Debug.LogWarning("MiddleBtnOnDrag --> " + selectedObject.name + " ::: " + position);
        }

        private void MiddleBtnOnEndDrag(GameObject selectedObject, Vector2 position)
        {
            Debug.LogWarning("MiddleBtnOnEndDrag --> " + selectedObject.name + " ::: " + position);
        }

        private void MiddleBtnOnScroll(float y)
        {
            Debug.LogWarning("MiddleBtnOnScroll --> " + y);

            if(y > 0)
                MainPanel.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            else
                MainPanel.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
            //限制范围
            MainPanel.localScale = new Vector3(Mathf.Clamp(MainPanel.localScale.x, 0.2f, 3f), Mathf.Clamp(MainPanel.localScale.y, 0.2f, 3f), Mathf.Clamp(MainPanel.localScale.z, 0.2f, 3f));

        }


    }
}
