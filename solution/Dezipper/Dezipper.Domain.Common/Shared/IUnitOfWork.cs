using System;

namespace com.udragan.netCore.webApi.Dezipper.Domain.Common.Shared
{
	/// <summary>
	/// Generic Unit Of Work interface.
	/// </summary>
	/// <seealso cref="System.IDisposable" />
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Commits all tracked changes to the context.
		/// </summary>
		void Commit();
	}
}
