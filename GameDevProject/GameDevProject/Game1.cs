﻿using GameDevProject.Classes.Enemies;
using GameDevProject.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using GameDevProject.Classes;
using GameDevProject.Classes.Enemies;
using GameDevProject.Classes.Hero;
using GameDevProject.Classes.LevelDesign;
using GameDevProject.States;
using GameDevProject.Interfaces;
using GameDevProject.Classes.Factory;

namespace GameDevProject
{
    public class Game1 : Game
    {
        //TODO HEAVY REFACTORING
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _heroTexture;
        private Texture2D _enemyTexture;
        private Texture2D _chargerTexture;
        private Texture2D _rangedTexture;
        private Texture2D _arrowTexture;
        private UnitFactory unitFactory;
        Texture2D blokTexture;
        List<IUnit> units = new List<IUnit>();
        Color heroColor = Color.White;

        bool attackable = true;
        // *****************
        private Hero hero;
        private ChargerEnemy enemy1;
        private RangedEnemy enemy2;
        //******************
        Map map = new Map();
        Map map2 = new Map();

        private State _currentState;
        private State _nextState;
        // List<Projectile> projectiles = new List<Projectile>();
        KeyboardState pastKey;

        ////////////////////////////////////
        List<Level> levels = new List<Level>();
        Level _lvl1;
        Level _lvl2;
        Level _currentLevel;
        Level _controlLevel;
        Map controlMap = new Map();
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
            // TODO: Add your initialization logic here
            //_graphics.IsFullScreen = true;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();
            base.Initialize();
            unitFactory = new UnitFactory();
            hero = new Hero(_heroTexture, new KeyboardReader(), Content.Load<Texture2D>("Projectiles/energy_ball"));
            //enemy1 = new ChargerEnemy(_chargerTexture, 1300, 405);//, Content.Load<Texture2D>("Projectiles/energy_ball"));
            //enemy2 = new RangedEnemy(_rangedTexture, 1400, 465, Content.Load<Texture2D>("Projectiles/arrow"));
            //this.units.Add(enemy1);
            //this.units.Add(enemy2);
            //this.units.Add(unitFactory.CreateUnit("CHARGER", 1300, 405, _chargerTexture));
            this.units.Add(unitFactory.CreateUnit("RANGED", 1400, 465, _rangedTexture, _arrowTexture));
            _lvl1 = new Level(map, this.units);
            _lvl2 = new Level(map2, new List<IUnit>());
            _controlLevel = new Level(controlMap, new List<IUnit>());
            _currentLevel = _controlLevel;// _lvl1;
        }
        // TODO SPAWNPOINT HERO AANPASSEN ZODAT MOVEMENT GEBLOKEERD KAN WORDEN IN TUSSENLEVEL
        protected override void LoadContent()
        {
            blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            Tiles.Content = Content;
            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,1,1},
                {0,1,0,0,0,1,0,0,0,1},
                {0,0,0,1,2,2,2,0,0,1},
                {0,0,1,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,1},
            }, 200);
            map2.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,1,1},
                {0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,1},
                {1,1,2,2,2,2,2,2,2,1},
            }, 200);
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
            // TODO: use this.Content to load your game content here
            _heroTexture = Content.Load<Texture2D>("PlayerCharacter/PlayerSpriteSheet");//"CharacterSheetExample");
            _rangedTexture = Content.Load<Texture2D>("Enemies/Ranged/spritesheet");
            _chargerTexture = Content.Load<Texture2D>("Enemies/Charger/_Run");
            _arrowTexture = Content.Load<Texture2D>("Projectiles/arrow");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            hero.Update(gameTime);

            _currentState.Update(gameTime);
            for (int i = _currentLevel.Units.Count - 1; i >= 0; i--)
            {
                if (units[i] is Enemy)
                {
                    Enemy enemy = units[i] as Enemy;
                
                /*units[i]*/enemy.Update(gameTime);
                    //enemies[i].UpdateProjectiles();
                    for (int j = hero.Projectiles.Count - 1; j >= 0; j--)
                    {
                        if (hero.Projectiles[j].HitBox.Intersects(/*units[i]*/enemy.HitBox))
                        {
                            /*units[i]*/enemy.Health--;
                            hero.Projectiles.RemoveAt(j);
                        }
                        if (/*units[i]*/enemy.Health == 0)
                        {
                            units.RemoveAt(i);
                        }
                    }
                }
            }
            foreach (var tile in _currentLevel.Map.CollisionTiles)
            {
                hero.Collision(tile.Rectangle);
                foreach (var enemy in units)
                {
                    enemy.Collision(tile.Rectangle);
                }
            }
            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            /*if (Keyboard.GetState().IsKeyDown(Keys.U)*//*&&pastKey.IsKeyUp(Keys.U)*//*)
            {
                hero.Shoot(hero.ProjectileSprite);//Content.Load<Texture2D>("Projectiles/energy_ball"));
            }*/

            pastKey = Keyboard.GetState();
            //hero.UpdateProjectiles();

            foreach (var unit in _currentLevel.Units)
            { 
                if (hero.HitBox.Intersects(unit.HitBox))
                {
                    hero.TakeDamage();
                    //hero.Position = hero.KnockbackPosition;
                    if (hero.Health <= 0)
                    {
                        _currentState = new DeathState(this,GraphicsDevice,Content);//Exit(); // TODO deathscreen maken
                    }
                }
                if (Vector2.Distance(hero.Position, unit.Position) < 500 && _currentState is GameState)
                {
                    if (unit is RangedEnemy)
                    {
                        RangedEnemy ranged = unit as RangedEnemy;
                        ranged.enemyAttack.Shoot(ranged.ProjectileSprite);
                    }
                    if (unit is ChargerEnemy)
                    {
                        ChargerEnemy charger = unit as ChargerEnemy;
                        charger.chargerAttack.Attack(gameTime);
                    }
                    //enemy.IsAttacking = true;
                }
                if (unit is RangedEnemy)
                {
                    foreach (var projectile in (unit as RangedEnemy).Projectiles)
                    {
                        if (hero.HitBox.Intersects(projectile.HitBox))
                        {
                            hero.TakeDamage();
                            hero.Position = hero.KnockbackPosition;
                            if (hero.Health <= 0)
                            {
                                Exit(); // TODO deathscreen maken
                            }
                        }
                    }
                }

            }
            /*foreach (var projectile in enemy.Projectiles)
            {
                if (hero.HitBox.Intersects(projectile.HitBox))
                {
                    hero.TakeDamage();
                    hero.Position = hero.KnockbackPosition;
                    if (hero.Health <= 0)
                    {
                        Exit(); // TODO deathscreen maken
                    }
                }
            }*/


            /*    hero.IsSpotted = true;
                //enemy.IsPatrolling = false;
            }
            else
            {
                hero.IsSpotted = false;
                enemy.IsPatrolling = true;
            }
            if (hero.IsSpotted)
            {
                //enemy.IsPatrolling = false;
                enemy.Charge();
                //enemy.Shoot();*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // TODO: Add your drawing code here
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
                    _currentState = new GameState(this, GraphicsDevice, Content);
                    _currentLevel = _lvl2;
                    break;
                case GameState:
                    // _spriteBatch.Draw(Content.Load<Texture2D>("Projectile"), hero.HitBox, Color.Red);
                    hero.Draw(_spriteBatch);
                    /* foreach (var enemy in _currentLevel.enemies)
                     {
                         _spriteBatch.Draw(Content.Load<Texture2D>("Projectile"), enemy.HitBox, Color.Red);
                     }*/
                    if (_currentLevel == _lvl1)
                    {
                        _lvl1.Draw(_spriteBatch);
                    }
                    else if (_currentLevel == _lvl2)
                    {
                        _lvl2.Draw(_spriteBatch);
                    }
                    _currentState.Draw(gameTime, _spriteBatch);

                    /*map.Draw(_spriteBatch);
                    
                    //_spriteBatch.Draw(Content.Load<Texture2D>("Projectile"), enemy.HitBox, Color.Red);
                    
                    foreach (var enemy in enemies)
                    {
                        enemy.Draw(_spriteBatch);
                        if (enemy.Health > 0)
                        {
                            foreach (var projectile in enemy.Projectiles)
                            {
                                projectile.Draw(_spriteBatch, 0.1f);
                            }
                        }     
                    }*/
                    foreach (var projectile in hero.Projectiles)
                    {
                        projectile.Draw(_spriteBatch, 0.1f);
                    }
                    break;
                case DeathState:
                    _currentState.Draw(gameTime, _spriteBatch);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}