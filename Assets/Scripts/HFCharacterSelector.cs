using UnityEngine;


public class HFCharacterSelector : MonoBehaviour
{

    [Header("Персонажи")]
    public GameObject femaleCharacter;
    public GameObject maleCharacter;



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

        switch(gender)
        {

            case Gender.Female:

                femaleCharacter.SetActive(true);
                maleCharacter.SetActive(false);

                Debug.Log("Выбран: Female");

                break;



            case Gender.Male:

                femaleCharacter.SetActive(false);
                maleCharacter.SetActive(true);

                Debug.Log("Выбран: Male");

                break;

        }

    }

}