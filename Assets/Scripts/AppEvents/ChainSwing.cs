using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSwing : MonoBehaviour
{
    // Start is called before the first frame update
    public float max = 50;
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(0, max), 0, Random.Range(0, max));
    }

   
}
