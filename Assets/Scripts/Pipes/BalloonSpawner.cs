using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] private Balloon _balloon;
    [SerializeField] private List<GameObject> _balloons;
    [SerializeField] private ColorsCollection _colors;
    private BalloonsController _balloonsController;
    private void Awake()
    {
        _balloonsController = FindObjectOfType<BalloonsController>();
    }
    private void OnEnable()
    {
        _balloons.Clear();
        for (int i = 0; i < _colors.Colors.Length; i++)
        {
            
            _balloon.SetColor(_colors.Colors[i]);
            _balloon.Index = i;
            var temp = _balloon.gameObject;
            _balloons.Add(temp);
        }
        StartCoroutine("SpawnBalls");
    }

    private IEnumerator SpawnBalls()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));

        var balloon = Instantiate(_balloons[Random.Range(0, _balloons.Count)], transform.position, Quaternion.Euler(0, 0, Random.Range(-15f, 15f)));
        var ball =  balloon.GetComponent<Balloon>();
        ball.Click += _balloonsController.OnBalloonClick;
        

        StartCoroutine("SpawnBalls");
    }
}
