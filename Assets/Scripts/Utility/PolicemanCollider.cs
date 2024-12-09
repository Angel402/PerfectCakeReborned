using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using ServiceLocatorPath;
using UnityEngine;
using UnityEngine.AI;

namespace Utility
{
    public class PolicemanCollider : MonoBehaviour
    {
        [SerializeField] private ConeTrigger coneTrigger;
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private List<Transform> patrolPoints;
        [SerializeField] private float velocity = 1;
        [SerializeField] private float stoppingDistance = .1f, waitWhenStop;
        [SerializeField] private Light flashLight;
        private Dialog _arrestDialog;
        private int _currentTargetIndex;

        private void Awake()
        {
            navMeshAgent.speed = velocity;
            StartCoroutine(PatrolToTarget(patrolPoints[0]));
        }

        public void Configure(Dialog arrestDialog, Color color)
        {
            _arrestDialog = arrestDialog;
            coneTrigger.Configure(OpenArrestDialog);
            flashLight.color = color;
        }

        private void OpenArrestDialog()
        {
            ServiceLocator.Instance.GetService<IDialogSystem>().OpenDialog(_arrestDialog);
        }

        private IEnumerator PatrolToTarget(Transform target)
        {
            navMeshAgent.enabled = true;
            var targetPosition = target.position;
            navMeshAgent.destination = targetPosition;
            while (Vector3.Distance(transform.position, targetPosition) >= stoppingDistance)
            {
                /*Debug.Log(Vector3.Distance(transform.position, targetPosition));*/
                yield return null;
            }
            
            _currentTargetIndex++;
            navMeshAgent.enabled = false;
            yield return new WaitForSeconds(waitWhenStop);
            if (_currentTargetIndex == patrolPoints.Count)
            {
                _currentTargetIndex = 0;
            }
            StartCoroutine(PatrolToTarget(patrolPoints[_currentTargetIndex]));
            
        }
    }
}