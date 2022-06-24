using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : MonoBehaviour
{

    private Animator anim;
    //public bool rotateCoin;

    //public GameObject destroyedVersion;

    void Start()
    {
        anim = GetComponent<Animator>();
        //rotateCoin = true;
    }

    void OnTriggerEnter(Collider c)
    {

        if (c.attachedRigidbody != null)
        {
            CoinCollector cc = c.attachedRigidbody.gameObject.GetComponent<CoinCollector>();

            if (cc != null)
            {
                EventManager.TriggerEvent<BombBounceEvent, Vector3>(c.transform.position);

                // play the animation
                if (anim != null)
                {                   
                  // rotateCoin = false;
                  // transform.Rotate(45.0f, 0.0f, 0.0f);
                   anim.SetBool("moveCoin", true);
                }                
                             
                cc.ReceiveCoin();
                
               // Instantiate(destroyedVersion, transform.position, transform.rotation);
               // Destroy(this.gameObject);
            }

        }

    }


    // CoinRotator
   void Update()
   {
       transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime * 5);
   }



    void OnTriggerExit(Collider c)
    {

        if (anim != null)
        {
            anim.SetBool("moveCoin", false);
            //rotateCoin = true;
        }
         
    }


}
