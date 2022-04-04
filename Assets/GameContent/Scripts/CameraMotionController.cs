using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{
    public Mechanic mechanic;
    public Camera camera;

    private void Update()
    {
//#if DEBUG
        var bySize = this.camera.orthographicSize / 3f;
        this.mechanic.speedByScreenSize = 160f / this.camera.pixelHeight * bySize;
        
//#endif
        
        var mechanicPos = this.mechanic.transform.position;
        mechanicPos.z = this.transform.position.z;
        this.transform.position = mechanicPos;
    }
}
