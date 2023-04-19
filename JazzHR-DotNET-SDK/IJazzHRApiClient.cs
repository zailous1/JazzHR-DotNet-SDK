using System;
using Zailous.JazzHR.Models;

namespace Zailous.JazzHR
{
    /// <summary>
    /// Defines methods for interacting with the JazzHR API.
    /// </summary>
    public interface IJazzHRApiClient
    {
        /// <summary>
        /// Gets a collection of activities.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of activities.</returns>
        Task<IEnumerable<Activity>> GetActivitiesAsync();

        /// <summary>
        /// Gets a collection of activities with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of activities.</returns>
        Task<IEnumerable<Activity>> GetActivitiesAsync(ActivitiesVars? vars);

        /// <summary>
        /// Gets a single activity by ID.
        /// </summary>
        /// <param name="id">The ID of the activity to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the activity with the specified ID, or null if no such activity exists.</returns>
        Task<Activity?> GetActivityAsync(string id);

        /// <summary>
        /// Gets a collection of applicants.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of applicants.</returns>
        Task<IEnumerable<Applicant>> GetApplicantsAsync();

        /// <summary>
        /// Gets a collection of applicants with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of applicants.</returns>
        Task<IEnumerable<Applicant>> GetApplicantsAsync(ApplicantsVars? vars);

        /// <summary>
        /// Gets a single applicant by ID.
        /// </summary>
        /// <param name="id">The ID of the applicant to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the applicant with the specified ID, or null if no such applicant exists.</returns>
        Task<ApplicantDetail?> GetApplicantAsync(string id);

        /// <summary>
        /// Gets a collection of applicant-to-job mappings.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of applicant-to-job mappings.</returns>
        Task<IEnumerable<ApplicantJobMapping>> GetApplicantJobMappingsAsync();

        /// <summary>
        /// Gets a collection of applicant-to-job mappings with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of applicant-to-job mappings.</returns>
        Task<IEnumerable<ApplicantJobMapping>> GetApplicantJobMappingsAsync(ApplicantJobMappingVars? vars);

        /// <summary>
        /// Gets a single applicant-to-job mapping by ID.
        /// </summary>
        /// <param name="id">The ID of the applicant-to-job mapping to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the applicant-to-job mapping with the specified ID, or null if no such mapping exists.</returns>
        Task<ApplicantJobMapping?> GetApplicantJobMappingAsync(string id);

        /// <summary>
        /// Gets a collection of hires.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of hires.</returns>
        Task<IEnumerable<Hire>> GetHiresAsync();

        /// <summary>
        /// Gets a collection of categories.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of categories.</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync();

        /// <summary>
        /// Gets a collection of categories with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of categories.</returns>
        Task<IEnumerable<Category>> GetCategoriesAsync(CategoriesVars? vars);

        /// <summary>
        /// Gets a single category by ID.
        /// </summary>
        /// <param name="id">The ID of the category to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the category with the specified ID, or null if no such category exists.</returns>
        Task<Category?> GetCategoryAsync(string id);

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="request">The request object containing the details of the category to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the response from the server indicating whether the category was created successfully.</returns>
        Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request);

        /// <summary>
        /// Gets a collection of jobs.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of jobs.</returns>
        Task<IEnumerable<JobDetail>> GetJobsAsync();

        /// <summary>
        /// Gets a collection of jobs with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of jobs.</returns>
        Task<IEnumerable<JobDetail>> GetJobsAsync(JobsVars? vars);

        /// <summary>
        /// Gets a single job by ID.
        /// </summary>
        /// <param name="id">The ID of the job to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the job with the specified ID, or null if no such job exists.</returns>
        Task<JobDetail?> GetJobAsync(string id);

        /// <summary>
        /// Downloads a resume file from a URL.
        /// </summary>
        /// <param name="url">The URL of the resume file to download.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the downloaded file as a byte array.</returns>
        Task<byte[]> DownloadResumeAsync(string url);

        /// <summary>
        /// Creates a mapping between a category and an applicant.
        /// </summary>
        /// <param name="request">The request object containing the details of the mapping to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the response from the server indicating whether the mapping was created successfully.</returns>
        Task<CreateCategoryApplicantMappingResponse> CreateCategoryApplicantMappingAsync(CreateCategoryApplicantMappingRequest request);

        /// <summary>
        /// Gets a collection of users.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of users.</returns>
        Task<IEnumerable<User>> GetUsersAsync();

        /// <summary>
        /// Gets a collection of users with optional query parameters.
        /// </summary>
        /// <param name="vars">Optional query parameters for the request.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains a collection of users.</returns>
        Task<IEnumerable<User>> GetUsersAsync(UsersVars? vars);

        /// <summary>
        /// Gets a single user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the user with the specified ID, or null if no such user exists.</returns>
        Task<UserDetail?> GetUserAsync(string id);

        /// <summary>
        /// Creates a new note.
        /// </summary>
        /// <param name="request">The request object containing the details of the note to create.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. The result contains the response from the server indicating whether the note was created successfully.</returns>
        Task<CreateNoteResponse> CreateNoteAsync(CreateNoteRequest request);
    }
}