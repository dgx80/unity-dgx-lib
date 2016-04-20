//
// ActionMoving.cs
//
// Author:
//       Jean-Pierre Bouchard <>
//
// Copyright (c) 2015 Jean-Pierre Bouchard
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DGX.Character.Anim;
using UnityEngine;

namespace DGX.Character.Action
{
    public class ActionMoving : DGX.Action.ActionBase
    {
        private MoveableAnimation mMoveableAnimation;
        private Vector3 mTargetPoint;
        private Transform mTransform;
        private CharacterController mCharacterController;
        private float mSpeed = 10;
        Quaternion mNewRotation;
        
        public ActionMoving (int id, MoveableAnimation moveableAnimation, Transform transform, CharacterController characterController, float speed)
            : base (id, false)
        {
            mMoveableAnimation = moveableAnimation;
            mTransform = transform;
            mCharacterController = characterController;
            mSpeed = speed;
        }
        protected override void handleInit ()
        {
            base.handleInit ();
            mNewRotation = Quaternion.LookRotation (mTargetPoint - mTransform.position, Vector3.forward);
            mNewRotation.x = 0f;
            mNewRotation.z = 0f;
            mTransform.transform.LookAt (mTargetPoint);
        }
        protected override void handleRun ()
        {
            base.handleRun ();
            float distance = Vector3.Distance (mTransform.position, VECTOR_TARGET);
            //LOGGER.logTag ("distance", distance);
            if (distance <= 0.7f) {
                LOGGER.logTag("distance", distance);
                Stop();
            }
            
            Quaternion newRotation = Quaternion.LookRotation (mTargetPoint - mTransform.position, Vector3.forward);
            newRotation.x = 0f;
            newRotation.z = 0f;
            
            mTransform.rotation = Quaternion.Slerp (mTransform.rotation, newRotation, Time.deltaTime * 10);
            mCharacterController.SimpleMove (mTransform.forward * mSpeed);
        }
        
        protected MoveableAnimation MOVEABLE_ANIMATION
        {
            get { return mMoveableAnimation;}
        }
        public Vector3 VECTOR_TARGET { 
            get{ return mTargetPoint;}
            set
            { 
                mTargetPoint = value;
            }
        }
    }
}

