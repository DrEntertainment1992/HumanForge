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



    private Vector3 startScale = Vector3.one;



    private void Awake()
    {
        if(bodyRoot != null)
        {
            startScale = bodyRoot.localScale;
        }


        Debug.Log(
            "HFBodyController Awake: "
            + gameObject.name
        );
    }



    private void Start()
    {
        ApplyAll();


        Debug.Log(
            "HFBodyController Start: "
            + gameObject.name
        );
    }



    private void Update()
    {
        // только для теста
        ApplyHeight();
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

        Debug.Log(
            "SetHeight: "
            + value
        );

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



    public void SetBody(
        SkinnedMeshRenderer newBody
    )
    {
        body = newBody;

        ApplyMorphs();
    }




    // =====================================
    // Применение
    // =====================================


    private void ApplyAll()
    {
        ApplyHeight();
        ApplyMorphs();
    }





    private void ApplyHeight()
    {

        if(bodyRoot == null)
        {
            Debug.LogError(
                "BodyRoot пустой у "
                + gameObject.name
            );

            return;
        }



        float scale =
            heightCm /
            baseHeightCm;



        bodyRoot.localScale =
            startScale * scale;



        Debug.Log(
            "Рост применён: "
            + gameObject.name
            + " "
            + heightCm
            + "cm"
            + " scale="
            + scale
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