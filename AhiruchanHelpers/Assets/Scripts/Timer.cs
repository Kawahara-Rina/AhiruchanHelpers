/*
    Timer.cs
    Kawahara Rina

    ゲーム中のカウントダウンタイマーを管理するクラス。
*/

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;   // 制限時間を表示するテキスト
    [SerializeField] private float time;       // 制限時間

    private GameManager gm;  // GameManager取得用

    // 制限時間のカウントダウンをする関数
    private void CountDownTime()
    {
        // 制限時間を表示する
        timerText.text = string.Format("{0}", Mathf.Ceil(time));
        time -= Time.deltaTime;
    }

    // 制限時間が0になった場合の処理をする関数
    private void TimeIsUp()
    {
        // ゲームの状態をゲームオーバーに
        gm.isGameOver = true;

        // タイマーは0秒表示
        timerText.text = string.Format("0");
    }

    // Start is called before the first frame update
    void Start()
    {
        // GameManagerのコンポーネントを取得
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲーム中の場合
        if (!gm.isGameClear)
        {
            // 制限時間をカウントダウン
            CountDownTime();
        }

        // 制限時間が残り0秒の場合
        if (time < 0)
        {
            // ゲームオーバー時の処理へ
            TimeIsUp();
        }

    }

}
