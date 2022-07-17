using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    

    //Script
    private CombatManager combatManager;

    // Start is called before the first frame update
    void Start()
    {
        combatManager = FindObjectOfType<CombatManager>();
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Entered in combat zone");
            combatManager.inCombatZone = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Exit from combat zone");
            combatManager.inCombatZone = false;
            combatManager.inCombat = true;
        }
    }
}
