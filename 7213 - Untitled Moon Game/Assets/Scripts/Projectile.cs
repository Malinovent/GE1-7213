using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 3;
    [SerializeField] private float lifetimeInSeconds = 10;
    [SerializeField] private int damage = 5;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * vitesse;

        Destroy(this.gameObject, lifetimeInSeconds);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1. Tag
        //2. Trouver dans les dossier (Fait pas)
        //3. Layer
        //4. Name
        //5. ????

        //Strategy 2
        Health health = collision.GetComponent<Health>();

        if(health)
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }

        
        /*
        //Strategy 1
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(this.gameObject);
        }*/

    }

}
