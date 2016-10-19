using System;
namespace deznet
{
	/// <summary>
	/// Gender.
	/// </summary>
	public enum Gender
	{
		Mulher,
		Homem
	}

	/// <summary>
	/// Person.
	/// </summary>
	public class Person : BaseItem
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public Gender Gender { get; set; }

		/// <summary>
		/// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:deznet.Person"/>.
		/// </summary>
		/// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:deznet.Person"/>.</returns>
		public override string ToString()
		{
			return $"{ID}, {FirstName}, {LastName}, {Age}, {Gender.ToString()}";
		}
		

		public Person()
		{
		}
	}
}
