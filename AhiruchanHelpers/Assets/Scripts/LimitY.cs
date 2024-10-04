using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitY : MonoBehaviour
{
    public float minY; // Y�������̍ŏ����W
    public float maxY; // Y�������̍ő���W

    private void Update()
    {
        // ���݂̃I�u�W�F�N�g�̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // Y�������̍��W�𐧌�
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // ���������������W���I�u�W�F�N�g�ɔ��f
        transform.position = currentPosition;
    }
}