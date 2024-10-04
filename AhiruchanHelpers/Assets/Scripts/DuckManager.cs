/*
    DuckManager.cs
    Kawahara Rina

    あひるを管理するクラス。
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour
{
    // Score取得用(Score:スコアを管理するクラス)
    private Score sc;
    // GameManager取得用(GameManager:ゲーム中のメインの処理を行うクラス)
    private GameManager gm;

    // ゴールしたかどうかのフラグ(一度だけ使用するため)
    private bool isGoal = false;
    // アニメーター取得用
    private Animator animator;

    // アヒルと何かが衝突した場合の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 衝突したオブジェクトのタグを取得
        var tag = collision.gameObject.tag;

        // ゲーム中に 触れるとゲームオーバーの物と衝突した場合
        if(tag == "DangerousItems" && !gm.isGameClear)
        {
            // Dieアニメーションのトリガーを発火
            animator.SetTrigger("Die");

            // ゲームオーバーのフラグを立てる
            gm.isGameOver = true;
        }
    }


    // アヒルと何かが触れた場合の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 触れたオブジェクトのタグを取得
        var tag = collision.gameObject.tag;

        // ゲーム中にゴールに触れた場合
        if (tag == "Goal" && !gm.isGameOver)
        {
            // 一度だけスコアを加算
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
        // Score、GameManager取得
        sc = GameObject.Find("score").GetComponent<Score>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        // animatorコンポーネント取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 

    }
}
