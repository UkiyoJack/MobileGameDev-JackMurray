using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BannerAdExample : MonoBehaviour
{
    //buttons are for functionality testing:
    [SerializeField] Button _loadBannerButton;
    [SerializeField] Button _showBannerButton;
    [SerializeField] Button _hideBannerButton;

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    /*[SerializeField] string _iOSAdUnitId = "Banner_iOS";*/


    string _adUnitId = null; //remains null for unsupported platforms

    
    void Start()
    {
        //get ad unit id for current platform


        _adUnitId = _androidAdUnitId; //ad unit is always android

        //disable button until ready to show
        /*_showBannerButton.interactable = false;
        _hideBannerButton.interactable = false;*/

        //set position
        Advertisement.Banner.SetPosition(_bannerPosition);

        /*//call load banner when clicked
        _loadBannerButton.onClick.AddListener(LoadBanner);
        _loadBannerButton.interactable = true;*/
        LoadBanner();


    }

    //load banner method
    public void LoadBanner()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitId, options);

    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");

        /*// Configure the Show Banner button to call the ShowBannerAd() method when clicked:
        _showBannerButton.onClick.AddListener(ShowBannerAd);
        // Configure the Hide Banner button to call the HideBannerAd() method when clicked:
        _hideBannerButton.onClick.AddListener(HideBannerAd);*/

       /* // Enable both buttons:
        _showBannerButton.interactable = true;
        _hideBannerButton.interactable = true;
*/
        ShowBannerAd();
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    public void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

            // Show the loaded Banner Ad Unit:
            Advertisement.Banner.Show(_adUnitId, options);
        Debug.Log("Banner Shown!");
       
    }

    // Implement a method to call when the Hide Banner button is clicked:
    public void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() {
        Debug.Log("Banner Clicked!");
    }

    void OnBannerShown()
    {
        Debug.Log("Banner Shown!");
    }

    void OnBannerHidden() {
        Debug.Log("Banner Hidden!");
    }


    void OnDestroy()
    {
        // Clean up the listeners:
        _loadBannerButton.onClick.RemoveAllListeners();
        _showBannerButton.onClick.RemoveAllListeners();
        _hideBannerButton.onClick.RemoveAllListeners(); 
    }
}