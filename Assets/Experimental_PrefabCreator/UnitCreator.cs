using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCreator : MonoBehaviour
{
    [SerializeField] private UnitDataBase _unitData;
    private GameObject _gameObject;
    private void Awake()
    {
        
    }
    public Unit BuildUnit(int unitIndex, int colorIndex)
    {
        var gameObject = new GameObject();
        
        var mainUnitData = _unitData.GetMainUnitData(unitIndex);
        gameObject.name = mainUnitData.Item1;

        Unit unit = gameObject.AddComponent<Unit>();

        unit.Index = unitIndex;

        unit.SpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        unit.SpriteRenderer.sprite = mainUnitData.Item2;
        unit.SpriteRenderer.color = _unitData.GetColor(colorIndex);

        unit.Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        unit.Rigidbody2D.gravityScale = 0;

        unit.Collider = gameObject.AddComponent<PolygonCollider2D>();
        unit.Collider.isTrigger = true;

        unit.Animator = gameObject.GetComponent<Animator>();
        unit.Custom = mainUnitData.Item3;
        unit.Atack = mainUnitData.Item4;
        
        return unit;
    }
}
