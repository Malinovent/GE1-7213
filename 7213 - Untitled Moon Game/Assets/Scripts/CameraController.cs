using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Singleton Implementation
    public static CameraController Singleton;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField] private Transform cible;
    [SerializeField] private AnimationCurve curve;

    private void Update()
    {
        Vector3 targetPosition = this.transform.position;

        targetPosition = Vector3.Lerp(targetPosition, cible.transform.position, 10f * Time.deltaTime);
        
        targetPosition.z = -10;

        this.transform.position = targetPosition;
    }

    public void ChangeCible(Transform newCible)
    {
        cible = newCible;
    }
}
