using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TPMovement : MonoBehaviour
{
    //funciona github por favoooooooooooooooor
    //funcionou?
    //carol boba

    public float jumpForce;
    public float walkSpeed;
    public float runningSpeed;
    public float crouchingSpeed;
    public float turnSmoothVelocity;
    public float centerYnormal, centerYcrouch, heightNormal, heightCrouch;
    public Transform camera;
    public LayerMask groundLayer;
    public GameObject alma;

    int jumps = 2;
    float speed;
    float turnSmoothTime = 0.1f;
    float ccycenter, ccheight;
    bool animorto;
    Vector3 moveDir;
    Animator anim;
    CharacterController controller;
    Rigidbody rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        controller.GetComponent<CharacterController>().height = heightNormal;
        controller.GetComponent<CharacterController>().center = new Vector3(0, centerYnormal, 0.5f);

        ccheight = heightNormal;
        ccycenter = centerYnormal;

        camera = Camera.main.transform;
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hori, 0, vert);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(jumps > 0)
            {
                anim.SetTrigger("jump");
                jumps--;
            }
        }

        Collider[] feetTrigger = Physics.OverlapSphere(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.3f), 0.25f);
        for (int i = 0; i < feetTrigger.Length; i++)
        {
            if (feetTrigger[i].gameObject.CompareTag("Ground"))
            {
                jumps = 1;
                break;
            }
        }

        if (animorto)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                anim.SetTrigger("purificar");
                Instantiate(alma, transform.position, Quaternion.identity);
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            anim.SetTrigger("rugir");
            //passaros se mexem em direção do objetivo
        }

        if (direction.magnitude >= 0.1f)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
                anim.SetBool("crouch", false);

                speed = walkSpeed;

                ccheight = heightNormal;
                ccycenter = centerYnormal;
            }

            if (Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                anim.SetBool("crouch", false);

                speed = runningSpeed;

                ccheight = heightNormal;
                ccycenter = centerYnormal;
            }

            if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);
                anim.SetBool("crouch", true);

                speed = crouchingSpeed;

                ccheight = heightCrouch;
                ccycenter = centerYcrouch;
            }
            controller.GetComponent<CharacterController>().height = ccheight;
            controller.GetComponent<CharacterController>().center = new Vector3(0, ccycenter, 0.5f);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("run", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animorto"))
        {
            animorto = true;
        }

        if (other.gameObject.CompareTag("Fogo"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Animorto"))
        {
            animorto = false;
        }
    }
}
