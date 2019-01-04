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
		/// Initializes a new instance of the <see cref="LocationInfo" /> class.
		/// </summary>
		/// <param name="zipCode">The location`s zip cpde.</param>
		/// <param name="name">The location`s name.</param>
		/// <param name="country">The country.</param>
		/// <param name="countryAbbr">The country abbriviation.</param>
		/// <param name="latitude">The latitude.</param>
		/// <param name="longitude">The longitude.</param>
		public LocationInfo(
			int zipCode,
			string name,
			string country,
			string countryAbbr,
			double latitude,
			double longitude)
		{
			ZipCode = zipCode;
			Name = name;
			Country = country;
			CountryAbbr = countryAbbr;
			Latitude = latitude;
			Longitude = longitude;
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

		/// <summary>
		/// Gets the country.
		/// </summary>
		public string Country { get; private set; }

		/// <summary>
		/// Gets the country abbr.
		/// </summary>
		public string CountryAbbr { get; private set; }

		/// <summary>
		/// Gets the latitude.
		/// </summary>
		public double Latitude { get; private set; }

		/// <summary>
		/// Gets the longitude.
		/// </summary>
		public double Longitude { get; private set; }

		#endregion

		#region Public methods

		/// <summary>
		/// Updates this <see cref="LocationInfo"/> entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Update(LocationInfo entity)
		{
			//ZipCode = entity.ZipCode;
			Name = entity.Name;
			Country = entity.Country;
			CountryAbbr = entity.CountryAbbr;
			Latitude = entity.Latitude;
			Longitude = entity.Longitude;
		}

		#endregion
	}
}
