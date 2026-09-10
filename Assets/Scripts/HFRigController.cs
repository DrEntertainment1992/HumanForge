using UnityEngine;


public class HFRigController : MonoBehaviour
{

    public enum CharacterGender
    {
        Female,
        Male
    }



    [Header("Стартовый пол")]
    public CharacterGender startGender =
        CharacterGender.Female;



    [Header("Персонажи")]
    public GameObject femaleCharacter;

    public GameObject maleCharacter;



    [Header("UI контроллер")]
    public CharacterUIController uiController;



    private CharacterGender currentGender;



    private void Start()
    {
        SetGender(startGender);
    }




    public void SetFemale()
    {
        SetGender(CharacterGender.Female);
    }




    public void SetMale()
    {
        SetGender(CharacterGender.Male);
    }




    public void ToggleGender()
    {

        if(currentGender == CharacterGender.Female)
            SetMale();
        else
            SetFemale();

    }




    private void SetGender(CharacterGender gender)
    {

        currentGender = gender;



        if(gender == CharacterGender.Female)
        {

            femaleCharacter.SetActive(true);

            maleCharacter.SetActive(false);



            if(uiController != null)
                uiController.SelectFemale();



            Debug.Log("Активна женщина");

        }
        else
        {

            femaleCharacter.SetActive(false);

            maleCharacter.SetActive(true);



            if(uiController != null)
                uiController.SelectMale();



            Debug.Log("Активен мужчина");

        }

    }

}