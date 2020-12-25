// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/22 11:03:15
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Raydata.VisualProgramming
{
    public class InspectorPanel : MonoBehaviour
    {
        #region 公开字段
        public GameObject cube;
        public GameObject cubebtn;
        public Image mousePointer ;
        private Vector3 offset=new Vector3(20f,-30f,0f);
        public Sprite shareSprite, addSprite;
        #endregion



        void Start()
        {
            EventTriggerListener.Get(cubebtn).onBeginDrag += cubebtnOnBeginDrag;
            EventTriggerListener.Get(cubebtn).onDrag += cubebtnOnDrag;
            EventTriggerListener.Get(cubebtn).onEndDrag += cubebtnOnEndDrag;
        }


        public void cubebtnOnBeginDrag(GameObject go,PointerEventData eventData)
        {
            //Debug.Log("cubebtnOnBeginDrag");
            mousePointer.sprite = shareSprite;
            mousePointer.gameObject.SetActive(true);
        }

        public void cubebtnOnDrag(GameObject go, PointerEventData eventData)
        {
            //Debug.Log("cubebtnOnDrag");
            mousePointer.transform.position = Input.mousePosition + offset;
            if(eventData.pointerCurrentRaycast.gameObject)
            {
                if(eventData.pointerCurrentRaycast.gameObject.name== "NameText")
                    mousePointer.sprite = addSprite;
                else
                    mousePointer.sprite = shareSprite;
            }
        }

        public void cubebtnOnEndDrag(GameObject go, PointerEventData eventData)
        {

            if(eventData.pointerCurrentRaycast.gameObject.name == "NameText")
                eventData.pointerCurrentRaycast.gameObject.GetComponent<TransportationHub>().Send(cube);
         
            mousePointer.gameObject.SetActive(false);
        }

     
    }
}
