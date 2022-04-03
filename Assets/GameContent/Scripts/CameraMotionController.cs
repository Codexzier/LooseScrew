using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotionController : MonoBehaviour
{
    public Mechanic mechanic;
    public Camera camera;

    private void Update()
    {
#if DEBUG
        this.mechanic.speedByScreenSize = 160f / this.camera.pixelHeight;
#endif
        
        Vector3 mechanic = this.mechanic.transform.position;
        mechanic.z = transform.position.z;
        transform.position = mechanic;
    }
}
