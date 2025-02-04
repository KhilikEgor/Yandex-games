using DG.Tweening.Plugins.Options;
using Solitaire.Models;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Solitaire.Presenters
{
    public class WinsPresenter : OrientationAwarePresenter
    {
        [SerializeField]
        private Button _buttonNewMatch;


        [Inject] private readonly Game _game;



        protected override void Start()
        {
            base.Start();

            if (_buttonNewMatch == null)
            {
                Debug.LogError("Button is not assigned!");
                return;
            }

            if (_game.NewMatchCommand == null)
            {
                Debug.LogError("NewMatchCommand is null!");
                return;
            }

            _game.NewMatchCommand.BindTo(_buttonNewMatch).AddTo(this);
            _game.NewMatchCommand.Subscribe(_ => Debug.Log("Button clicked!")).AddTo(this);
        }

        protected override void OnOrientationChanged(bool isLandscape)
        {
        }
    }
}
