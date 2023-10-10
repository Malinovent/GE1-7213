using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Mouvement2DRigidbody movementBehaviour;
    [SerializeField] private FiringBehaviour firingBehaviour;

    // Update is called once per frame
    void Update()
    {
        JumpInput();
        MoveInput();
        ShootProjectile();
    }

    private void MoveInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        movementBehaviour.Move(dirX);
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Jump
            movementBehaviour.Jump();
        }
    }

    private void ShootProjectile()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            firingBehaviour.FireProjectile();
        }
    }


}
