using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitX : MonoBehaviour
{
    public float minX; // x�������̍ŏ����W
    public float maxX; // x�������̍ő���W

    private void Update()
    {
        // ���݂̃I�u�W�F�N�g�̈ʒu���擾
        Vector3 currentPosition = transform.position;

        // x�������̍��W�𐧌�
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // ���������������W���I�u�W�F�N�g�ɔ��f
        transform.position = currentPosition;
    }
}