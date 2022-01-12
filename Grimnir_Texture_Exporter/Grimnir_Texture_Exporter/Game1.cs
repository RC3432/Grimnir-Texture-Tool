using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System.IO;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Grimnir_Texture_Exporter
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
           /* String line;
            try
            {
               
            }
            catch (Exception e)
            {
               
            }
            finally
            {
                
            }
            */ //scrapped
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }
        
        Texture2D readfile;
        DisplayMode disp;
        Texture2D texture2D;
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            readfile = Content.Load<Texture2D>("texture");
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }
        bool called = false;
        protected override void Update(GameTime gameTime)
        {

            if (called == false)
            {
                readfile.Save("texture_release.tga", ImageFileFormat.Tga);
                readfile.Save("texture_release.jpg", ImageFileFormat.Jpg);
                readfile.Save("texture_release.png", ImageFileFormat.Png);
               
                called = true;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            base.Update(gameTime);
        }
        bool dontexplodestuff = false;
        protected override void Draw(GameTime gameTime)
        {
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            if (dontexplodestuff == false)
            {

                graphics.ApplyChanges();
                dontexplodestuff = true;

            }
            Color BG = new Color(0.5f, 0.5f, 0.5f);
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(readfile, new Vector2(450, 240), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
