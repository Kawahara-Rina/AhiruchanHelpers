/*
    Timer.cs
    Kawahara Rina

    �Q�[�����̃J�E���g�_�E���^�C�}�[���Ǘ�����N���X�B
*/

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;   // �������Ԃ�\������e�L�X�g
    [SerializeField] private float time;       // ��������

    private GameManager gm;  // GameManager�擾�p

    // �������Ԃ̃J�E���g�_�E��������֐�
    private void CountDownTime()
    {
        // �������Ԃ�\������
        timerText.text = string.Format("{0}", Mathf.Ceil(time));
        time -= Time.deltaTime;
    }

    // �������Ԃ�0�ɂȂ����ꍇ�̏���������֐�
    private void TimeIsUp()
    {
        // �Q�[���̏�Ԃ��Q�[���I�[�o�[��
        gm.isGameOver = true;

        // �^�C�}�[��0�b�\��
        timerText.text = string.Format("0");
    }

    // Start is called before the first frame update
    void Start()
    {
        // GameManager�̃R���|�[�l���g���擾
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[�����̏ꍇ
        if (!gm.isGameClear)
        {
            // �������Ԃ��J�E���g�_�E��
            CountDownTime();
        }

        // �������Ԃ��c��0�b�̏ꍇ
        if (time < 0)
        {
            // �Q�[���I�[�o�[���̏�����
            TimeIsUp();
        }

    }

}
