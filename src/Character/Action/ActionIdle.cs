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

namespace DGX.Character.Action
{
    public class ActionIdle : DGX.Action.ActionBase
    {
        private MoveableAnimation mMoveableAnimation;
        #region CONSTRUCTOR
        
        public ActionIdle(int id, MoveableAnimation moveableAnimation)
            : base (id, false)
        {
            mMoveableAnimation = moveableAnimation;
        }
        
        #endregion
        
        #region EVENTS
        
        protected override void handleInit ()
        {
            base.handleInit ();
        }
        protected override void handleRun ()
        {
            base.handleRun ();
            mMoveableAnimation.playingIdle ();
        }
        protected override void handleEnding ()
        {
            base.handleEnding ();
        }
        #endregion
    }
}

