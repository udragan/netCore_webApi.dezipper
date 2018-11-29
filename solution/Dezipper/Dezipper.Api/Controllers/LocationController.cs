using System;
using System.Collections.Generic;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dezipper.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	[Authorize]
	public class LocationController : Controller
	{
		IDezipperUnitOfWork _unitOfWork;

		public LocationController(IDezipperUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		// GET: api/Location
		[HttpGet]
		public IEnumerable<LocationInfo> Get()
		{
			return _unitOfWork.LocationInfos.GetAll();
		}

		// GET: api/Location/5
		[HttpGet("{id}")]
		public LocationInfo Get(int id)
		{
			return _unitOfWork.LocationInfos.Get(id);
		}

		// POST: api/Location
		[HttpPost]
		public void Post([FromBody]LocationInfo value)
		{
			_unitOfWork.LocationInfos.Add(value);
			_unitOfWork.Commit();
		}

		// PUT: api/Location/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]LocationInfo value)
		{
			LocationInfo entity = _unitOfWork.LocationInfos.Get(id);

			if (entity != null)
			{
				entity.Update(value);
				_unitOfWork.Commit();
			}
		}

		// DELETE: api/Location/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			LocationInfo entity = _unitOfWork.LocationInfos.Get(id);

			if (entity != null)
			{
				_unitOfWork.LocationInfos.Remove(entity);
				_unitOfWork.Commit();
			}
		}
	}
}
