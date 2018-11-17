using System;
using System.Collections.Generic;
using com.udragan.netCore.webApi.Dezipper.Domain.Interfaces;
using com.udragan.netCore.webApi.Dezipper.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dezipper.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class HomeController : Controller
	{
		IDezipperUnitOfWork _unitOfWork;

		public HomeController(IDezipperUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
		}

		// GET: api/Home
		[HttpGet]
		public IEnumerable<LocationInfo> Get()
		{
			return _unitOfWork.LocationInfos.GetAll();
		}

		// GET: api/Home/5
		[HttpGet("{id}", Name = "Get")]
		public LocationInfo Get(int id)
		{
			return _unitOfWork.LocationInfos.Get(id);
		}

		// POST: api/Home
		[HttpPost]
		public void Post([FromBody]LocationInfo value)
		{
			_unitOfWork.LocationInfos.Add(value);
			_unitOfWork.Commit();
		}

		// PUT: api/Home/5
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

		// DELETE: api/ApiWithActions/5
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
