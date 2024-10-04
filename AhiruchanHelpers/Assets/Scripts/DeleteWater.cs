/*
    DeleteWater.cs
    Kawahara Rina

    生成したメタボールを定期的に削除するクラス。
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteWater : MonoBehaviour
{
    // 画面左下の座標を取得する用
    Vector3 screenLeftBottom;

    // Start is called before the first frame update
    void Start()
    {
        // 画面の左下の座標を取得
        screenLeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        // 画面の一番下よりy座標が小さくなった場合
        if (transform.position.y < screenLeftBottom.y - 1f)
        {
            // オブジェクトを削除
            Destroy(gameObject);
        }
    }
}
