using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;

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
		/// Gets the identity resources.
		/// </summary>
		/// <returns>A collection of IdentityResources.</returns>
		public static IEnumerable<IdentityResource> GetIdentityResources()
		{
			return new List<IdentityResource>
			{
				new IdentityResources.OpenId(),
				new IdentityResources.Profile(),
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
				},
				//OpenID Connect implicit flow client
				new Client
				{
					ClientId = "dezipper.api",
					ClientName = "Open Id Client",
					AllowedGrantTypes = GrantTypes.Implicit,
					RequireConsent = false,

					// where to redirect to after login
					RedirectUris = { "http://localhost:50001/signin-oidc" },

					// where to redirect to after logout
					PostLogoutRedirectUris = { "http://localhost:50001/signout-callback-oidc" },

					AllowedScopes = new List<string>
					{
						IdentityServerConstants.StandardScopes.OpenId,
						IdentityServerConstants.StandardScopes.Profile
					}
				}
			};
		}

		public static List<TestUser> GetUsers()
		{
			return new List<TestUser>
			{
				new TestUser
				{
					SubjectId = "1",
					Username = "post",
					Password = "pass"
				},
				new TestUser
				{
					SubjectId = "2",
					Username = "man",
					Password = "pass"
				}
			};
		}
	}
}
