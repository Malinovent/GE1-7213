using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int _currentHealth;

    [SerializeField] UnityEvent onTakeDamage;
    [SerializeField] UnityEvent onGainHealth;

    public int CurrentHealth => _currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);
        //Debug.Log(this.gameObject.name + " Took " + damage + " damage. Remaining health " + _currentHealth);
        if(_currentHealth <= 0)
        {
            CameraController.Singleton.ChangeCible(this.transform);
            //Destroy(this.gameObject);
            TimeManager.Singleton.TimeSlow(0.1f, 2);
            gameObject.SetActive(false);
        }

        onTakeDamage?.Invoke();
    }

    public void GainHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, maxHealth);

        onGainHealth?.Invoke();
    }
}
