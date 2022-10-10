using System;
using TMPro;
using UnityEngine;

namespace Bonus
{// За отображение числа бонуса
    public class BonusVeiw : MonoBehaviour
    {
        [SerializeField] private BaseBonus bonus;

        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            bonus.OnFillUpdate += UpdateUI;
        }

        private void UpdateUI()
        {
            _text.text = bonus.LeftToFill.ToString();
        }
    }
}