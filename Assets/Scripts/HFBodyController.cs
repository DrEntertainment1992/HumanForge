using UnityEngine;


public class HFBodyController : MonoBehaviour
{

    [Header("Активное тело")]
    public SkinnedMeshRenderer body;


    [Header("Параметры тела")]

    [Range(140,220)]
    public float heightCm = 176;


    [Range(0,100)]
    public float muscle = 50;


    [Range(0,100)]
    public float weight = 50;



    [Header("Базовый рост тела")]
    public float baseHeightCm = 176;



    private float startScale = 1f;



    void Awake()
    {
        SaveBaseScale();
    }



    void Start()
    {
        ApplyBody();
    }



    void OnValidate()
    {
        if(body == null)
            return;


        ApplyBody();
    }



    // =====================================================
    // Установка тела
    // Используется HFRigController
    // =====================================================

    public void SetBody(
        SkinnedMeshRenderer newBody
    )
    {

        body = newBody;


        SaveBaseScale();


        ApplyBody();

    }





    void SaveBaseScale()
    {

        if(body == null)
            return;


        startScale =
            body.transform.localScale.x;

    }





    // =====================================================
    // ПУБЛИЧНЫЕ НАСТРОЙКИ
    // =====================================================


    public void SetHeight(
        float value
    )
    {

        heightCm = value;

        ApplyHeight();

    }





    public void SetMuscle(
        float value
    )
    {

        muscle = value;

        ApplyMorphs();

    }





    public void SetWeight(
        float value
    )
    {

        weight = value;

        ApplyMorphs();

    }






    // =====================================================
    // ОБНОВЛЕНИЕ
    // =====================================================


    void ApplyBody()
    {

        ApplyHeight();

        ApplyMorphs();

    }





    // =====================================================
    // РОСТ
    // =====================================================


    void ApplyHeight()
    {

        if(body == null)
            return;



        float scale =
            heightCm /
            baseHeightCm;



        // меняем только тело
        // НЕ Human_BASE

        body.transform.localScale =
            Vector3.one *
            (startScale * scale);


    }







    // =====================================================
    // MORPH SHAPES
    // =====================================================


    void ApplyMorphs()
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





    void SetBlend(
        string name,
        float value
    )
    {

        int index =
            body.sharedMesh
            .GetBlendShapeIndex(name);



        if(index < 0)
            return;



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