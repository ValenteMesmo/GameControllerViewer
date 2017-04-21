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
        Texture2D DPadButton2;
        Texture2D AnalogStick;

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            ControllerTexture = Content.Load<Texture2D>("base");
            RoundButton = Content.Load<Texture2D>("button_round");
            ShouderButton = Content.Load<Texture2D>("button_shoulder_actual");
            TriggerButton = Content.Load<Texture2D>("button_shoulder");
            StartButton = Content.Load<Texture2D>("button_start");
            DPadButton = Content.Load<Texture2D>("button_dpad"); 
            AnalogStick = Content.Load<Texture2D>("button_analog"); ;
            DPadButton2 = Content.Load<Texture2D>("button_dpad2");
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

            GraphicsDevice.Clear(Color.Blue);
            spriteBatch.Begin();

            var color = new Color(0,255,0);
            var color_focus = new Color(255, 0, 0);

            //base
            spriteBatch.Draw(
                ControllerTexture,
                new Rectangle(0, 0, ControllerTexture.Width, ControllerTexture.Height),
                color);

            var dpad_X = 30;
            var dpad_Y = -10;
            //dup
            spriteBatch.Draw(
                DPadButton,
                new Rectangle(100 + dpad_X, 120 + dpad_Y, DPadButton.Width, DPadButton.Height),
                gamePadState.DPad.Up == ButtonState.Pressed ? color_focus : color);
            
            //ddown
            spriteBatch.Draw(
                DPadButton,
                new Rectangle(100 + dpad_X, 165 + dpad_Y, ShouderButton.Width, ShouderButton.Height),
                null,
                gamePadState.DPad.Down == ButtonState.Pressed ?color_focus : color,
                0f,
                new Vector2(0, 0),
                SpriteEffects.FlipVertically,
                0f);

            //dright
            spriteBatch.Draw(
                DPadButton2,
                new Rectangle(115 + dpad_X, 145 + dpad_Y, DPadButton.Width, DPadButton.Height),
                gamePadState.DPad.Right == ButtonState.Pressed ?color_focus : color);

            //dleft
            spriteBatch.Draw(
                DPadButton2,
                new Rectangle(80 + dpad_X, 145 + dpad_Y, ShouderButton.Width, ShouderButton.Height),
                null,
                gamePadState.DPad.Left == ButtonState.Pressed ?color_focus : color,
                0f,
                new Vector2(0, 0),
                SpriteEffects.FlipHorizontally,
                0f);

            //x
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(460, 165, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.A == ButtonState.Pressed ?color_focus : color);

            //triangulo
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(460, 100, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Y == ButtonState.Pressed ?color_focus : color);

            //quadrado
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(420, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.X == ButtonState.Pressed ?color_focus : color);

            //bola
            spriteBatch.Draw(
                RoundButton,
                new Rectangle(500, 135, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.B == ButtonState.Pressed ?color_focus : color);
                        
            //start
            spriteBatch.Draw(
                StartButton,
                new Rectangle(380,70, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Start == ButtonState.Pressed ?color_focus : color);

            //select
            spriteBatch.Draw(
                StartButton,
                new Rectangle(190, 70, RoundButton.Width, RoundButton.Height),
                gamePadState.Buttons.Back == ButtonState.Pressed ?color_focus : color);

            //r2
            spriteBatch.Draw(
                TriggerButton,
                new Rectangle(460, 25, TriggerButton.Width, TriggerButton.Height),
                gamePadState.Triggers.Right >0 ? color_focus : color);
            
            //r1            
            spriteBatch.Draw(
                ShouderButton,
                new Rectangle(460, 40, ShouderButton.Width, ShouderButton.Height),
                null,
                gamePadState.Buttons.RightShoulder == ButtonState.Pressed ?color_focus : color,
                0f,
                new Vector2(0, 0),
                SpriteEffects.FlipHorizontally,
                0f);

            //l2            
            spriteBatch.Draw(
                TriggerButton,
                new Rectangle(125, 25, TriggerButton.Width, TriggerButton.Height),
                null,
                gamePadState.Triggers.Left > 0 ? color_focus : color,
                0f,
                new Vector2(0, 0),
                SpriteEffects.FlipHorizontally,
                0f);
            //l1
            spriteBatch.Draw(
                ShouderButton,
                new Rectangle(125, 40, ShouderButton.Width, ShouderButton.Height),
                gamePadState.Buttons.LeftShoulder == ButtonState.Pressed ?color_focus : color);

            

            //L
            spriteBatch.Draw(
                AnalogStick,
                new Rectangle(
                    210 + (int)(gamePadState.ThumbSticks.Left.X * 15),
                    200 - (int)(gamePadState.ThumbSticks.Left.Y * 15),
                    AnalogStick.Width,
                    AnalogStick.Height),
                gamePadState.Buttons.LeftStick == ButtonState.Pressed ?color_focus : color);

            //R
            spriteBatch.Draw(
                AnalogStick,
                new Rectangle(
                    375 + (int)(gamePadState.ThumbSticks.Right.X * 15),
                    200 - (int)(gamePadState.ThumbSticks.Right.Y * 15),
                    AnalogStick.Width,
                    AnalogStick.Height),
                gamePadState.Buttons.RightStick == ButtonState.Pressed ?color_focus : color);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
