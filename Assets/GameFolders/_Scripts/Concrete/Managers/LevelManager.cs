using UnityEngine;
public class LevelManager : MonoBehaviour
{
    GameObject levelPrefab;
    SOLevelData soLevelData;

    void Awake()
    {
        soLevelData = GetSOLevelData();
    }
    SOLevelData GetSOLevelData()
    {
        return Resources.Load<SOLevelData>("Datas/SOLevelData");
    }


    void OnEnable()
    {
        CoreGameSignals.Instance.onLevelInit += onLevelInit;
        CoreGameSignals.Instance.onLevelFailed += onLevelFailed;
        CoreGameSignals.Instance.onNextLevelPhase += onNextLevelPhase;
        CoreGameSignals.Instance.onRestartLevelPhase += onRestartLevelPhase;
    }

    private void onNextLevelPhase(float playerIncreaseValue)
    {
        soLevelData.levelData.PlayerSpeed += playerIncreaseValue;
        Debug.Log(soLevelData.levelData.PlayerSpeed+ "level phase");
    }

    private void onRestartLevelPhase()
    {
        soLevelData.levelData.PlayerSpeed = 0f;
        Debug.Log(soLevelData.levelData.PlayerSpeed+"leve restart");
    }
    private void onLevelFailed()
    {
        Destroy(levelPrefab);
    }

    private void onLevelInit(byte levelIndex)
    {
        levelPrefab = Instantiate(Resources.Load<GameObject>($"Prefabs/LevelPrefabs/level {levelIndex}"));
    }

    void OnDisable()
    {
        CoreGameSignals.Instance.onLevelInit -= onLevelInit;
        CoreGameSignals.Instance.onLevelFailed -= onLevelFailed;
        CoreGameSignals.Instance.onNextLevelPhase -= onNextLevelPhase;
        CoreGameSignals.Instance.onRestartLevelPhase -= onRestartLevelPhase;
    }
}
