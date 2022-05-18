using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace PetrovLabWpf14
{
	// Определить класс Product для хранения информации о товаре.
	// Класс должен содержать характеристики Название товара (строка), Цена (число), 
	// Изображение (строка - путь к файлу с изображением), Категория(перечисление, возможные значения – Еда, Бытовая техника). 
	// Разработать шаблон данных для отображения списка товаров в компоненте ListBox.
	// При помощи триггеров определите разный шаблон для товаров категории Еда и категории Бытовая техника.

	public partial class MainWindow : Window
	{
		private ObservableCollection<Product> products;

		public Product Product { get; set; } = new Product();

		public MainWindow()
		{
			InitializeComponent();

			products = new ObservableCollection<Product>();

			DataContext = Product;
			var categories = new Dictionary<CategoryTypes, string>();
			categories.Add(CategoryTypes.Food, "еда");
			categories.Add(CategoryTypes.Technics, "бытовая техника");
			categoryComboBox.ItemsSource = categories;

			productsList.ItemsSource = products;
		}

		// обработка кнопки выбора изображения
		private void buttonSelectImage_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new OpenFileDialog();
			dlg.Filter = "jpg files (*.jpg)|*.jpg|Все файлы (*.*)|*.*";
			if(dlg.ShowDialog() == true)
			{
				Product.ImagePath = dlg.FileName;
			}
		}

		// обработка кнопки добавления продукта
		private void buttonAddProduct_Click(object sender, RoutedEventArgs e)
		{
			products.Add(new Product()
			{
				Name = Product.Name,
				Price = Product.Price,
				ImagePath = Product.ImagePath,
				Category = Product.Category,
			});
			// сброс к значению по-умолчанию
			Product.Reset();
		}
	}
}
