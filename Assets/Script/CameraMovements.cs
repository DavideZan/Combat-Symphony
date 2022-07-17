using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private Player playerManager;

    [SerializeField] private Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    // Start is called before the first frame update

    private void Start()
    {
        GyroManager.Instance.EnableGyro();
        playerManager = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = GyroManager.Instance.GetGyroRotation() * baseRotation;
        transform.position = playerManager.PlayerPos();
    }
}
