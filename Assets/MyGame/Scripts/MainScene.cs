using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {


    public GameObject MainMenux;
    public GameObject Mech;
    static public bool ScoreCountTurn = false;
    public GameObject TutorialObject = null;
    void OnMouseUp()
    {
     
        TutorialObject.SetActive(false);
        DetectCollider.IfInMain = false;
        DetectCollider.Score = 0.00f;
        MainMenux.SetActive(false);
        Mech.transform.rotation = Quaternion.Euler(270, 180, 0);
        DetectCollider.Speed = 100;
        ScoreCountTurn = true;
      

    }
}
