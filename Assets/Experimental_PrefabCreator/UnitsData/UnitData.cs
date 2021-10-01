using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitData", menuName = "UnitData", order = 52)]
public class UnitData : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private AnimationClip _animationCustom;
    [SerializeField] private AnimationClip _animationAtack;

    public (string, Sprite, AnimationClip, AnimationClip) GetUnitData()
    {
        var mainUnitData =
            (
            name: _name,
            sprite: _sprite,
            animationCustom: _animationCustom,
            animationAtack: _animationAtack
            );

        return mainUnitData;
    }
}
