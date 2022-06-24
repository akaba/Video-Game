using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public bool hasCoin;
    // Start is called before the first frame update
    void Start()
    {
        hasCoin = false;

    }

    public void ReceiveCoin()
    {
        hasCoin = true;
        //  Debug.LogError("hasBall value is : " + hasBall);
    }
}
