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
        ReturnToMenu();
    }

    private void MoveInput()
    {
        float dirX = Input.GetAxis("Horizontal");
        movementBehaviour.Move(dirX);
    }

    private void ReturnToMenu()
    {
        if(Input.GetKeyDown(KeyCode.Home))
        {
            GameManager.Singleton.GoToMainMenu();

            GameManager.Singleton.GameMode = "MainMenu";
        }
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
