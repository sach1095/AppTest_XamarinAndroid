using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Apptest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apptest.Droid
{
    public class StockAdpter : RecyclerView.Adapter
    {
        private readonly IDbService dbService = null;
        private List<Stock> stocks = new List<Stock>();
        public event EventHandler<Stock> ItemClick;
        public StockAdpter(IDbService dbService)
        {
            this.dbService = dbService;
            Task.Run(async () => this.stocks = await this.dbService.GetItems<Stock>()).Wait();
        }
        public override int ItemCount => this.stocks.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as StockViewholder;

            // Load the photo caption from the photo album:
            vh.Caption.Text = this.stocks[position].Symbol;
            vh.Id.Text = this.stocks[position].Id.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).
               Inflate(Resource.Layout.ItemsStockView, parent, false);

            var vh = new StockViewholder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int index)
        {
            if (index < 0 || index > stocks.Count)
            {
                throw new IndexOutOfRangeException();
            }
            this.ItemClick?.Invoke(this, this.stocks[index]);
        }

        public async Task OnRefresh()
        {
            this.stocks = await this.dbService.GetItems<Stock>();
            NotifyDataSetChanged();
        }


        public async Task Delete(int index)
        {
            if (index < 0 || index > stocks.Count)
            {
                throw new IndexOutOfRangeException();
            }
            Stock toDelete = this.stocks[index];
            await this.dbService.DeleteItem(toDelete);
            this.stocks.RemoveAt(index);
            this.NotifyItemRemoved(index);
        }
        public async Task ConcateString(int index)
        {
            if (index < 0 || index > stocks.Count)
            {
                throw new IndexOutOfRangeException();
            }
            Stock toModify = this.stocks[index];
            toModify.Symbol = $"{toModify.Symbol} {toModify.Symbol}";
            await this.dbService.SaveItem(toModify);
            this.NotifyItemChanged(index);
        }
    }

    class StockViewholder : RecyclerView.ViewHolder
    {
        public TextView Caption { get; private set; }
        public TextView Id { get; private set; }
        private Action<int> listener;

        public StockViewholder(View itemView, Action<int> listener) : base(itemView)
        {
            //this.listener = listener;
            //Id = itemView.FindViewById<TextView>(Resource.Id.stockid);
            //Caption = itemView.FindViewById<TextView>(Resource.Id.stockValue);

            //itemView.Click += ItemView_Click;
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            this.listener?.Invoke(this.LayoutPosition);
        }

        public StockViewholder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}