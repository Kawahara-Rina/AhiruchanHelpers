/*
    Score.cs
    Kawahara Rina

    スコアを管理するクラス。
*/ 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;  // スコアを表示するテキスト
    [SerializeField] private int clearScore;  // クリアに必要スコア数

    private GameManager gm;                   // ゲームマネージャ取得用

    public int getDuckScore;                  // 獲得したアヒルの数(スコア)


    // スコアを表示する関数
    private void ShowScore()
    {
        // スコアを表示
        scoreText.text = string.Format("× {0}", getDuckScore);

        // 獲得したアヒルの数がクリアに必要なスコア数を超えた場合
        if (getDuckScore >= clearScore)
        {
            // ゲームクリアのフラグを立てる
            gm.isGameClear = true;
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
        // スコアを表示
        ShowScore();
    }
}
