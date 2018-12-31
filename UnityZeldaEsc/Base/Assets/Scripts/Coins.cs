using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public int coinsVal = 0;
    Text score;

    private void Start()
    {
        score = GetComponent<Text>();

    }
     void Update()
    {
        score.text = coinsVal.ToString();
    }
}
