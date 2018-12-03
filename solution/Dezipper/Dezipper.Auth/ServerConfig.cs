using System.Collections.Generic;
using IdentityServer4.Models;

namespace com.udragan.netCore.webApi.Dezipper.Auth
{
	/// <summary>
	/// Identity server configuration.
	/// </summary>
	public class ServerConfig
	{
		/// <summary>
		/// Gets the API resources.
		/// </summary>
		/// <returns>A colleciton of Api resources.</returns>
		public static IEnumerable<ApiResource> GetApiResources()
		{
			return new List<ApiResource>
			{
				new ApiResource("dezipperApi", "Dezipper API")
			};
		}

		/// <summary>
		/// Gets the clients.
		/// </summary>
		/// <returns>A collection of IdentityServer clients.</returns>
		public static IEnumerable<Client> GetClients()
		{
			return new List<Client>
			{
				new Client
				{
					ClientId = "postman",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("postman".Sha256())
					},
					AllowedScopes = { "dezipperApi" }

				},
				new Client
				{
					ClientId = "client",
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					ClientSecrets =
					{
						new Secret("changeMe".Sha256())
					},
					AllowedScopes = { "dezipperApi" }
				}
			};
		}
	}
}
