using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stroke : MonoBehaviour
{
    ///<summary>
    ///�`�����̃R���|�[�l���g���X�g
    ///</summary>
    private List<LineRenderer> lineRenderersList;

    ///<summary>
    ///�`�����̃}�e���A��
    ///</summary>
    public Material lineMaterial;

    ///<summary>
    ///�`�����̐F
    ///</summary>
    public Color lineColor;

    ///<summary>
    ///�`�����̑���
    ///</summary>
    [Range(0, 10)] public float lineWidth;

    private void Awake()
    {
        lineRenderersList = new List<LineRenderer>();
    }

    private void Update()
    {
        //�{�^���������ꂽ���ɐ��I�u�W�F�N�g�̒ǉ����s��
        if (Input.GetMouseButtonDown(0))
        {
            AddLineObject();
        }
        //�{�^����������Ă��鎞��,LineRenderer�Ɉʒu�f�[�^�̐ݒ���w�肵�Ă���
        if (Input.GetMouseButton(0))
        {
            AddPositionDataToLineRendererList();
        }
    }

    ///<summary>
    ///���I�u�W�F�N�g�̒ǉ����s�����\�b�h
    ///</summary>
    private void AddLineObject()
    {
        //�ǉ�����I�u�W�F�N�g���C���X�^���X
        GameObject lineObject = new GameObject();

        //�I�u�W�F�N�g��LineRender�����t����
        lineObject.AddComponent<LineRenderer>();

        //�`�����̃R���|�[�l���g���X�g�ɒǉ�����
        lineRenderersList.Add(lineObject.GetComponent<LineRenderer>());

        //���Ɛ����q���_�̐���0�ɏ�����
        lineRenderersList.Last().positionCount = 0;

        //�}�e���A����������
        lineRenderersList.Last().material = lineMaterial;

       //���̐F��������
       lineRenderersList.Last().material.color = lineColor;

        //���̑�����������
        lineRenderersList.Last().startWidth = lineWidth;
        lineRenderersList.Last().endWidth   = lineWidth;
    }

    ///<summary>
    ///�`�����̃R���|�[�l���g�Ɉʒu����o�^���Ă���
    ///</summary>
    private void AddPositionDataToLineRendererList()
    {
        //���W�̕ϊ����s���}�E�X�ʒu���擾
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 1.0f);
        var mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);

        //���Ɛ����q���_�̐����X�V
        lineRenderersList.Last().positionCount += 1;
        //�`�����̃R���|�[�l���g���X�g���X�V
        lineRenderersList.Last().SetPosition(lineRenderersList.Last().positionCount - 1, mousePosition);
    
    }
}
