using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    
    float speed = 0;//回転速度
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//マウスが押されたら
        {
            startPos = Input.mousePosition;//マウスがクリックした座標
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //マウスを離した座標
            Vector2 endPos = Input.mousePosition;
            
            float swipeLength = endPos.x - this.startPos.x;
            //スワイプの長さを初速度に変換する
            this.speed = swipeLength / 1500.0f;

        }
        transform.Translate(this.speed, 0, 0);//x軸　移動速度

        this.speed *= 0.70f;
    }
    
    /*
    private float starPosX;
    private float endPosY;   
    private bool isBeingHeld=false;
    void Start()
    {
        Application.targetFrameRate = 60;

    }
    void Update()
    { 
    if(isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }


    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
     */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "flag")
        {
           // SceneManager.LoadScene("GameOverScene"); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reset
            Debug.Log("水が汚された　Try Again");
        }
        
          if (collision.gameObject.tag == "ducky")
        {

            Debug.Log("アヒルが潰れました");
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
        }
        
    }
}
