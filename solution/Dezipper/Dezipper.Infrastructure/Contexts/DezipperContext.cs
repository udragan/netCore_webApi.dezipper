using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Dezipper.Infrastructure.Contexts
{
	/// <summary>
	/// Dezipper persistence context.
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class DezipperContext : DbContext
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DezipperContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public DezipperContext(DbContextOptions<DezipperContext> options)
			: base(options)
		{ }

		#endregion

		#region DbSets

		/// <summary>
		/// Gets or sets the location infos dbset.
		/// </summary>
		public DbSet<LocationInfo> LocationInfos { get; set; }

		#endregion
	}
}
