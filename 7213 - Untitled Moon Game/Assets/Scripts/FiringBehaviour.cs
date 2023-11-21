using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileFiringPoint;
    [SerializeField] private int poolSize = 5;

    private Queue<GameObject> pool = new Queue<GameObject>();
    private GameObject poolParent;

    private void Start()
    {
        poolParent = new GameObject();
        poolParent.name = "Projectile Pool";

        CreateProjectiles();
    }

    private void CreateProjectiles()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectile.transform.parent = poolParent.transform;
            ReturnToPool(projectile);

            projectile.GetComponent<Projectile>().OnDeactivate += ReturnToPool;
        }
    }

    private void ReturnToPool(GameObject projectile)
    {
        pool.Enqueue(projectile);
    }

    private GameObject GetFromPool()
    {
        if(pool.Count == 0)
        {
            CreateProjectiles();
        }

        return pool.Dequeue();
    }

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

        GameObject projectile = GetFromPool();
        projectile.SetActive(true);
        projectile.transform.position = projectileFiringPoint.position;
        projectile.transform.rotation = rotation;
    }




}
