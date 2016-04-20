//
// GuardStateMachine.cs
//
// Author:
//       Razan <>
//
// Copyright (c) 2015 Razan
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
namespace DGX.Character.Action.Guard
{
    public class IAGuardStateMachine : DGX.Action.StateMachine
    {
        #region DECLARATION
        
        public enum eState
        {
            watching = 0,
            chase,
            attack
        }
        #endregion
        #region ATTRIBUTES
        private ActionGuardWatching mActionGuardWatching;
        private ActionChase mActionChase;
        private ActionAttack mActionAttack;
        
        #endregion
        
        #region CONSTRUCTOR
        
        public IAGuardStateMachine (Fighter fighter)
            : base()
        {
            //construct
            mActionGuardWatching = new ActionGuardWatching((int)eState.watching, fighter);
            mActionChase = new ActionChase((int)eState.chase, fighter);
            mActionAttack = new ActionAttack((int)eState.attack, fighter);
            //Add
            addAction(mActionGuardWatching);
            addAction(mActionChase);
            addAction(mActionAttack);
            
            //Trigger
            mActionGuardWatching.addTrigger((int)ActionGuardWatching.eTrigger.found, mActionChase);
            mActionChase.addTrigger((int)ActionChase.eTrigger.reached, mActionAttack);
            mActionAttack.addTrigger((int)ActionAttack.eTrigger.hit, mActionAttack);
            
            // m_actionIdle = new ActionIdle ((int)eCharacterState.idle, moveableAnimation);
            //addAction (m_actionIdle);
            
            startNewState (eState.watching);
            //ACTION_DEFAULT = m_actionIdle;
        }
        #endregion
        
        #region EVENTS
        
        #endregion
        #region UPDATE
        
        #endregion
        #region ACTIONS
        
        /*public bool onIdle()
        {
            return startNewCharacterState(eCharacterState.idle);
        }
        */
        #endregion
        #region PROPERTIES
        
        public eState STATE
        {
            get {return (eState)ACTION_CURRENT_ID;}
        }
        #endregion
        #region UTILITY
        protected bool startNewState(eState state)
        {
            LOGGER.log ("start new state:" + state.ToString ());
            return startNewAction((int)state, false);
        }
        
        #endregion
    }
}

