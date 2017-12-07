// ========================================================
// 描 述：
// 作 者：xzf 
// 创建时间：2017/11/29 09:27:42
// 版 本：v 1.0
// ========================================================
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MaskableGraphic {

    private RectTransform _myRect;
    public List<FunctionFormula> Formulas = new List<FunctionFormula>();
    float height = 0;
    float width = 0;

    //xy轴的最大值
    float xMax = 100;
    float yMax = 100;

    void init() {
        _myRect = this.rectTransform;
        height = _myRect.sizeDelta.y;
        width = _myRect.sizeDelta.x;
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        init();
        vh.Clear();

        //画X轴
        Vector2 lp = new Vector2(-width / 2, -height / 2 + 10);
        Vector2 rp = new Vector2(width / 2, -height / 2 + 10);
        DrawTools.DrawLine(vh, lp, rp, color, 1);
        //箭头
        Vector2 xArr = new Vector2(width / 2, -height / 2 + 10);
        DrawTools.DrawArrow(vh, xArr, DrawTools.ArrowDirection.Right, color, 16);

        //画Y轴
        Vector2 up = new Vector2(-width / 2 + 10, +height / 2);
        Vector2 dp = new Vector2(-width / 2 + 10, -height / 2);
        DrawTools.DrawLine(vh, up, dp, color, 1);
        //箭头
        Vector2 yArr = new Vector2(-width / 2 + 10, +height / 2);
        DrawTools.DrawArrow(vh, yArr, DrawTools.ArrowDirection.Up, color, 16);
    }
}
public class FunctionFormula
{
    /// <summary>
    /// 函数表达式
    /// </summary>
    public Func<float, float> Formula;
    /// <summary>
    /// 函数图对应线条颜色
    /// </summary>
    public Color FormulaColor;
    public float FormulaWidth;

    public FunctionFormula() { }
    public FunctionFormula(Func<float, float> formula, Color formulaColor, float width)
    {
        Formula = formula;
        FormulaColor = formulaColor;
        FormulaWidth = width;
    }
}
