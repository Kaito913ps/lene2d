using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        // クリックをしたタイミング
        if(Input.GetMouseButtonDown(0))
        {
            //lineObjを生成、初期化する
            addLineObject();
        }
    }

    void addLineObject()
    {
        //空のゲームオブジェクト作成
        GameObject lineObj = new GameObject();
        //オブジェクトの名前をStrokeに変更
        lineObj.name = "Stroke";
        //lineObjにLineRendereコンポーネント追加
        lineObj.AddComponent<LineRenderer>();
        //lineRendererリストにlineObjを追加
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObjを自身の子要素に設定
        lineObj.transform.SetParent(transform);
        //lineObj初期化処理
        initRenderes();
    }

    //lineObj初期化処理
    void initRenderes()
    {
        //線を繋ぐ点を0に初期化
        lineRenderers.Last().positionCount = 0;
        //マテリアルを初期化
        lineRenderers.Last().material = lineMaterial;
        //色の初期化
        lineRenderers.Last().material.color = lineColor;
        //太さの初期化
        lineRenderers.Last().startWidth = lineWidth;
        lineRenderers.Last().endWidth = lineWidth;
    }
}
