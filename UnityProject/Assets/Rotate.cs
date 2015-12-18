using UnityEngine;
using System.Collections;

/// <summary>
/// Simple class for rotating an object automatically.
/// Used just to provide an example of something happening in the scene
/// </summary>
public class Rotate : MonoBehaviour {

    public enum axis { X, Y, Z };

    public axis Axis = axis.X;

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
        Vector3 rotateAround = Vector3.zero;
        switch (Axis) {
            case axis.X:
                rotateAround = Vector3.right;
                break;
            case axis.Y:
                rotateAround = Vector3.up;
                break;
            case axis.Z:
                rotateAround = Vector3.forward;
                break;
        }
        this.transform.Rotate(rotateAround, 50 * Time.deltaTime);
    }
}
