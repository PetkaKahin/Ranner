using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        Player.HealthUpdate += HealthUpdate;    
    } 

    private void OnDisable()
    {
        Player.HealthUpdate -= HealthUpdate;
    }

    public void HealthUpdate(int health)
    {
        _text.text = health.ToString();
    }
}
