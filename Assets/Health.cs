using System;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 100f;
    [SerializeField] private Button _button;

    private float _currentHealth;

    public float MaxHealth => _maxHealth;

    public event Action<float> Changed;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
        Changed?.Invoke(_currentHealth);
    }

    public void TakeDamage(float damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Changed?.Invoke(_currentHealth);
    }

    private void OnButtonClicked()
    {
        TakeDamage(10f);
    }
}
