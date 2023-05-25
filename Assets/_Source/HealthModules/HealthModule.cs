using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthSystem
{
    public class HealthModule : MonoBehaviour
    {
        [SerializeField] private IDamagable _owner;

        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;

        [SerializeField] private bool _isRegenerating;
        [SerializeField] private int _regenerationPerSecond;

        [Header("Для тех, чьё ХП отображается")]
        [SerializeField] private UIHealthDrawer _uiHealthDrawer;

        float _secondTimer = 1;


        private void Start()
        {
            if (_uiHealthDrawer != null) _uiHealthDrawer.InitHPbar(_maxHealth, _currentHealth);
        }

        private void Update()
        {
            if (_isRegenerating && _currentHealth < _maxHealth)
            {
                _secondTimer -= Time.deltaTime;
                if (_secondTimer < 0)
                {
                    _secondTimer = 1;
                    Heal(_regenerationPerSecond);
                }
            }
        }

        public void GetDamage(int damage)
        {
            if (damage < _currentHealth)
            {
                _currentHealth -= damage;
                if (_uiHealthDrawer != null) _uiHealthDrawer.Refresh(_currentHealth);
                
                _owner.Damage();
            }
            else
            {
                _currentHealth = 0;
                if (_uiHealthDrawer != null) _uiHealthDrawer.Refresh(_currentHealth);
                
                _owner.Annihilate();
            }
        }

        public void Heal(int healedHP)
        {
            _currentHealth = _maxHealth > _currentHealth + healedHP ? _currentHealth + healedHP : _maxHealth;
            if (_uiHealthDrawer != null) _uiHealthDrawer.Refresh(_currentHealth);
        }
    }
}