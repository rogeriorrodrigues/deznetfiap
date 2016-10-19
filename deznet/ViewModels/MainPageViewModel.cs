using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace deznet
{
	public class MainPageViewModel : BaseViewModel
	{
		/// <summary>
		/// The database.
		/// </summary>
		readonly Database database;

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Age { get; set; }
		public int GenderIndex { get; set; } = -1;
		public ObservableCollection<string> Records { get; set; }

		public ICommand AddCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand DeleteAllCommand { get; set; }

		public ICommand GenderCommand { get; set; }
		public ICommand AgeFilterCommand { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="T:deznet.MainPageViewModel"/> class.
		/// </summary>
		public MainPageViewModel()
		{
			AddCommand = new Command(Add);
			DeleteCommand = new Command(Delete);
			DeleteAllCommand = new Command(DeleteAll);
			GenderCommand = new Command(FilterByGender);
			AgeFilterCommand = new Command(FilterByAge);

			//Caso não exista ele cria a base
			database = new Database("People");
			//Caso não exista ele cria a tabela
			database.CreateTable<Person>();

			Records = new ObservableCollection<string>();

			ShowAllRecods();

		}

		/// <summary>
		/// Add this instance.
		/// </summary>
		void Add()
		{
			int age;
			if (int.TryParse(Age, out age))
			{
				var record = new Person
				{
					FirstName = FirstName,
					LastName = LastName,
					Age = age,
					Gender = GenderIndex == 0 ? Gender.Mulher : Gender.Homem
				};

				database.SaveItem(record);

				Records.Add(record.ToString());
				RaisePropertyChanged(nameof(Records));
				ClearForm();

			}
		}

		/// <summary>
		/// Delete the specified obj.
		/// </summary>
		/// <param name="obj">Object.</param>
		void Delete(object obj)
		{
			var itemString = (string)obj;
			var columns = itemString.Split(',').Select(i => i.Trim()).ToList();

			int id;
			if (int.TryParse(columns[0], out id))
			{
				database.DeleteItem<Person>(id);
				Records.Clear();
				ShowAllRecods();

			}
		}

		/// <summary>
		/// Deletes all.
		/// </summary>
		void DeleteAll()
		{
			database.DeleteAll<Person>();
			Records.Clear();
		}

		/// <summary>
		/// Filters the by age.
		/// </summary>
		/// <param name="obj">Object.</param>

		void FilterByAge(object obj)
		{
			int age;
			if (int.TryParse((string)obj, out age))
			{
				var result = database.Query<Person>("SELECT * FROM Person WHERE Age > ?", new object[] { age });
				Records.Clear();

				foreach (var person in result)
				{
					Records.Add(person.ToString());
				}
			}
		}

		/// <summary>
		/// Filters the by gender.
		/// </summary>
		/// <param name="obj">Object.</param>
		void FilterByGender(object obj)
		{
			var gender = ((string)obj) == "Mulher" ? Gender.Mulher : Gender.Homem;
			var result = database.Query<Person>("SELECT * FROM Person WHERE Gender = ?", new object[] { gender });

			Records.Clear();
			foreach (var person in result)
			{
				Records.Add(person.ToString());
			}
		}

		/// <summary>
		/// Clears the form.
		/// </summary>
		void ClearForm()
		{
			FirstName = string.Empty;
			LastName = string.Empty;
			Age = string.Empty;
			GenderIndex = -1;

			RaisePropertyChanged(nameof(FirstName));
			RaisePropertyChanged(nameof(LastName));
			RaisePropertyChanged(nameof(Age));
			RaisePropertyChanged(nameof(GenderIndex));
		}

		/// <summary>
		/// Shows all recods.
		/// </summary>
		void ShowAllRecods()
		{
			Records.Clear();
			var people = database.GetItems<Person>();

			foreach (var person in people)
			{
				Records.Add(person.ToString());
			}
		}
	}
}
