using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroManager : MonoBehaviour
{

    private Gyroscope gyro;
    private Quaternion rotation;
    private bool gyroActive;


    #region Instance
    private static GyroManager instance;
    public static GyroManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GyroManager>();
                if(instance == null)
                {
                    instance = new GameObject("Spawned GyroManager", typeof(GyroManager)).GetComponent<GyroManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    #endregion 
    public void EnableGyro()
    {
        //Alredy activated
        if (gyroActive)
            return;

        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            gyroActive = gyro.enabled;
        }
    }

    void Update()
    {
        if (gyroActive)
        {
            rotation = gyro.attitude;
                Debug.Log(rotation);
        }
    }
    public Quaternion GetGyroRotation()
    {
        return rotation;
    }
}
