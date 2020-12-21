// *************************************************************************************************************
// 创建者: autorCreat
// 创建时间: 2020/12/18 15:32:32
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Raydata.NodeGraph
{
    public class ChoosabilityNodeGroup : MonoBehaviour
    {
        #region 公开字段
        public InputField selectInputField;
        public Button backBtn;
        public Button nextBtn;
        public RectTransform contentRect; 
        #endregion

        #region 公开字段


        #endregion

        void Start()
        {
            Addbuttonlistener();
        }

        private void Addbuttonlistener()
        {
            selectInputField.onValueChanged.AddListener (selectInputFieldOnValueChanged);
            backBtn.onClick.AddListener(backBtnOnClick);
            nextBtn.onClick.AddListener(nextBtnOnClick);
        }
   
        private void backBtnOnClick()
        {
            Vector3 nowV3 = contentRect.localPosition;
            contentRect.DOLocalMoveX(nowV3.x + 180, 0.5f);
            Debug.Log(1);    
        }

        private void nextBtnOnClick()
        {
            Vector3 nowV3 = contentRect.localPosition;
            contentRect.DOLocalMoveX(nowV3.x - 180, 0.5f);
            Debug.Log(212);
        }

        private void selectInputFieldOnValueChanged(string arg)
        {
            
        }
    }
}
