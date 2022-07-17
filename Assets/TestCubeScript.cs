using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent(typeof(Rigidbody))]
public class TestCubeScript : MonoBehaviour
{
    private Quaternion origin = Quaternion.identity;
  
    public float yAcceleration;
    public float yMaxAccelaration = 0;


    //acceleration
    public float speed = 1;
    private Rigidbody rb;

    private void GetOrigin()
    {
        origin = Input.gyro.attitude;
    }

    private void Start()
    {    
        GyroManager.Instance.EnableGyro();
        GetOrigin();

        //Acceleration
        rb = GetComponent<Rigidbody>();
      
    }

    private void Update()
    {
        transform.rotation = ConvertDxToSxHand(Quaternion.Inverse(origin) * Input.gyro.attitude);

        //Accelerometer
        yAcceleration = Input.acceleration.y * -1;

        if(yAcceleration > yMaxAccelaration)
        {
            yMaxAccelaration = yAcceleration;
        }

        if(yAcceleration >= 1.1)
        {
            rb.AddForce(0, yAcceleration * speed, 0);
        }
        
    }

    private Quaternion ConvertDxToSxHand(Quaternion dxHandQUaternion)
    {
        return new Quaternion(-dxHandQUaternion.x,
            -dxHandQUaternion.y,
            -dxHandQUaternion.z,
            dxHandQUaternion.w);
    }
}
