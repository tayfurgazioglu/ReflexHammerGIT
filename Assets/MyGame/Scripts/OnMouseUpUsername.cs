using UnityEngine;
using System.Collections;

public class OnMouseUpUsername : MonoBehaviour {

    public GameObject UsernameText = null;

  

    void OnMouseUp()
    {   
         
        UsernameInput.InLogin = true;
        UsernameInput.FirstTime = 0;
        ExitOnMouse.ExitDestroy = true;
     

      Destroy(DetectCollider.ExitIns, 0);
        UsernameText.SetActive(false);
    }
}
