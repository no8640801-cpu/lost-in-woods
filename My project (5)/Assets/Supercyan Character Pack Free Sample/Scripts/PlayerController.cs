using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    public float speed = 5f;
    public float rotationSpeed = 100f;
    private float horizontalInput;
    private float verticalInput;
    private float jumpForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0;

        animator.SetBool("isWalking", isMoving);

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
            
    }
    
}
