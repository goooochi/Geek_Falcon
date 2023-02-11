using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController1 : MonoBehaviour
{

    private Animator animator;
    Rigidbody rb;
    float sensitiveMove = 2f;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject player;
    Laser_Create_Player1 laser_Create_Player1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Cursor.visible = false;

        laser_Create_Player1 = player.GetComponent<Laser_Create_Player1>();
        //ウィンドウ内のみ
        Cursor.lockState = CursorLockMode.Confined;
        //中央にロック
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, 3);
            gameObject.transform.position += velocity * Time.deltaTime;
            animator.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, 3);
            gameObject.transform.position -= velocity * Time.deltaTime;
            animator.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(3, 0, 0);
            gameObject.transform.position -= velocity * Time.deltaTime;
            animator.SetBool("Walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(-3, 0, 0);
            gameObject.transform.position -= velocity * Time.deltaTime;
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
            rb.velocity = Vector3.zero;
        }


        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(0, -1, 0);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(0, 1, 0);
        //}

        
         if (Input.GetKey(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                cam.transform.DOMoveY(0.7f, 0.5f).SetEase(Ease.InOutQuad);
            }
                animator.SetBool("Walking", false);
            animator.SetBool("Squat", true);
           
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, -2);
                gameObject.transform.position += velocity * Time.deltaTime;
                laser_Create_Player1.canCreateLaser = false;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, 2);
                gameObject.transform.position += velocity * Time.deltaTime;
                laser_Create_Player1.canCreateLaser = false;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(2, 0, 0);
                gameObject.transform.position += velocity * Time.deltaTime;
                laser_Create_Player1.canCreateLaser = false;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Vector3 velocity = gameObject.transform.rotation * new Vector3(-2, 0, 2);
                gameObject.transform.position += velocity * Time.deltaTime;
                laser_Create_Player1.canCreateLaser = false;
            }
        }
       else if (Input.GetKey("left shift") && Input.GetKey(KeyCode.W)) //Shiftキーかつ上キーが押されている間
        {
            Vector3 velocity = gameObject.transform.rotation * new Vector3(0, 0, 3);
            gameObject.transform.position += velocity * Time.deltaTime;
            animator.SetBool("Running", true);
        }

        else
        {
            animator.SetBool("Running", false);
        }

        if (Input.GetKeyUp("left shift")) //Shiftキーを離したとき
        {
            animator.SetBool("Running", false);

        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            laser_Create_Player1.canCreateLaser = true;
            animator.SetBool("Squat", false);
            cam.transform.DOMoveY(2.2f, 1).SetEase(Ease.InOutQuad);
        }

        float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
        float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
        if (cam.transform.localRotation.x > -0.3 && -moveY <= 0)
        {
            cam.transform.localRotation *= Quaternion.Euler(-Mathf.Abs(moveY), 0, 0);

        }
        if (cam.transform.localRotation.x < 0.3 && -moveY >= 0)
        {
            cam.transform.localRotation *= Quaternion.Euler(Mathf.Abs(moveY), 0, 0);
          
        }
        transform.localRotation *= Quaternion.Euler(0, moveX, 0);

        if (Input.GetKey(KeyCode.Escape))
        {
            //
            Cursor.visible = true;
        }
    }
}
