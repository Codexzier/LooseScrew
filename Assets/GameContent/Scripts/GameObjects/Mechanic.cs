using System;
using UnityEngine;

public class Mechanic : MonoBehaviour
{
    public Vector3 change = new Vector3();
    public float speedByScreenSize { get; set; } = 1f;
    private static readonly float pixelFrac = 1f / 16f;
    private void Update()
    {
        this.change = new Vector3();
        
        
        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetKey(KeyCode.D))
        {
            this.change.x = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f || Input.GetKey(KeyCode.A))
        {
            this.change.x = -1;
        }
        else if (Input.GetAxisRaw("Vertical") > 0f || Input.GetKey(KeyCode.W))
        {
            this.change.y = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f || Input.GetKey(KeyCode.S))
        {
            this.change.y = -1;
        }
        else if (Input.GetAxisRaw("Fire1") > 0f|| Input.GetKeyUp(KeyCode.E))
        {
            // Interact
        }
    }

    private void LateUpdate()
    {
        var step = this.roundToPixelGrid(1f * Time.deltaTime);
        this.transform.position += this.change * step * speedByScreenSize;
    }
    protected float roundToPixelGrid(float f)
    {
        return Mathf.Ceil(f / pixelFrac) * pixelFrac;
    }
}