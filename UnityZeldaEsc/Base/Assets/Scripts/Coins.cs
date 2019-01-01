using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int coinAmount;



    public void CoinUpdate()
    {
        coinAmount += 1;
    }


}
