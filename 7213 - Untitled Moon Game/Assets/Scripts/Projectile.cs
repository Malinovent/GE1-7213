using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mali.Audio;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float vitesse = 3;
    [SerializeField] private float lifetimeInSeconds = 10;
    [SerializeField] private int damage = 5;
    [SerializeField] private string audioClipName = "fireball";
    [SerializeField] private ParticleSystem particles;

    private Rigidbody2D rb;

    //Délégué
    public Action<GameObject> OnDeactivate;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = transform.right * vitesse;
        StartCoroutine(DeactivateCoroutine());
    }

    IEnumerator DeactivateCoroutine()
    {
        yield return new WaitForSeconds(lifetimeInSeconds);
        DeactivateProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Solid"))
        {
            DeactivateProjectile();
            return;
        }

        //Strategy 2
        Health health = collision.GetComponent<Health>();

        if(health)
        {
            health.TakeDamage(damage);
            DeactivateProjectile();
        }
    }

    private void DeactivateProjectile()
    {
        AudioManager.Singleton.PlayAudio(audioClipName);
        GameObject go = Instantiate(particles.gameObject);
        go.transform.position = this.transform.position;
        Destroy(go, 2);

        this.gameObject.SetActive(false);

        OnDeactivate?.Invoke(this.gameObject);
    }


}
