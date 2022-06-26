using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stroke : MonoBehaviour
{
    ///<summary>
    ///描く線のコンポーネントリスト
    ///</summary>
    private List<LineRenderer> lineRenderersList;

    ///<summary>
    ///描く線のマテリアル
    ///</summary>
    public Material lineMaterial;

    ///<summary>
    ///描く線の色
    ///</summary>
    public Color lineColor;

    ///<summary>
    ///描く線の太さ
    ///</summary>
    [Range(0, 10)] public float lineWidth;

    private void Awake()
    {
        lineRenderersList = new List<LineRenderer>();
    }

    private void Update()
    {
        //ボタンが押された時に線オブジェクトの追加を行う
        if (Input.GetMouseButtonDown(0))
        {
            AddLineObject();
        }
        //ボタンが押されている時に,LineRendererに位置データの設定を指定していく
        if (Input.GetMouseButton(0))
        {
            AddPositionDataToLineRendererList();
        }
    }

    ///<summary>
    ///線オブジェクトの追加を行うメソッド
    ///</summary>
    private void AddLineObject()
    {
        //追加するオブジェクトをインスタンス
        GameObject lineObject = new GameObject();

        //オブジェクトにLineRenderを取り付ける
        lineObject.AddComponent<LineRenderer>();

        //描く線のコンポーネントリストに追加する
        lineRenderersList.Add(lineObject.GetComponent<LineRenderer>());

        //線と線を繋ぐ点の数を0に初期化
        lineRenderersList.Last().positionCount = 0;

        //マテリアルを初期化
        lineRenderersList.Last().material = lineMaterial;

       //線の色を初期化
       lineRenderersList.Last().material.color = lineColor;

        //線の太さを初期化
        lineRenderersList.Last().startWidth = lineWidth;
        lineRenderersList.Last().endWidth   = lineWidth;
    }

    ///<summary>
    ///描く線のコンポーネントに位置情報を登録していく
    ///</summary>
    private void AddPositionDataToLineRendererList()
    {
        //座標の変換を行いマウス位置を取得
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 1.0f);
        var mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //線と線を繋ぐ点の数を更新
        lineRenderersList.Last().positionCount += 1;
        //描く線のコンポーネントリストを更新
        lineRenderersList.Last().SetPosition(lineRenderersList.Last().positionCount - 1, mousePosition);
    
    }
}
