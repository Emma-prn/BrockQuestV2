using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Vector2 direction;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        setParam();
    }

    void setParam(){
        if(direction.x == 0 && direction.y == 0) // Idle
        {
            anim.SetInteger("direction",0);
        }
        else if(direction.y < 0) // Bas
        {
            anim.SetInteger("direction",1);
        }
        else if(direction.x > 0) // Droite
        {
            anim.SetInteger("direction",2);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if(direction.x < 0) // Gauche
        {
            anim.SetInteger("direction",2);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(direction.y > 0) // Haut
        {
            anim.SetInteger("direction",4);
        }
    }
}
