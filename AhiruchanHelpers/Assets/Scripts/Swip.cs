using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swip : MonoBehaviour
{
    public float swipeSpeed = 5f; // �X���C�v�ɂ��ړ����x
    public float swipeThreshold = 50f; // �X���C�v�����o����ŏ�����

    private Vector3 initialPosition; // �^�b�`�i�܂��̓N���b�N�j���n�܂����ʒu
    private bool isDragging = false; // �I�u�W�F�N�g���h���b�O�����ǂ����̃t���O

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        // �I�u�W�F�N�g���h���b�O���̏ꍇ
        if (isDragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            float swipeDistance = currentPosition.y - initialPosition.y;

            // �X���C�v�������������ȏ�ł���΁A�㉺�Ɉړ�������
            if (Mathf.Abs(swipeDistance) > swipeThreshold)
            {
                float direction = swipeDistance > 0 ? 1f : -1f; // �X���C�v�̕������擾
                Vector3 newPosition = transform.position + Vector3.up * swipeSpeed * direction * Time.deltaTime;
                transform.position = newPosition;
            }
        }
    }
}