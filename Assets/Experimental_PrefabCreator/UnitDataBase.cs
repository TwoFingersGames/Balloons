using UnityEngine;

[CreateAssetMenu(fileName = "UnitDataBase", menuName = "UnitDataBase", order = 51)]
public class UnitDataBase : ScriptableObject
{
    [Header("MainUnitData")]
    [SerializeField] private UnitData[] _unitsData; 

    [Header("Colors")] 
    [SerializeField] private Color32[]  _colors;

    
    public (string, Sprite, AnimationClip, AnimationClip) GetMainUnitData(int index)
    {
        return _unitsData[index].GetUnitData();
    }

    public Color32 GetColor(int index)
    {
        Color32 color = _colors[index];
        return color;
    }

    public int GetUnitCount()
    {
        return _unitsData.Length;
    }
    
}
