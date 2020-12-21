using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Raydata.NodeGraph
{
    public static class ToolUtility
    {
        static Vector3 tempV2;
        public static Vector3 ScreenPointToLocalPointInRectangle(RectTransform mRectTrans, Vector2 screenPoint)
        {
            RectTransformUtility.ScreenPointToWorldPointInRectangle(mRectTrans, screenPoint, GLDrawLineController.instance.mainCamera, out tempV2);
            return tempV2;
        }

        public static Vector2 WorldToScreenPoint(Vector3 worldPoint)
        {
            return RectTransformUtility.WorldToScreenPoint(GLDrawLineController.instance.mainCamera, worldPoint);
        }
    }
}