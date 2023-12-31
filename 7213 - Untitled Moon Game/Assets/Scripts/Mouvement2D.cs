using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement2D : MonoBehaviour
{
    [SerializeField] private float vitesse = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, vitesse, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, vitesse, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(vitesse, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(vitesse, 0, 0);
        }

        transform.position -= new Vector3(0, 0.1f, 0);
    }
}
