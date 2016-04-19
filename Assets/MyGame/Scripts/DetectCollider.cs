using System;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;





public class GoogleMobileAdsDemoHandler : IInAppPurchaseHandler
{
    private readonly string[] validSkus = { "android.test.purchased" };

    //Will only be sent on a success.
    public void OnInAppPurchaseFinished(IInAppPurchaseResult result)
    {
        result.FinishPurchase();
      
    }

    //Check SKU against valid SKUs.
    public bool IsValidPurchase(string sku)
    {
        foreach (string validSku in validSkus)
        {
            if (sku == validSku)
            {
                return true;
            }
        }
        return false;
    }

    //Return the app's public key.
    public string AndroidPublicKey
    {
        //In a real app, return public key instead of null.
        get { return null; }
    }
}

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class DetectCollider : MonoBehaviour
{


    public static Rect m_screenRect = new Rect(0, 0, 640, 960);

    public Texture2D m_textureInvisible = null;
    public Texture2D m_textureNaked = null;
    public Texture2D m_textureBadge = null;
    public Texture2D m_textureWarning = null;

    public GUIStyle m_styleButton = null;

   // public Rect m_giftizButton;
    public Rect LeaderButton;
    public Rect LeaderButtonExit;
    public Rect SettingsButton;
    public Rect HeartReck;

    public GameObject LeaderBoardActive = null;
    public GameObject LeaderBoardBackground = null;

    static public bool LeaderExiter = true;
    static public bool ExitButton = false;
    static public bool InSeetings = false;

   static public int OneTimeButton = 1;

    public GameObject ExitPrefab;

    public Texture2D LeaderTexture = null;
    public Texture2D LeaderTextureExit = null;
    public Texture2D SettingsText = null;

    public GameObject UsernameChange = null;

    public GameObject UsernameTextMesh = null;
    

    static public bool IfInMain = true;

    static public GameObject ExitIns = null;

    public Texture2D HeartTexture = null;
    public Texture2D HeartTexture2 = null;

    public GameObject HeartGameScreen1 = null;
    public GameObject HeartGameScreen2 = null;

    static public int Life = 0;

        public GameObject MainAskScreen = null;

    static public bool MainAskScreenBool = false;


    public TextMesh YourPlaceInLeaderBoard = null;

    public TextMesh YouCanOnlyHaveOneLife = null;







   










    public static Rect UpdateDimension(Rect position, float dy = 0.0f)
    {
        position.y += dy;
        return (
            new Rect(
                (position.x / m_screenRect.width) * Screen.width,
                (position.y / m_screenRect.height) * Screen.height,
                (position.width / m_screenRect.width) * Screen.width,
                (position.height / m_screenRect.height) * Screen.height
            ));
    }

 


    public void OnGUI()
    {



        



        if (IfInMain)
        {
           
                if (LeaderExiter)
            {




                if (Life == 0)
                {


                    HeartGameScreen1.SetActive(true);
                    HeartGameScreen2.SetActive(false);
                    m_styleButton.normal.background = m_styleButton.active.background = HeartTexture;
                    if (GUI.Button(UpdateDimension(HeartReck), "", m_styleButton) == true)
                    {

                        MainAskScreen.SetActive(true);
                     
                    }
                }
                else
                {

                    HeartGameScreen1.SetActive(false);
                    HeartGameScreen2.SetActive(true);
                    m_styleButton.normal.background = m_styleButton.active.background = HeartTexture2;
                    if (GUI.Button(UpdateDimension(HeartReck), "", m_styleButton) == true)
                    {
                        GameObject Only1Life = Instantiate(YouCanOnlyHaveOneLife.gameObject, GameObject.Find("WarningHold").transform.position, GameObject.Find("WarningHold").transform.rotation) as GameObject;

                        Destroy(Only1Life.gameObject, 1.5f);
                        Debug.Log("You can only have 1 life");

                    }

                }




                    m_styleButton.normal.background = m_styleButton.active.background = SettingsText;
                if (GUI.Button(UpdateDimension(SettingsButton), "", m_styleButton) == true)
                {
                    OneTimeTutorialObject.SetActive(false);
                    InSeetings = true;
                    ExitButton = true;
                    HighScoreText.gameObject.SetActive(false);
                    TapToStart.gameObject.SetActive(false);
                    Score3DText.gameObject.SetActive(false);
                    LeaderExiter = false;
                    OneTimeButton = 1;

                    UsernameChange.SetActive(true);
                }
                if (!InSeetings)
                {
                //    m_styleButton.active.background = GetGiftizButtonTexture(); // get correct texture
                //    m_styleButton.normal.background = m_styleButton.active.background = GetGiftizButtonTexture();
                //    if (GUI.Button(UpdateDimension(m_giftizButton), "", m_styleButton) == true)
                //    {
                //        GiftizBinding.buttonClicked();

                //       
                //    }

                    m_styleButton.normal.background = m_styleButton.active.background = LeaderTexture;
                    if (GUI.Button(UpdateDimension(LeaderButton), "", m_styleButton) == true)
                    {
                        OneTimeTutorialObject.SetActive(false);
                        LeaderBoardActive.SetActive(true);
                        LeaderBoardBackground.SetActive(true);
                        ExitButton = true;
                        HighScoreText.gameObject.SetActive(false);
                        TapToStart.gameObject.SetActive(false);
                        Score3DText.gameObject.SetActive(false);
                        LeaderExiter = false;
                        OneTimeButton = 1;

                        YourPlaceInLeaderBoard.text = ">5000" + ". " + Username + " - " + HighScore ;


                        for (int i = 0; i < Highscores.highscoresList.Length; i++)
                        {
                            if (Username == Highscores.highscoresList[i].username)
                            {
                                YourPlaceInLeaderBoard.gameObject.SetActive(true);

                                
                                YourPlaceInLeaderBoard.text = (i+1) + ". " + Username + " - " + Highscores.highscoresList[i].score ;
                            }

                        }

                    }
                }
            }
                if (ExitButton)
                {
                
                if (OneTimeButton == 1)
                {
                    ExitIns = Instantiate(ExitPrefab, GameObject.Find("ExitSummon").transform.position, GameObject.Find("ExitSummon").transform.rotation) as GameObject;
                    OneTimeButton = 0;
                }
               if(ExitOnMouse.ExitDestroy == true)
                {
                   

                    InSeetings = false;
                    LeaderBoardActive.SetActive(false);
                    LeaderBoardBackground.SetActive(false);
                    HighScoreText.gameObject.SetActive(true);
                    TapToStart.gameObject.SetActive(true);
                    Score3DText.gameObject.SetActive(true);
                    ExitButton = false;
                    LeaderExiter = true;
                    ExitOnMouse.ExitDestroy = false;
                  //  UsernameInput.InLogin = false;
                  //  UsernameInput.FirstTime = 1;
                    UsernameTextMesh.SetActive(false);
                  

                }
                
                       
                
              
            }

        }

    }


    

  //  public Texture2D GetGiftizButtonTexture()
 //   {
 //       Texture2D inter = null;
 //       switch (GiftizBinding.giftizButtonState)
 //       {
  //          case GiftizBinding.GiftizButtonState.Invisible: inter = m_textureInvisible; break;
 //           case GiftizBinding.GiftizButtonState.Naked: inter = m_textureNaked; break;
  //          case GiftizBinding.GiftizButtonState.Badge: inter = m_textureBadge; break;
  //          case GiftizBinding.GiftizButtonState.Warning: inter = m_textureWarning; break;
 //       }
 //       return inter;
 //   }









    static public string Username = "Type";

    int ADCOUNT = 0;

    static public float Speed = 100;

    static public float Score = 0;

    public GameObject Torus;

    public TextMesh Score3DText;
    public TextMesh TapToStart;



    public GameObject RightBall = null;
    public GameObject LeftBall = null;



   bool RightLeftMove = true;

    public Material Right = null;
    public Material Left = null;

    public TextMesh SpawnScoreUp;
    public TextMesh HighScoreText;

  

   // bool GiftizBool = true;

    public Transform SpawnScoreLeft;
    public Transform SpawnScoreRight;

    public GameObject SpawnHalo;

    public GameObject MainMenu;

    float HighScore = 0;

    int randomnumb = 0;

    public TextMesh GreetingAwesome;
    public TextMesh GreetingPerfect;
    public TextMesh GreetingRampage;

    bool Firstone = true;
    bool Secondone = false;
    bool Thirdone = false;
    bool Fourthone = true;
    bool LastOne = true;
    int KeepScore = 0;
    public static string TempUser;
    

    public GameObject OneTimeTutorialObject = null;
    int OneTimeTutorial = 0;


    float LifeCountAfterFail = 0;
    bool LifeCountBool = false;
    public TextMesh LifeCountText = null;

    void Update()
    {
        
        if(Torus.transform.rotation.x >= 0.60f) 
        {
           

            RightLeftMove = true;
         
        }
        if (Torus.transform.rotation.x <= -0.60f)
        {
           

            RightLeftMove = false;
         
        }

        if (Input.GetMouseButtonDown(0))
        {
          
            if (RightLeftMove == true)
            {
                RightLeftMove = false;
            }
            else
                RightLeftMove = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (MainScene.ScoreCountTurn)
        {
            Score += Time.deltaTime;

            if(LifeCountBool)
            {
                LifeCountAfterFail += Time.deltaTime;
                LifeCountText.text = LifeCountAfterFail.ToString("0");
                if(LifeCountAfterFail >= 5.00f)
                {
                    LifeCountBool = false;
                    LifeCountText.gameObject.SetActive(false);
                }
            }

            //  ScoreT = Score.ToString();
            Score3DText.text = Score.ToString("0.00");

            RightBall.transform.Rotate(Vector3.right * 100 * Time.deltaTime);
            LeftBall.transform.Rotate(Vector3.left * 100 * Time.deltaTime);

            if (RightLeftMove)
            {

                Torus.transform.Rotate(Vector3.down * Speed * Time.deltaTime);
            }
            if (RightLeftMove == false)
            {
                Torus.transform.Rotate(Vector3.up * Speed * Time.deltaTime);
            }
          
            if (Speed <= 365)
                Speed += Time.deltaTime * 15;

           

          //  if (GiftizBool)
         //          {
         //       if (Score > 150)
         //       {
        //            GiftizBinding.missionComplete();
        //            GiftizBool = false;
        //            
       //         }
         //   }
            ApplauseTitle();
        }
    }
    
    void ApplauseTitle()
    {
       if(Score >= 100 && Firstone == true)
            {
            GameObject GreetingMessage = Instantiate(GreetingAwesome.gameObject, GameObject.Find("TitleHold").transform.position, GameObject.Find("TitleHold").transform.rotation) as GameObject;

            Destroy(GreetingMessage.gameObject, 2.0f);

          

            Firstone = false;
            Secondone = true;
        }
        if (Score >= 200 && Secondone == true)
        {
            GameObject GreetingMessage2 = Instantiate(GreetingPerfect.gameObject, GameObject.Find("TitleHold").transform.position, GameObject.Find("TitleHold").transform.rotation) as GameObject;

            Destroy(GreetingMessage2.gameObject, 2.0f);

            

            Secondone = false;
            Thirdone = true;
        }
        if(Score >=300 && Thirdone == true)
        {
            if (Fourthone)
            {
                GameObject GreetingMessage3 = Instantiate(GreetingRampage.gameObject, GameObject.Find("TitleHold").transform.position, GameObject.Find("TitleHold").transform.rotation) as GameObject;

                Destroy(GreetingMessage3.gameObject, 2.0f);

               

                Fourthone = false;
            }
            if (LastOne)
            {
                KeepScore = 0;
                KeepScore = (int)Score + 100;

                LastOne = false;
            }
            if(Score >= KeepScore)
            {
                GameObject GreetingMessage4 = Instantiate(GreetingRampage.gameObject, GameObject.Find("TitleHold").transform.position, GameObject.Find("TitleHold").transform.rotation) as GameObject;

                Destroy(GreetingMessage4.gameObject, 2.0f);

               
                LastOne = true;
            }




            
        }

    }
    void Awake()
    {
      //PlayerPrefs.DeleteAll();    
    }
    void Start()
    {
     

        if (!PlayerPrefs.HasKey("OneTimeTuto"))
        {
            PlayerPrefs.SetInt("OneTimeTuto", 0);
        }
        else
        {
            OneTimeTutorial = PlayerPrefs.GetInt("OneTimeTuto");
        }

        if(OneTimeTutorial == 0)
        {
            OneTimeTutorialObject.SetActive(true);
            OneTimeTutorial = 1;
            PlayerPrefs.SetInt("OneTimeTuto", OneTimeTutorial);
            PlayerPrefs.Save();
        }
        else
        {
            OneTimeTutorialObject.SetActive(false);
        }


            if (!PlayerPrefs.HasKey("LifePoint"))
        {
            PlayerPrefs.SetInt("LifePoint", 1);
        }
        else
        {
            Life = PlayerPrefs.GetInt("LifePoint");
        }
        if (!PlayerPrefs.HasKey("UsernameX"))
        {
            PlayerPrefs.SetString("UsernameX", "Type");
        }
        else
        {
            Username = PlayerPrefs.GetString("UsernameX");
        }
       TempUser = Username;

       
        ADCOUNT = 0;
        RequestBanner();

        if (!PlayerPrefs.HasKey("Hscore"))
        {
            PlayerPrefs.SetFloat("Hscore", 0.0f);
        }
        else
        {
            HighScore = PlayerPrefs.GetFloat("Hscore");
        }
        HighScoreText.text = "Best: " + HighScore.ToString("0.00");
        Highscores.AddNewHighscore(Username, (int)HighScore);
        Right.color = Color.red;
        Left.color = Color.green;
    }

    void OnCollisionExit(Collision collider)
    {
        if(collider.gameObject.name == "_LeftBall" || collider.gameObject.name == "_RightBall")
        {
            if (RightLeftMove == true)
            {
                
                Torus.transform.Rotate(Vector3.down * 5);
            }
            else
            {
                Torus.transform.Rotate(Vector3.up * 5);
               
            }
        }
    }


  

    void OnCollisionEnter(Collision collider)
    {


       // if (collider.gameObject.name == "_BUGFIXERLEFT" || collider.gameObject.name == "_BUGFIXERRIGHT")
      //  {
        //    if (RightLeftMove == true)
         //   {
         //       
         //       Torus.transform.Rotate(Vector3.up * 15);
        //        RightLeftMove = false;

         //  }
        //   else
         //   {
         //       Torus.transform.Rotate(Vector3.down * 15);
        //       
        //        RightLeftMove = true;
        //    }
       // }

        if (collider.gameObject.name == "_LeftBall" || collider.gameObject.name == "_RightBall")
        {
            if (RightLeftMove == true)
            {
              
                RightLeftMove = false;
            }
            else
            {
                RightLeftMove = true;
               
            }
        }

      


        if (collider.gameObject.name == "_RightBall")
        {

            if (Right.color == Color.red)
            {
                OnHitRedBall();

            }
            else
            {

                Score += 5.00f;
                Instantiate(SpawnScoreUp, SpawnScoreRight.position, Quaternion.identity);

                GameObject InstantiatedHalo = Instantiate(SpawnHalo, GameObject.Find("_RightBall").transform.position, GameObject.Find("_RightBall").transform.rotation) as GameObject;

                Destroy(InstantiatedHalo, 0.05f);




                randomnumb = UnityEngine.Random.Range(0, 11);

                if (randomnumb >= 5)
                {
                    Right.color = Color.red;
                }
                else
                    Right.color = Color.green;


                if (Right.color == Color.red && Left.color == Color.red)
                {
                    randomnumb = UnityEngine.Random.Range(0, 11);
                    if (randomnumb >= 5)
                    {
                        Right.color = Color.green;
                    }
                    else
                        Left.color = Color.green;
                }
            }

        }
        if (collider.gameObject.name == "_LeftBall")
        {

            if (Left.color == Color.red)
            {
                OnHitRedBall();
            }
            else
            {


                Score += 5.00f;
                Instantiate(SpawnScoreUp, SpawnScoreLeft.position, Quaternion.identity);



                GameObject InstantiatedHalo2 = Instantiate(SpawnHalo, GameObject.Find("_LeftBall").transform.position, GameObject.Find("_LeftBall").transform.rotation) as GameObject;

                Destroy(InstantiatedHalo2, 0.05f);




                randomnumb = UnityEngine.Random.Range(0, 11);

                if (randomnumb >= 5)
                {
                    Left.color = Color.red;
                }
                else
                    Left.color = Color.green;

                if (Right.color == Color.red && Left.color == Color.red)
                {
                    randomnumb = UnityEngine.Random.Range(0, 11);
                    if (randomnumb >= 5)
                    {
                        Right.color = Color.green;
                    }
                    else
                        Left.color = Color.green;
                }
            }
        }


    }


    void OnHitRedBall()
    {
        if (Life != 1 && !LifeCountBool)
        {
            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetFloat("Hscore", HighScore);
                PlayerPrefs.Save();
            }
            
            Highscores.AddNewHighscore(Username, (int)Score);
            IfInMain = true;
            MainScene.ScoreCountTurn = false;
            HighScoreText.text = "Best: " + HighScore.ToString("0.00");

            MainMenu.SetActive(true);
            ADCOUNT++;

            if (ADCOUNT == 8)
            {
                RequestInterstitial();
            }

            if (ADCOUNT == 15)
            {
                ShowInterstitial();
                ADCOUNT = 0;
            }
            LifeCountBool = false;
            LifeCountText.gameObject.SetActive(false);
        }
        else
        {
            Life = 0;
            PlayerPrefs.SetInt("LifePoint", Life);
            PlayerPrefs.Save();
            HeartGameScreen1.SetActive(true);
            HeartGameScreen2.SetActive(false);

            if (!LifeCountBool)
            {
                LifeCountBool = true;
                LifeCountText.gameObject.SetActive(true);
                LifeCountAfterFail = 0;
            }
        }
    }




















    private BannerView bannerView;
    private InterstitialAd interstitial;
  

    private void RequestBanner()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-9301832331799563/9619898538";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-9301832331799563/9247161730";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Register for ad events.
        bannerView.AdLoaded += HandleAdLoaded;
        bannerView.AdFailedToLoad += HandleAdFailedToLoad;
        bannerView.AdOpened += HandleAdOpened;
        bannerView.AdClosing += HandleAdClosing;
        bannerView.AdClosed += HandleAdClosed;
        bannerView.AdLeftApplication += HandleAdLeftApplication;
        // Load a banner ad.
        bannerView.LoadAd(createAdRequest());
    }

    private void RequestInterstitial()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
            string adUnitId = "ca-app-pub-9301832331799563/4417642932";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-9301832331799563/1723894933";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);
        // Register for ad events.
        interstitial.AdLoaded += HandleInterstitialLoaded;
        interstitial.AdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.AdOpened += HandleInterstitialOpened;
        interstitial.AdClosing += HandleInterstitialClosing;
        interstitial.AdClosed += HandleInterstitialClosed;
        interstitial.AdLeftApplication += HandleInterstitialLeftApplication;
        GoogleMobileAdsDemoHandler handler = new GoogleMobileAdsDemoHandler();
        interstitial.SetInAppPurchaseHandler(handler);
        // Load an interstitial ad.
        interstitial.LoadAd(createAdRequest());
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest createAdRequest()
    {
        return new AdRequest.Builder()
                .AddTestDevice(AdRequest.TestDeviceSimulator)
                .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
                .AddKeyword("game")
                .SetGender(Gender.Male)
                .SetBirthday(new DateTime(1985, 1, 1))
                .TagForChildDirectedTreatment(false)
                .AddExtra("color_bg", "9B30FF")
                .Build();

    }

    private void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            print("Interstitial is not ready yet.");
        }
    }

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, EventArgs args)
    {
        print("HandleAdLoaded event received.");
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleFailedToReceiveAd event received with message: " + args.Message);
    }

    public void HandleAdOpened(object sender, EventArgs args)
    {
        print("HandleAdOpened event received");
    }

    void HandleAdClosing(object sender, EventArgs args)
    {
        print("HandleAdClosing event received");
    }

    public void HandleAdClosed(object sender, EventArgs args)
    {
        print("HandleAdClosed event received");
    }

    public void HandleAdLeftApplication(object sender, EventArgs args)
    {
        print("HandleAdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("HandleInterstitialLoaded event received.");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        print("HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        print("HandleInterstitialOpened event received");
    }

    void HandleInterstitialClosing(object sender, EventArgs args)
    {
        print("HandleInterstitialClosing event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        print("HandleInterstitialLeftApplication event received");
    }

    #endregion
}
