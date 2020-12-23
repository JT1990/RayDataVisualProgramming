// *************************************************************************************************************
// 创建者: 魏国栋
// 创建时间: 2020/12/21 15:11:47
// 挂载对象: 
// 功能: 
// 版 本：v 1.2.0
// *************************************************************************************************************

using UnityEngine;

public class SingleMono<T> : MonoBehaviour where T : SingleMono<T>
{
    private static T _instance;
    public static T Instance {
        get {

            if(_instance == null)
            {
                _instance = FindObjectOfType(typeof(T)) as T;
                if(_instance == null)
                {
                    GameObject go = new GameObject {
                        name = "Single_" + typeof(T).ToString()
                    };
                    _instance = go.AddComponent<T>();
                    if(GameObject.Find("DontDestroy"))
                        go.transform.SetParent(GameObject.Find("DontDestroy").transform);
                }
            }
            return _instance;
        }
    }
}
