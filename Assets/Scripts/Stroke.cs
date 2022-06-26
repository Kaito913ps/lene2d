using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroke : MonoBehaviour
{
    //線の材質
    [SerializeField] Material lineMaterial;

    //線の色
    [SerializeField] Color lineColor;

    //線の太さ
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    
    //追加　LineRender型のリスト宣言
    List<LineRenderer> lineRenderers;
    void Start()
    {
        //追加　Listの初期化
        lineRenderers = new List<LineRenderer>();
    }

    
    void Update()
    {
        
    }
}
