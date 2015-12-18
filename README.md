# GearHMDMonitor

The Oculus SDK for Unity has no built-in method for telling when the device has been taken off by the user. 
Doing this will trigger OnPause() being called, but only around 10 seconds after the device has been taken 
off, which in the case of a game or app that plays videos, can be an issue if the app keeps running while
the user isn't looking at the screen. 

This native Android plugin solves this issue by providing an easy way to know immediatley when a user takes
the Gear VR device off and when they put it on again.  

The UnityProject directory contains an example Unity project (set up with Unity 5.2), with everything you need to build 
it for Android. In this project the device plays a sound when it is put on and taken off, but this could easily be
hooked into something else such as pausing/unpausing a game or video.

The AndroidPlugin directory contains the source to the native Android plugin used in the 
Unity project (GearHMDMonitor.jar), which has been tested against Android 5.0 (API level 21).

## Building

Before you can run the app on a Gear VR device you will need to [obtain a signature](https://developer.oculus.com/osig/)
for your device from Oculus and place it in the `UnityProject/Assets/Plugins/Android/assets` directory. 

To build the Unity project, just open it in Unity, connect an Android device and go to *Build 
and Run* in the menu. There is already a compiled version of the Android plugin (AndroidPlugin.jar)
in the Unity project `Assets` folder so there is no need to compile it first just to run the
program.

To build the Android plugin, first make sure you have installed the 
[Android SDK](https://developer.android.com/sdk/index.html) and [Ant](http://ant.apache.org/). 
First, either make sure your `ANDROID_HOME` environment variable is set to your installation
of the Android SDK, or edit the `sdk.dir=...` line in the `local.properties` file inside 
the AndroidPlugin folder.

Once that is all configured, navigate to AndroidPlugin and run
```
ant jar
```
Then copy the compiled `AndroidPlugin.jar` from `AndroidPlugin/bin` to `UnityProject/Assets`.

