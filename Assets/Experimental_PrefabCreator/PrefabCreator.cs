using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;


public class PrefabCreator : MonoBehaviour
{
    [Tooltip("Не должно превышать количество <Units Data> в <UnitDataBase>")]
    [SerializeField] private int _unitsCount;
    [Tooltip("Не должно превышать количество <Colors> в <UnitDataBase>")]
    [SerializeField] private int _colorsCount;
    [SerializeField] private List<GameObject> _createdPrefabs;
    [SerializeField] private List<Unit> _createdUnits;
    [SerializeField] private UnitCreator _unitCreator;
    [SerializeField] private UnitPrefabsBase _unitPrefabsBase;
    [SerializeField] private GameObject[] _childrenObjects;
    private const string FOLDER_PATH = "Assets/UnitPrefabs";
    private const string FOLDER_NAME = "UnitPrefabs";
    private void OnValidate()
    {
        _unitCreator = FindObjectOfType<UnitCreator>();
    }
    public void ClearPrefabs()
    {
        foreach (var unit in _createdUnits)
        {
            Destroy(unit.gameObject);
        }
        _createdUnits.Clear();
        _createdPrefabs.Clear();
        AssetDatabase.DeleteAsset(FOLDER_PATH);
        AssetDatabase.Refresh();
    }
    public void CreatePrefabs()
    {
        
        CreateUnits();
        StartCoroutine(CheckFolder());
        
        
        
    }
    private IEnumerator CheckFolder()
    {
        if (AssetDatabase.IsValidFolder(FOLDER_PATH))
        {
            Debug.Log("valid true");
            SavePrefabs();
            Debug.Log("ok!");
            yield break;
        }
        else
        {
            Debug.Log("valid false");
            string guid = AssetDatabase.CreateFolder("Assets", FOLDER_NAME);
            string newFolderPath = AssetDatabase.GUIDToAssetPath(guid);
            AssetDatabase.Refresh();
            Debug.Log("folder created  "+ newFolderPath);
            yield return new WaitForSeconds(1f);
            StartCoroutine(CheckFolder());
            
        }
    }
    private void SavePrefabs()
    {
        for (int i = 0; i < _createdUnits.Count; i++)
        {

            foreach (var child in _childrenObjects)
            {
                GameObject temp = Instantiate(child, _createdUnits[i].gameObject.transform);
                temp.transform.SetParent(_createdUnits[i].gameObject.transform);
                temp.GetComponent<HingeJoint2D>().connectedBody = _createdUnits[i].Rigidbody2D;
            }

            _createdPrefabs.Add(PrefabUtility.SaveAsPrefabAsset(_createdUnits[i].gameObject, FOLDER_PATH + "/" + _createdUnits[i].name + i + ".prefab"));
            
        }
        
    }

    private void CreateUnits()
    {
        for (int i = 0; i < _unitsCount; i++)
        {
            for (int j = 0; j < _colorsCount; j++)
            {
                _createdUnits.Add(_unitCreator.BuildUnit(i, j));
                
            }
        }
        
    }
}
