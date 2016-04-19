using UnityEngine;
using System.Collections;

public class ExitOnMouse : MonoBehaviour
{
  

    static public bool ExitDestroy = false;

    void OnMouseUp()
    {
       
     
        DestoryMeX();
    
    }

    public void DestoryMeX()
    {
        ExitDestroy = true;
        Destroy(gameObject, 0);
    }
}