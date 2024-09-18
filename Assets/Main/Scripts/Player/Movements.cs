
using TDS_Player;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private   bool isDrivingCar;
    private  bool IsDrivingTank, IsDrivingPoliceTank;
    private Transform carTransform;
    private Controller playerController;
    private Transform TankTransform;
    private Transform PoliceTankTransform;
    

    private void Awake() => playerController = GetComponent<Controller>();

    private void Update()
    {
        if(carTransform != null)
        {
            transform.position = carTransform.position;
            if(playerController != null) playerController.enabled = false; 
        }

       else if(TankTransform != null)
        {
            transform.position = TankTransform.position;
            if(playerController != null) playerController.enabled = false;  
        }

        else if(PoliceTankTransform != null)
        {
            transform.position = PoliceTankTransform.position;
            if(playerController != null) playerController.enabled = false;
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

    public void DriveTank(Transform Tank)
    {
        IsDrivingTank = true;
        TankTransform = Tank;
    }

    public void ExitTank()
    {
        IsDrivingTank = false;
        TankTransform = null;

        if (playerController != null)
            playerController.enabled = true;
    }

    public void DrivePoliceTank(Transform police)
    {
        IsDrivingPoliceTank = true;
        PoliceTankTransform = police;
    }

    public void ExitPoliceTank()
    {
        IsDrivingPoliceTank =false;
        PoliceTankTransform = null;

        if(playerController != null)
            playerController.enabled = true;
    }
}
