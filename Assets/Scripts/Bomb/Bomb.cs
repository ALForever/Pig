using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Animator _animator;
    private Collider2D _enemyCollider;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _activationTime = 1f;
    [SerializeField] private float _detonationAreaRatio = .5f;
    [SerializeField] private bool _isActive;
    public Bomb(float activationTime, float detonationAreaRatio = 0.5f)
    {
        this._activationTime = activationTime;
        this._detonationAreaRatio = detonationAreaRatio;
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        StartCoroutine(Activation());
    }
    private void OnEnable()
    {
        StartCoroutine(Activation());
    }
    void Update()
    {
        _enemyCollider = Physics2D.OverlapCircle(transform.position, transform.localScale.x * _detonationAreaRatio, _enemyLayer);
        if (_isActive && _enemyCollider)
            Explosion();
    }   
    private IEnumerator Activation()
    {
        yield return new WaitForSeconds(_activationTime);
        _animator.SetTrigger("activation");
        _isActive = true;
    }
    private void Explosion()
    {
        _animator.SetTrigger("explosion");
        _enemyCollider.GetComponentInParent<Enemy.StationBehaviour>().IsDirty = true;
        _isActive = false;
    }
    private void AnimationEventSetInactivity()//BombExplosionAnimation
    {
        gameObject.SetActive(false);
    }
}