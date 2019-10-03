﻿using UnityEngine;
using UnityEngine.Serialization;

namespace Bullet
{
    public abstract class AbstractBullet : MonoBehaviour
    {
        //攻击伤害
        public int BulletAtkDamage;
        //水平或垂直的最大移动速度
        public float MaxMoveSpeedXy;
        //子弹实际移动的方向
        public Vector2 BulletMoveDir;
        //子弹实际移动的速度（带方向，它等于speed * dir，但有可能在其他子弹的设计中，改变这个最简单的计算方式）
        [FormerlySerializedAs("BulletMoveVelocity")] public Vector2 BulletDeltaMovement;


        public LayerMask MirrorLayerMask;
        public LayerMask PlayerLayerMask;
        public LayerMask ZombieLayerMask;
        public LayerMask BossLayerMask;
        public LayerMask WallLayerMask;

        public virtual void Start()
        {
        }
    
        public virtual void Update()
        {
            CalculateBulletVelocity();
            Move();
        }
    
        /// <summary>
        /// 子弹的移动
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// 子弹速度的计算
        /// </summary>
        public abstract void CalculateBulletVelocity();
    
        //碰撞事件
        public abstract void OnTriggerEnter2D(Collider2D hitTarget);

        public abstract void Die();

    }
}
