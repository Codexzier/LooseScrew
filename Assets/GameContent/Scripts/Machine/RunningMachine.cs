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

    public int pointsForRepair;
    public bool isDamage;

    public Replacement replacementState { get; set; }

    public float coolDownMin = 3f;
    public float stepTime = 0.003f;
    
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
        if(this.isDamage) return;
        
        var step = Time.deltaTime * this.stepTime;
        this.coolDown += step;
        
        if (this.replacementState == Replacement.None) return;
        
        this.coolDown = 0f;

        if (this.RepairPlace.MustRepair)
        {
            this.HasRepaired();
        }
        
        this.status += step;
        if (this.status > 1f)
        {
            this.replacementState = Replacement.None;
            this.isDamage = true;
        }

        this.damageState.SetValue(this.status);
    }

    public void StartDamageReport(Replacement replacement, bool forceToDamage = false)
    {
        if (this.coolDown < this.coolDownMin && !forceToDamage)
        {
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

    private void HasRepaired()
    {
        if (!this.RepairPlace.HasRepaired)
        {
            return;
        }

        var pointsForShortSteps = (int)((0.5f - this.stepTime) * 100);
        var pointsForFastRepaired = (int)((1f - this.status) * 100);
        this.pointsForRepair += pointsForFastRepaired + pointsForShortSteps;

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
        
        if (this.coolDownMin < 0.3f) return;
        this.coolDownMin -= 0.1f;
    }
}