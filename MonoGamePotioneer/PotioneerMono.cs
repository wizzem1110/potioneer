using Microsoft.VisualBasic.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGamePotioneer.Entities;
using MonoGameWindowsDesktopApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;

namespace MonoGameWindowsDesktopApplication1;

public class PotioneerMono : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont _font;

    private Entity Player;
    private IList<Entity> Walls;

    public PotioneerMono()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        var width = _graphics.PreferredBackBufferWidth;
        var height = _graphics.PreferredBackBufferHeight;

        var rnd = new Random();

        this.Walls = new List<Entity>()
        {
            new Entity(new Vector2((float)rnd.NextDouble() * width, (float)rnd.NextDouble() * height)),
            new Entity(new Vector2((float)rnd.NextDouble() * width, (float)rnd.NextDouble() * height)),
            new Entity(new Vector2((float)rnd.NextDouble() * width, (float)rnd.NextDouble() * height)),
            new Entity(new Vector2((float)rnd.NextDouble() * width, (float)rnd.NextDouble() * height))
        };

        this.Player = new Entity(new Vector2(width / 2, height / 2), 500f);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        foreach (Entity entity in this.Walls)
        {
            Texture2D texture = Content.Load<Texture2D>("grey_wall_ph");
            entity.AddTexture(texture);
        }

        this.Player.AddTexture(Content.Load<Texture2D>("player_ph"));

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        var keyState = Keyboard.GetState();

        var mover = new EntityController();
        UpdatePlayer(gameTime, keyState);

        base.Update(gameTime);
    }

    private void UpdatePlayer(GameTime gameTime, KeyboardState keyState)
    {
        if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
            this.Player.Position.Y -= this.Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
            this.Player.Position.Y += this.Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
            this.Player.Position.X -= this.Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
            this.Player.Position.X += this.Player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (this.Walls.Any(obj => obj.Collision.Intersects(this.Player.Collision)))
        {
            this.Player.Position.X = 100;
            this.Player.Position.Y = 100;
        }

        if (this.Player.Position.X > _graphics.PreferredBackBufferWidth - this.Player.Texture.Width / 2)
            this.Player.Position.X = _graphics.PreferredBackBufferWidth - this.Player.Texture.Width / 2;
        else if (this.Player.Position.X < this.Player.Texture.Width / 2)
            this.Player.Position.X = this.Player.Texture.Width / 2;

        if (this.Player.Position.Y > _graphics.PreferredBackBufferHeight - this.Player.Texture.Height / 2)
            this.Player.Position.Y = _graphics.PreferredBackBufferHeight - this.Player.Texture.Height / 2;
        else if (this.Player.Position.Y < this.Player.Texture.Height / 2)
            this.Player.Position.Y = this.Player.Texture.Height / 2;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        foreach (Entity entity in this.Walls)
        {
            DrawEntity(entity);
        }

        DrawEntity(this.Player);

        //_spriteBatch.DrawString(default, this.Player.Texture.Width.ToString(), this.Player.Position, Color.AliceBlue);

        _spriteBatch.End();

        base.Draw(gameTime);
    }

    private void DrawEntity(Entity entity)
    {
        _spriteBatch.Draw(
            entity.Texture,
            entity.Position,
            null,
            Color.White,
            0f,
            new Vector2(this.Player.Texture.Width / 2, this.Player.Texture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f);
    }
}