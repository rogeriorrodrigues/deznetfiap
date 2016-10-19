using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;


namespace deznet
{
	public class Database
	{
		/// <summary>
		/// The locker.
		/// </summary>
		static object locker = new object();

		/// <summary>
		/// Gets the SQL Lite.
		/// </summary>
		/// <value>The SQL Lite.</value>
		ISQLiteService SQLite
		{
			get {
				return DependencyService.Get<ISQLiteService>();
			}
		}
		/// <summary>
		/// The connection.
		/// </summary>
		readonly SQLiteConnection connection;

		/// <summary>
		/// The name of the database.
		/// </summary>
		readonly string DatabaseName;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:deznet.Database"/> class.
		/// </summary>
		/// <param name="databaseName">Database name.</param>
		public Database(string databaseName)
		{
			DatabaseName = databaseName;
			connection = SQLite.GetConnection(DatabaseName);
		}
		/// <summary>
		/// Creates the table.
		/// </summary>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public void CreateTable<T>()
		{
			lock (locker)
			{
				connection.CreateTable<T>();
			}
		}
		/// <summary>
		/// Gets the size.
		/// </summary>
		/// <returns>The size.</returns>
		public long GetSize()
		{
			return SQLite.GetSize(DatabaseName);
		}
		/// <summary>
		/// Saves the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="item">Item.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public int SaveItem<T>(T item)
		{
			lock (locker)
			{
				var id = ((BaseItem)(object)item).ID;
				if (id != 0)
				{
					connection.Update(item);
					return id;
				}
				else
				{
					return connection.Insert(item);
				}
			}
		}
		/// <summary>
		/// Executes the query.
		/// </summary>
		/// <param name="query">Query.</param>
		/// <param name="args">Arguments.</param>
		public void ExecuteQuery(string query, object[] args)
		{
			lock (locker)
			{
				connection.Execute(query, args);
			}
		}
		/// <summary>
		/// Query the specified query and args.
		/// </summary>
		/// <param name="query">Query.</param>
		/// <param name="args">Arguments.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public List<T> Query<T>(string query, object[] args) where T : new()
		{
			lock (locker)
			{
				return connection.Query<T>(query, args);

			}
		}
		/// <summary>
		/// Gets the items.
		/// </summary>
		/// <returns>The items.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public IEnumerable<T> GetItems<T>() where T : new()
		{
			lock (locker)
			{
				return (from i in connection.Table<T>() select i).ToList();
			}
		}
		/// <summary>
		/// Deletes the item.
		/// </summary>
		/// <returns>The item.</returns>
		/// <param name="id">Identifier.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public int DeleteItem<T>(int id)
		{
			lock (locker)
			{
				return connection.Delete<T>(id);
			}
		}
		/// <summary>
		/// Deletes all.
		/// </summary>
		/// <returns>The all.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public int DeleteAll<T>()
		{
			lock (locker)
			{
				return connection.DeleteAll<T>();
			}
		}


	}
}
