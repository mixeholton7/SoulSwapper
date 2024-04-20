using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScience : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        //var points = 0;
        var playerType = 0;

        if (other.tag == "Point")
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

            // print("WHat tag am I ? : player: " + playerType);
            scoreManeger.Instance.AddPoint(playerType);
            Destroy(other.gameObject);
        }
    }
}
