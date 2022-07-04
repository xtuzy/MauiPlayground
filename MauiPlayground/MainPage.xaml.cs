
using MauiLib.CustomControls.DrawableView;
using MauiLib.CustomControls.LikeView;
using MauiLib.CustomControls.Platform;
using MauiPlayground.Pages;
using SharpConstraintLayout.Maui.Widget;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;

namespace MauiPlayground
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            flyout.listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;
            if(item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                //flyout.listView.SelectedItem = null;
                //IsPresented = false;
            }
        }
    }
}