﻿using System.Collections.Generic;
using Galaga.Entity;

#nullable enable

namespace Galaga.Game {
    public interface IGame {
        public World GetWorld();

        public Player GetPlayer();

        // 플레이어가 게임을 클리어 했는지 여부
        public bool IsCleared();

        // 플레이어가 패배했는지 여부를 반환
        public bool IsOver();

        public void OnTick(int currentTick);
    }

    public abstract class BaseGame : IGame {
        private readonly World _world;
        private readonly Player _player;

        protected BaseGame(World world) {
            this._world = world;

            _player = new Player(world);
            world.EntityManager.AddEntity(_player);
        }

        public abstract bool IsCleared();

        public abstract bool IsOver();

        public World GetWorld() {
            return _world;
        }

        public Player GetPlayer() {
            return _player;
        }

        public void OnTick(int currentTick) {
            _world.OnTick(currentTick);
        }
    }

    internal class Stage1Game : BaseGame {
        public Stage1Game() : base(new World(new EntitySpawner())) {
            
        }

        public override bool IsCleared() {
            return false;
        }

        public override bool IsOver() {
            return false;
        }

        // Stage 1의 엔티티 소환을 관리
        private class EntitySpawner : IEntitySpawner {
            public IEnumerable<Entity.Entity> GetSpawnEntities(int currentTick) {
                return new Entity.Entity[0];
            }
        }
    }
}
