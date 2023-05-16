using web1c_backend.Models.Entities;

namespace web1c_backend.Models.Http.Responses
{
    public class NestedDataResponse<T>: DataResponse<T> where T: EntityWithRoute
    {
        public EntityWithRoute[]? RelatedEvents { get; set; }

        public EntityWithRoute[]? RelatedAgreements { get; set; }
    }
}
