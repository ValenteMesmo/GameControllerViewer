using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace GameControllerViewer
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        Texture2D ControllerTexture;
        Texture2D RoundButton;
        Texture2D ShouderButton;
        Texture2D TriggerButton;
        Texture2D StartButton;
        Texture2D DPadButton;
        Texture2D AnalogStick;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ControllerTexture = Content.Load<Texture2D>("base");
            RoundButton = Content.Load<Texture2D>("button_round");
            ShouderButton = Content.Load<Texture2D>("button_shoulder_actual");
            TriggerButton = Content.Load<Texture2D>("button_shoulder");
            StartButton = Content.Load<Texture2D>("button_start");
            DPadButton = Content.Load<Texture2D>("button_dpad"); ;
            AnalogStick = Content.Load<Texture2D>("button_analog"); ;
        }


        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //base
            spriteBatch.Draw(
                ControllerTexture,
                new Rectangle(0, 0, ControllerTexture.Width, ControllerTexture.Height),
                Color.Green);

            //x
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(460, 165, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.A == ButtonState.Pressed ? Color.Red : Color.Green);

            //triangulo
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(460, 100, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Y == ButtonState.Pressed ? Color.Red : Color.Green);

            //quadrado
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(420, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.X == ButtonState.Pressed ? Color.Red : Color.Green);

            //bola
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(500, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.B == ButtonState.Pressed ? Color.Red : Color.Green);

            //start
            spriteBatch.Draw(
                StartButton,
                new Rectangle(400, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Start == ButtonState.Pressed ? Color.Red : Color.Green);

            //select
            spriteBatch.Draw(
                StartButton,
                new Rectangle(308, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Back == ButtonState.Pressed ? Color.Red : Color.Green);

            //r1
            spriteBatch.Draw(
                ShouderButton,
                new Rectangle(460, 50, ShouderButton.Width, ShouderButton.Height),
                gamePadState.Buttons.RightShoulder == ButtonState.Pressed ? Color.Red : Color.Green);

            //r2
            spriteBatch.Draw(
                TriggerButton,
                new Rectangle(460, 25, TriggerButton.Width, TriggerButton.Height),
                new Color(gamePadState.Triggers.Right, 1f - gamePadState.Triggers.Right, 0));

            //L
            spriteBatch.Draw(
                AnalogStick,
                new Rectangle(
                    210 + (int)(gamePadState.ThumbSticks.Left.X * 15),
                    200 - (int)(gamePadState.ThumbSticks.Left.Y * 15),
                    AnalogStick.Width,
                    AnalogStick.Height),
                gamePadState.Buttons.LeftStick == ButtonState.Pressed ? Color.Red : Color.Green);

            //R
            spriteBatch.Draw(
                AnalogStick,
                new Rectangle(
                    375 + (int)(gamePadState.ThumbSticks.Right.X * 15),
                    200 - (int)(gamePadState.ThumbSticks.Right.Y * 15),
                    AnalogStick.Width,
                    AnalogStick.Height),
                gamePadState.Buttons.RightStick == ButtonState.Pressed ? Color.Red : Color.Green);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
