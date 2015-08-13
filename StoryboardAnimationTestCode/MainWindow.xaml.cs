using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StoryboardAnimationTestCode
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ボタン押下時の処理
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Storyboardでアニメーションさせるイメージコントローラーを格納する変数
            Image targetImage = BonchanImage;

            // 押されたボタンの名前を取得
            String buttonName = ((Button)sender).Name;

            // 押されたボタンによって、対象のイメージコントローラーを切り替える
            if (buttonName == "BonButton") targetImage = BonchanImage;
            else if (buttonName == "NoruchiButton") targetImage = NorucchiImage;
            else if (buttonName == "RossyButton") targetImage = RossyImage;
            else if (buttonName == "ShiroButton") targetImage = ShirochanImage;
            else if (buttonName == "BamiButton") targetImage = BamichanImage;
            else if (buttonName == "ChakoButton") targetImage = ChakochanImage;
            else if (buttonName == "FukuButton") targetImage = FukuchanImage;
            else targetImage = BonchanImage;

            // Storyboardを取得
            Storyboard puppetMoveStoryboard = (Storyboard)this.Resources["PuppetMoveStoryboard"];

            // Storyboardのアニメーション子要素であるDoubleAnimationの対象コントローラー(Storyboard.TargetName)を
            // 上で決めたImageコントローラーに変更する
            foreach (var child in puppetMoveStoryboard.Children)
            {
                Storyboard.SetTarget(child, targetImage);
            }

            // アニメーションの開始
            puppetMoveStoryboard.Begin();
        }
    }
}
