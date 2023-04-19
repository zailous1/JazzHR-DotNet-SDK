using RestSharp;

namespace Zailous.JazzHR
{
    /// <summary>
    /// An interface for making RESTful API requests.
    /// </summary>
    internal interface IRestClient
    {
        /// <summary>
        /// Executes an asynchronous RESTful API request with the specified <see cref="RestRequest"/>.
        /// </summary>
        /// <param name="request">The <see cref="RestRequest"/> object representing the API request.</param>
        /// <returns>A <see cref="Task{TResult}"/> object that represents the result of the API request.</returns>
        Task<RestResponse> ExecuteAsync(RestRequest request);
    }
}