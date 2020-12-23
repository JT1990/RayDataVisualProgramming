using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Raydata.VisualProgramming
{
    public static class ToolUtility
    {
        static Vector3 tempV2;
        public static Vector3 ScreenPointToLocalPointInRectangle( Vector2 screenPoint, RectTransform mRectTrans = null)
        {
            if(mRectTrans==null)
            {
                RectTransformUtility.ScreenPointToWorldPointInRectangle(GlobalObject.Instance.m_RectTrans, screenPoint, GLDrawLineController.instance.mainCamera, out tempV2);
            }
            else
            {
                RectTransformUtility.ScreenPointToWorldPointInRectangle(mRectTrans, screenPoint, GLDrawLineController.instance.mainCamera, out tempV2);
            }
            return tempV2;
        }

        public static Vector2 WorldToScreenPoint(Vector3 worldPoint)
        {
            return RectTransformUtility.WorldToScreenPoint(GLDrawLineController.instance.mainCamera, worldPoint);
        }
    }
}