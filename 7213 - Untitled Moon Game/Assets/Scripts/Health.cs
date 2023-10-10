using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        Debug.Log(this.gameObject.name + " Took " + damage + " damage. Remaining health " + _currentHealth);
        if(_currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
