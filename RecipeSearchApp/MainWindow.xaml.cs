using RecipeSearchApp.Entities.Response.Category;
using RecipeSearchApp.Entities.Response.Recipe;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeSearchApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<CategoryDto> largeCategories = new List<CategoryDto>();
        private List<SubCategoryDto> mediaumCategories = new List<SubCategoryDto>();
        private List<SubCategoryDto> smallCategories = new List<SubCategoryDto>();
        private List<RecipeDto> recipes = new List<RecipeDto>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                dataGrid.ItemsSource = recipes;
            }
            catch (ApiException ex)
            {
                ex.Message.Show();
            }
            catch (Exception ex)
            {
                ex.Message.Show();
            }
        }

        private void categoryHyperLink_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var result = await Api.Get<CategoryResult>("CategoryList/20170426?format=json&applicationId=93c10287-f698-4da3-a4c3-7f51e61f8e7d&accessKey=pk_MCPsqryxVAJJe2tXf0GqOJ84tob0LPmbdhvpias7fLG");
            largeCategories.AddRange(result.Result.Large);
            largeCategories.Insert(0, new CategoryDto { CategoryId = "0", CategoryName = "全て" });
            mediaumCategories.AddRange(result.Result.Medium);
            smallCategories.AddRange(result.Result.Small);

            largeComboBox.ItemsSource = largeCategories;
            largeComboBox.SelectedItem = largeCategories.FirstOrDefault();
        }

        private List<CategoryDto> CategoryFilter(List<CategoryDto> categories, string ward)
        {
            if (!ward.IsNullOrEmpty())
            {
                return CategoryFilter(categories.Where(a => a.CategoryName.Contains(ward)).ToList(), "");
            }
            return categories;
        }
        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void largeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var largeCategory = largeComboBox.SelectedItem as CategoryDto;
            if (largeCategory == null) return;

            var mediumList = SubCategoryFilter(mediaumCategories, int.Parse(largeCategory.CategoryId));
            if (!mediumList.Any(a => a.CategoryId == 0))
            {
                mediumList.Insert(0, new SubCategoryDto { CategoryId = 0, CategoryName = "全て" });
            }
            mediumComboBox.ItemsSource = mediumList;
            mediumComboBox.SelectedItem = mediumList.FirstOrDefault();
        }

        private void mediumComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mediumCategory = mediumComboBox.SelectedItem as SubCategoryDto;
            if (mediumCategory == null) return;

            
            var smallList = SubCategoryFilter(smallCategories, mediumCategory.CategoryId);
            if (!smallList.Any(a => a.CategoryId == 0))
            {
                smallList.Insert(0, new SubCategoryDto { CategoryId = 0, CategoryName = "全て" });
            }
            smallComboBox.ItemsSource = smallList;
            smallComboBox.SelectedItem = smallList.FirstOrDefault();
        }

        private void smallComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private List<SubCategoryDto> SubCategoryFilter(List<SubCategoryDto> subCategories, int parentCategoryId)
        {
            if (parentCategoryId != 0) return SubCategoryFilter(subCategories.Where(a => a.ParentCategoryId == parentCategoryId.ToString()).ToList(), 0);
            return subCategories;
        }
    }
}