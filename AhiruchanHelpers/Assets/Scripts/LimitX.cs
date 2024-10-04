using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitX : MonoBehaviour
{
    public float minX; // x軸方向の最小座標
    public float maxX; // x軸方向の最大座標

    private void Update()
    {
        // 現在のオブジェクトの位置を取得
        Vector3 currentPosition = transform.position;

        // x軸方向の座標を制限
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // 制限をかけた座標をオブジェクトに反映
        transform.position = currentPosition;
    }
}