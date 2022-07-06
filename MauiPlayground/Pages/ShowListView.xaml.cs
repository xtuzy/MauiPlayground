
using SharpConstraintLayout.Maui.Widget;
using System.Diagnostics;
using static SharpConstraintLayout.Maui.Widget.FluentConstraintSet;

namespace MauiPlayground.Pages;

public partial class ShowListView : ContentPage
{
    public ShowListView()
    {
        InitializeComponent();
        SetListView(list);
    }

    ListViewViewModel listViewViewModel;
    void SetListView(ListView listView)
    {
       

        var dataTemplate = new DataTemplate(() =>
        {
            var viewCell = new ViewCell();
            var layout = new ConstraintLayout() { ConstrainWidth = ConstraintSet.MatchParent, ConstrainHeight = ConstraintSet.WrapContent, BackgroundColor = Color.FromRgb(66, 66, 66) };
            var title = new Label() { TextColor = Colors.White, FontSize = 30, FontAttributes = FontAttributes.Bold };
            title.SetBinding(Label.TextProperty, nameof(MicrosoftNews.Title));
            var image = new Image();
            image.SetBinding(Image.SourceProperty, nameof(MicrosoftNews.ImageUrl));
            var sourceFrom = new Label() { TextColor = Color.FromRgb(175, 165, 136), FontSize = 12, FontAttributes = FontAttributes.Bold };
            sourceFrom.SetBinding(Label.TextProperty, nameof(MicrosoftNews.Index));
            var sourceFromeImage = new Image();
            sourceFromeImage.SetBinding(Image.SourceProperty, nameof(MicrosoftNews.SourceFormImageUrl));
            layout.AddElement(image, title, sourceFromeImage, sourceFrom);

            var guideLine = new Guideline() { };
            layout.AddElement(guideLine);

            var littleWindow = new FluentConstraintSet();
            littleWindow.Clone(layout);
            littleWindow
            .Select(guideLine, image, sourceFromeImage, sourceFrom, title).Clear()//��Ҫ�Ƴ�֮ǰ��Լ��
            .Select(guideLine).GuidelineOrientation(Orientation.X).GuidelinePercent(0.6f)
            .Select(image).EdgesXTo().BottomToTop(guideLine)
            .Width(SizeBehavier.MatchParent).Height(SizeBehavier.WrapContent)
            .Select(sourceFromeImage).LeftToLeft(null, 20).BottomToTop(title, 20)
            .Width(20).Height(20)
            .Select(sourceFrom).LeftToRight(sourceFromeImage, 20).CenterYTo(sourceFromeImage)
            .Select(title).LeftToLeft(null, 20).RightToRight(null, 20).BottomToBottom(null, 20).Width(SizeBehavier.MatchConstraint);

            var bigWindow = new FluentConstraintSet();
            bigWindow.Clone(layout);
            bigWindow
            .Select(guideLine, image, sourceFromeImage, sourceFrom, title).Clear()//��Ҫ�Ƴ�֮ǰ��Լ��
            .Select(image).RightToRight(null, 20).TopToTop(null, 20)
            .Width(140).Height(140)
            .Select(sourceFromeImage).LeftToLeft(null, 20).TopToTop(image)
            .Width(20).Height(20)
            .Select(sourceFrom).LeftToRight(sourceFromeImage, 20).CenterYTo(sourceFromeImage)
            .Select(title).LeftToLeft(null, 20).RightToLeft(image, 20).TopToBottom(sourceFromeImage, 20).Width(SizeBehavier.MatchConstraint);

            double oldValue = -1;
            layout.SizeChanged += (sender, e) =>
            {
                if (oldValue == -1)
                {
                    if ((sender as View).Bounds.Width > 744)
                    {
                        bigWindow.ApplyTo(layout);
                    }
                    else
                    {
                        littleWindow.ApplyTo(layout);
                    }
                }

                if ((sender as View).Bounds.Width > 744)
                {
                    if (oldValue < 744)
                        bigWindow.ApplyTo(layout);

                }
                else
                {
                    if (oldValue > 744)
                        littleWindow.ApplyTo(layout);
                }
                oldValue = (sender as View).Bounds.Width;
            };

            viewCell.View = layout;
            return viewCell;
        });

        var list = CreateData(1000);
        listView.ItemTemplate = dataTemplate;
        listViewViewModel = new ListViewViewModel() { News = list };
        this.BindingContext = listViewViewModel;
        listView.HasUnevenRows = true;
        listView.ItemsSource = listViewViewModel.News;
    }

    List<MicrosoftNews> CreateData(int count)
    {
        var sourceList = new List<MicrosoftNews>();
        sourceList.Add(new MicrosoftNews()
        {
            Title = "���� | ��³����������;�ͳ�׹���¹� ������11��34��",
            ImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAXjc2n?w=300&h=174&q=60&m=6&f=jpg&u=t",
            SourceForm = "MSN",
            SourceFormImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/BBVQ5Hs.img?w=36&h=36&q=60&m=6&f=png&u=t"
        });
        sourceList.Add(new MicrosoftNews()
        {
            Title = "�Ϻ�16��������15����ʵ�����������",
            ImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/BB19W3O1?w=300&h=174&q=60&m=6&f=jpg&u=t",
            SourceForm = "ÿ�վ�������",
            SourceFormImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAO4ppI.img?w=36&h=36&q=60&m=6&f=png&u=t"
        });
        sourceList.Add(new MicrosoftNews()
        {
            Title = "Ԭ¡ƽ�뿪����һ����",
            ImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/BB19n8rU.img?w=406&h=304&q=90&m=6&f=jpg&x=2277&y=1318&u=t",
            SourceForm = "������",
            SourceFormImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AARPRel.img?w=36&h=36&q=60&m=6&f=png&u=t"
        });
        sourceList.Add(new MicrosoftNews()
        {
            Title = "��AndroidӦ��֧��ϵͳ Match Group��Google�����ʱ��Э",
            ImageUrl = "https://img-s-msn-com.akamaized.net/tenant/amp/entityid/AAXxMr9.img?w=300&h=225&q=90&m=6&f=jpg&u=t",
            SourceForm = "cnBeta",
        });

        var list = new List<MicrosoftNews>();
        Random rnd = new Random();
        for(var index = 0; index < count; index++)
        {
            var source = sourceList[rnd.Next(0,sourceList.Count-1)];
            list.Add(new MicrosoftNews()
            {
                Index = index,
                Title = source.Title,
                ImageUrl = source.ImageUrl,
                SourceForm = source.SourceForm,
                SourceFormImageUrl = source.SourceFormImageUrl,
            });
        }
        return list;
    }
}

internal class MicrosoftNews
{
    int index;
    public int Index
    {
        get 
        {
            //���Ի����б�ʱ�Ƿ����
            Debug.WriteLine(index);
            return index; 
        }
        set=>index = value;
    }
    public string Title { get; set; }
    public string SourceForm { get; set; }
    public string SourceFormImageUrl { get; set; }
    //public string Details { get; set; }
    public string ImageUrl { get; set; }
}

internal class ListViewViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{

    private List<MicrosoftNews> news;
    public List<MicrosoftNews> News
    {
        get => news;
        set => SetProperty(ref news, value);
    }

}