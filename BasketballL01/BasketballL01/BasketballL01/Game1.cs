using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BasketballL01
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        GraphicsDeviceManager graphics;
        private int MAX_X_BALL;
        private int MAX_Y_BALL;
        SpriteBatch spriteBatch;
        private Texture2D ballSprite;
        private Texture2D paddleSprite;
        private Vector2 ballPosition = Vector2.Zero;
        private Vector2 paddlePosition = Vector2.Zero;
        private Vector2 ballSpeed = new Vector2(150,150);
        private Vector2 paddleSpeed = new Vector2(250, 0);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            MAX_X_BALL = GraphicsDevice.Viewport.Width - ballSprite.Width;
            MAX_Y_BALL = GraphicsDevice.Viewport.Height - ballSprite.Height;
            paddlePosition = new Vector2(GraphicsDevice.Viewport.Width/2 - paddleSprite.Width / 2, GraphicsDevice.Viewport.Height - paddleSprite.Height);
            IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ballSprite = Content.Load<Texture2D>("basketball");
            paddleSprite = Content.Load<Texture2D>("hand");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Right))
            {
                paddlePosition.X += paddleSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (key.IsKeyDown(Keys.Left))
            {
                paddlePosition.X -= paddleSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (ballPosition.X > MAX_X_BALL || ballPosition.X < 0)
            {
                ballSpeed.X *= -1;
            }
            if (ballPosition.Y > MAX_Y_BALL || ballPosition.Y < 0)
            {
                ballSpeed.Y *= -1;
            }


            ballPosition += (ballSpeed * (float) gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(ballSprite, ballPosition, Color.White);
            spriteBatch.Draw(paddleSprite, paddlePosition, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
