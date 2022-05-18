using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PetrovLabWpf14
{
	public enum CategoryTypes
	{
		Food = 0,
		Technics = 1
	}

	public class Product : INotifyPropertyChanged
	{
		private string _name;
		public string Name 
		{
			get { return _name; }
			set { _name = value; OnPropertyChanged(); }
		}

		private double _price;
		public double Price 
		{
			get { return _price; }
			set { _price = value; OnPropertyChanged(); }
		}
		
		private string _imagePath;
		public string ImagePath 
		{
			get { return _imagePath; }
			set { _imagePath = value; OnPropertyChanged(); }
		}

		private CategoryTypes _category;
		public CategoryTypes Category 
		{
			get { return _category; }
			set { _category = value; OnPropertyChanged(); }
		}

		public string CategoryName
		{
			get
			{
				if(Category == CategoryTypes.Food)
					return "Еда";
				else
					return "Бытовая техника";
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] string PropertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
		}

		/// <summary>
		/// сброс к значению по-умолчанию
		/// </summary>
		public void Reset()
		{
			ImagePath = string.Empty;
			Price = 0;
			Name = string.Empty;
			Category = CategoryTypes.Food;
		}
	}
}
