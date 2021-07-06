using System;
using model;
using UnityEngine;
using view;

namespace animation
{
    public class EffectController : MonoBehaviour
    {
        private static EffectController _instance;

        public static EffectController Instance()
        {
            return _instance;
        }

        private GameObject directionEffect;
        public GameObject selection;
        private GameObject selectionObject;

        private void Awake()
        {
            _instance = this;
            directionEffect = (GameObject) Resources.Load("MoveEffect");
        }

        public void Clean()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (selectionObject != null) selectionObject.SetActive(false);
        }

        public void ShowMoveEffect(Vector3 position, Direction direction)
        {
            GameObject effectObject =
                (GameObject) Instantiate(directionEffect, position, Quaternion.identity, transform);
            effectObject.GetComponent<SpriteRenderer>().sprite = direction.image;
            effectObject.transform.localPosition = position;
        }

        public void ShowAttackEffect(Vector3 position, Skill skill)
        {
            GameObject effectObject =
                (GameObject) Instantiate(directionEffect, position, Quaternion.identity, transform);
            effectObject.GetComponent<SpriteRenderer>().sprite = skill.image;
            effectObject.transform.localPosition = position;
        }

        public void ShowSelection(CharacterView characterView)
        {
            if (selectionObject == null)
            {
                selectionObject = Instantiate(selection, transform);
            }

            selectionObject.transform.SetParent(characterView.transform);
            selectionObject.transform.localPosition = Vector3.zero;
            selectionObject.SetActive(true);
        }
    }
}