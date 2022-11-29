using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Net.Mime;

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
            Start
        }
        float seconds;
        float startTime;
        Song MJMusic;
        Texture2D StartTexture;
        Texture2D LeanStartTexture;
        Texture2D LeanMiddleTexture;
        Texture2D LeanLowTexture;
        Texture2D LeanMiddleAgainTexture;
        Texture2D StandingUpTexture;
        Texture2D IntroTexture;
        Rectangle StartRect;
        Rectangle IntroRect;
        Rectangle LeanStartRect;
        Rectangle LeanMiddleRect;
        Rectangle LeanLowRect;
        Rectangle LeanMiddleAgainRect;
        Rectangle StandingUpRect;
        Screen screen;
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
            TitleFont = Content.Load<SpriteFont>("Title");
            //Song MJMusic = Content.Load<Song>("Smooth Criminal");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            seconds = (float)gameTime.TotalGameTime.TotalSeconds - startTime;

            if (seconds > 0)
                screen = Screen.Start;
               if (seconds > 5)
                screen = Screen.LeanStart;
               if (seconds > 6)
                    screen = Screen.LeanMiddle;
                if (seconds > 7)
                screen = Screen.LeanLow;
                if (seconds > 8)
                screen = Screen.LeanMiddleAgain;
                if (seconds > 9)
                    screen = Screen.StandingUp;

            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            
            if (screen == Screen.Start)
            {
                //MediaPlayer.Play(MJMusic);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}