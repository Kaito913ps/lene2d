using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        // �N���b�N�������^�C�~���O
        if(Input.GetMouseButtonDown(0))
        {
            //lineObj�𐶐��A����������
            addLineObject();
        }
    }

    void addLineObject()
    {
        //��̃Q�[���I�u�W�F�N�g�쐬
        GameObject lineObj = new GameObject();
        //�I�u�W�F�N�g�̖��O��Stroke�ɕύX
        lineObj.name = "Stroke";
        //lineObj��LineRendere�R���|�[�l���g�ǉ�
        lineObj.AddComponent<LineRenderer>();
        //lineRenderer���X�g��lineObj��ǉ�
        lineRenderers.Add(lineObj.GetComponent<LineRenderer>());
        //lineObj�����g�̎q�v�f�ɐݒ�
        lineObj.transform.SetParent(transform);
        //lineObj����������
        initRenderes();
    }

    //lineObj����������
    void initRenderes()
    {
        //�����q���_��0�ɏ�����
        lineRenderers.Last().positionCount = 0;
        //�}�e���A����������
        lineRenderers.Last().material = lineMaterial;
        //�F�̏�����
        lineRenderers.Last().material.color = lineColor;
        //�����̏�����
        lineRenderers.Last().startWidth = lineWidth;
        lineRenderers.Last().endWidth = lineWidth;
    }
}
