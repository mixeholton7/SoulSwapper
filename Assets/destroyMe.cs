using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMe : MonoBehaviour
{
    private bool IAmNew = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BecomeNotNew());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == gameObject.tag && !IAmNew)
        {
            Destroy(other.gameObject);
        }
    }

    IEnumerator BecomeNotNew()
    {
        yield return new WaitForSeconds(1);
        IAmNew = false;
    }
}
