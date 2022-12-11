using GameDevProject.Classes.Enemies;
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
        List<IUnit> unitsLevel1 = new List<IUnit>();
        List<IUnit> unitsLevel2 = new List<IUnit>();
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

        Texture2D backgroundtest;
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
            unitsLevel1.Add(unitFactory.CreateUnit("CHARGER", 500, 0/*1300, 400*/, _chargerTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("RANGED", 650, 385, _rangedTexture, _arrowTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("RANGED", 350, 680, _rangedTexture, _arrowTexture));
            unitsLevel1.Add(unitFactory.CreateUnit("CHARGER", 1100, 825, _chargerTexture));
            _lvl1 = new Level(map, unitsLevel1);
            _lvl2 = new Level(map2, new List<IUnit>());
            _controlLevel = new Level(controlMap, new List<IUnit>());
            _currentLevel = _controlLevel;// _lvl1;
        }
        // TODO SPAWNPOINT HERO AANPASSEN ZODAT MOVEMENT GEBLOKEERD KAN WORDEN IN TUSSENLEVEL
        protected override void LoadContent()
        {
            // blokTexture = new Texture2D(GraphicsDevice, 1, 1);
            Tiles.Content = Content;
            /*map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,1,1},
                {0,1,0,0,0,1,0,0,0,1},
                {0,0,0,1,2,2,2,0,0,1},
                {0,0,1,2,2,2,2,2,1,1},
                {1,1,2,2,2,2,2,2,2,1},
            }, 200);*/
            /*map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2},
                {0,0,0,0,0,2,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,4},
                {0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,2,1},
                {2,2,2,5,5,1,2,0,3,5,1,1,1,2,0,0,0,0,0,0,0,0,0,0,4,1},
                {2,1,2,0,0,2,0,0,0,0,3,5,2,0,0,0,0,0,0,0,0,0,2,2,1,1},
                {2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,4,1},
                {2,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,2,2,2,0,0,0,0,0,3,2},
                {2,0,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,0,4},
                {2,0,0,3,5,2,0,0,0,0,0,3,5,5,5,5,2,0,0,0,2,2,2,2,0,4},
                {2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,1,1,2,0,4},
                {2,1,2,2,2,0,0,0,0,2,2,2,2,2,2,2,2,2,2,5,5,5,5,2,0,4},
                {2,1,5,5,5,2,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4},
                {2,2,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,2,2,2,2,0,0,4},
                {2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
            }, 75);*/
            map.Generate(new int[,]
            {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,19},
                {0,0,0,0,0,17,18,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,19},
                {0,0,0,17,1,16,12,1,2,3,4,5,6,4,12,13,14,11,10,7,8,9,0,0,17,20},
                {1,2,3,16,20,20,21,0,23,20,20,20,20,21,0,0,0,0,0,0,0,0,0,0,19,20},
                {20,20,21,0,0,25,0,0,0,0,23,20,21,0,0,0,0,0,0,0,0,0,24,28,29,20},
                {20,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24,28,29,28,21,0,24,20},
                {25,0,0,0,0,0,0,30,0,0,0,0,0,0,0,0,24,28,21,0,0,0,0,0,23,20},
                {26,0,0,0,24,28,29,28,29,24,28,29,28,29,28,29,28,21,0,0,0,0,0,0,0,25},
                {27,0,0,24,21,0,0,0,0,0,0,24,28,29,24,28,22,0,0,0,24,28,29,22,0,26},
                {31,22,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,24,28,29,28,29,0,27},
                {31,28,29,31,22,0,0,0,0,24,28,29,28,29,28,29,28,29,28,29,28,29,28,21,0,25},
                {31,28,29,31,28,29,28,31,28,28,21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,26},
                {31,22,0,0,0,0,0,0,0,0,0,0,0,24,22,0,0,0,0,24,28,29,22,0,0,27},
                {28,29,28,29,28,31,29,28,29,30,31,24,0,24,28,29,28,29,28,29,28,29,28,29,28,29},
                {20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20,20},
            }, 75);
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
                if (unitsLevel1[i] is Enemy)
                {
                    Enemy enemy = unitsLevel1[i] as Enemy;

                    /*units[i]*/
                    enemy.Update(gameTime);
                    //enemies[i].UpdateProjectiles();
                    for (int j = hero.Projectiles.Count - 1; j >= 0; j--)
                    {
                        if (hero.Projectiles[j].HitBox.Intersects(/*units[i]*/enemy.HitBox))
                        {
                            /*units[i]*/
                            enemy.Health--;
                            hero.Projectiles.RemoveAt(j);
                        }
                        if (/*units[i]*/enemy.Health == 0)
                        {
                            unitsLevel1.RemoveAt(i);
                        }
                    }
                }
            }
            foreach (var tile in _currentLevel.Map.CollisionTiles)
            {
                hero.Collision(tile.DestinationRectangle);
                foreach (var enemy in unitsLevel1)
                {
                    enemy.Collision(tile.DestinationRectangle);
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
                        _currentState = new DeathState(this, GraphicsDevice, Content);//Exit(); // TODO deathscreen maken
                    }
                }
                if (Vector2.Distance(hero.Position, unit.Position) < 450 && _currentState is GameState && hero.Position.Y - unit.Position.Y > 25)
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

                    /*foreach (var enemy in _currentLevel.Units)
                    {
                        _spriteBatch.Draw(Content.Load<Texture2D>("Projectile"), enemy.HitBox, Color.Red);
                    }*/
                    if (_currentLevel == _lvl1)
                    {
                        _spriteBatch.Draw(Content.Load<Texture2D>("Backgrounds/backgroundLevelOne"),new Vector2(0,0),new Rectangle(0,0,1024,576),Color.White,0,new Vector2(0,0),1.875f,SpriteEffects.None,0);
                        _lvl1.Draw(_spriteBatch);
                    }
                    else if (_currentLevel == _lvl2)
                    {
                        _lvl2.Draw(_spriteBatch);
                    }
                    //_spriteBatch.Draw(Content.Load<Texture2D>("Projectile"), hero.HitBox, Color.Red);
                    hero.Draw(_spriteBatch);

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