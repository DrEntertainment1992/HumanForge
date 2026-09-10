using UnityEngine;


public class HFBodyController : MonoBehaviour
{

    [Header("Тело")]
    public SkinnedMeshRenderer body;



    [Header("Корень персонажа")]
    public Transform bodyRoot;



    [Header("Рост")]

    [Range(140,220)]
    public float heightCm = 176;


    public float baseHeightCm = 176;



    [Header("Мышцы")]
    [Range(0,100)]
    public float muscle = 50;



    [Header("Вес")]
    [Range(0,100)]
    public float weight = 50;




    private void Start()
    {
        ApplyAll();
    }




    private void OnValidate()
    {
        if(!Application.isPlaying)
        {
            ApplyAll();
        }
    }





    // =====================================
    // Публичные функции
    // =====================================


    public void SetHeight(float value)
    {

        heightCm = value;

        ApplyHeight();

    }





    public void SetMuscle(float value)
    {

        muscle = value;

        ApplyMorphs();

    }





    public void SetWeight(float value)
    {

        weight = value;

        ApplyMorphs();

    }






    // =====================================
    // Обновление тела
    // =====================================


    private void ApplyAll()
    {

        ApplyHeight();

        ApplyMorphs();

    }






    // =====================================
    // Рост
    // =====================================


    private void ApplyHeight()
    {

        if(bodyRoot == null)
        {
            Debug.LogError(
                "Нет Body Root у "
                + gameObject.name
            );

            return;
        }



        float scale =
            heightCm /
            baseHeightCm;



        bodyRoot.localScale =
            Vector3.one * scale;



        Debug.Log(
            "Рост: "
            + gameObject.name
            + " "
            + heightCm
            + " см"
        );

    }






    // =====================================
    // BlendShapes
    // =====================================


    private void ApplyMorphs()
    {

        if(body == null)
            return;


        if(body.sharedMesh == null)
            return;



        SetBlend(
            "HF_Muscle_Low",
            100 - muscle
        );


        SetBlend(
            "HF_Muscle_High",
            muscle
        );



        SetBlend(
            "HF_Weight_Thin",
            100 - weight
        );


        SetBlend(
            "HF_Weight_Heavy",
            weight
        );

    }






    private void SetBlend(
        string name,
        float value
    )
    {

        int index =
            body.sharedMesh
            .GetBlendShapeIndex(name);



        if(index < 0)
        {
            Debug.LogWarning(
                "Не найден BlendShape: "
                + name
            );

            return;
        }



        body.SetBlendShapeWeight(
            index,
            Mathf.Clamp(
                value,
                0,
                100
            )
        );

    }

}