using System.Linq;
using UnityEngine;

public class RunningMachine : MonoBehaviour
{
    public ReplacementItem[] Items;
    public ReplacementItem steam;
    public ReplacementItem plate;

    public RepairPlace RepairPlace;

    public ProgressBar damageState;
    
    public float status;
    public float coolDown;

    public Replacement replacementState { get; set; }
    private void Start()
    {
        foreach (var replacementItem in this.Items)
        {
            replacementItem.Hide();
        }
        
        this.steam.Hide();
        this.plate.Hide();
        this.damageState.Hide();
    }

    void Update()
    {
        var step = Time.deltaTime * 0.1f;
        this.coolDown += step;
        
        if (this.replacementState == Replacement.None) return;
        
        this.coolDown = 0f;

        if (this.RepairPlace.MustRepair)
        {
            this.HasRepaired();
        }
        
        if (step + this.status > 1f)
        {
            this.replacementState = Replacement.None;
            
            // TODO: game over
            Debug.Log("Game Over");
            //this.Items[(int)this.replacementState ].Hide();
            this.HasRepaired();
        }
        else
        {
            this.status += step;
        }

        this.damageState.SetValue(this.status);
    }

    public void StartDamageReport(Replacement replacement)
    {
        if (this.coolDown < 0.5f)
        {
            //Debug.Log($"cool down {this.coolDown}");
            return;
        }
        
        //Debug.Log($"Damage is: {replacement}");
        this.replacementState = replacement;
        var item = this.Items.FirstOrDefault(f => f.Replacement == this.replacementState);
        if (item == null)
        {
            return;
        }
        item.Show();
        this.RepairPlace.NeedReplacement = this.replacementState;
        this.RepairPlace.MustRepair = true;
        this.RepairPlace.HasRepaired = false;

        this.plate.Show();
        this.steam.Show();
        this.damageState.Show();

        this.status = 0f;
    }

    public void HasRepaired()
    {
        if (!this.RepairPlace.HasRepaired)
        {
            return;
        }

        this.RepairPlace.HasRepaired = false;
        this.RepairPlace.MustRepair = false;
        
        this.replacementState = Replacement.None;
        
        foreach (var replacementItem in this.Items)
        {
            replacementItem.Hide();
        }
        
        this.plate.Hide();
        this.steam.Hide();

        this.coolDown = 0f;
        
        this.damageState.Hide();
    }
}