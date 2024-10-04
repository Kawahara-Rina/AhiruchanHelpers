/*
    WaterGenerator.cs
    Kawahara Rina

    メタボールを生成するクラス。
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{

    [SerializeField] private GameObject prefabWater; // 生成するプレファブ
    [SerializeField] private GameObject canvas;      // 描画するキャンバス

    [SerializeField] private int maxWaterCnt;        // 出せる量の上限数

    [SerializeField] private float span;             // プレファブの生成スパン
    [SerializeField] private float wait;             // 何秒待つか指定用
    [SerializeField] private float minX;             // プレファブを生成するx座標のランダムの値を決める用
    [SerializeField] private float maxX;             // 
    [SerializeField] private float y;                // プレファブを生成するy座標

    private int waterCnt = 0;      // 現在出た水の量

    private float delta = 0;       // プレファブ生成からの経過時間
    private float waitTimer;       // 次に水を生成するまでのウェイトタイマー

    private bool isWaterMax=false; // 水がいっぱいになったかどうかのフラグ

   private GameManager gm;         // ゲームマネージャ取得用

    // 水の量が上限に達した場合の処理
    private void OnTriggerStay2D(Collider2D other)
    {
        isWaterMax = true;
    }

    // 水の量が上限に達していない場合の処理
    private void OnTriggerExit2D(Collider2D other)
    {
        isWaterMax = false;
    }

    // 水を生成する関数
    private void GenerateWater()
    {
        // 水の量が上限に達していない場合
        if (!isWaterMax)
        {
            // プレファブ生成から経過した時間を計算
            delta += Time.deltaTime;
        }

        //生成スパンを超えた場合水を生成
        if (delta >= span)
        {
            // 経過時間をリセット
            delta = 0;

            // 水の量をカウント
            waterCnt++;

            // 水(prefabWater)を生成
            var water = Instantiate(prefabWater, canvas.transform);

            // 生成する水のx座標を範囲からランダムに決定
            var x = Random.Range(minX, maxX);

            // 水の座標を代入
            water.transform.position = new Vector3(x, y, 0);
        }
    }

    // 水の生成を一定時間停止する関数
    private void StopGenerate()
    {
        // 限界水位に達していない場合
        if (!isWaterMax)
        {
            // ウェイトタイマーをカウントアップ
            waitTimer += Time.deltaTime;
        }

        // 数秒待ってからまた水を生成
        if (waitTimer >= wait)
        {
            // 0秒で初期化
            waitTimer = 0;

            // 出せる水の量をリセット
            waterCnt = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // ゲームマネージャのコンポーネントを取得
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    { 
        // 一度に出せる水の量の上限値を超えていない場合
        if (waterCnt <= maxWaterCnt)
        {
            // 水を生成する処理を実行
            GenerateWater();
        }
        // 上限数を超えた場合
        else
        {
            // 生成を止める処理を実行
            StopGenerate();
        }

    }
}
