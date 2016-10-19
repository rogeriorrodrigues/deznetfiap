using System;
using SQLite;

namespace deznet
{
	/// <summary>
	/// Base item.
	/// </summary>
	public class BaseItem
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public BaseItem()
		{
		}
	}
}
