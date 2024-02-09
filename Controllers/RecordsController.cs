using JsonApiDotNetCore.Configuration;
using JsonApiDotNetCore.Services;
using TNRD.Zeepkist.GTR.Database.Models;

namespace TNRD.Zeepkist.GTR.Backend.JsonApi.Controllers;

public class RecordsController : ReadOnlyController<Record>
{
    public RecordsController(
        IJsonApiOptions options,
        IResourceGraph resourceGraph,
        ILoggerFactory loggerFactory,
        IResourceQueryService<Record, int> resourceService
    )
        : base(options, resourceGraph, loggerFactory, resourceService)
    {
    }
}
