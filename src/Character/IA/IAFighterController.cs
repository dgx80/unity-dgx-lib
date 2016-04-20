//
// IAController.cs
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
using UnityEngine;
using DGX.Character.Action;

namespace DGX.Character.IA
{
    public class IAFighterController : ScriptableObject
    {
        private Character.Fighter mFighter;
        public Fighter player;
        private IAStateMachine mIAStateMachine;
        
        protected override void init ()
        {
            base.init ();
            mFighter = GetComponent<Character.Fighter>();
            mFighter.OPPONENT = player.gameObject;
            mIAStateMachine = new IAStateMachine(mFighter);
        }
        // Update is called once per frame
        void Update () 
        {
            //TODO
            //encapsuler ce code dans la state machine
            mIAStateMachine.handleUpdate();
            /*if (!m_fighter.inRange()) {
                switch (m_fighter.CHARACTER_STATE)
                {
                case FighterStateMachine.eCharacterState.idle:
                    m_fighter.goToOpponent();
                    break;
                }
            } else {
                switch (m_fighter.CHARACTER_STATE)
                {
                case FighterStateMachine.eCharacterState.run:
                case FighterStateMachine.eCharacterState.walk:
                    m_fighter.onIdle();
                    break;
                }
            }*/
        }
        void OnMouseOver()
        {
            player.GetComponent<Fighter> ().OPPONENT = gameObject;
        }
    }
}

