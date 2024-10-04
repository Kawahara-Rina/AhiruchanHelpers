/*
    GameManager.cs
    Kawahara Rina

    �Q�[�����̃��C���̏������s���N���X�B
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �萔
    const string LAST_STAGE = "Stage3";  // �Ō�̃X�e�[�W��
    const float WAIT_TIME = 8f;          // Invoke�Ŏg�p����E�F�C�g�^�C��

    [SerializeField] private GameObject gameoverPanel;   // �Q�[���I�[�o�[���ɕ\������p�l��
    [SerializeField] private Image gameoverImage;        // �Q�[���I�[�o�[���ɕ\������C���[�W
    [SerializeField] private GameObject gameclearPanel;  // �Q�[���N���A���ɕ\������p�l��

    [SerializeField] private AudioClip gameoverSE;       // �Q�[���I�[�o�[���̌��ʉ�
    [SerializeField] private AudioClip gameclearSE;      // �Q�[���N���A���̌��ʉ�

    [SerializeField] private float addend;               // ���Z����l(gameoverImage�̓����x�ω��Ɏg�p)

    private float imageAlpha;        // Image�̓����x�ω��Ɏg�p
    private bool isPlay = false;     // ���ʉ�����x�����炷���߂Ɏg�p����t���O
    private AudioSource audioSource; // �I�[�f�B�I�\�[�X�擾�p

    public bool isGameClear;         // �Q�[�����N���A�����ꍇ�ɐ�������t���O
    public bool isGameOver;          // �Q�[���I�[�o�[�����ꍇ�ɐ�������t���O

    #region �p�u���b�N�֐�

    #region TitleButtonOnClick - �e�V�[���^�C�g���{�^���������̏���
    public void TitleButtonOnClick()
    {
        // �^�C�g���V�[���֑J��
        SceneManager.LoadScene("TitleScene");
    }
    #endregion

    #region RetryButtonOnClick - �e�V�[�����g���C�{�^���������̏���
    public void RetryButtonOnClick()
    {
        // ���݂̃V�[�����ă��[�h
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region NextButtonOnClick - �e�V�[���l�N�X�g�X�e�[�W�{�^���������̏���
    public void NextButtonOnClick()
    {
        // ���̃V�[���̃r���h�C���f�b�N�X��ݒ�
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) %
                                            SceneManager.sceneCountInBuildSettings;
        // ���̃V�[���֑J��
        SceneManager.LoadScene(nextSceneIndex);
    }
    #endregion

    #endregion

    // ��x�������ʉ���炷�֐�
    private void PlayOnceSE(AudioClip seName)
    {
        if (!isPlay)
        {
            audioSource.PlayOneShot(seName);
            isPlay = true;
        }
    }

    // �Q�[���I�[�o�[���̏���������֐�
    private void GameOver()
    {
        // �Q�[���I�[�o�[���̌��ʉ�����x�����炷
        PlayOnceSE(gameoverSE);

        // gameoverImage�̓����x���ő�ɂȂ����ꍇ
        if (imageAlpha >= 1)
        {
            // �Q�[���I�[�o�[���̃p�l����\������
            gameoverPanel.SetActive(true);
        }
        else
        {
            // gameoverImage�̓����x���ő�ɂȂ�܂ŏ��X�ɉ��Z
            imageAlpha += addend;
        }

        // gameoverImage�̓����x��ύX
        gameoverImage.GetComponent<Image>().color = new Color(1, 1, 1, imageAlpha);
    }

    // �Q�[���N���A���̏���������֐�
    private void GameClear()
    {
        // �Q�[���N���A���̌��ʉ�����x�����炷
        PlayOnceSE(gameclearSE);

        // �Q�[���N���A���̃p�l����\������
        gameclearPanel.SetActive(true);

        // �N���A�����X�e�[�W���Ō�̃X�e�[�W�Ȃ�΁A�����ŃN���A�V�[���֑J��
        if (SceneManager.GetActiveScene().name == LAST_STAGE)
        {
            // waitTime���҂��Ă���N���A�V�[���֑J��
            Invoke("NextButtonOnClick", WAIT_TIME);
        }
    }


    void Start()
    {
        isGameClear = false;
        isGameOver = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[���N���A�����ꍇ
        if (isGameClear)
        {
            // �Q�[���N���A���̏��������s
            GameClear();
        }

        // �Q�[���I�[�o�[�����ꍇ
        if(isGameOver)
        {
            // �Q�[���I�[�o�[���̏��������s
            GameOver();
        }
    }
}
