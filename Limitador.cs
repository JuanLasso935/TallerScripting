using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limitador : MonoBehaviour
{
    int count;
    public float restaporpedida;
    private void Update()
    {
        
    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "Destroy(Bajando interes)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));
            count++;
        }
        if (otherObj.gameObject.tag == "Destroy(Bajando interes)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));
            count++;

        }
        if (otherObj.gameObject.tag == "Destroy(Bajando interes)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));
            count++;
        }
        if (otherObj.gameObject.tag == "Destroy(Sin bajar interer)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));

        }
        if (otherObj.gameObject.tag == "Destroy(Sin bajar interer)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));

        }
        if (otherObj.gameObject.tag == "Destroy(Sin bajar interer)")
        {
            Destroy(GameObject.Find(otherObj.collider.name));

        }
        if (count >5 )
        {
            restaporpedida = 2;
            count = 0;
        }
        restaporpedida = 0;
    }

}
