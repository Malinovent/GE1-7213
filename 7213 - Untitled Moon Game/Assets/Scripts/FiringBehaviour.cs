using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFiringPoint;

    public void FireProjectile()
    {
        //Direction vers le droite par default
        Vector3 direction = Vector3.zero;

        //Direction vers le gauche si le x est negative
        if(transform.localScale.x < 0)
        {
            direction = new Vector3(0, 0, 180);
        }

        Quaternion rotation = Quaternion.Euler(direction);

        GameObject instance = Instantiate(projectilePrefab, projectileFiringPoint.position, rotation);
        /*
        //Direction vers le gauche si le x est negative
        if (transform.localScale.x < 0)
        {
            instance.transform.localEulerAngles = new Vector3(0, 0, 180);
        }*/
    }


}
