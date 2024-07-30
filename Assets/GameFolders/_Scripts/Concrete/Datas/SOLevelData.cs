using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOLevelData", menuName = "ScriptableObjects/LevelData", order = 1)]
public class SOLevelData : ScriptableObject
{
   [SerializeField] public LevelData levelData;
}
