using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class ScenesSystem : MonoBehaviour, IScenesSystem
    {
        private PlayerMediator _mediator;

        public void TransitionToScene(string sceneName)
        {
            _mediator.SetTrigger("FadeIn");
            _mediator.CloseDialog();
            StartCoroutine(LoadScene(sceneName));
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return new WaitForSeconds(.5f);
            SceneManager.LoadScene(sceneName);
            yield return new WaitForSeconds(.5f);
            _mediator.SetTrigger("FadeOut");
        }

        public void Configure(PlayerMediator playerMediator)
        {
            _mediator = playerMediator;
        }
    }
}