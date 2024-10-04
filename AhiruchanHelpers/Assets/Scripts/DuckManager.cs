/*
    DuckManager.cs
    Kawahara Rina

    ���Ђ���Ǘ�����N���X�B
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    // Score�擾�p(Score:�X�R�A���Ǘ�����N���X)
    private Score sc;
    // GameManager�擾�p(GameManager:�Q�[�����̃��C���̏������s���N���X)
    private GameManager gm;

    // �S�[���������ǂ����̃t���O(��x�����g�p���邽��)
    private bool isGoal = false;
    // �A�j���[�^�[�擾�p
    private Animator animator;

    // �A�q���Ɖ������Փ˂����ꍇ�̏���
    void OnCollisionEnter2D(Collision2D collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O���擾
        var tag = collision.gameObject.tag;

        // �Q�[������ �G���ƃQ�[���I�[�o�[�̕��ƏՓ˂����ꍇ
        if(tag == "DangerousItems" && !gm.isGameClear)
        {
            // Die�A�j���[�V�����̃g���K�[�𔭉�
            animator.SetTrigger("Die");

            // �Q�[���I�[�o�[�̃t���O�𗧂Ă�
            gm.isGameOver = true;
        }
    }


    // �A�q���Ɖ������G�ꂽ�ꍇ�̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �G�ꂽ�I�u�W�F�N�g�̃^�O���擾
        var tag = collision.gameObject.tag;

        // �Q�[�����ɃS�[���ɐG�ꂽ�ꍇ
        if (tag == "Goal" && !gm.isGameOver)
        {
            // ��x�����X�R�A�����Z
            if (!isGoal)
            {
                sc.getDuckScore++;
                isGoal = true;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Score�AGameManager�擾
        sc = GameObject.Find("score").GetComponent<Score>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        // animator�R���|�[�l���g�擾
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
