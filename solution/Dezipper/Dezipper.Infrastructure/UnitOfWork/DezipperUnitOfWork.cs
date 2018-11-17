using System;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Infrastructure.Contexts;

namespace com.udragan.netCore.webApi.Dezipper.Infrastructure.UnitOfWork
{
	/// <summary>
	/// Unit of work to ensure data modification transactions.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Dezipper.Domain.Interfaces.IDezipperUnitOfWork" />
	public class DezipperUnitOfWork : IDezipperUnitOfWork
	{
		#region Members

		private DezipperContext _context;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="DezipperUnitOfWork" /> class.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="locationInfoRepository">The location info repository.</param>
		public DezipperUnitOfWork(
			DezipperContext context,
			ILocationInfoRepository locationInfoRepository)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
			LocationInfos = locationInfoRepository ?? throw new ArgumentNullException(nameof(locationInfoRepository));
		}

		#endregion

		#region IDezipperUnitOfWork

		/// <summary>
		/// Gets the location infos repository.
		/// </summary>
		public ILocationInfoRepository LocationInfos { get; private set; }

		/// <summary>
		/// Commits all tracked changes to the context.
		/// </summary>
		public void Commit()
		{
			_context.SaveChanges();
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			_context.Dispose();
		}

		#endregion
	}
}
