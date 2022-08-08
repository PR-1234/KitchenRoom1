using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CharacterWalk : MonoBehaviour
{
    static Animator anim;
    public float speed = 2.0f;
    public float rotationSpeed =75.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical")*speed;
        float rotation = Input.GetAxis("Horizontal")*rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        Vector3 movement = new Vector3(translation, 0, rotation);
        rb.AddForce(movement * speed);

        if(translation !=0)
        {
            anim.SetBool("Armaturewalk_cycle", true);
        } else {
            anim.SetBool("Armaturewalk_cycle",false);
        }
    }
}
