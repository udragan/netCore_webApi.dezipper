using com.udragan.netCore.webApi.Dezipper.Domain.Common.Shared;

namespace com.udragan.netCore.webApi.Dezipper.Domain.Models
{
	/// <summary>
	/// POCO class representing the location info.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Dezipper.Domain.Common.Shared.Entity" />
	public class LocationInfo : Entity
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LocationInfo"/> class.
		/// </summary>
		/// <param name="zipCode">The location`s zip cpde.</param>
		/// <param name="name">The location`s name.</param>
		public LocationInfo(
			int zipCode,
			string name)
		{
			ZipCode = zipCode;
			Name = name;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the location`s zip code.
		/// </summary>
		public int ZipCode { get; private set; }

		/// <summary>
		/// Gets the location`s name.
		/// </summary>
		public string Name { get; private set; }

		#endregion
	}
}
