// ========================================================
// 描 述：
// 作 者：xzf 
// 创建时间：2017/11/29 10:12:25
// 版 本：v 1.0
// ========================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawTools{

    /// <summary>
    /// 画直线
    /// </summary>
    /// <param name="vh">VertexHelper</param>
    /// <param name="startPos">起始点</param>
    /// <param name="endPos">终点</param>
    /// <param name="color0">颜色</param>
    /// <param name="lineWidth">宽度</param>
    public static void DrawLine(VertexHelper vh, Vector2 startPos, Vector2 endPos, Color color0, float lineWidth = 2.0f) {
        float dis = Vector2.Distance(startPos, endPos);
        float y = lineWidth * 0.5f * (endPos.x - startPos.x) / dis;
        float x = lineWidth * 0.5f * (endPos.y - startPos.y) / dis;
        if (y <= 0) y = -y;
        else x = -x;
        UIVertex[] vertex = new UIVertex[4];
        vertex[0].position = new Vector3(startPos.x + x, startPos.y + y);
        vertex[1].position = new Vector3(endPos.x + x, endPos.y + y);
        vertex[2].position = new Vector3(endPos.x - x, endPos.y - y);
        vertex[3].position = new Vector3(startPos.x - x, startPos.y - y);
        for (int i = 0; i < vertex.Length; i++) vertex[i].color = color0;
        vh.AddUIVertexQuad(vertex);
    }

    public enum ArrowDirection {
        Right,
        Up
    }
    /// <summary>
    /// 画箭头
    /// </summary>
    /// <param name="vh">VertexHelper</param>
    /// <param name="startPos">起点</param>
    /// <param name="direction">方向</param>
    /// <param name="color0">颜色</param>
    /// <param name="len">大小</param>
    public static void DrawArrow(VertexHelper vh, Vector2 startPos, ArrowDirection direction,Color color0, float len = 8)
    {
        Vector2 p1 = Vector2.zero;
        Vector2 p2 = Vector2.zero;
        Vector2 p3 = Vector2.zero;
        switch (direction) {
            case ArrowDirection.Right:
                //*
                //    *
                //*
                p1 = new Vector2(startPos.x, startPos.y);
                p2 = new Vector2(startPos.x - 0.865f * len, startPos.y - len/2);
                p3 = new Vector2(startPos.x - 0.865f * len, startPos.y + len / 2);
                break;
            case ArrowDirection.Up:
                //   *
                //
                //*     *
                p1 = new Vector2(startPos.x, startPos.y);
                p2 = new Vector2(startPos.x + len/2, startPos.y - 0.865f * len);
                p3 = new Vector2(startPos.x - len/2, startPos.y - 0.865f * len);
                break;
        }
        UIVertex[] us = new UIVertex[4];
        us[0].position = p1;
        us[1].position = p2;
        us[2].position = p3;
        us[3].position = p3;
        for (int i = 0; i < us.Length; i++) us[i].color = color0;
        vh.AddUIVertexQuad(us);
    }


}
