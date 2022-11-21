using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private new Rigidbody rigidbody = null;

    float force = 250.0f;
    float distance = 0.22f;
    float windForce = 0.0f;
    bool isGround = false;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.transform.GetComponent<Rigidbody>();
        rigidbody.AddForce(force, 0.0f, 0.0f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform trans = this.transform;
        Vector3 pos = trans.position;

        
        Vector3 rayPositionR = transform.position + new Vector3(0.4f, 0.0f, 0.0f);
        Ray ray = new Ray(rayPositionR, -Vector3.up);
        bool isGroundR = Physics.Raycast(ray, distance);

        Vector3 rayPositionL = transform.position + new Vector3(-0.4f, 0.0f, 0.0f);
        ray = new Ray(rayPositionL, -Vector3.up);
        bool isGroundL = Physics.Raycast(ray, distance);

        Vector3 rayPosition = transform.position;
        ray = new Ray(rayPositionL, -Vector3.up);
        isGround = Physics.Raycast(ray, distance + 0.1f) ;

        if (Input.GetMouseButtonDown(1) && isGround)
        {         
            rigidbody.AddForce(0.0f, 500.0f, 0.0f);
            animator.SetTrigger("Jump");
        }
        
        if (isGroundL||isGroundR)
        {
            Vector3 v = rigidbody.velocity;
            rigidbody.velocity = new Vector3(v.x, 0.0f, v.z);
            transform.position = new Vector3(pos.x, pos.y + 0.001f, pos.z);
           
        }
        Vector3 target = new Vector3();
        target.x = transform.position.x + rigidbody.velocity.x;
        target.y = transform.position.y;
        target.z = transform.position.z;
        this.transform.LookAt(target);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name=="Wind")
        {
            windForce = Random.Range(50, 100);
            Debug.Log(windForce);
            rigidbody.AddForce(0.0f,windForce, 0.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

}
