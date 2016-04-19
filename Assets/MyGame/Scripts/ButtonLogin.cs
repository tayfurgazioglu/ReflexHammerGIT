using UnityEngine;
using System.Collections;

public class ButtonLogin : MonoBehaviour {

   bool TakenName = false;
    public TextMesh TakenUsername = null;
    public TextMesh TextWarning = null;
	void OnMouseUp()
    {
        TakenName = false;
            for (int i = 0; i < Highscores.highscoresList.Length; i++)
            {
                if (DetectCollider.Username == Highscores.highscoresList[i].username)
                {

                if (DetectCollider.TempUser != DetectCollider.Username)

                {

               
                    TextWarning.gameObject.SetActive(false);
                    TakenUsername.gameObject.SetActive(true);
                    TakenName = true;
                }
            }
            }





        if (TakenName == false)
        {
            TakenUsername.gameObject.SetActive(false);
            UsernameInput.SwitchLogin = true;
        }
        

    }
}
