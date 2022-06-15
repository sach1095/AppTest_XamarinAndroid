using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Apptest.Droid;
using Apptest.Core;
using Google.Android.Material.TextField;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.Platforms.Android.Views;
using Apptest.Core.ViewModels;

namespace Apptest.Droid
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : MvxActivity<SecondViewModel>
    {
        RecyclerView mRecyclerView;
        StockAdpter mAdapter;
        ItemTouchHelper itemTouchHelper;
        Swipe2DismissTouchHelperCallback swipe2DismissTouchHelperCallback;

        private TextInputEditText inputText;
        private Button insertNewItem;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SecondLayout);
            //this.insertNewItem = FindViewById<Button>(Resource.Id.addElement);

            //this.inputText = FindViewById<TextInputEditText>(Resource.Id.inputText);
            //this.insertNewItem.Click += OnInsertClicked;

            //this.mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            //this.mRecyclerView.SetLayoutManager(new LinearLayoutManager(this));
            //this.mRecyclerView.SetAdapter(this.mAdapter);
            //this.swipe2DismissTouchHelperCallback = new Swipe2DismissTouchHelperCallback();
            //this.mAdapter.ItemClick += OnItemClick;
            //this.itemTouchHelper = new ItemTouchHelper(this.swipe2DismissTouchHelperCallback);
            //this.itemTouchHelper.AttachToRecyclerView(mRecyclerView);
            //this.swipe2DismissTouchHelperCallback.ItemSwiped += OnItemSwiped;
        }

        //private void Swipe2DismissTouchHelperCallback_ItemSwiped(object sender, int e)
        //{
        //    throw new NotImplementedException();
        //}


        //void OnItemClick(object sender, Stock item)
        //{
        //    Toast.MakeText(this, $"This is item : {item.Id} : {item.Symbol}", ToastLength.Short).Show();
        //}

        //async void OnItemSwiped(object sender, ParamSwiped paramSwiped)
        //{
        //    if (paramSwiped.Direction == ItemTouchHelper.Left)
        //        await this.mAdapter.Delete(paramSwiped.Position);
        //    else if (paramSwiped.Direction == ItemTouchHelper.Right)
        //        await this.mAdapter.ConcateString(paramSwiped.Position);
        //}
        //private async void OnInsertClicked(object sender, EventArgs e)
        //{
        //    var insert = new Stock { Symbol = this.inputText.Text };
        //    await DbPartage.DB.SaveItem(insert);
        //    this.inputText.Text = "";
        //    await this.mAdapter.OnRefresh();
        //}
    }
}