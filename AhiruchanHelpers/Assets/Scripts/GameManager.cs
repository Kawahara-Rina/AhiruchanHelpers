/*
    GameManager.cs
    Kawahara Rina

    ゲーム中のメインの処理を行うクラス。
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 定数
    const string LAST_STAGE = "Stage3";  // 最後のステージ名
    const float WAIT_TIME = 8f;          // Invokeで使用するウェイトタイム

    [SerializeField] private GameObject gameoverPanel;   // ゲームオーバー時に表示するパネル
    [SerializeField] private Image gameoverImage;        // ゲームオーバー時に表示するイメージ
    [SerializeField] private GameObject gameclearPanel;  // ゲームクリア時に表示するパネル

    [SerializeField] private AudioClip gameoverSE;       // ゲームオーバー時の効果音
    [SerializeField] private AudioClip gameclearSE;      // ゲームクリア時の効果音

    [SerializeField] private float addend;               // 加算する値(gameoverImageの透明度変化に使用)

    private float imageAlpha;        // Imageの透明度変化に使用
    private bool isPlay = false;     // 効果音を一度だけ鳴らすために使用するフラグ
    private AudioSource audioSource; // オーディオソース取得用

    public bool isGameClear;         // ゲームをクリアした場合に成立するフラグ
    public bool isGameOver;          // ゲームオーバーした場合に成立するフラグ

    #region パブリック関数

    #region TitleButtonOnClick - 各シーンタイトルボタン押下時の処理
    public void TitleButtonOnClick()
    {
        // タイトルシーンへ遷移
        SceneManager.LoadScene("TitleScene");
    }
    #endregion

    #region RetryButtonOnClick - 各シーンリトライボタン押下時の処理
    public void RetryButtonOnClick()
    {
        // 現在のシーンを再ロード
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    #endregion

    #region NextButtonOnClick - 各シーンネクストステージボタン押下時の処理
    public void NextButtonOnClick()
    {
        // 次のシーンのビルドインデックスを設定
        int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) %
                                            SceneManager.sceneCountInBuildSettings;
        // 次のシーンへ遷移
        SceneManager.LoadScene(nextSceneIndex);
    }
    #endregion

    #endregion

    // 一度だけ効果音を鳴らす関数
    private void PlayOnceSE(AudioClip seName)
    {
        if (!isPlay)
        {
            audioSource.PlayOneShot(seName);
            isPlay = true;
        }
    }

    // ゲームオーバー時の処理をする関数
    private void GameOver()
    {
        // ゲームオーバー時の効果音を一度だけ鳴らす
        PlayOnceSE(gameoverSE);

        // gameoverImageの透明度が最大になった場合
        if (imageAlpha >= 1)
        {
            // ゲームオーバー時のパネルを表示する
            gameoverPanel.SetActive(true);
        }
        else
        {
            // gameoverImageの透明度が最大になるまで徐々に加算
            imageAlpha += addend;
        }

        // gameoverImageの透明度を変更
        gameoverImage.GetComponent<Image>().color = new Color(1, 1, 1, imageAlpha);
    }

    // ゲームクリア時の処理をする関数
    private void GameClear()
    {
        // ゲームクリア時の効果音を一度だけ鳴らす
        PlayOnceSE(gameclearSE);

        // ゲームクリア時のパネルを表示する
        gameclearPanel.SetActive(true);

        // クリアしたステージが最後のステージならば、自動でクリアシーンへ遷移
        if (SceneManager.GetActiveScene().name == LAST_STAGE)
        {
            // waitTime分待ってからクリアシーンへ遷移
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
        // ゲームクリアした場合
        if (isGameClear)
        {
            // ゲームクリア時の処理を実行
            GameClear();
        }

        // ゲームオーバーした場合
        if(isGameOver)
        {
            // ゲームオーバー時の処理を実行
            GameOver();
        }
    }
}
