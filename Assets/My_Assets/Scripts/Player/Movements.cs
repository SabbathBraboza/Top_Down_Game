using System.Collections;
using System.Collections.Generic;
using TDS_Player;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private  bool isDrivingCar;
    private Transform carTransform;
    private Controller playerController;

    private void Awake() => playerController = GetComponent<Controller>();

    private void Update()
    {
        if(carTransform != null)
        {
            transform.position = carTransform.position;
            if(playerController != null)
            {
                playerController.enabled = false;
            }
        }
    }

    public void DriveCar(Transform car)
    {
        isDrivingCar = true;
        carTransform = car;
    }

    public void ExitCar()
    {
        isDrivingCar = false;
        carTransform = null;

        if (playerController != null)
            playerController.enabled = true;
    }

}
