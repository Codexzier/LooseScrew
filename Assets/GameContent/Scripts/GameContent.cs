using TMPro;
using UnityEngine;

public class GameContent : MonoBehaviour
{
    public MachineRoomController MachineRoom;
    public GameObject GameOver;
    public GameOverPanel GameOverPanel;

    public TextMeshProUGUI tmpPoints;

    private int points; 
    
    public void Update()
    {
        if (this.MachineRoom.allEngineAreDamage)
        {
            this.GameOver.SetActive(true);
            this.GameOverPanel.SetText(this.points);
            Time.timeScale = 0f;
            
            return;
        }
        
        var p = this.MachineRoom.GetPoints();
        
        if(p == 0 || p == this.points) return;

        this.points = p;
        
        this.tmpPoints.text = $"{this.points:0000}";
    }
}