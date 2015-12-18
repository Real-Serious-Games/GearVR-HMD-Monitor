using UnityEngine;
using System.Collections;
using System;

public class GearHMDMonitor : MonoBehaviour 
{
    private AndroidJavaObject nativePlugin;
    private AudioSource audioSource;
    private bool hmdPresent;

    public AudioClip putDeviceOnSound;
    public AudioClip takeDeviceOffSound;

    // Use this for initialization
    void Awake() 
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    nativePlugin = new AndroidJavaObject("com.RSG.GearHMDMonitor.GearHMDMonitor", currentActivity);
                }
            }
        }

        hmdPresent = IsHMDPresent();
        Debug.Log("Device present: " + hmdPresent);

        // Set up audio source
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = this.gameObject.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// Call through to the native Java code and return whether or not the HMD is on a user's face.
    /// </summary>
    public bool IsHMDPresent()
    {
        if (Application.platform == RuntimePlatform.Android && nativePlugin != null)
        {
            return nativePlugin.Call<bool>("IsHMDPresent");
        }
        return true;
    }
    
    // Update is called once per frame
    void Update () 
    {
        var hmdCurrentlyPresent = IsHMDPresent();
        if (hmdCurrentlyPresent != hmdPresent)
        {
            this.hmdPresent = hmdCurrentlyPresent;

            // Do something when the device is taken off or put back on
            if (hmdPresent)
            {
                audioSource.PlayOneShot(putDeviceOnSound);
            }
            else
            {
                audioSource.PlayOneShot(takeDeviceOffSound);
            }

        }
    }

    void OnDestroy()
    {
        if (nativePlugin != null)
        {
            nativePlugin.Dispose();
        }
    }
}
