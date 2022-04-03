using System;
using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public TextMeshProUGUI tmpPoints;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void SetText(int points)
    {
        this.tmpPoints.text = $"Points: {points}";
    }
}