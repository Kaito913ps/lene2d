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
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
