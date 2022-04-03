using UnityEngine;

public class MechanicInputController : MonoBehaviour
{
    public Mechanic Mechanic;
    
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1f)
        {
            return;
        }
        
        if ( Input.GetKey(KeyCode.D))this.Mechanic.change.x = 1;
        else if (Input.GetKey(KeyCode.A))   this.Mechanic.change.x = -1;
        else if (Input.GetKey(KeyCode.W)) this.Mechanic.change.y = 1;
        else if (Input.GetKey(KeyCode.S)) this.Mechanic.change.y = -1;
        else if (Input.GetKeyUp(KeyCode.E)) 
        {
            // Interact
        }
    }
}
