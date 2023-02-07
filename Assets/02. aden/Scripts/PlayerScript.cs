using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody rb;
    private int jampCount = 1;
    float sensitiveMove = 0.8f;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator playerAnima;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        playerAnima = GetComponent<Animator>();
        //カーソル非表示
        Cursor.visible = false;
        //自由に動かせる
        Cursor.lockState = CursorLockMode.None;
        //ウィンドウ内のみ
        Cursor.lockState = CursorLockMode.Confined;
        //中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime;
            playerAnima.SetBool("walk",true);
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += -transform.right * Time.deltaTime;
            playerAnima.SetBool("walk",true);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * Time.deltaTime;
            playerAnima.SetBool("back", true);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime;
            playerAnima.SetBool("walk", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jampCount > 0)
        {
            rb.AddForce(transform.up * 200);
            playerAnima.SetBool("jamp", true);
        }


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            transform.position += transform.forward * Time.deltaTime;
            playerAnima.SetBool("walk", false);

        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.position += -transform.right * Time.deltaTime;
            playerAnima.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            transform.position += -transform.forward * Time.deltaTime;
            playerAnima.SetBool("back", false);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime;
            playerAnima.SetBool("walk", false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(transform.up * 200);
            playerAnima.SetBool("jamp", false);
        }


        float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
            float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
        if (cam.transform.localRotation.x > -0.3 && -moveY<=0)
        {
            cam.transform.localRotation *= Quaternion.Euler(-Mathf.Abs(moveY), 0, 0);
            Debug.Log(cam.transform.localRotation);
        }
        if (cam.transform.localRotation.x < 0.3 && -moveY >= 0)
        {
            cam.transform.localRotation *= Quaternion.Euler(Mathf.Abs(moveY), 0, 0);
            Debug.Log(cam.transform.localRotation);
        }
        transform.localRotation *= Quaternion.Euler(0, moveX, 0);

        if (Input.GetKey(KeyCode.Escape))
        {
            //カーソル表示
            Cursor.visible = true;
        }
    }
}


