using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement2DRigidbody : MonoBehaviour
{

    [SerializeField] private float vitesse;
    [SerializeField] private float forceSaut = 100;
    [SerializeField] private float maxNombreSaut = 2;

    private float sautCounter = 0;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        rb.velocity = new Vector2(vitesse * direction, rb.velocity.y);

        if(direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Jump()
    {   
        if(sautCounter < maxNombreSaut)
        { 
            rb.AddForce(new Vector2(0, forceSaut));
            sautCounter++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //1. Deuxieme collider
        //2. Raycasting
        //3. Tag
        //4. Normal

        if (collision.contacts[0].normal.y >= 0.8)
        {
            sautCounter = 0;
        }
    }
}
