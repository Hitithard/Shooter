using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider magicSlider;

    private void Awake() => healthSlider = GetComponentInChildren<Slider>();
    public void UpdateHealthBar(float currentValue,float maxValue)
    {
        healthSlider.value = currentValue / maxValue;
    }
    public void UpdateMagicBar(float currentValue, float maxValue)
    {
        if (currentValue <=0)
            magicSlider.gameObject.SetActive(false);
        else
            magicSlider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
