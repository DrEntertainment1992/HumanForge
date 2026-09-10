using UnityEngine;


public class CharacterUIController : MonoBehaviour
{

    [Header("Контроллеры тела")]

    public HFBodyController femaleController;

    public HFBodyController maleController;



    private HFBodyController currentController;



    private void Start()
    {
        currentController = femaleController;
    }



    public void SelectFemale()
    {
        currentController = femaleController;

        Debug.Log("Выбрана женщина");
    }



    public void SelectMale()
    {
        currentController = maleController;

        Debug.Log("Выбран мужчина");
    }



    public void SetHeight(float value)
    {
        if(currentController != null)
        {
            currentController.SetHeight(value);
        }
    }



    public void SetMuscle(float value)
    {
        if(currentController != null)
        {
            currentController.SetMuscle(value);
        }
    }



    public void SetWeight(float value)
    {
        if(currentController != null)
        {
            currentController.SetWeight(value);
        }
    }

}