using System;
using System.Collections.Generic;
using model;
using scriptableObject;
using UnityEngine;
using UnityEngine.UI;

namespace ui
{
    public class HeroPanelView : MonoBehaviour
    {
        private Hero _hero;

        private void OnDestroy()
        {
            if (_hero != null)
            {
                // _hero.OnCharacterDeath -= OnCharacterDeath;
            }
        }

        public static HeroPanelView CreateHeroPanelView(Hero hero, Transform parent)
        {
            var gameObject = (GameObject) Instantiate(Resources.Load("HeroPanel"), parent);
            HeroPanelView heroPanel = gameObject.GetComponent<HeroPanelView>();
            heroPanel.SyncWithModel(hero);
            return heroPanel;
        }

        public void SyncWithModel(Hero hero)
        {
            transform.Find("Image").GetComponent<Image>().sprite = ((HeroSo) hero.CharacterSo).Portrait;
            GetComponentInChildren<ActionPanelView>().SyncWithModel(hero.Orders, hero);
            GetComponentInChildren<HealthBarScript>().SyncWithModel(hero);
            _hero = hero;
            // _hero.OnCharacterDeath += OnCharacterDeath;
        }

        private void OnCharacterDeath()
        {
            Destroy(gameObject);
        }
    }
}