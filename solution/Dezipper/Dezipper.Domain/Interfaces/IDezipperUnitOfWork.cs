using com.udragan.netCore.webApi.Dezipper.Domain.Common.Shared;

namespace com.udragan.netCore.webApi.Dezipper.Domain.Interfaces
{
	/// <summary>
	/// Dezipper application unit of work interface.
	/// </summary>
	/// <seealso cref="com.udragan.netCore.webApi.Dezipper.Domain.Common.Shared.IUnitOfWork" />
	public interface IDezipperUnitOfWork : IUnitOfWork
	{
		/// <summary>
		/// Gets the location infos repository.
		/// </summary>
		ILocationInfoRepository LocationInfos { get; }
	}
}
