using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Net.Mime;
using System.Reflection.Emit;

namespace Part_1_5__MonoGame_Assignment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        enum Screen
        {
            Intro,
            LeanStart,
            LeanMiddle,
            LeanLow,
            LeanMiddleAgain,
            StandingUp,
            Start,
            Moonwalk,
            End
            
        }
        float seconds;
        float startTime;
        bool songplayed;
        Texture2D StartTexture;
        Texture2D LeanStartTexture;
        Texture2D LeanMiddleTexture;
        Texture2D LeanLowTexture;
        Texture2D LeanMiddleAgainTexture;
        Texture2D StandingUpTexture;
        Texture2D IntroTexture;
        Texture2D MoonwalkTexture;
        Texture2D MoonwalkBackground;
        Texture2D EndTexture;
        Rectangle EndRect;
        Rectangle StartRect;
        Rectangle IntroRect;
        Rectangle LeanStartRect;
        Rectangle LeanMiddleRect;
        Rectangle LeanLowRect;
        Rectangle LeanMiddleAgainRect;
        Rectangle StandingUpRect;
        Rectangle MoonwalkRect;
        Rectangle MoonwalkBackgroundRect;
        Vector2 MoonwalkSpeed;
        Screen screen;
        SoundEffect MJMusic;
        MouseState mouseState;
        SpriteFont TitleFont;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            songplayed = false;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            startTime = 0;
            IntroRect = new Rectangle(0, 0, 800, 500);
            LeanStartRect = new Rectangle(0, 0, 800, 500);
            LeanMiddleRect = new Rectangle(0, 0, 800, 500);
            LeanLowRect = new Rectangle(0, 0, 800, 500);
            LeanMiddleAgainRect = new Rectangle(0, 0, 800, 500);
            StandingUpRect = new Rectangle(0, 0, 800, 500);
            StartRect = new Rectangle(0, 0, 800, 500);
            MoonwalkBackgroundRect = new Rectangle(0, 0, 800, 500);
            EndRect = new Rectangle(0, 0, 800, 500);
            MoonwalkRect = new Rectangle(700, 350, 79, 130);
            MoonwalkSpeed = new Vector2(-2, 0);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            StartTexture = Content.Load<Texture2D>("SmoothCriminalTitle");
            IntroTexture = Content.Load<Texture2D>("Intro");
            LeanStartTexture = Content.Load<Texture2D>("LeanStart");
            LeanMiddleTexture = Content.Load<Texture2D>("LeanMiddle");
            LeanLowTexture = Content.Load<Texture2D>("LeanLow");
            LeanMiddleAgainTexture = Content.Load<Texture2D>("LeanMiddle2");
            StandingUpTexture = Content.Load<Texture2D>("Standing");
            MoonwalkTexture = Content.Load<Texture2D>("Moonwalk");
            TitleFont = Content.Load<SpriteFont>("Title");
            MoonwalkBackground = Content.Load<Texture2D>("White Background");
            EndTexture = Content.Load<Texture2D>("on-toes");
            MJMusic = Content.Load<SoundEffect>("Smooth Criminal");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;
            if (!songplayed)
            {
                songplayed = true;
                MJMusic.Play();
            }


            if (seconds > 0)
                screen = Screen.Start;
               if (seconds > 5 || mouseState.LeftButton == ButtonState.Pressed)
                screen = Screen.LeanStart;
               if (seconds > 6)
                    screen = Screen.LeanMiddle;
                if (seconds > 7)
                screen = Screen.LeanLow;
                if (seconds > 8)
                screen = Screen.LeanMiddleAgain;
                if (seconds > 9)
                    screen = Screen.StandingUp;
                if (seconds > 10)
                {
                screen = Screen.Moonwalk;
                MoonwalkRect.X += (int)MoonwalkSpeed.X;
                }
            if (MoonwalkRect.Right > 800 || MoonwalkRect.Left < 0)
            {
                screen = Screen.End;
            }
            //ending from song
            if (seconds > 150)
            {
                screen = Screen.End;
                Exit();

            }
                
                


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
           

            if (screen == Screen.Start)
            {
                
                _spriteBatch.Draw(StartTexture, StartRect, Color.White);
                _spriteBatch.DrawString(TitleFont, "Welcome to the club", new Vector2(275, 150), Color.White);
            }
                


            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(IntroTexture, IntroRect, Color.White);
            }

            else if (screen == Screen.LeanStart)
            {
                _spriteBatch.Draw(LeanStartTexture, LeanStartRect, Color.White);
            }

            else if (screen == Screen.LeanMiddle)
            {
                _spriteBatch.Draw(LeanMiddleTexture, LeanMiddleRect, Color.White);
            }

            else if (screen == Screen.LeanLow)
            {
                _spriteBatch.Draw(LeanLowTexture, LeanLowRect, Color.White);
            }

            else if (screen == Screen.LeanMiddleAgain)
            {
                _spriteBatch.Draw(LeanMiddleAgainTexture, LeanMiddleAgainRect, Color.White);
            }

            else if (screen == Screen.StandingUp)
            {
                _spriteBatch.Draw(StandingUpTexture, StandingUpRect, Color.White);
            }
            else if (screen == Screen.Moonwalk)
            {
                _spriteBatch.Draw(MoonwalkBackground, MoonwalkBackgroundRect, Color.White);
                _spriteBatch.Draw(MoonwalkTexture, MoonwalkRect, Color.White);
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(EndTexture, EndRect, Color.White);
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}