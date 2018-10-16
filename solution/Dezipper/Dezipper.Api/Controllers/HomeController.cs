﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Dezipper.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class HomeController : Controller
	{
		// GET: api/Home
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Home/5
		[HttpGet("{id}", Name = "Get")]
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Home
		[HttpPost]
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Home/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
