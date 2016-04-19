using UnityEngine;
using System.Collections;

public class OnMouseNo : MonoBehaviour {

    public GameObject MainAskScreen = null;

    void OnMouseUp()
    {
        MainAskScreen.SetActive(false);
    }

}
