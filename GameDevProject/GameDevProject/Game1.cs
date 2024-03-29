﻿using GameDevProject.Classes.Enemies;
using GameDevProject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameDevProject.Classes;
using GameDevProject.Classes.Hero;
using GameDevProject.Classes.LevelDesign;
using GameDevProject.Interfaces;
using GameDevProject.Classes.Factory;
using GameDevProject.Classes.PickUp;
using Microsoft.Xna.Framework.Media;

namespace GameDevProject
{
    /// <summary>
    /// S Hero en Enemies gebruiken SRP om update/attack te regelen.
    /// O wordt gebruikt bij enemies, er kunnen makkelijk nieuwe soorten enemies gemaakt worden zonder de base (abstracte) Enemy class aan te passen
    /// L De enemies gebruiken LSP, ze kunnen op dezelfde manier gebruikt worden door het programma
    /// I
    /// D
    /// </summary>
    public class Game1 : Game
    { 
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;

        private Texture2D _chargerTexture;
        private Texture2D _rangedTexture;
        private Texture2D _arrowTexture;
        private Texture2D _pickupTexture;
        private Texture2D _trapTexture;
        private UnitFactory unitFactory;
        private PickupFactory pickupFactory;

        List<IUnit> unitsLevel1 = new List<IUnit>();
        List<IUnit> unitsLevel2 = new List<IUnit>();

        private Hero hero;

        Map map = new Map();
        Map map2 = new Map();

        private State _currentState;
        private State _nextState;

        Level _lvl1;
        Level _lvl2;
        Level _currentLevel;
        Level _controlLevel;
        Map controlMap = new Map();

        List<Pickup> pickupsLevel1 = new List<Pickup>();
        List<Pickup> pickupsLevel2 = new List<Pickup>();

        Song Nomu;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        protected override void Initialize()
        {
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
            base.Initialize();

            unitFactory = new UnitFactory();
            pickupFactory = new PickupFactory();

            hero = new Hero(_heroTexture, Content.Load<Texture2D>("Projectiles/energy_ball"));

            unitsLevel1.Add(unitFactory.CreateUnit("CHARGER", 500, 0, _chargerTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("RANGED", 650, 385, _rangedTexture, _arrowTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("CHARGER", 350, 675, _chargerTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("CHARGER", 1100, 825, _chargerTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("TRAP", 902, 1025, _trapTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("TRAP",1803,100,_trapTexture));

            unitsLevel2.Add(unitFactory.CreateUnit("TRAP",70,915,_trapTexture));

            pickupsLevel1.Add(pickupFactory.CreatePickUp("COIN", 400, 25, _pickupTexture));
            pickupsLevel1.Add(pickupFactory.CreatePickUp("COIN", 1075, 25, _pickupTexture));
            pickupsLevel1.Add(pickupFactory.CreatePickUp("COIN", 800, 100, _pickupTexture));
            pickupsLevel1.Add(pickupFactory.CreatePickUp("COIN", 200, 500, _pickupTexture));
            pickupsLevel1.Add(pickupFactory.CreatePickUp("COIN", 1600, 500, _pickupTexture));

            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 1150, 100, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 1825, 325, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 150, 325, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 1825, 775, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 400, 625, _pickupTexture));

            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 700, 775, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 175, 700, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 500, 175, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 700, 625, _pickupTexture));
            pickupsLevel2.Add(pickupFactory.CreatePickUp("COIN", 1500, 625, _pickupTexture));

            _lvl1 = new Level(map, unitsLevel1, pickupsLevel1);
            _lvl2 = new Level(map2, unitsLevel2, pickupsLevel2);
            _controlLevel = new Level(controlMap, new List<IUnit>(), new List<Pickup>());
            _currentLevel = _controlLevel;
        }
        protected override void LoadContent()
        {
            Tiles.Content = Content;

            map.Generate(new int[,]
            {
                {25,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19},
                {26,0,0,0,0,17,18,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,19},
                {27,0,0,17,1,16,12,1,2,3,4,5,6,4,12,13,14,11,10,7,8,9,0,0,17,20},
                {12,2,3,16,20,20,21,0,23,20,20,20,20,21,0,0,0,0,0,0,0,0,0,0,19,20},
                {20,20,21,0,0,25,0,0,0,0,23,20,21,0,0,0,0,0,0,0,0,0,24,28,29,20},
                {20,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24,28,29,28,21,0,24,20},
                {25,0,0,0,0,0,0,30,0,0,0,0,0,0,0,0,24,28,21,0,0,0,0,0,23,20},
                {26,0,0,0,24,28,29,28,29,24,28,29,28,29,28,29,28,21,0,0,0,0,0,0,0,25},
                {27,0,0,24,21,0,0,0,0,0,0,24,28,29,24,28,22,0,0,0,24,28,29,22,0,26},
                {31,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24,28,29,28,29,0,27},
                {31,28,29,31,22,0,0,0,0,24,28,29,28,29,28,29,28,29,28,29,28,29,28,21,0,25},
                {31,28,29,31,28,29,28,31,28,28,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26},
                {31,22,50,0,0,0,0,0,0,0,0,0,0,24,22,0,0,0,0,24,28,29,22,0,0,27},
                {28,29,28,29,28,31,29,28,29,30,31,24,0,24,28,29,28,29,28,29,28,29,28,29,28,29},
                {20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
            }, 75);
            map2.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,17,20,20},
                {18,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19,20,20},
                {12,0,0,0,0,0,0,0,0,0,0,0,0,17,1,2,3,18,0,0,0,0,0,19,20,20},
                {20,2,3,1,2,3,1,2,3,1,2,3,1,16,0,0,0,12,7,8,9,0,0,23,20,20},
                {22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24},
                {29,28,29,28,29,25,0,0,0,0,0,17,1,2,3,18,0,0,0,0,0,17,2,3,1,1},
                {25,0,0,0,0,26,25,0,1,2,3,21,0,0,0,23,1,2,3,1,2,21,0,0,0,24},
                {26,0,0,0,0,0,26,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24},
                {27,0,0,0,0,0,27,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,0,24},
                {25,0,0,0,0,1,26,1,2,3,1,2,3,20,1,2,3,20,1,2,3,1,21,0,0,24},
                {26,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24},
                {27,0,0,0,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,1,2,3,20},
                {27,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,50,24},
                {28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29,28,29},
                {20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
            }, 75);
            controlMap.Generate(new int[,]
            {
                {0,0,1,0,0,0,0,0,1,1},
                {1,1,1,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,1},
                {1,1,2,2,2,2,2,2,2,1},
            }, 200);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, GraphicsDevice, Content);

            _heroTexture = Content.Load<Texture2D>("PlayerCharacter/PlayerSpriteSheet");//"CharacterSheetExample");
            _rangedTexture = Content.Load<Texture2D>("Enemies/Ranged/spritesheet");
            _chargerTexture = Content.Load<Texture2D>("Enemies/Charger/_Run");
            _trapTexture = Content.Load<Texture2D>("Enemies/Trap/Spike");
            _arrowTexture = Content.Load<Texture2D>("Projectiles/arrow");
            _pickupTexture = Content.Load<Texture2D>("Pickups/PickUps");

            Nomu = Content.Load<Song>("Music/Good Kid - Nomu 8-bit");
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.Play(Nomu);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            hero.Update(gameTime);
            _currentState.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Add))
            {
                MediaPlayer.Volume += 0.025f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Subtract))
            {
                MediaPlayer.Volume -= 0.025f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.M))
            {
                MediaPlayer.Volume = 0;
            }

            foreach (var tile in _currentLevel.Map.CollisionTiles)
            {
                hero.Collision(tile.DestinationRectangle);
                foreach (var enemy in unitsLevel1)
                {
                    enemy.Collision(tile.DestinationRectangle);
                }
            }
            foreach (var tile in _currentLevel.Map.FinishTiles)
            {
                if (hero.HitBox.TouchRightOf(tile.DestinationRectangle) || hero.HitBox.TouchLeftOf(tile.DestinationRectangle))
                {
                    if (_currentLevel == _lvl2)
                    {
                        _currentState = new EndState(this, GraphicsDevice, Content);
                    }
                    else
                    {
                        _currentLevel = _lvl2;
                        hero.Position = hero.SpawnPosition;
                    }
                }
            }
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }
            for (int i = _currentLevel.Units.Count - 1; i >= 0; i--)
            {
                if (_currentLevel.Units[i] is Enemy)
                {
                    Enemy enemy = _currentLevel.Units[i] as Enemy;

                    enemy.Update(gameTime);
                    for (int j = hero.Projectiles.Count - 1; j >= 0; j--)
                    {
                        if (hero.Projectiles[j].HitBox.Intersects(/*units[i]*/enemy.HitBox))
                        {
                            enemy.Health--;
                            hero.Projectiles.RemoveAt(j);
                        }
                        if (enemy.Health == 0)
                        {
                            _currentLevel.Units.RemoveAt(i);
                        }
                    }
                }
            }
            for (int i = _currentLevel.Pickups.Count - 1; i >= 0; i--)
            {
                _currentLevel.Pickups[i].Update(gameTime);
                if (_currentLevel.Pickups[i].HitBox.Intersects(hero.HitBox))
                {
                    hero.Score++;
                    _currentLevel.Pickups.RemoveAt(i);
                }
            }
            if (hero.Score == 15)
            {
                _currentState = new EndState(this, GraphicsDevice, Content);
            }

            foreach (var unit in _currentLevel.Units)
            {
                if (hero.HitBox.Intersects(unit.HitBox))
                {
                    hero.TakeDamage(gameTime);
                    if (hero.Health <= 0)
                    {
                        _currentState = new DeathState(this, GraphicsDevice, Content);
                    }
                }
                if (Vector2.Distance(hero.Position, unit.Position) < 450 && _currentState is GameState && hero.Position.Y - unit.Position.Y > 25)
                {
                    if (unit is Enemy)
                    {
                        (unit as Enemy).Attack(gameTime);
                    }
                }
                if (unit is IRangedAttacker)
                {
                    foreach (var projectile in (unit as RangedEnemy).Projectiles)
                    {
                        if (hero.HitBox.Intersects(projectile.HitBox) && hero.Attackable)
                        {
                            hero.TakeDamage(gameTime);
                            if (hero.Health <= 0)
                            {
                                _currentState = new DeathState(this, GraphicsDevice, Content);
                            }
                        }
                    }
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);
            _spriteBatch.Begin();
            switch (_currentState)
            {
                case MenuState:
                    _currentState.Draw(gameTime, _spriteBatch);
                    break;
                case LevelSelectState:
                    _currentState.Draw(gameTime, _spriteBatch);
                    break;
                case LevelOneState:
                    _currentState = new GameState(this, GraphicsDevice, Content);
                    _currentLevel = _lvl1;
                    break;
                case LevelTwoState:
                    MediaPlayer.IsRepeating = true;
                    _currentState = new GameState(this, GraphicsDevice, Content);
                    _currentLevel = _lvl2;
                    break;
                case GameState:
                    
                    if (_currentLevel == _lvl1)
                    {
                        _spriteBatch.Draw(Content.Load<Texture2D>("Backgrounds/backgroundLevelOne"), new Vector2(0, 0), new Rectangle(0, 0, 1024, 576), Color.White, 0, new Vector2(0, 0), 1.875f, SpriteEffects.None, 0);
                        _lvl1.Draw(_spriteBatch);
                    }
                    if (_currentLevel == _lvl2)
                    {
                        _spriteBatch.Draw(Content.Load<Texture2D>("Backgrounds/backgroundLevelOne"), new Vector2(0, 0), new Rectangle(0, 0, 1024, 576), Color.White, 0, new Vector2(0, 0), 1.875f, SpriteEffects.FlipHorizontally, 0);
                        _lvl2.Draw(_spriteBatch);
                    }
                    hero.Draw(_spriteBatch);
                    _currentState.Draw(gameTime, _spriteBatch);
                    _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts/Font"), "Score: " + hero.Score, new Vector2(25, 25), Color.Red);

                    foreach (var projectile in hero.Projectiles)
                    {
                        projectile.Draw(_spriteBatch, 0.1f);
                    }
                    break;
                case DeathState:
                    GraphicsDevice.Clear(Color.Black);
                    _currentState.Draw(gameTime, _spriteBatch);
                    break;
                case EndState:
                    GraphicsDevice.Clear(Color.Black);
                    _currentState.Draw(gameTime, _spriteBatch);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}