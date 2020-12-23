using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raydata.VisualProgramming
{
    public class BezierCurversMathf
    {

        /// <summary>
        /// 绘制n阶贝塞尔曲线路径
        /// </summary>
        /// <param name="points">输入点</param>
        /// <param name="count">点数-1</param>
        /// <param name="step">步长,步长越小，轨迹点越密集</param>
        /// <returns></returns>
        public static Vector3[] DrawBezierCurves(Vector3[] points, int count, float step)
        {
            List<Vector3> bezierCurvesPoints = new List<Vector3>();
            float t = 0f;
            do
            {
                Vector3 temp_point = BezierInterpolation(t, points, count);    // 计算插值点
                t += step;
                bezierCurvesPoints.Add(temp_point);
            }
            while(t <= 1 && count > 1);    // 一个点的情况直接跳出.
            return bezierCurvesPoints.ToArray();  // 曲线轨迹上的所有坐标点
        }
        /// <summary>
        /// n阶贝塞尔曲线插值计算函数
        /// 根据起点，n个控制点，终点 计算贝塞尔曲线插值
        /// </summary>
        /// <param name="t">当前插值位置0~1 ，0为起点，1为终点</param>
        /// <param name="points">起点，n-1个控制点，终点</param>
        /// <param name="count">n+1个点</param>
        /// <returns></returns>
        private static Vector3 BezierInterpolation(float t, Vector3[] points, int count)
        {
            // 一个点都没有
            if(points.Length >= 1)
            {
                if(count == 1)
                    return points[0];
                else
                {
                    Vector3[] tmp_points = new Vector3[count];
                    for(int i = 1; i < count; i++)
                    {
                        tmp_points[i - 1].x = (float)(points[i - 1].x * t + points[i].x * (1 - t));
                        tmp_points[i - 1].y = (float)(points[i - 1].y * t + points[i].y * (1 - t));
                        tmp_points[i - 1].z = -1;

                    }
                    return BezierInterpolation(t, tmp_points, count - 1);
                }
            }
            else
            {
                return points[0];
            }




        }
        /// <summary>
        /// 计算组合数公式
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private static int CalcCombinationNumber(int n, int k)
        {
            int[] result = new int[n + 1];
            for(int i = 1; i <= n; i++)
            {
                result[i] = 1;
                for(int j = i - 1; j >= 1; j--)
                    result[j] += result[j - 1];
                result[0] = 1;
            }
            return result[k];
        }
    }
}