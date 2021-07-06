using System;
using UnityEngine;
using UnityEngine.UI;

namespace ui
{
    public class HealthBarScript : MonoBehaviour
    {
        private Character _character;
        private Image image;

        public void SyncWithModel(Character character)
        {
            _character = character;
            image = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        }

        private void Update()
        {
            image.fillAmount = (float) _character.hp / _character.maxHp;
        }
    }
}