using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSeter : MonoBehaviour
{
    [SerializeField] private Bomb _bombPrefab;
    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand = false;
    [SerializeField] private bool _replaceOld = false;

    private BombPool<Bomb> pool;

    private void Start()
    {
        pool = new BombPool<Bomb>(_bombPrefab, _poolCount, new GameObject("Bomb pool").transform)
        {
            AutoExpand = _autoExpand,
            ReplaceOld = _replaceOld
        };
    }
    public void SetBomb()
    {
        if (transform.hasChanged)
        {
            Bomb bomb = this.pool.GetFreeElement();
            if (bomb)
                bomb.transform.position = transform.position;
            transform.hasChanged = false;
        }
    }
}