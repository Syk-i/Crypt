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
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            coinsVal += 10;
            Destroy(gameObject);

        }

    }
    void Update()
    {
        
        score.text = coinsVal.ToString();

    }
    
    
}
