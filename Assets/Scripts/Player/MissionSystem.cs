using System;
using System.Collections.Generic;
using System.Linq;
using InteractableObjects.Items;
using UnityEngine;

namespace Player
{
    public class MissionSystem : MonoBehaviour, IMissionSystem
    {
        [SerializeField] private float markingTime = .5f;
        [SerializeField] private List<Mission> mainObjectives;

        private void Awake()
        {
            foreach (var objective in mainObjectives)
            {
                objective.Configure(markingTime);
            }
        }

        public void CompleteMainObjective(Ingredient ingredient)
        {
            foreach (var missionUI in mainObjectives.Where(mission => mission.Name == ingredient.ItemName))
            {
                missionUI.ObjectiveCompeted();
            }
            
        }
    }
}