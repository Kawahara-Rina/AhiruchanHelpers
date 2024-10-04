using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    
    float speed = 0;//��]���x
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//�}�E�X�������ꂽ��
        {
            startPos = Input.mousePosition;//�}�E�X���N���b�N�������W
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //�}�E�X�𗣂������W
            Vector2 endPos = Input.mousePosition;
            
            float swipeLength = endPos.x - this.startPos.x;
            //�X���C�v�̒����������x�ɕϊ�����
            this.speed = swipeLength / 1500.0f;

        }
        transform.Translate(this.speed, 0, 0);//x���@�ړ����x

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
            Debug.Log("���������ꂽ�@Try Again");
        }
        
          if (collision.gameObject.tag == "ducky")
        {

            Debug.Log("�A�q�����ׂ�܂���");
            Destroy(collision.gameObject);
            GetComponent<AudioSource>().Play();
        }
        
    }
}
