using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HFBodyUI : MonoBehaviour
{
    [Header("Sliders")]
    public Slider weightSlider;
    public Slider muscleSlider;
    public Slider heightSlider;

    [Header("Values")]
    public TMP_Text weightValue;
    public TMP_Text muscleValue;
    public TMP_Text heightValue;

    private void Start()
    {
        weightSlider.onValueChanged.AddListener(UpdateWeightText);
        muscleSlider.onValueChanged.AddListener(UpdateMuscleText);
        heightSlider.onValueChanged.AddListener(UpdateHeightText);

        UpdateWeightText(weightSlider.value);
        UpdateMuscleText(muscleSlider.value);
        UpdateHeightText(heightSlider.value);
    }

    private void UpdateWeightText(float value)
    {
        weightValue.text = Mathf.RoundToInt(value * 100f) + "%";
    }

    private void UpdateMuscleText(float value)
    {
        muscleValue.text = Mathf.RoundToInt(value * 100f) + "%";
    }

    private void UpdateHeightText(float value)
    {
        heightValue.text = Mathf.RoundToInt(value) + " см";
    }
}