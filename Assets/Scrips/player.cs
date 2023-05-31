using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody rb;
    public float forceMultiplier;
    public float jumpForce;
    public bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalforce = Input.GetAxis("Horizontal") * forceMultiplier;
        float verticalforce = Input.GetAxis("Vertical") * forceMultiplier;

        horizontalforce *= Time.deltaTime;
        verticalforce *= Time.deltaTime;

        transform.Translate(horizontalforce,0,verticalforce);

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(0f,jumpForce,0,ForceMode.Impulse);
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
}
