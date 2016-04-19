using UnityEngine;
using System.Collections;

public class ScoreDestoyer : MonoBehaviour
{


    void OnCollisionEnter(Collision collider)
    {

        if (collider.gameObject.name == "PlaneDestroy")
        {
           
            Destroy(gameObject);
          
            
        }
    }
}
