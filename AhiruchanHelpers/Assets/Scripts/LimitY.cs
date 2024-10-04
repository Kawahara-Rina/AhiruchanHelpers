using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitY : MonoBehaviour
{
    public float minY; // Y軸方向の最小座標
    public float maxY; // Y軸方向の最大座標

    private void Update()
    {
        // 現在のオブジェクトの位置を取得
        Vector3 currentPosition = transform.position;

        // Y軸方向の座標を制限
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);

        // 制限をかけた座標をオブジェクトに反映
        transform.position = currentPosition;
    }
}