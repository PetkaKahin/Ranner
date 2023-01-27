using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Let))]

public class LetTextDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _textDamage;

    private Let _let;

    private void Start()
    {
        _let = GetComponent<Let>();
        _textDamage.text = $"{_let.Damage}";
    }
}
