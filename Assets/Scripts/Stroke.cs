using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stroke : MonoBehaviour
{
    //���̍ގ�
    [SerializeField] Material lineMaterial;

    //���̐F
    [SerializeField] Color lineColor;

    //���̑���
    [Range(0.1f, 0.5f)]
    [SerializeField] float lineWidth;
    
    //�ǉ��@LineRender�^�̃��X�g�錾
    List<LineRenderer> lineRenderers;
    void Start()
    {
        //�ǉ��@List�̏�����
        lineRenderers = new List<LineRenderer>();
    }

    
    void Update()
    {
        
    }
}
