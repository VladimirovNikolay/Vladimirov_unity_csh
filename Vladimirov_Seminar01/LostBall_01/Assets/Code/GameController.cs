using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class GameController : MonoBehaviour
{
    private InteractiveObject[] _interactiveObjects;

    public Text _finishGameLabel;
    private DisplayEndGame _displayEndGame;

    private void Awake()
    {
        _interactiveObjects = FindObjectsOfType<InteractiveObject>();
        _displayEndGame = new DisplayEndGame(_finishGameLabel);
        foreach (var w in _interactiveObjects)
        {
            if (w is BadBonus badBonus)
            {
                badBonus.CaughtPlayer += CaughtPlayer;
                badBonus.CaughtPlayer += _displayEndGame.GameOver;
            }
        }
    }

    private void CaughtPlayer(object value, Color color)
    {
        Time.timeScale = 0.0f;
    }

    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame(Text finishGameLabel)
        {
            _finishGameLabel = finishGameLabel;
            _finishGameLabel.text = String.Empty;
        }

        public void GameOver(object o, Color color)
        {
            _finishGameLabel.text = $"Game Over! Your killer - {((GameObject)o).name} {color} color";
        }
    }

    private void Update()
    {
        for (var i = 0; i < _interactiveObjects.Length; i++)
        {
            var interactiveObject = _interactiveObjects[i];
            if (interactiveObject == null)
            {
                continue;
            }
            if (interactiveObject is IFlay flay)
            {
                flay.Flay();
            }
            if (interactiveObject is IRotation rotation)
            {
                rotation.Rotation();
            }
            if (interactiveObject is IFlicker flicker)
            {
                flicker.Flicker();
            }

        }
    }

}
