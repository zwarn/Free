using System.Collections.Generic;
using model;
using UnityEngine;

namespace ui
{
    public class HeroesPanelView : MonoBehaviour
    {
        public void SyncWithModel(List<Hero> heroes)
        {
            Clear();
            foreach (var hero in heroes)
            {
                HeroPanelView.CreateHeroPanelView(hero, transform);
            }
        }

        private void Clear()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}