using UnityEngine;


public class HFRigController : MonoBehaviour
{
    public enum CharacterGender
    {
        Female,
        Male
    }


    [Header("Текущий пол")]
    [SerializeField]
    private CharacterGender currentGender =
        CharacterGender.Female;


    [Header("Персонажи")]
    [SerializeField]
    private GameObject femaleCharacter;

    [SerializeField]
    private GameObject maleCharacter;


    [Header("Тела")]
    [SerializeField]
    private SkinnedMeshRenderer femaleBody;

    [SerializeField]
    private SkinnedMeshRenderer maleBody;


    [Header("Контроллер тела")]
    [SerializeField]
    private HFBodyController bodyController;



    private void Start()
    {
        ApplyGender();
    }



    private void OnValidate()
    {
        if (!Application.isPlaying)
            return;

        ApplyGender();
    }



    // =====================================================
    // PUBLIC
    // =====================================================


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
        if (currentGender ==
            CharacterGender.Female)
        {
            SetMale();
        }
        else
        {
            SetFemale();
        }
    }



    public CharacterGender GetGender()
    {
        return currentGender;
    }



    // =====================================================
    // APPLY
    // =====================================================


    private void ApplyGender()
    {
        if (femaleCharacter == null ||
            maleCharacter == null)
        {
            Debug.LogWarning(
                "HFRigController: не назначены персонажи"
            );

            return;
        }



        switch (currentGender)
        {

            case CharacterGender.Female:

                femaleCharacter.SetActive(true);
                maleCharacter.SetActive(false);


                if (bodyController != null)
                {
                    bodyController.SetBody(
                        femaleBody
                    );
                }

                break;



            case CharacterGender.Male:

                femaleCharacter.SetActive(false);
                maleCharacter.SetActive(true);


                if (bodyController != null)
                {
                    bodyController.SetBody(
                        maleBody
                    );
                }

                break;
        }
    }
}