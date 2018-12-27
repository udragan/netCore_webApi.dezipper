using System;
using System.Collections.Generic;
using System.Linq;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Dezipper.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class LocationController : Controller
	{
		IDezipperUnitOfWork _unitOfWork;
		IConfiguration _config;

		public LocationController(IDezipperUnitOfWork unitOfWork, IConfiguration config)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
			_config = config;
		}

		// GET: api/Location
		[Authorize]
		[HttpGet]
		public IEnumerable<LocationInfo> Get()
		{
			return _unitOfWork.LocationInfos
				.GetAll()
				.Take(int.Parse(_config.GetSection("Api:MaxNumberOfResults").Value));
		}

		// GET: api/Location/5
		[HttpGet("{id}")]
		public LocationInfo Get(int id)
		{
			return _unitOfWork.LocationInfos.Get(id);
		}

		// POST: api/Location
		[Authorize]
		[HttpPost]
		public void Post([FromBody]LocationInfo value)
		{
			_unitOfWork.LocationInfos.Add(value);
			_unitOfWork.Commit();
		}

		// PUT: api/Location/5
		[Authorize]
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
		[Authorize]
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
