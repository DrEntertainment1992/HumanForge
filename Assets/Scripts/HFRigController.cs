using UnityEngine;


public class HFRigController : MonoBehaviour
{

    public enum CharacterGender
    {
        Female,
        Male
    }



    [Header("Стартовый пол")]
    [SerializeField]
    private CharacterGender currentGender =
        CharacterGender.Female;



    [Header("Персонажи")]
    [SerializeField]
    private GameObject femaleCharacter;


    [SerializeField]
    private GameObject maleCharacter;



    private void Start()
    {
        ApplyGender();
    }




    public void SetFemale()
    {
        currentGender =
            CharacterGender.Female;

        ApplyGender();
    }




    public void SetMale()
    {
        currentGender =
            CharacterGender.Male;

        ApplyGender();
    }




    public void ToggleGender()
    {

        if(currentGender ==
           CharacterGender.Female)
        {
            SetMale();
        }
        else
        {
            SetFemale();
        }

    }




    private void ApplyGender()
    {

        if(femaleCharacter == null ||
           maleCharacter == null)
        {
            Debug.LogWarning(
                "HFRigController: не назначены персонажи"
            );

            return;
        }



        if(currentGender ==
           CharacterGender.Female)
        {

            femaleCharacter.SetActive(true);

            maleCharacter.SetActive(false);


            Debug.Log("Активен Female");

        }
        else
        {

            femaleCharacter.SetActive(false);

            maleCharacter.SetActive(true);


            Debug.Log("Активен Male");

        }

    }

}