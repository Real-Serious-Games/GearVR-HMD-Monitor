package com.RSG.GearHMDMonitor;

import android.content.Intent;
import android.content.IntentFilter;
import android.content.BroadcastReceiver;
import android.content.Context;

// OnPause isn't called immediatly when the Gear VR device is taken off, so we need to listen for
// the proximity sensor events to tell.
public class GearHMDMonitor
{
    private boolean isHMDPresent = true;

    // Called when the device is put on a user's face
    private static final String MOUNT_HANDLED_INTENT = "com.oculus.mount_handled";
    // Called when the device is taken off
    private static final String PROXIMITY_SENSOR_INTENT = "android.intent.action.proximity_sensor";

    private BroadcastReceiver receiver = new BroadcastReceiver() {
        @Override 
        public void onReceive(Context context, Intent intent) {
            if (intent.getAction().equals(PROXIMITY_SENSOR_INTENT)) {
                isHMDPresent = false;
            } else if (intent.getAction().equals(MOUNT_HANDLED_INTENT)) {
                isHMDPresent = true;
            }
        }
    };

    // Set up the context and register our intent broadcast receivers
	public GearHMDMonitor(Context context)
	{
        context.registerReceiver(receiver, new IntentFilter(MOUNT_HANDLED_INTENT));
        context.registerReceiver(receiver, new IntentFilter(PROXIMITY_SENSOR_INTENT));
	}

    // Return whether or not the HMD is present
    public boolean IsHMDPresent()
    {
        return isHMDPresent;
    }
}