//
// IAStateMachine.cs
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
using DGX.Character.Action;
using DGX.Character.Action.Guard;

namespace DGX.Character.IA
{
    public class IAStateMachine : DGX.Action.StateMachine
    {
        
        #region DECLARATION
        
        public enum eState
        {
            nothing = 0, //do nothing, just stay there
            guard,//stay and protected his position
            friendly,
            hunter// try to kill a group
        }
        #endregion
        #region ATTRIBUTES
        
        private ActionNothing mActionNothing;
        private ActionGuard mActionGuard;
        
        #endregion
        
        #region CONSTRUCTOR
        
        public IAStateMachine (Fighter fighter)
            : base()
        {
            //Character.Anim.MoveableAnimation moveableAnimation = fighter.GetComponent<Character.Anim.MoveableAnimation> ();
            mActionNothing = new ActionNothing ((int)eState.nothing);
            mActionGuard = new ActionGuard ((int)eState.guard, fighter);
            
            addAction (mActionNothing);
            addAction(mActionGuard);
            startNewAction ((int)eState.guard, false);
        }
        #endregion
        
        #region EVENTS
        
        #endregion
        #region UPDATE
        
        #endregion
        #region ACTIONS
        
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
