using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = false;
    private string _gameId;

    public static event System.Action OnAdsInitialized;

    void Awake()
    {
        
    }
    void Start()
    {
        InitializeAds();
        Debug.Log("calling initializeAds!");
    }

    public void InitializeAds()
    {

#if UNITY_ANDROID
        _gameId = _androidGameId;
#elif UNITY_EDITOR
            _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Debug.Log("Initializing Unity Ads with Game ID: " + _gameId);
            Advertisement.Initialize(_gameId, _testMode, this);
        }
        else
        {
            Debug.Log("Unity Ads is already initialized or not supported.");
        }
    }


    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");

        OnAdsInitialized?.Invoke();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
        if (error == UnityAdsInitializationError.INTERNAL_ERROR)
        {
            Debug.Log("Retrying initialization...");
            InitializeAds();
        }
    }
}