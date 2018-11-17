using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using com.udragan.netCore.webApi.Dezipper.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace com.udragan.netCore.webApi.Dezipper.Infrastructure.Repositories
{
	/// <summary>
	/// The repository for manipulaiton of <see cref="LocationInfo"/> entities.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Dezipper.Domain.Interfaces.ILocationInfoRepository" />
	public class LocationInfoRepository : ILocationInfoRepository
	{
		#region Members

		private DezipperContext _context;

		#endregion

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LocationInfoRepository"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public LocationInfoRepository(DezipperContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		#endregion

		#region ILocationInfoRepository

		/// <summary>
		/// Adds the specified entity to the repository.
		/// </summary>
		/// <param name="entity">The entity to create.</param>
		/// <returns><see cref="LocationInfo"/> entity that is added to storage.</returns>
		public LocationInfo Add(LocationInfo entity)
		{
			_context.LocationInfos
				.Add(entity);

			return entity;
		}

		/// <summary>
		/// Finds all entities that satisfy the specified predicate.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		/// <returns>A collection of <see cref="LocationInfo"/>s that satisfy the predicate.</returns>
		public IEnumerable<LocationInfo> Find(Expression<Func<LocationInfo, bool>> predicate)
		{
			return _context.LocationInfos
				.Where(predicate)
				.ToList();
		}

		/// <summary>
		/// Gets the entity by its identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>
		/// The entity with provided identifier.
		/// </returns>
		public LocationInfo Get(long id)
		{
			return _context.LocationInfos
				.FirstOrDefault(x => x.Id == id);
		}

		/// <summary>
		/// Gets all entities.
		/// </summary>
		/// <returns>
		/// A collection of all available entities in the repository.
		/// </returns>
		public IEnumerable<LocationInfo> GetAll()
		{
			return _context.LocationInfos
				.AsNoTracking();
		}

		/// <summary>
		/// Removes the entity from repository.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public void Remove(LocationInfo entity)
		{
			_context.LocationInfos
				.Remove(entity);
		}

		#endregion
	}
}
