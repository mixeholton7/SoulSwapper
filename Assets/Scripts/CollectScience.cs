using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScience : MonoBehaviour
{
    public bool canIEat = true;
 
    private void OnTriggerEnter(Collider other)
    {
        var playerType = 0;

        if (other.tag == "Point" || canIEat)
        {
            if (this.gameObject.tag == "Player1")
            {
                playerType = 1;
            }
            if (this.gameObject.tag == "Player2")
            {
                playerType = 2;
            }
            if (this.gameObject.tag == "Player3")
            {
                playerType = 3;
            }

            scoreManeger.Instance.AddPoint(playerType);
            Destroy(other.gameObject);
        }
    }
}
