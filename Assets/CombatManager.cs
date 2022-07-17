using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    //bool
    public bool inCombatZone = false;
    public bool inCombat;
    public bool canParry = false;
    public bool hasParried = false;

    //float
    public float hitTimer = 2.5f;
    public float backTimer;
    public float timeForParry = 1f;
    public float backParry;

    //Vector3
    public Vector3 acceleration;



    [Header("Audio")]
    public AudioSource swordSlash;
    public AudioSource parry;
    public AudioSource playerHitted;


    // Start is called before the first frame update
    void Start()
    {
        inCombat = true;
        backTimer = hitTimer;
        backParry = timeForParry;
       
    }

    // Update is called once per frame
    void Update()
    {
        //get accelleration
        acceleration = Input.acceleration;

        if (inCombatZone && inCombat)
        {
            backTimer -= Time.deltaTime;

            if(backTimer <= 0)
            {
                backTimer = hitTimer;
                swordSlash.Play();
                inCombat = false;            
                canParry = true;
                hasParried = false;
            }
        }

        //parry
        if (canParry)
        {
            backParry -= Time.deltaTime;

            if (backParry <= 0)
            {
                canParry = false;
                backParry = timeForParry;

                //get hit
                if (!hasParried)
                {
                    playerHitted.Play();
                }

                hasParried = false;
            }
        }   

        if(canParry & acceleration.y >= 0.8f)
        {
            parry.Play();
            hasParried = true;
            canParry = false;
        }
    }

}
