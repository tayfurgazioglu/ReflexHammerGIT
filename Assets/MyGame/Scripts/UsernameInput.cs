using UnityEngine;
using System.Collections;

public class UsernameInput : MonoBehaviour
{
    static public bool InLogin = true;
    static public int FirstTime = 0;
    public GameObject FirstTimeBackground = null;
    public TextMesh TapToStartBack = null;
    public TextMesh BestBack = null;

   // public TextMesh FirstTimeUsernameMesh = null;

    public GUIStyle m_styleButton = null;
    public Rect SubmiTButton;
    
    public Rect TextArea;
    public TextMesh WarningUsername;
    public TextMesh WarningTakenUsername;
    public GUIStyle username_style;
    public GUIStyle WindowsTexture;

    static public bool SwitchLogin = false;
   
    Rect UpdateDimension(Rect position, float dy = 0.0f)
    {
        position.y += dy;
        return (
            new Rect(
                (position.x / DetectCollider.m_screenRect.width) * Screen.width,
                (position.y / DetectCollider.m_screenRect.height) * Screen.height,
                (position.width / DetectCollider.m_screenRect.width) * Screen.width,
                (position.height / DetectCollider.m_screenRect.height) * Screen.height
            ));
    }
    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTimeNumb"))
       {
            PlayerPrefs.SetInt("FirstTimeNumb", 0);
            PlayerPrefs.Save();
       }


        FirstTime = PlayerPrefs.GetInt("FirstTimeNumb");
    }


void Field(int id)
    {
        username_style.fontSize = Mathf.Min((Screen.height) / 6, (Screen.width) / 6);
        DetectCollider.Username = GUI.TextField(new Rect(10, 20, 380, 270), DetectCollider.Username,username_style);
    }


    void OnGUI()
    {



        if (FirstTime == 0)
        {
            if (InLogin)
            {
           
                    FirstTimeBackground.SetActive(true);
                    DetectCollider.IfInMain = false;
                    TapToStartBack.gameObject.SetActive(false);
                    BestBack.gameObject.SetActive(false);
                // FirstTimeUsernameMesh.gameObject.SetActive(true);


                // GUILayout.BeginArea(UpdateDimension(TextArea));

                
               // username_style.fontSize = Mathf.Min((Screen.height) / 15,(Screen.width) / 5);
              //  DetectCollider.Username = GUI.TextField(new Rect(Screen.width / 2 , Screen.height / 2, 222, 111), DetectCollider.Username, username_style);
              
              //  DetectCollider.Username = GUILayout.TextField(DetectCollider.Username);





                GUI.Window(0, new Rect(Screen.width / 2-200, Screen.height / 2-200, 400, 300), Field, "LOGIN");







                //GUILayout.EndArea();

                if (SwitchLogin)
                {
                    if (DetectCollider.Username != "Type" && DetectCollider.Username.Length <= 10 && !DetectCollider.Username.Contains("\\"))
                    {
                        WarningUsername.gameObject.SetActive(false);
                        FirstTime = 1;
                        PlayerPrefs.SetInt("FirstTimeNumb", FirstTime);
                        PlayerPrefs.Save();
                      
                        PlayerPrefs.SetString("UsernameX", DetectCollider.Username);
                        PlayerPrefs.Save();
                        InLogin = false;
                     
                        FirstTimeBackground.SetActive(false);
                        TapToStartBack.gameObject.SetActive(true);
                        BestBack.gameObject.SetActive(true);
                        DetectCollider.IfInMain = true;
                        //     FirstTimeUsernameMesh.gameObject.SetActive(false);
                      
                        SwitchLogin = false;
                        
                    }
                    else
                    {
                   
                        
                        SwitchLogin = false;
                        WarningUsername.gameObject.SetActive(true);
                        WarningTakenUsername.gameObject.SetActive(false);
                    }

                }

            }
        }
    }
}
