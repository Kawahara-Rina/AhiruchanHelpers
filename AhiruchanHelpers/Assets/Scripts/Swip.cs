using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swip : MonoBehaviour
{
    public float swipeSpeed = 5f; // スワイプによる移動速度
    public float swipeThreshold = 50f; // スワイプを検出する最小距離

    private Vector3 initialPosition; // タッチ（またはクリック）が始まった位置
    private bool isDragging = false; // オブジェクトがドラッグ中かどうかのフラグ

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        // オブジェクトがドラッグ中の場合
        if (isDragging)
        {
            Vector3 currentPosition = Input.mousePosition;
            float swipeDistance = currentPosition.y - initialPosition.y;

            // スワイプした距離が一定以上であれば、上下に移動させる
            if (Mathf.Abs(swipeDistance) > swipeThreshold)
            {
                float direction = swipeDistance > 0 ? 1f : -1f; // スワイプの方向を取得
                Vector3 newPosition = transform.position + Vector3.up * swipeSpeed * direction * Time.deltaTime;
                transform.position = newPosition;
            }
        }
    }
}