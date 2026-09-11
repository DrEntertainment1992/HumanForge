using UnityEngine;


public class CharacterUIController : MonoBehaviour
{
    [Header("Контроллеры персонажей")]
    public HFBodyController femaleController;
    public HFBodyController maleController;

    [Header("UI")]
    public HFBodyUI bodyUI;


    private HFBodyController currentController;


    private void Start()
    {
        SelectFemale();
    }


    // =====================================================
    // ВЫБОР ПЕРСОНАЖА
    // =====================================================

    public void SelectFemale()
    {
        currentController = femaleController;

        LoadCurrentCharacterToUI();

        Debug.Log("UI: выбрана женщина");
    }


    public void SelectMale()
    {
        currentController = maleController;

        LoadCurrentCharacterToUI();

        Debug.Log("UI: выбран мужчина");
    }


    // =====================================================
    // СЛАЙДЕРЫ
    // =====================================================

    public void SetHeight(float value)
    {
        if (currentController == null)
            return;

        currentController.SetHeight(value);
    }


    public void SetMuscle(float value)
    {
        if (currentController == null)
            return;

        // Slider 0..1
        // HFBodyController 0..100
        currentController.SetMuscle(value * 100f);
    }


    public void SetWeight(float value)
    {
        if (currentController == null)
            return;

        // Slider 0..1
        // HFBodyController 0..100
        currentController.SetWeight(value * 100f);
    }


    // =====================================================
    // ЗАГРУЗКА НАСТРОЕК В UI
    // =====================================================

    private void LoadCurrentCharacterToUI()
    {
        if (currentController == null)
            return;

        if (bodyUI == null)
            return;


        // ВАЖНО:
        // SetValueWithoutNotify меняет положение ползунка,
        // но НЕ вызывает SetHeight / SetMuscle / SetWeight.

        bodyUI.heightSlider.SetValueWithoutNotify(
            currentController.heightCm
        );

        bodyUI.muscleSlider.SetValueWithoutNotify(
            currentController.muscle / 100f
        );

        bodyUI.weightSlider.SetValueWithoutNotify(
            currentController.weight / 100f
        );


        bodyUI.RefreshValues();
    }
}