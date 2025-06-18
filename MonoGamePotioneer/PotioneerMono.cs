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
    private Character Player;
    private IList<Entity> Walls = new List<Entity>();
    private IList<Projectile> Projectiles = new List<Projectile>();

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
        GenerateWalls(4, width, height, rnd);

        this.Player = new Character(new Vector2(100, 100), 500f);

        base.Initialize();
    }

    private void GenerateWalls(int amount, int width, int height, Random rnd)
    {
        this.Walls = new List<Entity>();
        for (var i = 0; i < amount; i++)
        {
            this.Walls.Add(
                new Entity(
                    new Vector2(
                        GetRandomWallPosition() * width,
                        GetRandomWallPosition() * height)));
        }
        ;

        float GetRandomWallPosition()
        {
            return (float)(rnd.NextDouble() + 1)/2;
        }
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

        UpdatePlayer(gameTime, keyState);

        if (keyState.IsKeyDown(Keys.M))
        {
            var projectile = new Projectile(this.Player.Position, 2000f, default);
            projectile.AddTexture(Content.Load<Texture2D>("wall_ph"));
            this.Projectiles.Add(projectile);     
        }

        base.Update(gameTime);
    }

    private void UpdatePlayer(GameTime gameTime, KeyboardState keyState)
    {
        float timeElapsedSeconds = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.Up))
        {
            this.Player.Move(timeElapsedSeconds, Direction.Up);
        }

        if (keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.Down))
        {
            this.Player.Move(timeElapsedSeconds, Direction.Down);
        }

        if (keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.Left))
        {
            this.Player.Move(timeElapsedSeconds, Direction.Left);
        }

        if (keyState.IsKeyDown(Keys.D) || keyState.IsKeyDown(Keys.Right))
        {
            this.Player.Move(timeElapsedSeconds, Direction.Right);
        }

        this.Player.UpdateCollision();

        foreach (var projectile in Projectiles)
        {
            projectile.Move(timeElapsedSeconds);
            projectile.UpdateCollision();
        }

        if (CheckCollision())
            {
                this.Player.Position.X = 0;
                this.Player.Position.Y = 0;
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

    private bool CheckCollision()
    {
        foreach (var wall in this.Walls)
        {
            if (wall.Collision.Intersects(this.Player.Collision))
            {
                return true;
            }
        }

        return this.Walls.Any(obj => obj.Collision.Intersects(this.Player.Collision));
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