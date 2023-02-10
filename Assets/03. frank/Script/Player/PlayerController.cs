using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    Rigidbody rb;
    float sensitiveMove = 2f;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
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

        if (Input.GetKey("left shift") && Input.GetKey(KeyCode.W)) //Shiftキーかつ上キーが押されている間
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

        float moveX = Input.GetAxis("Mouse X") * sensitiveMove;
        float moveY = Input.GetAxis("Mouse Y") * sensitiveMove;
        if (cam.transform.localRotation.x > -0.3 && -moveY <= 0)
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
            //
            Cursor.visible = true;
        }
    }
}
