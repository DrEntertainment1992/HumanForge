using UnityEngine;


public class CharacterUIController : MonoBehaviour
{

    [Header("Контроллеры тела")]

    public HFBodyController femaleController;

    public HFBodyController maleController;



    private HFBodyController currentController;



    private void Start()
    {
        SelectFemale();
    }



    public void SelectFemale()
    {
        currentController = femaleController;

        Debug.Log(
            "UI контроллер: Женщина " +
            currentController
        );
    }



    public void SelectMale()
    {
        currentController = maleController;

        Debug.Log(
            "UI контроллер: Мужчина " +
            currentController
        );
    }



    public void SetHeight(float value)
    {
        if(currentController == null)
        {
            Debug.LogWarning("Нет выбранного тела");
            return;
        }

        currentController.SetHeight(value);
    }



    public void SetMuscle(float value)
    {
        if(currentController == null)
        {
            Debug.LogWarning("Нет выбранного тела");
            return;
        }

        currentController.SetMuscle(value);
    }



    public void SetWeight(float value)
    {
        if(currentController == null)
        {
            Debug.LogWarning("Нет выбранного тела");
            return;
        }

        currentController.SetWeight(value);
    }

}