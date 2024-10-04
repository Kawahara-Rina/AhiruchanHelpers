/*
    WaterGenerator.cs
    Kawahara Rina

    ���^�{�[���𐶐�����N���X�B
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{

    [SerializeField] private GameObject prefabWater; // ��������v���t�@�u
    [SerializeField] private GameObject canvas;      // �`�悷��L�����o�X

    [SerializeField] private int maxWaterCnt;        // �o����ʂ̏����

    [SerializeField] private float span;             // �v���t�@�u�̐����X�p��
    [SerializeField] private float wait;             // ���b�҂��w��p
    [SerializeField] private float minX;             // �v���t�@�u�𐶐�����x���W�̃����_���̒l�����߂�p
    [SerializeField] private float maxX;             // 
    [SerializeField] private float y;                // �v���t�@�u�𐶐�����y���W

    private int waterCnt = 0;      // ���ݏo�����̗�

    private float delta = 0;       // �v���t�@�u��������̌o�ߎ���
    private float waitTimer;       // ���ɐ��𐶐�����܂ł̃E�F�C�g�^�C�}�[

    private bool isWaterMax=false; // ���������ς��ɂȂ������ǂ����̃t���O

   private GameManager gm;         // �Q�[���}�l�[�W���擾�p

    // ���̗ʂ�����ɒB�����ꍇ�̏���
    private void OnTriggerStay2D(Collider2D other)
    {
        isWaterMax = true;
    }

    // ���̗ʂ�����ɒB���Ă��Ȃ��ꍇ�̏���
    private void OnTriggerExit2D(Collider2D other)
    {
        isWaterMax = false;
    }

    // ���𐶐�����֐�
    private void GenerateWater()
    {
        // ���̗ʂ�����ɒB���Ă��Ȃ��ꍇ
        if (!isWaterMax)
        {
            // �v���t�@�u��������o�߂������Ԃ��v�Z
            delta += Time.deltaTime;
        }

        //�����X�p���𒴂����ꍇ���𐶐�
        if (delta >= span)
        {
            // �o�ߎ��Ԃ����Z�b�g
            delta = 0;

            // ���̗ʂ��J�E���g
            waterCnt++;

            // ��(prefabWater)�𐶐�
            var water = Instantiate(prefabWater, canvas.transform);

            // �������鐅��x���W��͈͂��烉���_���Ɍ���
            var x = Random.Range(minX, maxX);

            // ���̍��W����
            water.transform.position = new Vector3(x, y, 0);
        }
    }

    // ���̐�������莞�Ԓ�~����֐�
    private void StopGenerate()
    {
        // ���E���ʂɒB���Ă��Ȃ��ꍇ
        if (!isWaterMax)
        {
            // �E�F�C�g�^�C�}�[���J�E���g�A�b�v
            waitTimer += Time.deltaTime;
        }

        // ���b�҂��Ă���܂����𐶐�
        if (waitTimer >= wait)
        {
            // 0�b�ŏ�����
            waitTimer = 0;

            // �o���鐅�̗ʂ����Z�b�g
            waterCnt = 0;
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
        // ��x�ɏo���鐅�̗ʂ̏���l�𒴂��Ă��Ȃ��ꍇ
        if (waterCnt <= maxWaterCnt)
        {
            // ���𐶐����鏈�������s
            GenerateWater();
        }
        // ������𒴂����ꍇ
        else
        {
            // �������~�߂鏈�������s
            StopGenerate();
        }

    }
}
