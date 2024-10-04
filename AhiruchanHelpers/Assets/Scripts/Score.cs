/*
    Score.cs
    Kawahara Rina

    �X�R�A���Ǘ�����N���X�B
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;  // �X�R�A��\������e�L�X�g
    [SerializeField] private int clearScore;  // �N���A�ɕK�v�X�R�A��

    private GameManager gm;                   // �Q�[���}�l�[�W���擾�p

    public int getDuckScore;                  // �l�������A�q���̐�(�X�R�A)


    // �X�R�A��\������֐�
    private void ShowScore()
    {
        // �X�R�A��\��
        scoreText.text = string.Format("�~ {0}", getDuckScore);

        // �l�������A�q���̐����N���A�ɕK�v�ȃX�R�A���𒴂����ꍇ
        if (getDuckScore >= clearScore)
        {
            // �Q�[���N���A�̃t���O�𗧂Ă�
            gm.isGameClear = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���}�l�[�W���̃R���|�[�l���g���擾
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // �X�R�A��\��
        ShowScore();
    }
}
