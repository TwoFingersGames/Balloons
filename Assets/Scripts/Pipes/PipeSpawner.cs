using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private int _quantity;
    [SerializeField] private float _distance;
    [SerializeField] private Pipe _pipe;
    private float _customDistance => (_pipe.transform.localScale.x + _distance) / 2f;
    
    private void Start()
    {
        Spawn();
    }
    private Pipe[] Spawn()
    {
        Pipe[] pipes = new Pipe[_quantity];
        for (int i = 1; i < _quantity + 1; i++)
        {
            Vector2 spawnPosition;
            if (_quantity % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    spawnPosition = new Vector2(transform.position.x + _customDistance * (i - 1), transform.position.y);
                }
                else
                {
                    spawnPosition = new Vector2(transform.position.x - _customDistance * i, transform.position.y);
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    spawnPosition = new Vector2(transform.position.x + _customDistance + _customDistance * (i - 1), transform.position.y);
                }
                else
                {
                    spawnPosition = new Vector2(transform.position.x + _customDistance - _customDistance * i, transform.position.y);
                }
            }
            
            
            
            pipes[i - 1] = Instantiate(_pipe, spawnPosition, Quaternion.identity, transform);
            
        }
        return pipes;
    }
}
