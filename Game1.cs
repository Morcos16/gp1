using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace gp1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 pos1 = Vector2.Zero;
        //Logo logo;
        //Logo logotrans;
        private List<Logo> logoList;
        private Random rnd;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D mauTexture = Content.Load<Texture2D>(@"mau_logo");
            Texture2D mauTransTex = Content.Load<Texture2D>(@"mau_logo_trans");

            Vector2 pos1 = Vector2.Zero;

            Vector2 pos2;
            pos2.X = Window.ClientBounds.Width / 2 - mauTransTex.Width / 2;
            pos2.Y = Window.ClientBounds.Height / 2 - mauTransTex.Height / 2;

            int stopX = Window.ClientBounds.Width - mauTexture.Width;
            int stopY = Window.ClientBounds.Height - mauTexture.Height;

            rnd = new Random();

            logoList = new List<Logo>();

            for (int i = 0; i < 10; i++)
            {
                int randX = rnd.Next(0, stopX);
                int randY = rnd.Next(0, stopY);
                Vector2 pos = new Vector2(randX, randY);
                Logo templogo = new Logo(mauTransTex, pos, stopX, stopY);
                logoList.Add(templogo);
            }

            //logo = new Logo(mauTexture, pos1, stopX, stopY);
            //logotrans = new Logo(mauTransTex, pos2, stopX, stopY);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Logo logo in logoList) 
            {
                logo.Update();
            }
            // TODO: Add your update logic here
            //logo.Update();
            //logotrans.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (Logo logo in logoList) 
            {
                logo.Draw(_spriteBatch);
            }

            //logo.Draw(_spriteBatch);
            //logotrans.Draw(_spriteBatch);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
