using UnityEngine;


public class HFCharacterSelector : MonoBehaviour
{

    [Header("Персонажи")]
    public GameObject femaleCharacter;
    public GameObject maleCharacter;


    [Header("Тела")]
    public SkinnedMeshRenderer femaleBody;
    public SkinnedMeshRenderer maleBody;


    [Header("Контроллер тела")]
    public HFBodyController bodyController;



    public enum Gender
    {
        Female,
        Male
    }


    public Gender startGender = Gender.Female;



    void Start()
    {
        ApplyGender(startGender);
    }



    public void SelectFemale()
    {
        ApplyGender(Gender.Female);
    }



    public void SelectMale()
    {
        ApplyGender(Gender.Male);
    }




    void ApplyGender(Gender gender)
    {

        if(gender == Gender.Female)
        {

            femaleCharacter.SetActive(true);
            maleCharacter.SetActive(false);


            if(bodyController != null)
                bodyController.SetBody(femaleBody);


            Debug.Log("Выбран: Female");

        }



        if(gender == Gender.Male)
        {

            femaleCharacter.SetActive(false);
            maleCharacter.SetActive(true);


            if(bodyController != null)
                bodyController.SetBody(maleBody);


            Debug.Log("Выбран: Male");

        }

    }

}