using System;
using System.Collections;
using InteractableObjects.Objects;
using TMPro;
using UnityEngine;

namespace Player
{
    public class DialogSystem : MonoBehaviour, IDialogSystem
    {
        [SerializeField] private TMP_Text dialogText;
        [SerializeField] [Range(0.01f, 0.1f)] private float msPerLetter;
        /*[SerializeField]*/
        private bool _dialogOpen, _showingDialog, _firstFrameHappen, _waitingForOption;
        private string _showedDialog;
        private Dialog _currentDialog;
        private IPlayerMediator _playerMediator;

        public void Configure(IPlayerMediator playerMediator)
        {
            _playerMediator = playerMediator;
        }
        

        public void OpenDialog(Dialog dialog, bool wasDialogOpen = false)
        {
            if (wasDialogOpen == false)
            {
                if (_dialogOpen) return;
                _dialogOpen = true;
                _playerMediator.ResetTrigger("CloseDialog");
                _playerMediator.SetTrigger("OpenDialog");
            }
            _currentDialog = dialog;
            _currentDialog.eventsWhenOpen?.Invoke();
            StartCoroutine(ShowDialogText());
        }

        public void Interacted()
        {
            if (!_showingDialog && _dialogOpen)
            {
                if (_currentDialog.isLastDialog)
                {
                    CloseDialog();
                }
                else
                {
                    if (_currentDialog.options.Count == 1)
                    {
                        OpenDialog(_currentDialog.options[0], true);
                    }
                }
            }

            if (_showingDialog && _firstFrameHappen)
            {
                StopAllCoroutines();
                dialogText.text = _currentDialog.text;
                ShowOptions();
                _showingDialog = false;
            }
        }

        private void CloseDialog()
        {
            _playerMediator.ResetTrigger("OpenDialog");
            _playerMediator.SetTrigger("CloseDialog");
            _currentDialog = null;
            _dialogOpen = false;
        }

        private IEnumerator ShowDialogText()
        {
            _showedDialog = "";
            _showingDialog = true;
            var currentDialogText = _currentDialog.text;
            _firstFrameHappen = false;
            yield return null;
            _firstFrameHappen = true;
            foreach (var t in currentDialogText)
            {
                _showedDialog += t;
                dialogText.text = _showedDialog;
                yield return new WaitForSeconds(msPerLetter);
            }

            ShowOptions();
            _showingDialog = false;
        }

        private void ShowOptions()
        {
            var cont = 1;
            if (_currentDialog.options is {Count: > 1})
            {
                _waitingForOption = true;
                foreach (var option in _currentDialog.options)
                {
                    dialogText.text += $"\n{cont}  {option.lineToSelectDialog}";
                    cont ++;
                }
            }
        }
        
        public void ActionKey(int key)
        {
            if (_waitingForOption && _currentDialog.options.Count >= key)
            {
                _waitingForOption = false;
                OpenDialog(_currentDialog.options[key - 1], true);
            }
        }
    }
}