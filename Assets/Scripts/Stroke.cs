using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stroke : MonoBehaviour
{
    /// <summary>
    /// �`�����̃R���|�[�l���g���X�g
    /// </summary>
    private List<LineRenderer> lineRendererList;

    /// <summary>
    /// �`�����̃}�e���A��
    /// </summary>
    public Material lineMaterial;

    /// <summary>
    /// �`�����̐F
    /// </summary>
    public Color lineColor;

    /// <summary>
    /// �`�����̑���
    /// </summary>
    [Range(0, 10)] public float lineWidth;


    void Awake()
    {
        lineRendererList = new List<LineRenderer>();
    }

    void Update()
    {

        // �{�^���������ꂽ���ɐ��I�u�W�F�N�g�̒ǉ����s��
        if (Input.GetMouseButtonDown(0))
        {
            this.AddLineObject();
        }

        // �{�^����������Ă��鎞�ALineRenderer�Ɉʒu�f�[�^�̐ݒ���w�肵�Ă���
        if (Input.GetMouseButton(0))
        {
            this.AddPositionDataToLineRendererList();
        }
    }

    /// <summary>
    /// ���I�u�W�F�N�g�̒ǉ����s�����\�b�h
    /// </summary>
    private void AddLineObject()
    {

        // �ǉ�����I�u�W�F�N�g���C���X�^���X
        GameObject lineObject = new GameObject();

        // �I�u�W�F�N�g��LineRenderer�����t����
        lineObject.AddComponent<LineRenderer>();

        // �`�����̃R���|�[�l���g���X�g�ɒǉ�����
        lineRendererList.Add(lineObject.GetComponent<LineRenderer>());

        // ���Ɛ����Ȃ��_�̐���0�ɏ�����
        lineRendererList.Last().positionCount = 0;

        // �}�e���A����������
        lineRendererList.Last().material = this.lineMaterial;

        // ���̐F��������
        lineRendererList.Last().material.color = this.lineColor;

        // ���̑�����������
        lineRendererList.Last().startWidth = this.lineWidth;
        lineRendererList.Last().endWidth = this.lineWidth;
    }

    /// <summary>
    /// �`�����̃R���|�[�l���g���X�g�Ɉʒu����o�^���Ă���
    /// </summary>
    private void AddPositionDataToLineRendererList()
    {

        // ���W�̕ϊ����s���}�E�X�ʒu���擾
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 1.0f);
        var mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // ���Ɛ����Ȃ��_�̐����X�V
        lineRendererList.Last().positionCount += 1;

        // �`�����̃R���|�[�l���g���X�g���X�V
        lineRendererList.Last().SetPosition(lineRendererList.Last().positionCount - 1, mousePosition);
    }
}
