/*
    DeleteWater.cs
    Kawahara Rina

    �����������^�{�[�������I�ɍ폜����N���X�B
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWater : MonoBehaviour
{
    // ��ʍ����̍��W���擾����p
    Vector3 screenLeftBottom;

    // Start is called before the first frame update
    void Start()
    {
        // ��ʂ̍����̍��W���擾
        screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        // ��ʂ̈�ԉ����y���W���������Ȃ����ꍇ
        if (transform.position.y < screenLeftBottom.y - 1f)
        {
            // �I�u�W�F�N�g���폜
            Destroy(gameObject);
        }
    }
}
