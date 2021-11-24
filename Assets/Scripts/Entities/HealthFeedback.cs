using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Health))]
public class HealthFeedback : MonoBehaviour
{
    [Serializable]
    public class FeedbackWrapper
    {
        public int Health;
        public Sprite Sprite;
    }

    [SerializeField]
    private List<FeedbackWrapper> feedback;

    [SerializeField]
    private SpriteRenderer artRenderer;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnEntityHit.AddListener(CalculateFeedback);
        _health.OnEntityDie.AddListener(CalculateFeedback); 
    }

    private void CalculateFeedback()
    {
        FeedbackWrapper selectedFeedback = feedback
                                                .Where(x => x.Health >= _health.Current)
                                                .OrderBy(x => x.Health)
                                                .FirstOrDefault();

        if (selectedFeedback != null)
        {
            artRenderer.sprite = selectedFeedback.Sprite;
        }
    }        

}
