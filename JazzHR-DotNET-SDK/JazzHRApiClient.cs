using Zailous.JazzHR.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Zailous.JazzHR
{
    /// <summary>
    /// Represents a client for interacting with the JazzHR API.
    /// </summary>
    public class JazzHRApiClient : IJazzHRApiClient
    {
        private readonly IHttpClient _httpClient;
        private readonly JazzHRApiClientConfig _config;
        private readonly ILogger<JazzHRApiClient> _logger;

        internal string ApiKey { get; private set; }
        internal int MaxPageResults { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClient"/> class.
        /// </summary>
        /// <param name="config">An instance of a configuration object containing the API key.</param>
        /// <param name="logger">An instance of a logger used for logging.</param>        
        public JazzHRApiClient(string apiKey, ILogger<JazzHRApiClient> logger)
            : this(new HttpClient(new JazzHRApiClientConfig(apiKey)), new JazzHRApiClientConfig(apiKey), logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClient"/> class.
        /// </summary>
        /// <param name="config">An instance of a configuration object containing the API key.</param>
        /// <param name="logger">An instance of a logger used for logging.</param>        
        public JazzHRApiClient(JazzHRApiClientConfig config, ILogger<JazzHRApiClient> logger)
            : this(new HttpClient(config), config, logger)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of an HTTP client used to communicate with the JazzHR API.</param>
        /// <param name="config">An instance of a configuration object containing the API key.</param>
        /// <param name="logger">An instance of a logger used for logging.</param>        
        internal JazzHRApiClient(IHttpClient httpClient, JazzHRApiClientConfig config, ILogger<JazzHRApiClient> logger)
        {
            _httpClient = httpClient;
            _config = config;
            _logger = logger;

            ApiKey = _config.APIKey;
            MaxPageResults = config.MaxPageResults;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JazzHRApiClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of an HTTP client used to communicate with the JazzHR API.</param>
        /// <param name="config">An instance of a configuration object containing the API key.</param>
        /// <param name="logger">An instance of a logger used for logging.</param>  
        /// <param name="maxPageResults">Maximum number of results to be returned in a single page.</param>  /// 
        internal JazzHRApiClient(IHttpClient httpClient, JazzHRApiClientConfig config, ILogger<JazzHRApiClient> logger, int maxPageResults)
            : this(httpClient, config, logger)
        {
            MaxPageResults = maxPageResults;
        }

        /// <summary>
        /// Retrieves an activity by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the activity to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains the activity with the specified identifier, or null if not found.
        /// </returns>
        public async Task<Activity?> GetActivityAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<Activity>($"activities/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving activity with ID {Id}: {Message}", id, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all activities asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Activity"/> objects.
        /// </returns>
        public async Task<IEnumerable<Activity>> GetActivitiesAsync()
            => await GetActivitiesAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Retrieves activities asynchronously with optional filtering using the specified variables.
        /// </summary>
        /// <param name="vars">The <see cref="ActivitiesVars"/> instance containing filter options, or null for no filtering.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Activity"/> objects that match the specified filter options.
        /// </returns>
        public async Task<IEnumerable<Activity>> GetActivitiesAsync(ActivitiesVars? vars)
        {
            try
            {
                return await GetAsync<Activity>("activities", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving activities: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an applicant detail by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the applicant detail to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains the applicant detail with the specified identifier, or null if not found.
        /// </returns>
        public async Task<ApplicantDetail?> GetApplicantAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<ApplicantDetail>($"applicants/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving applicant with ID {Id}: {Message}", id, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all applicants asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Applicant"/> objects.
        /// </returns>
        public async Task<IEnumerable<Applicant>> GetApplicantsAsync()
            => await GetApplicantsAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Retrieves applicants asynchronously with optional filtering using the specified variables.
        /// </summary>
        /// <param name="vars">The <see cref="ApplicantsVars"/> instance containing filter options, or null for no filtering.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Applicant"/> objects that match the specified filter options.
        /// </returns>
        public async Task<IEnumerable<Applicant>> GetApplicantsAsync(ApplicantsVars? vars)
        {
            try
            {
                return await GetAsync<Applicant>("applicants", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving applicants: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all applicant-job mappings asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="ApplicantJobMapping"/> objects.
        /// </returns>
        public async Task<IEnumerable<ApplicantJobMapping>> GetApplicantJobMappingsAsync()
            => await GetApplicantJobMappingsAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Retrieves applicant-job mappings asynchronously with optional filtering using the specified variables.
        /// </summary>
        /// <param name="vars">The <see cref="ApplicantJobMappingVars"/> instance containing filter options, or null for no filtering.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="ApplicantJobMapping"/> objects that match the specified filter options.
        /// </returns>
        public async Task<IEnumerable<ApplicantJobMapping>> GetApplicantJobMappingsAsync(ApplicantJobMappingVars? vars)
        {
            try
            {
                return await GetAsync<ApplicantJobMapping>("applicants2jobs", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving applicant job mappings: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an applicant-job mapping by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the applicant-job mapping to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains the applicant-job mapping with the specified identifier, or null if not found.
        /// </returns>
        public async Task<ApplicantJobMapping?> GetApplicantJobMappingAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<ApplicantJobMapping>($"applicants2jobs/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the applicant job mapping with ID {Id}: {Message}", id, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves all hires asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Hire"/> objects.
        /// </returns>
        public async Task<IEnumerable<Hire>> GetHiresAsync()
        {
            try
            {
                return await GetAsync<Hire>("hires", null).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving hires: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a category by its identifier asynchronously.
        /// </summary>
        /// <param name="id">The identifier of the category to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains the category with the specified identifier, or null if not found.
        /// </returns>
        public async Task<Category?> GetCategoryAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<Category>($"categories/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the category with ID {Id}: {Message}", id, ex.Message);
                throw;
            }
        }


        /// Retrieves all categories asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Category"/> objects.
        /// </returns>
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
            => await GetCategoriesAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Retrieves categories asynchronously with optional filtering using the specified variables.
        /// </summary>
        /// <param name="vars">The <see cref="CategoriesVars"/> instance containing filter options, or null for no filtering.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="Category"/> objects that match the specified filter options.
        /// </returns>
        public async Task<IEnumerable<Category>> GetCategoriesAsync(CategoriesVars? vars)
        {
            try
            {
                return await GetAsync<Category>("categories", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving categories: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Creates a new category asynchronously using the specified request.
        /// </summary>
        /// <param name="request">The <see cref="CreateCategoryRequest"/> instance containing the new category data.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a <see cref="CreateCategoryResponse"/> instance with the newly created category information.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
        public async Task<CreateCategoryResponse> CreateCategoryAsync(CreateCategoryRequest request)
        {
            try
            {
                _ = request ?? throw new ArgumentNullException(nameof(request));
                return await PostAsync<CreateCategoryResponse>("categories", request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a category: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a job asynchronously by its ID.
        /// </summary>
        /// <param name="id">The ID of the job to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a <see cref="JobDetail"/> instance with the job information, or null if no job was found with the specified ID.
        /// </returns>
        public async Task<JobDetail?> GetJobAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<JobDetail>($"jobs/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving job detail for ID {Id}: {Message}", id, ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Retrieves all jobs asynchronously with no filtering.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="JobDetail"/> objects representing all jobs in the system.
        /// </returns>
        public async Task<IEnumerable<JobDetail>> GetJobsAsync()
            => await GetJobsAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Retrieves all jobs asynchronously with optional filtering.
        /// </summary>
        /// <param name="vars">The <see cref="JobsVars"/> instance containing the filtering parameters, or null to retrieve all jobs.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="JobDetail"/> objects representing the matching jobs in the system.
        /// </returns>
        public async Task<IEnumerable<JobDetail>> GetJobsAsync(JobsVars? vars)
        {
            try
            {
                return await GetAsync<JobDetail>("jobs", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving jobs: {Message}", ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Downloads the resume of an applicant from the specified URL asynchronously.
        /// </summary>
        /// <param name="url">The URL of the resume to download.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a byte array containing the resume data.
        /// </returns>
        public async Task<byte[]> DownloadResumeAsync(string url)
        {
            try
            {
                return await _httpClient.DownloadAsync(url).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to download resume from {Url}: {Message}", url, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Creates a new mapping between a category and an applicant asynchronously.
        /// </summary>
        /// <param name="request">The <see cref="CreateCategoryApplicantMappingRequest"/> instance containing the mapping details.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a <see cref="CreateCategoryApplicantMappingResponse"/> object representing the newly created mapping in the system.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="request"/> is null.</exception>
        public async Task<CreateCategoryApplicantMappingResponse> CreateCategoryApplicantMappingAsync(CreateCategoryApplicantMappingRequest request)
        {
            try
            {
                _ = request ?? throw new ArgumentNullException(nameof(request));

                return await PostAsync<CreateCategoryApplicantMappingResponse>("categories2applicants", request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating category applicant mapping: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all users asynchronously.
        /// </summary>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="User"/> objects
        /// representing all the users in the system.
        /// </returns>
        public async Task<IEnumerable<User>> GetUsersAsync()
            => await GetUsersAsync(null).ConfigureAwait(false);

        /// <summary>
        /// Gets a list of all users asynchronously with optional filtering and pagination.
        /// </summary>
        /// <param name="vars">The <see cref="UsersVars"/> instance containing the filtering and pagination details.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of <see cref="User"/> objects
        /// representing the users that match the specified filter criteria, or all users
        /// if no filter criteria were specified.
        /// </returns>
        public async Task<IEnumerable<User>> GetUsersAsync(UsersVars? vars)
        {
            try
            {
                return await GetAsync<User>("users", vars).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving users: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Gets a user by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a <see cref="UserDetail"/> object representing the user with
        /// the specified ID, or <see langword="null"/> if no such user exists.
        /// </returns>
        public async Task<UserDetail?> GetUserAsync(string id)
        {
            try
            {
                return await DeserializeApiResponse<UserDetail>($"users/{id}").ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving user {Id}: {Message}", id, ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Creates a note asynchronously.
        /// </summary>
        /// <param name="request">A <see cref="CreateNoteRequest"/> object representing the note to create.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains a <see cref="CreateNoteResponse"/> object representing the newly
        /// created note.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="request"/> is <see langword="null"/>.</exception>
        public async Task<CreateNoteResponse> CreateNoteAsync(CreateNoteRequest request)
        {
            try
            {
                _ = request ?? throw new ArgumentNullException(nameof(request));

                return await PostAsync<CreateNoteResponse>("notes", request).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a note: {Message}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Retrieves a paginated list of items of type <typeparamref name="T"/> from the subpath.
        /// </summary>
        /// <typeparam name="T">The type of the items to retrieve.</typeparam>
        /// <param name="subpath">The subpath to append to the base URL.</param>
        /// <param name="pathVars">Optional query string parameters to add to the request.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an <see cref="IEnumerable{T}"/> of the requested items.
        /// </returns>
        internal async Task<IEnumerable<T>> GetAsync<T>(string subpath, IPathVars? pathVars)
        {
            var results = new List<T>();
            IEnumerable<T>? items = null;
            int pageNum = 0;

            try
            {
                do
                {
                    pageNum++;
                    items = await GetPageAsync<T>(subpath, pathVars, pageNum).ConfigureAwait(false);
                    if (items.Any())
                    {
                        results.AddRange(items);
                    }
                }
                while (items?.Count() >= MaxPageResults);

                return results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting data for type {Type}: {Message}", typeof(T).Name, ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Sends a POST request to the specified API endpoint asynchronously, with the specified request body.
        /// </summary>
        /// <typeparam name="T">The type of the expected response object.</typeparam>
        /// <param name="subpath">The subpath of the API endpoint to send the request to.</param>
        /// <param name="request">The <see cref="CreateRequest"/> instance containing the request body.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation. When the task completes successfully, the <see cref="Task{TResult}.Result"/> property contains a <typeparamref name="T"/> object representing the API response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="response"/> or <paramref name="result"/> is null.</exception>
        internal async Task<T> PostAsync<T>(string subpath, CreateRequest request)
        {
            try
            {
                request.ApiKey = ApiKey;
                string body = JsonConvert.SerializeObject(request);

                string? response = await _httpClient.PostAsync(subpath, body).ConfigureAwait(false);
                _ = response ?? throw new ArgumentNullException(nameof(response));

                T? result = JsonConvert.DeserializeObject<T>(response);
                _ = result ?? throw new ArgumentNullException(nameof(result));

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while posting data for type {Type}: {Message}", typeof(T).Name, ex.Message);
                throw;
            }
        }


        /// <summary>
        /// Retrieves a single page of results of the specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of objects to retrieve.</typeparam>
        /// <param name="subpath">The subpath to append to the API base URL.</param>
        /// <param name="pathVars">An instance of an <see cref="IPathVars"/> implementation containing optional parameters to include in the request URL.</param>
        /// <param name="pageNum">The page number to retrieve.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/> property contains an <see cref="IEnumerable{T}"/> of the retrieved objects.
        /// </returns>
        internal async Task<IEnumerable<T>> GetPageAsync<T>(string subpath, IPathVars? pathVars, int pageNum)
        {
            if (pathVars != null)
            {
                subpath += pathVars.ToSubpath();
            }

            subpath += $"/page/{pageNum}";

            string? response = await _httpClient.GetAsync(subpath).ConfigureAwait(false);

            if (string.IsNullOrWhiteSpace(response))
            {
                return new List<T>();
            }

            try
            {
                return response.TrimStart()[0] switch
                {
                    '[' => JsonConvert.DeserializeObject<IEnumerable<T>>(response) ?? new List<T>(),
                    '{' => JsonConvert.DeserializeObject<T>(response) is T result && result != null ? new List<T> { result } : new List<T>(),
                    _ => throw new JsonSerializationException("Invalid JSON format."),
                };
            }
            catch (JsonSerializationException ex)
            {
                _logger.LogError(ex, "Failed to deserialize response content to type {Type}.", typeof(T).Name);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get page for {Type} with subpath {Subpath} and page number {PageNum}.", typeof(T).Name, subpath, pageNum);
                throw;
            }
        }


        /// <summary>
        /// Deserializes an API response to the specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of object to deserialize the response to.</typeparam>
        /// <param name="subpath">The subpath of the API endpoint to call.</param>
        /// <returns>
        /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
        /// When the task completes successfully, the <see cref="Task{TResult}.Result"/>
        /// property contains an instance of <typeparamref name="T"/> representing the deserialized API response.
        /// If the API response is empty or whitespace, the method returns null.
        /// </returns>
        internal async Task<T?> DeserializeApiResponse<T>(string subpath) where T : class
        {
            try
            {
                string? response = await _httpClient.GetAsync(subpath).ConfigureAwait(false);

                return !string.IsNullOrWhiteSpace(response)
                    ? JsonConvert.DeserializeObject<T>(response)
                    : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deserializing API response for subpath {Subpath} with type {Type}.", subpath, typeof(T).Name);
                throw;
            }
        }

    }
}
