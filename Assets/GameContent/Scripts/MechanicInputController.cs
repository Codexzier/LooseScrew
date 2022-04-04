using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        if ( Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))this.Mechanic.change.x = 1;
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) )   this.Mechanic.change.x = -1;
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) this.Mechanic.change.y = 1;
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) this.Mechanic.change.y = -1;
        else if (Input.GetKeyUp(KeyCode.E)) 
        {
            // Interact
        }
        else if(Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
