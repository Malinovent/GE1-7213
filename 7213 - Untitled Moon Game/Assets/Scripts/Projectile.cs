using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mali.Audio;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 3;
    [SerializeField] private float lifetimeInSeconds = 10;
    [SerializeField] private int damage = 5;
    [SerializeField] private string audioClipName = "fireball";
    [SerializeField] private ParticleSystem particles;

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
        //Strategy 2
        Health health = collision.GetComponent<Health>();

        if(health)
        {
            health.TakeDamage(damage);
            AudioManager.Singleton.PlayAudio(audioClipName);
            GameObject go = Instantiate(particles.gameObject);
            go.transform.position = this.transform.position;
            Destroy(go, 2);
            Destroy(this.gameObject);
        }
    }

}
