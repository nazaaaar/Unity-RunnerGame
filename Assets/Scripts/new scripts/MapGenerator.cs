using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject oneWay;
    [SerializeField] private GameObject bothWay;
    [SerializeField] private GameObject stageEnd;
    [SerializeField] private GameObject startGame;
    enum PlatformType
    {
        OneWay,
        BothWay,
        StageEnd,
    }

    private float z = 1;
    void Start()
    {
        StageHandler.NewStage();
        StageHandler.NewStage();
        StageHandler.NewStage();
        StageHandler.AddToStage(startGame);
        GenerateStage();
        GenerateStage();
    }

    private bool isPositive = true;
    private float speed, x;

    private void GenerateStage()
    {
        StageHandler.NewStage();
        while (!Generate()) ;
        StageHandler.ClearStage();
    }
    private bool Generate()
    {
        z += Random.Range(5, 8f);

        switch (GenPlatformType())
        {
            case PlatformType.OneWay: {
                    speed = Random.Range(5.0f, 6.5f);
                    if (!isPositive) speed *= -1;
                    isPositive = !isPositive;

                    x = Random.Range(-14f, 0);
                    StageHandler.AddToStage(Instantiate(oneWay, new Vector3(x, 0, z), Quaternion.identity))
                        .GetComponent<Platform>().Speed = speed;
                    StageHandler.AddToStage(Instantiate(oneWay, new Vector3(x + Random.Range(6, 14f), 0, z), Quaternion.identity))
                        .GetComponent<Platform>().Speed = speed;
                    break; }
            case PlatformType.BothWay: {
                    speed = Random.Range(6.5f, 7f);
                    if (!isPositive) speed *= -1;
                    isPositive = !isPositive;

                    StageHandler.AddToStage(Instantiate(bothWay, new Vector3(Random.Range(-14f, 14), 0, z), Quaternion.identity))
                        .GetComponent<Platform>().Speed = speed;
                    break; }
            case PlatformType.StageEnd: {
                    x = Random.Range(-3f, 3);
                    StageHandler.AddToStage(Instantiate(stageEnd, new Vector3(x, 0, z), Quaternion.identity)).GetComponentInChildren<StageTrigger>().OnStageAchieved += MapGenerator_OnStageActivated;
                    return true;
                     }
        }
        return false;
        
    }

    private void MapGenerator_OnStageActivated(object sender, System.EventArgs e)
    {
        GenerateStage();
    }

    private int k = 1;
    private PlatformType GenPlatformType()
    {
        int rnd;
        if (k < 5)
            rnd = Random.Range(0, 6);
        else if (k == 6) rnd = Random.Range(0, 12);
        else rnd = 6;

        k++;
        if (rnd < 4) return PlatformType.OneWay;
        else if (rnd < 6) return PlatformType.BothWay;
        else { k = 1; return PlatformType.StageEnd; }
    }

}
