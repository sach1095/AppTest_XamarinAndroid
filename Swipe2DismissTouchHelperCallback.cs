using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apptest.Droid
{
    public class ParamSwiped
    {
        public int Position { get; set; }
        public int Direction { get; set; }
    }

    public class Swipe2DismissTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {
        public event EventHandler<ParamSwiped> ItemSwiped;
        public Swipe2DismissTouchHelperCallback(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        public Swipe2DismissTouchHelperCallback()
            : base(0, ItemTouchHelper.Left)
        {
        }

        public override int GetSwipeDirs(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder) => ItemTouchHelper.Left | ItemTouchHelper.Right;
       

        public override bool OnMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target) => false;


        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {
            this.ItemSwiped?.Invoke(this, new ParamSwiped
            {
                Position = viewHolder.LayoutPosition,
                Direction = direction,
            });
        }
    }
}