using UnityEngine;

public class Mechanic : MonoBehaviour
{

    private void Update()
    {
        if (Time.timeScale < 1f)
        {
            return;
        }

        if (Input.GetAxisRaw("Horizontal") > 0f || Input.GetKey(KeyCode.D)) 
        {
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f || Input.GetKey(KeyCode.A))
        {
        }
        else if (Input.GetAxisRaw("Vertical") > 0f || Input.GetKey(KeyCode.W))
        {
        }
        else if (Input.GetAxisRaw("Vertical") < 0f || Input.GetKey(KeyCode.S))
        {
        }
        else if (Input.GetAxisRaw("Fire1") > 0f|| Input.GetKeyUp(KeyCode.E))
        {
            // Interact
        }
    }
}

public class BaseObject : MonoBehaviour
{
   
}