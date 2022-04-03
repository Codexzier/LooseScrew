using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoHideRender : MonoBehaviour
{
    private void Start()
    {
        var r = this.GetComponent<Renderer>();

        if (r != null)
        {
            r.enabled = false;
        }
    }
}
