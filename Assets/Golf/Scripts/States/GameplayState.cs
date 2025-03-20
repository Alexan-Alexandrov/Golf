using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

namespace Golf
{
    public class GameplayState : GameState
    {
        public LevelController levelcontroller;
        public PlayerController playercontroller;
        public GameState gameOverState;
        public TMP_Text scoreText;

        protected override void OnEnable()
        {
            base.OnEnable();

            levelcontroller.enabled = true;
            playercontroller.enabled = true;

            GameEvents.onCollisionBall += onGameOver;
            GameEvents.onStickHit += onStickHit;
        }

        private void onStickHit()
        {
            scoreText.text = $"Score : {levelcontroller.score}";
        }

        private void onGameOver()
        {
            Exit();
            gameOverState.Enter();

        }

        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionBall -= onGameOver;

            levelcontroller.enabled = false;
            playercontroller.enabled = false;

            
        }

       
    }
}
